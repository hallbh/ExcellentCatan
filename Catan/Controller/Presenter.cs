using System.Threading;
using Catan.Controller.TurnMachines;
using Catan.Model;
using static Catan.Properties.Resources;
using static Catan.Model.ItemHelper;

namespace Catan.Controller
{
    public class Presenter
    {
        private readonly View view;
        private TurnManager manager;
        private readonly ItemFilter playerDisplayFilter;
        public bool GameOver { get; private set; }

        public Presenter(View view)
        {
            playerDisplayFilter += ResourceCards;
            playerDisplayFilter += DevelopmentCards;
            this.view = view;
        }

        #region Locale-Independent Methods

        public void MainLoop()
        {
            while (!GameOver)
            {
                ProcessPlayerActions();
                Thread.Sleep(0);
            }
        }

        public void ProcessPlayerActions()
        {
            while (view.HasNextPlayerAction())
            {
                var action = view.GetNextPlayerAction();
                if (action.Type == ActionType.Exit)
                {
                    GameOver = true;
                    return;
                }

                manager.HandleAction(action);
            }
        }

        public virtual void RegisterTurnManager(TurnManager turnManager)
        {
            manager = turnManager;
        }

        public virtual void ColorRoad(Player player, int index)
        {
            view.ColorRoad(player.Color, index);
        }

        public virtual void ColorSettlement(Player player, int index)
        {
            view.ColorSettlement(player.Color, index);
        }

        public virtual void SetCity(int index)
        {
            view.SetCity(index);
        }

        public virtual void SetRobberPosition(int index)
        {
            view.SetRobberPosition(index);
        }

        #endregion
        public virtual void DisplayPlayerResources(Player player)
        {
            view.SetPlayerName(player.Color.LocalizedString());
            foreach (var pair in player.GetMatchingItems(playerDisplayFilter))
            {
                var text = string.Format(Culture, Presenter_KeyValueFormat, pair.Key.LocalizedString(), pair.Value);
                view.SetResource(pair.Key, text);
            }
        }

        #region Locale-Aware Methods

        public virtual void PromptError(string message)
        {
            var str = string.Format(Culture, message);
            view.SetErrorPromptLabel(str);
        }

        public virtual void PromptUser(Player player, string message)
        {
            var str = string.Format(Culture, Presenter_PromptUser_UserMessageFormat, player.Color.LocalizedString(), message);
            view.SetPromptLabel(str);
        }

        public virtual void RollDiceValue(int dieValue)
        {
            var str = string.Format(Culture, dieValue.ToString());
            view.SetDiceRoll(str);
        }

        public virtual void DisplayPlayerVictory(Player activePlayer)
        {
            var color = activePlayer.Color;
            var message = string.Format(Culture, Presenter_DisplayPlayerVictory_VictoryTextFormat, color.LocalizedString());
            view.DisplayPlayerVictory(color, message);
        }

        public virtual void SetupHex(int index, Hex hex)
        {
            var type = hex.Resource;
            var rollNumber = hex.RollNumber;
            var formatStr = string.Format(Culture, Presenter_KeyValueFormat, type.LocalizedString(), rollNumber);
            view.SetupHex(index, formatStr, type);
        }

        public virtual void SetupHarbor(int index, Harbor harbor)
        {
            var type = harbor.Resource;
            var from = harbor.Resource == Item.Any ? 3 : 2;
            const int to = 1;
            var formatStr = string.Format(Culture, Presenter_KeyValueFormat, from, to);
            view.SetupHarbor(index, formatStr, type);
        }

        public virtual void DisplayLargestArmyOwner(string owner)
        {
            view.SetLargestArmyOwner(owner);
        }

        public virtual void DisplayLongestRoadOwner(string owner)
        {
            view.SetLongestRoadOwner(owner);
        }
        #endregion
    }
}