using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.GamePlay
{
    public class WaitCity : TurnState
    {
        internal override string Prompt => Resources.PlaceCity_Instruction;

        public WaitCity(GameModel model) : base(model)
        {
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type == ActionType.Intersection)
            {
                if (Board.PlaceCity(ActivePlayer, action.Index))
                {
                    Presenter.SetCity(action.Index);
                    return State<Build>();
                }

                PromptError(Resources.PlaceCity_Failed);
            }

            PromptError(Resources.TurnState_GeneralInvalidInput);
            return this;
        }
    }
}