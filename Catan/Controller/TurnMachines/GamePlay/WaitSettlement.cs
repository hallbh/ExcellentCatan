using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.GamePlay
{
    public class WaitSettlement : TurnState
    {
        internal override string Prompt => Resources.PlaceSettlement_Instruction;

        public WaitSettlement(GameModel model) : base(model)
        {
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type == ActionType.Intersection)
            {
                if (Board.PlaceSettlement(ActivePlayer, action.Index))
                {
                    Presenter.ColorSettlement(ActivePlayer, action.Index);
                    Board.CheckLongestRoad(Model);
                    return State<Build>();
                }

                PromptError(Resources.PlaceSettlement_Fail);
                return this;
            }

            PromptError(Resources.TurnState_GeneralInvalidInput);
            return this;
        }
    }
}