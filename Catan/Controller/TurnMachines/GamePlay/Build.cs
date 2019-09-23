using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.GamePlay
{
    public class Build : TurnState
    {
        internal override string Prompt => Resources.Build_Instruction;

        public Build(GameModel model) : base(model)
        {
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            var couldBuild = true;
            var couldAfford = true;

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (action.Type)
            {
                case ActionType.RequestCity:
                    if (!Board.CanPlaceCitySomewhere(ActivePlayer))
                    {
                        couldBuild = false;
                        break;
                    }
                    if (Bank.BuyItem(ActivePlayer, Item.City)) return State<WaitCity>();
                    couldAfford = false;
                    break;
                case ActionType.RequestSettlement:
                    if (!Board.CanPlaceSettlementSomewhere(ActivePlayer))
                    {
                        couldBuild = false;
                        break;
                    }
                    if (Bank.BuyItem(ActivePlayer, Item.Settlement)) return State<WaitSettlement>();
                    couldAfford = false;
                    break;
                case ActionType.RequestRoad:
                    if (!Board.CanPlaceRoadSomewhere(ActivePlayer))
                    {
                        couldBuild = false;
                        break;
                    }
                    if (Bank.BuyItem(ActivePlayer, Item.Road)) return State<WaitRoad>();
                    couldAfford = false;
                    break;
                case ActionType.RequestDevCard:
                    if (Bank.BuyDevCard(ActivePlayer))
                    {
                        Presenter.DisplayPlayerResources(ActivePlayer);
                        return this; 
                    }
                    couldAfford = false;
                    break;
                case ActionType.EndTurn:
                    PromptError(@"");
                    ActivePlayerIndex++;
                    return State<WaitRollDice>();
                default:
                    return this;
            }

            if (!couldBuild) PromptError(Resources.Build_CannotPlace);
            if (!couldAfford) PromptError(Resources.Build_CannotAfford);
            return this;
        }
    }
}