using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using static Catan.Model.Item;
using static Catan.Model.ItemHelper;
using Newtonsoft.Json;


namespace Catan.Model
{
    public class Bank : ItemContainer
    {
        public Bank() : base(InitialResources())
        {
        }

        private static Dictionary<Item, int> InitialResources()
        {
            
            var stream = typeof(GameBoard).Assembly.GetManifestResourceStream(@"Catan.Resources.BankSetup.json");
            using (var r =
                new StreamReader(stream ?? throw new InvalidOperationException(@"Manifest resource stream was null")))
            {
                var json = r.ReadToEnd();
                dynamic jsonObj = JsonConvert.DeserializeObject(json);

                var initialResourceDict = new Dictionary<Item, int>();
                foreach (var pair in jsonObj)
                {
                    var item = (Item) Enum.Parse(typeof(Item), pair.Name);
                    var amount = (int) pair.Value;
                    initialResourceDict.Add(item, amount);
                }

                return initialResourceDict;
            }
        }

        public virtual void SatisfyResourceRequests(List<ResourceRequest> requests)
        {
            foreach (var pair in GetMatchingItems(ResourceCards))
            {
                var resource = pair.Key;
                var applicableRequests = requests.Where(r => r.Resource == resource).ToList();
                var count = applicableRequests.Sum(r => r.Amount);
                if (CanTransferItem(resource, count))
                {
                    foreach (var request in applicableRequests)
                    {
                        Transfer(resource.Count(request.Amount), request.Player);
                    }
                }
            }
        }

        public virtual bool BuyItem(Player player, Item item)
        {
            return TransferIfPossible(player, item);
        }

        public virtual bool BuyDevCard(Player player)
        {
            var devCardDict = GetMatchingItems(DevelopmentCards);
            var itemsList = FlattenDictionary(devCardDict);
            if (itemsList.Count==0)
            {
                return false;
            }
            var item = PopRandomItemFromList(itemsList);
            return TransferIfPossible(player, item);
        }

        private bool TransferIfPossible(ItemContainer player, Item item)
        {
            var cost = CostOf(item);
            if (player.CanTransfer(cost) && CanReceive(cost))
            {
                player.Transfer(cost, this);
                return true;
            }
            
            return false;
        }

        private static ImmutableItemContainer CostOfDevelopmentCard(Item card)
        {
            var itemDictionary = new Dictionary<Item, int>
            {
                {card, -1},
                {Ore, 1},
                {Grain, 1},
                {Wool, 1}
            };
            return new ImmutableItemContainer(itemDictionary);
        }

        private static readonly ImmutableDictionary<Item, ImmutableItemContainer> CostDict =
            new Dictionary<Item, ImmutableItemContainer>
            {
                {
                    Road, new ImmutableItemContainer(new Dictionary<Item, int>
                    {
                        {Road, -1},
                        {Brick, 1},
                        {Lumber, 1}
                    })
                },
                {
                    Settlement, new ImmutableItemContainer(new Dictionary<Item, int>
                    {
                        {Settlement, -1},
                        {Brick, 1},
                        {Lumber, 1},
                        {Grain, 1},
                        {Wool, 1}
                    })
                },
                {
                    City, new ImmutableItemContainer(new Dictionary<Item, int>
                    {
                        {Settlement, 1},
                        {City, -1},
                        {Grain, 2},
                        {Ore, 3}
                    })
                }
            }.ToImmutableDictionary();

        internal static ItemContainer CostOf(Item item)
        {
            if (CostDict.ContainsKey(item))
            {
                return CostDict[item];
            }

            if (item.Matches(DevelopmentCards))
            {
                return CostOfDevelopmentCard(item);
            }

            throw new ArgumentException(@"Item not handled here");
        }

        public virtual void TakeBackCardsOnSevenRoll(ImmutableList<Player> players)
        {
            foreach (var player in players)
            {
                var resourcesDict =  player.GetMatchingItems(ResourceCards);
                var resources = FlattenDictionary(resourcesDict);
                var numToSteal = resources.Count > 7 ? resources.Count / 2 : 0;
                for (var i = 0; i < numToSteal; i++)
                {
                    var item = PopRandomItemFromList(resources);
                    player.Transfer(item.Count(), this);
                }
            }
        }
    }
}
