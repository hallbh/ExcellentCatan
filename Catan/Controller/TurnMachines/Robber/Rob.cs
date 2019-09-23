using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.Robber
{
    public class Rob : TurnState
    {
        private int selectedHexIndex;
        internal override string Prompt => Resources.Rob_Instruction;

        public Rob(GameModel model) : base(model)
        {
        }

        public void SetSelectedHex(int index)
        {
            selectedHexIndex = index;
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type != ActionType.Intersection)
            {
                PromptError(Resources.TurnState_GeneralInvalidInput);
                return this;
            }

            var intersection = Board.GetIntersection(action.Index);
            var owner = intersection.GetOwner();

            if (owner == ActivePlayer)
            {
                PromptError(Resources.Rob_CannotRobSelf);
                return this;
            }

            if (owner == null)
            {
                PromptError(Resources.Rob_MustSelectCity);
                return this;
            }

            if (!Board.CheckAdjacencyBetweenHexAndIntersection(selectedHexIndex, action.Index))
            {
                PromptError(Resources.Rob_MustBeAdjacent);
                return this;
            }

            var opponentResources = ItemContainer.FlattenDictionary(owner.GetMatchingItems(ItemHelper.ResourceCards));
            if (opponentResources.Count > 0)
            {
                var stolenItem = ItemContainer.PopRandomItemFromList(opponentResources);
                owner.Transfer(stolenItem.Count(), ActivePlayer);
            }
            else
            {
                PromptError(Resources.Rob_PlayerIsBroke);
            }

            return ReturnState;
        }
    }
}