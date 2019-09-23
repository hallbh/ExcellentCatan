using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Catan.Properties;

namespace Catan.Model
{
    public enum Item
    {
     Desert, Any, Road, City, Settlement,
     LongestRoadCard, LargestArmyCard,
     // Next Row = ResourceCards
     Lumber, Ore, Wool, Brick, Grain, 
     // Next Row = DevelopmentCards
     VictoryPointCard, YearOfPlentyCard, MonopolyCard, RoadBuildingCard, KnightCard
    }
    
    public delegate bool ItemFilter(Item item);
    public static class ItemHelper
    {

        private static readonly ImmutableList<Item> ResourceCardList = ImmutableList.CreateRange(new List<Item>
        {
            Item.Lumber, Item.Ore, Item.Wool, Item.Brick, Item.Grain
        });

        public static bool ResourceCards(Item item)
        {
            return ResourceCardList.Contains(item);
        }

        private static readonly ImmutableList<Item> DevCardList = ImmutableList.CreateRange(new List<Item>
        {
            Item.VictoryPointCard, Item.YearOfPlentyCard, Item.MonopolyCard, Item.RoadBuildingCard, Item.KnightCard
        });

        public static bool DevelopmentCards(Item item)
        {
            return DevCardList.Contains(item);
        }

        public static bool Matches(this Item item, ItemFilter filter)
        {
            return filter.GetInvocationList().Cast<ItemFilter>().Any(del => del(item));
        }

        public static ItemContainer Count(this Item item, int count = 1)
        {
            return new ItemContainer.ImmutableItemContainer(new Dictionary<Item, int>{{item, count}});
        }

        public static string LocalizedString(this Item item)
        {
            return Resources.ResourceManager.GetString(@"Item_" + item);
        }
    }


    
}
