using System;
using Catan.Controller.TurnMachines.DevCards;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Controller.TurnMachines.TurnZero;
using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines
{
    public class TurnManager
    {
        internal TurnState CurrentState;
        internal readonly GameModel Model;

        public TurnManager(GameModel model)
        {
            this.Model = model;
            CurrentState = model.State(typeof(PlaceInitialSettlement));
            CurrentState.OnEnter();
        }

        public virtual void HandleAction(PlayerAction action)
        {
            Model.Presenter.DisplayPlayerResources(Model.ActivePlayer);
            CheckForVictory();
            if (action.Type == ActionType.PlayDevCard)
            {
                HandleDevCard(action);
            }
            else
            {
                var oldState = CurrentState;
                CurrentState = oldState.HandleInput(action);
                if (oldState != CurrentState)
                {
                    CurrentState.OnEnter();
                }
            }

            CheckForVictory();
        }

        internal void HandleDevCard(PlayerAction action)
        {
            TurnState newState;
            var item = action.Value;
            if (Model.PlayedDevCardThisTurn)
            {
                Model.Presenter.PromptError(Resources.DevCard_AlreadyPlayed);
                return;
            }

            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (item)
            {
                case Item.KnightCard:
                    newState = Model.State<PlayKnight>();
                    break;
                case Item.MonopolyCard:
                    newState = Model.State<PlayMonopoly>();
                    break;
                case Item.RoadBuildingCard:
                    newState = Model.State<PlayRoadBuilding>();
                    break;
                case Item.YearOfPlentyCard:
                    newState = Model.State<PlayYearOfPlenty>();
                    break;
                default:
                    throw new ArgumentException(@"Invalid Dev Card Type");
            }
            
            if (Model.ActivePlayer.GetAmount(item) <= 0)
            {
                Model.Presenter.PromptUser(Model.ActivePlayer, Resources.DevCard_NoCard);
                return;
            }

            if (!Model.InitialDevCards.ContainsKey(item) || Model.InitialDevCards[item] < 1)
            {
                Model.Presenter.PromptUser(Model.ActivePlayer, Resources.DevCard_BoughtThisTurn);
                return;
            }

            Model.PlayedDevCardThisTurn = true;
            Model.ActivePlayer.Discard(item);
            newState.ReturnStateType = CurrentState.GetType();
            CurrentState = newState;
            CurrentState.OnEnter();
        }

        private void CheckForVictory()
        {
            if (Model.ActivePlayer.CanWin)
            {
                CurrentState = Model.State<EndGame>();
                CurrentState.OnEnter();
            }
        }
    }
}
