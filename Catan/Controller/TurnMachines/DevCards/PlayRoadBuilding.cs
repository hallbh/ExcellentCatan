using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.DevCards
{
    public class PlayRoadBuilding : TurnState
    {
        internal override string Prompt => Resources.PlaceRoad_Instruction;
        private int placedRoads;
        private readonly ItemContainer roadContainer = Item.Road.Count();

        public PlayRoadBuilding(GameModel model) : base(model)
        {
            OnEnterList.Add(RoadBuildingOnEnter);
        }

        protected void RoadBuildingOnEnter()
        {
            
            placedRoads = 0;
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type != ActionType.Path)
            {
                PromptError(Resources.TurnState_GeneralInvalidInput);
                return this;
            }
            
            if (ActivePlayer.CanTransfer(roadContainer) && placedRoads < 2 && Board.CanPlaceRoadSomewhere(ActivePlayer))
            {
                ActivePlayer.Transfer(roadContainer, Bank);

                if (!Board.PlaceRoad(Model, action.Index))
                {
                    PromptError(Resources.PlaceRoad_Failed);
                    return this;
                }

                Presenter.ColorRoad(ActivePlayer, action.Index);

                if (placedRoads == 0)
                {
                    PromptUser(Resources.PlayRoadBuilding_SecondInstruction);
                    placedRoads++;
                    return this;
                }
                return ReturnState;
            }

            PromptError(Resources.PlayRoadBuilding_NoRoads);
            return ReturnState;
        }
    }
}
