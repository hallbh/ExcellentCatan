using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.GamePlay
{
    public class WaitRoad : TurnState
    {
        internal override string Prompt => Resources.PlaceRoad_Instruction;

        public WaitRoad(GameModel model) : base(model)
        {
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type == ActionType.Path)
            {
                if (Board.PlaceRoad(Model, action.Index))
                {
                    Presenter.ColorRoad(ActivePlayer, action.Index);
                    return State<Build>();
                }

                PromptError(Resources.PlaceRoad_Failed);
            }

            PromptError(Resources.TurnState_GeneralInvalidInput);
            return this;
        }
    }
}