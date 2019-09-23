using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Catan.Model;
using Catan.Properties;
using View = Catan.Controller.View;
using static Catan.Model.Item;

namespace Catan.GUI
{
    public partial class MainGameForm : Form, View
    {
        private readonly ConcurrentQueue<PlayerAction> actionQueue;
        private readonly Dictionary<int, IntersectionControl> intersections;
        private readonly Dictionary<int, RoadControl> roads;
        private readonly Dictionary<int, HexControl> hexes;
        private readonly Dictionary<int, HarborControl> harbors;

        public MainGameForm()
        {
            actionQueue = new ConcurrentQueue<PlayerAction>();
            InitializeComponent();
            intersections =  panel1.Controls.OfType<IntersectionControl>().ToDictionary(x => x.Index);
            roads =  panel1.Controls.OfType<RoadControl>().ToDictionary(x => x.Index);
            hexes = panel1.Controls.OfType<HexControl>().ToDictionary(x => x.Index);
            harbors = panel1.Controls.OfType<HarborControl>().ToDictionary(x => x.Index);

            foreach (var button in tableLayoutPanel1.Controls.OfType<CustomButtonControl>())
            {
                button.Text = button.TypeOfAction.LocalizedString();
            }
            // Initialize owner label to nobody
            longestRoadLabel.Text = Resources.Item_LongestRoadCard;
            largestArmyLabel.Text = Resources.Item_LargestArmyCard;
            longestRoadOwnerLabel.Text = Resources.Player_None;
            largestArmyOwnerLabel.Text = Resources.Player_None;

            Text = Resources.Title;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private delegate void DelegateSetupHex(int index, string hexLabel, Item type);

        private delegate void DelegateSetLabel(string s);

        private delegate void DelegateSetResources(Item item, string resourceLabel);

        private delegate void DelegateWinner(PlayerColor color, string message);

        private delegate void DelegateSetPlayerAttribute(PlayerColor color, int index);

        private delegate void DelegateSetIntProperty(int index);

        private Color GetResourceColor(Item type)
        {
            Color color;
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (type)
            {
                case Lumber:
                    color = Color.Green;
                    break;
                case Wool:
                    color = Color.FromArgb(128, 255, 128);
                    break;
                case Grain:
                    color = Color.FromArgb(192, 192, 0);
                    break;
                case Brick:
                    color = Color.Firebrick;
                    break;
                case Ore:
                    color = Color.Gray;
                    break;
                case Desert:
                    color = Color.FromArgb(128, 128, 0);
                    break;
                case Any:
                    color = Color.AliceBlue;
                    break;
                default:
                    throw new ArgumentException(@"Invalid Item Type for hex", nameof(type));
            }

            return color;
        }

        public void SetupHex(int index, string hexLabel, Item type)
        {
            if (hexControl1.InvokeRequired)
            {
                var del = new DelegateSetupHex(SetupHex);
                Invoke(del, index, hexLabel, type);
            }
            else
            {
                var hex = hexes[index];
                hex.Text = hexLabel;
                var color = GetResourceColor(type);
                hex.BackColor = color;
                hex.Refresh();
            }
        }

        public void SetupHarbor(int index, string harborLabel, Item type)
        {
            if (harbors[index].InvokeRequired)
            {
                var del = new DelegateSetupHex(SetupHex);
                Invoke(del, index, harborLabel, type);
            }
            else
            {
                var harbor = harbors[index];
                harbor.Text = harborLabel;
                var color = GetResourceColor(type);
                harbor.BackColor = color;
                harbor.Refresh();
            }
        }

        public void SetPromptLabel(string prompt)
        {
            if (promptLabel.InvokeRequired)
            {
                var del = new DelegateSetLabel(SetPromptLabel);
                Invoke(del, prompt);
            }
            else
            {
                promptLabel.Text = prompt;
                promptLabel.Refresh();
            }
        }

        public void SetErrorPromptLabel(string prompt)
        {
            if (errorLabel.InvokeRequired)
            {
                var del = new DelegateSetLabel(SetErrorPromptLabel);
                Invoke(del, prompt);
            }
            else
            {
                errorLabel.Text = prompt;
                errorLabel.Refresh();
            }
        }

        public void SetPlayerName(string name)
        {
            if (playerNameLabel.InvokeRequired)
            {
                var del = new DelegateSetLabel(SetPlayerName);
                Invoke(del, name);
            }
            else
            {
                playerNameLabel.Text = name;
                playerNameLabel.Refresh();
            }
        }

        public void SetResource(Item item, string resourceLabel)
        {
            if (grainLabel.InvokeRequired)
            {
                var del = new DelegateSetResources(SetResource);
                Invoke(del, item, resourceLabel);
            }
            else
            {
                Label label;
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (item)
                {
                    case Brick:
                        label = brickLabel;
                        break;
                    case Wool:
                        label = woolLabel;
                        break;
                    case Ore:
                        label = oreLabel;
                        break;
                    case Grain:
                        label = grainLabel;
                        break;
                    case Lumber:
                        label = lumberLabel;
                        break;
                    case VictoryPointCard:
                        label = victoryPointCardLabel;
                        break;
                    case YearOfPlentyCard:
                        label = yearOfPlentyCardLabel;
                        break;
                    case MonopolyCard:
                        label = monopolyCardLabel;
                        break;
                    case RoadBuildingCard:
                        label = roadBuildingCardLabel;
                        break;
                    case KnightCard:
                        label = knightCardLabel;
                        break;
                    default:
                        throw new ArgumentException(@"unhandled item", nameof(item));
                }

                label.Text = resourceLabel;
                label.Refresh();
            }
        }

        public void ColorSettlement(PlayerColor color, int index)
        {
            if (InvokeRequired)
            {
                var del = new DelegateSetPlayerAttribute(ColorSettlement);
                Invoke(del, color, index);
            }
            else
            {
                intersections[index].BackColor = GetColor(color);
                intersections[index].Refresh();
            }
        }

        public void ColorRoad(PlayerColor color, int index)
        {
            if (InvokeRequired)
            {
                var del = new DelegateSetPlayerAttribute(ColorRoad);
                Invoke(del, color, index);
            }
            else
            {
                roads[index].ForeColor = GetColor(color);
                roads[index].Refresh();
            }
        }

        public void SetRobberPosition(int index)
        {
            if (hexes[index].InvokeRequired)
            {
                var del = new DelegateSetIntProperty(SetRobberPosition);
                Invoke(del, index);
            }
            else
            {
                for (var i = 0; i < hexes.Count; i++)
                {
                    hexes[i].HasRobber = index == i;
                    hexes[i].Refresh();
                }
            }
        }

        public void SetCity(int index)
        {
            if (intersections[index].InvokeRequired)
            {
                var del = new DelegateSetIntProperty(SetCity);
                Invoke(del, index);
            }
            else
            {
                intersections[index].IsCity = true;
                intersections[index].Refresh();
            }
        }
        
        public void SetDiceRoll(string value)
        {
            if (diceValBox.InvokeRequired)
            {
                var del = new DelegateSetLabel(SetDiceRoll);
                Invoke(del, value);
            }
            else
            {
                diceValBox.Text = value;
                diceValBox.Refresh();
            }
        }
        
        public void DisplayPlayerVictory(PlayerColor color, string message)
        {
            if (victoryLabel.InvokeRequired)
            {
                var del = new DelegateWinner(DisplayPlayerVictory);
                Invoke(del, color, message);
            }
            else
            {
                victoryLabel.Text = message;
                victoryLabel.Visible = true;
                victoryLabel.ForeColor = GetColor(color);
                victoryLabel.Refresh();
            }
        }

        public void SetLongestRoadOwner(string owner)
        {
            if (longestRoadOwnerLabel.InvokeRequired)
            {
                var del = new DelegateSetLabel(SetLongestRoadOwner);
                Invoke(del, owner);
            }
            else
            {
                longestRoadOwnerLabel.Text = owner;
            }
        }

        public void SetLargestArmyOwner(string owner)
        {
            if (largestArmyOwnerLabel.InvokeRequired)
            {
                var del = new DelegateSetLabel(SetLargestArmyOwner);
                Invoke(del, owner);
            }
            else
            {
                largestArmyOwnerLabel.Text = owner;
            }
        }

        private static Color GetColor(PlayerColor color)
        {
            switch (color)
            {
                case PlayerColor.Blue:
                    return Color.Blue;
                case PlayerColor.Orange:
                    return Color.DarkOrange;
                case PlayerColor.White:
                    return Color.White;
                case PlayerColor.Red:
                    return Color.Red;
                default:
                    throw new ArgumentException(@"Unknown player color");
            }
        }

        private void HandleEvent(object sender, EventArgs e)
        {
            if (!(sender is InputSource))
            {
                throw new ArgumentException(@"sender must implement InputSource");
            }

            var src = (InputSource) sender;

            var action = src.GetPlayerAction();

            actionQueue.Enqueue(action);
        }

        public bool HasNextPlayerAction()
        {
            return !actionQueue.IsEmpty;
        }

        public PlayerAction GetNextPlayerAction()
        {
            actionQueue.TryDequeue(out var toReturn);
            return toReturn;
        }

        private void Form1_Load(object sender, EventArgs e){
        }

        private void Form1_Close(object sender, FormClosedEventArgs e)
        {
            actionQueue.Enqueue(new PlayerAction(ActionType.Exit));
        }
    }
}