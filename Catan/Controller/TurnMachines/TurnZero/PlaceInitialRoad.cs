using Catan.Controller.TurnMachines.GamePlay;
using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.TurnZero
{
    public class PlaceInitialRoad : TurnState
    {
        private int intersectionIndex;
        internal bool SecondRound;

        internal override string Prompt => Resources.PlaceInitialRoad_Instruction;

        public PlaceInitialRoad(GameModel model) : base(model)
        {
            SecondRound = false;
        }

        public void SetIntersectionIndex(int index)
        {
            intersectionIndex = index;
        }


        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type == ActionType.Path)
            {
                var path = Board.GetPath(action.Index);
                var adjIntersections = path.GetIntersections();
                if (path.GetOwner() != null)
                {
                    PromptError(Resources.PlaceRoad_AlreadyOccupied);
                    return this;
                }

                if (adjIntersections.Contains(Board.GetIntersection(intersectionIndex)))
                {
                    // PlaceRoad always succeeds if placed next to an intersection owned by the player
                    Board.PlaceRoad(Model, action.Index); 
                    return HandleSuccess(action.Index);
                    
                }
                PromptError(Resources.PlaceInitialRoad_NotAdjacent);
                return this;
            }
            PromptError(Resources.PlaceRoad_NotPath);
            return this;
        }

        private TurnState HandleSuccess(int index)
        {
            var placeSettlement = State<PlaceInitialSettlement>();
            Presenter.PromptError(@"");
            Presenter.ColorRoad(ActivePlayer, index);
            if (!SecondRound)
            {
                var isNowSecondRound = ActivePlayerIndex == Players.Count - 1;

                if (!isNowSecondRound)
                {
                    ActivePlayerIndex++;
                }
                else
                {
                    SecondRound = true;
                }
                
                return placeSettlement;
            }

            var setupIsDone = ActivePlayerIndex == 0;
            if (!setupIsDone)
            {
                ActivePlayerIndex--;
                return placeSettlement;
            }

            var requests = Board.GetInitialResourceRequests();
            Bank.SatisfyResourceRequests(requests);
            return State<WaitRollDice>();
        }
    }
}