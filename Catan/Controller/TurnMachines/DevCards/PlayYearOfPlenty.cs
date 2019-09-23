using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.DevCards
{
    public class PlayYearOfPlenty : TurnState
    {
        private int resourcesTaken;

        internal override string Prompt => Resources.PlayYearOfPlenty_Instruction;

        public PlayYearOfPlenty(GameModel model) : base(model)
        {
            OnEnterList.Add(YearOfPlentyOnEnter);
        }
        
        protected void YearOfPlentyOnEnter()
        {
            resourcesTaken = 0;
        }
       
        public override TurnState HandleInput(PlayerAction action)
        {
            
            var resourceCount = ItemContainer.FlattenDictionary(Model.Bank.GetMatchingItems(ItemHelper.ResourceCards)).Count;
            if (resourceCount == 0)
            {
                PromptError(Resources.PlayYearOfPlenty_OutOfAllResources);
                return ReturnState;
            }

            if (action.Type != ActionType.Hex)
            { 
                PromptError(Resources.PlayYearOfPlenty_Invalid);
                return this;
            }
            
            var resource = Board.GetHex(action.Index).Resource;
            if (resource == Item.Desert)
            {
                PromptError(Resources.PlayYearOfPlenty_Invalid);
                return this;
            }

            var amt = resource.Count();

            if (Bank.CanTransfer(amt))
            {
                PromptUser(Resources.PlayYearOfPlenty_SecondInstruction);
                Bank.Transfer(amt, ActivePlayer);
                resourcesTaken++;
            }
            else
            {
                PromptError(Resources.PlayYearOfPlenty_OutOfAResource);
            }

            return resourcesTaken < 2 ? this : ReturnState;
        }
    }
}