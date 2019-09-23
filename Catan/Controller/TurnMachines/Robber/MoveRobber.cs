using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.Robber
{
    public class MoveRobber : TurnState
    {
        internal override string Prompt => Resources.MoveRobber_Instruction;

        public MoveRobber(GameModel model) : base(model)
        {
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type == ActionType.Hex)
            {
                var idx = action.Index;
                if (Board.PlaceRobber(idx))
                {
                    Bank.TakeBackCardsOnSevenRoll(Players);
                    Presenter.SetRobberPosition(idx);
                    Presenter.DisplayPlayerResources(ActivePlayer);
                    if (!Board.HexBorderedByDifferentPlayer(idx, ActivePlayer))
                    {
                        return ReturnState;
                    }

                    var rob = State<Rob>();
                    rob.ReturnStateType = ReturnStateType;
                    rob.SetSelectedHex(idx);
                    return rob;
                }

                PromptError(Resources.MoveRobber_SameHexNotAllowed);
                return this;
            }

            PromptError(Resources.TurnState_GeneralInvalidInput);
            return this;
        }
    }
}