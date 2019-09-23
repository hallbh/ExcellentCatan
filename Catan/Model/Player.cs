using System.Collections.Generic;
using Catan.Properties;
using static Catan.Model.Item;

namespace Catan.Model
{
    public enum PlayerColor{Blue, Orange, Red, White }
    public static class PlayerColorHelper
    {
        public static string LocalizedString(this PlayerColor color)
        {
            return Resources.ResourceManager.GetString(@"Player_PlayerColor_" + color);
        }
    }

    public class Player : ItemContainer
    {
        public PlayerColor Color { get; }

        internal readonly DiscardContainer DiscardPile = new DiscardContainer();
        internal class DiscardContainer : ItemContainer
        {
            internal DiscardContainer()
            {
                CanTransferDelegates.Clear();
                CanTransferDelegates.Add(NoTransferBehavior);
                CanReceiveDelegates.Clear();
                CanReceiveDelegates.Add(NoUnReceiveBehavior);
            }
        }

        public Player(PlayerColor color) : base(InitialResources())
        {
            Color = color;
                CanTransferDelegates.Add(PlayerTransferBehavior);
                CanReceiveDelegates.Add(PlayerReceiveBehavior);
        }

        private static Dictionary<Item, int> InitialResources()
        {
            return new Dictionary<Item, int>
            {
                // Account for turn zero
                {Settlement, 2},
                {Road, 2},
                {Brick, 0},
                {Grain, 0},
                {Lumber, 0},
                {Ore, 0},
                {Wool, 0}
            };
        }


        public bool HasLongestRoad => GetAmount(LongestRoadCard) > 0;
        public bool HasLargestArmy => GetAmount(LargestArmyCard) > 0;

        public virtual int VictoryPoints
        {
            get
            {
                var count = GetAmount(Settlement);
                count += 2 * GetAmount(City);
                count += HasLargestArmy ? 2 : 0;
                count += HasLongestRoad ? 2 : 0;
                count += GetAmount(VictoryPointCard);
                return count;
            }
        }

        public virtual bool CanWin => VictoryPoints >= 10;
        
        protected bool PlayerTransferBehavior(Item item, int count)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (item)
            {
                case City when WouldExceedAllowedAmount(City, 4, count):
                case Settlement when WouldExceedAllowedAmount(Settlement, 5, count):
                case Road when WouldExceedAllowedAmount(Road, 15, count):
                    return false;
            }
            return true;
        }

        protected bool PlayerReceiveBehavior(Item item, int count)
        {
            // ReSharper disable once SwitchStatementMissingSomeCases
            switch (item)
            {
                case City when WouldExceedAllowedAmount(City, 4, -count):
                case Settlement when WouldExceedAllowedAmount(Settlement, 5, -count):
                case Road when WouldExceedAllowedAmount(Road, 15, -count):
                    return false;
            }
            return true;
        }

        protected bool WouldExceedAllowedAmount(Item resource, int max, int count)
        {
            return GetAmount(resource) - count > max;
        }

        public void Discard(Item item)
        {
            Transfer(item.Count(), DiscardPile);
        }
    }
}
