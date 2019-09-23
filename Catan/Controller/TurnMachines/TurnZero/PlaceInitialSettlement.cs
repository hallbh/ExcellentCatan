using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.TurnZero
{
    public class PlaceInitialSettlement : TurnState
    {
        internal override string Prompt => Resources.PlaceSettlement_Instruction;
        public PlaceInitialSettlement(GameModel model) : base(model)
        {
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type == ActionType.Intersection)
            {
                var validSettlement = Board.PlaceInitialSettlement(ActivePlayer, action.Index);
                if (validSettlement) {
                    Presenter.ColorSettlement(ActivePlayer, action.Index);
                    var placeRoad = State<PlaceInitialRoad>();
                    placeRoad.SetIntersectionIndex(action.Index);
                    return placeRoad;
                }

                PromptError(Resources.PlaceInitialSettlement_InvalidLocation);
                return this;
            }
            
            PromptError(Resources.PlaceInitialSettlement_NotIntersection);
            return this;
        }
    }
}
