using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.DevCards
{
    public class PlayMonopoly : TurnState
    {
        internal override string Prompt => Resources.PlayMonopoly_Instruction;
        public PlayMonopoly(GameModel model) : base(model)
        {
        }
        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type != ActionType.Hex)
            {
                PromptError(Resources.TurnState_GeneralInvalidInput);
                return this;
            }

            var selectedHex = Board.GetHex(action.Index);
                
            var toSteal = selectedHex.Resource;
            if (toSteal == Item.Desert)
            {
                PromptError(Resources.TurnState_GeneralInvalidInput);
                return this;
            }

            foreach (var victim in Players)
            {
                if (!victim.Equals(ActivePlayer))
                {
                    victim.Transfer(toSteal.Count(victim.GetAmount(toSteal)),ActivePlayer);
                }
            }
            PromptError(Resources.TurnState_GeneralInvalidInput);
            return ReturnState;

        }
    }
}
