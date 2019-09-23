using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Catan.Model
{
    public class ItemContainer
    {
        public delegate bool ItemDelegate(Item item, int count);
        private readonly Dictionary<Item, int> itemDictionary;

        protected readonly List<ItemDelegate> CanTransferDelegates;
        protected readonly List<ItemDelegate> CanReceiveDelegates;

        public ItemContainer(List<ItemDelegate> canTransfers=null, List<ItemDelegate> canReceives=null) : this(
            new Dictionary<Item, int>(), canTransfers, canReceives)
        {
        }

        public ItemContainer(Dictionary<Item, int> initialItems, List<ItemDelegate> canTransfers=null, List<ItemDelegate>canReceives=null)
        {
            itemDictionary = initialItems;
            CanTransferDelegates = canTransfers ?? new List<ItemDelegate>{DefaultTransferBehavior};
            CanReceiveDelegates = canReceives ?? new List<ItemDelegate>{DefaultReceiveBehavior};
        }
        
        internal static Random Rnd;
        public static List<Item> FlattenDictionary(ImmutableDictionary<Item, int> itemDict)
        {
            var itemsList = new List<Item>();
            foreach (var card in itemDict)
            {
                for (var i = 0; i < card.Value; i++)
                {
                    itemsList.Add(card.Key);
                }
            }

            return itemsList;
        }

        public static Item PopRandomItemFromList(List<Item> itemsList)
        {
            var idx = Rnd.Next(itemsList.Count);
            var value = itemsList[idx];
            itemsList.RemoveAt(idx);
            return value;
        }
        
        protected bool DefaultReceiveBehavior(Item item, int count)
        {
            return count > 0 || !itemDictionary.ContainsKey(item) || itemDictionary[item] >= -count;
        }
        
        protected bool DefaultTransferBehavior( Item item, int count)
        {
            return count <= 0 || itemDictionary.ContainsKey(item) && itemDictionary[item] >= count;
        }

        protected bool ImmutableBehavior(Item item, int count)
        {
            return false;
        }
        
        protected bool NoUnReceiveBehavior(Item resource, int amount)
        {
            return amount >= 0;
        }

        protected bool NoTransferBehavior(Item resource, int amount)
        {
            return amount <= 0;
        }

        protected bool CanReceiveItem(Item item, int count)
        {
            foreach (var invoked in CanReceiveDelegates)
            {
                if (!invoked(item, count))
                {
                    return false;
                }
            }
            return true;
        }
    
        protected bool CanTransferItem(Item item, int count)
        {
            foreach (var invoked in CanTransferDelegates)
            {
                if (!invoked(item, count))
                {
                    return false;
                }
            }

            return true;
        }

        public int GetAmount(Item item)
        {
            return itemDictionary.ContainsKey(item) ? itemDictionary[item] : 0;
        }

        internal virtual bool CanReceive(ItemContainer amt)
        {
            foreach (var item in amt.itemDictionary)
            {
                if (!CanReceiveItem(item.Key, item.Value))
                {
                    return false;
                }
            }

            return true;
        }


        public virtual bool CanTransfer(ItemContainer amt)
        {
            foreach (var item in amt.itemDictionary)
            {
                if (!CanTransferItem(item.Key, item.Value))
                {
                    return false;
                }
            }

            return true;
        }
        
        public virtual void Transfer(ItemContainer amounts, ItemContainer dest)
        {
            // Don't want to abort halfway through
            if (!CanTransfer(amounts))
            {
                throw new ArgumentException(@"Request too large for source");
            }

            if (!dest.CanReceive(amounts))
            {
                throw new ArgumentException(@"Request too large for destination");
            }

            foreach (var pair in amounts.itemDictionary)
            {
                dest.Add(pair.Key, pair.Value);
                Add(pair.Key, -pair.Value);
            }
        }

        public ImmutableDictionary<Item, int> GetMatchingItems(ItemFilter filter)
        {
            var outDictionary = new Dictionary<Item, int>();
            foreach (Item item in Enum.GetValues(typeof(Item)))
            {
                if (item.Matches(filter))
                {
                    outDictionary[item] = GetAmount(item);
                }
            }

            return outDictionary.ToImmutableDictionary();
        }

        private void Add(Item item, int amount)
        {
            if (!itemDictionary.ContainsKey(item))
            {
                itemDictionary[item] = amount;
            }
            else
            {
                itemDictionary[item] += amount;
            }
        }
        
        internal void UnsafeSetAmount(Item resource, int amount)
        {
            itemDictionary[resource] = amount;
        }

        internal class ImmutableItemContainer : ItemContainer
        {
            internal ImmutableItemContainer(Dictionary<Item, int> itemDictionary) : base(itemDictionary)
            {
                CanTransferDelegates.Add(ImmutableBehavior);
                CanReceiveDelegates.Add(ImmutableBehavior);
            }
        }
    }
}