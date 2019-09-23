using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Catan.Controller;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.DevCards;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.Controller.TurnMachines.Robber;
using Catan.Controller.TurnMachines.TurnZero;

namespace Catan.Model
{
    public class GameModel
    {
        public GameBoard Board { get; }
        public readonly Bank Bank;
        public readonly ImmutableList<Player> Players;
        public readonly Presenter Presenter;

        private int activePlayerIndex;
        public ImmutableDictionary<Item, int> InitialDevCards;
        public bool PlayedDevCardThisTurn;

        public int LongestRoadLength { get; set; }

        public int ActivePlayerIndex
        {
            get => activePlayerIndex;
            set
            {
                activePlayerIndex = value % Players.Count;
                InitialDevCards = ActivePlayer.GetMatchingItems(ItemHelper.DevelopmentCards);
                PlayedDevCardThisTurn = false;
            }
        }

        public Player ActivePlayer
        {
            get => Players[activePlayerIndex];
            set => activePlayerIndex = Players.IndexOf(value);
        }
        
        public GameModel(GameBoard board, Bank bank, IEnumerable<Player> players, Presenter presenter, ImmutableList<Type> typesToConstruct = null)
        {
            Board = board;
            Bank = bank;
            Players = players.ToImmutableList();
            Presenter = presenter;
            ActivePlayerIndex = 0;
            LongestRoadLength = 4;
            StateDictionary = MakeStates(typesToConstruct?? TurnStateList);
        }
        internal ImmutableDictionary<Type, dynamic> StateDictionary;

        public TurnState State(Type t)
        {            
            var val = StateDictionary[t];
            return (TurnState) val;
        }

        public T State<T>() where T: TurnState
        {
            var val = StateDictionary[typeof(T)];
            return (T) val;
        }

        internal static readonly ImmutableList<Type> TurnStateList = new List<Type>
        {
            typeof(WaitCity),            
            typeof(WaitRoad),
            typeof(WaitSettlement),
            typeof(EndGame),
            typeof(Build),
            typeof(Trade),
            typeof(Rob),
            typeof(MoveRobber),
            typeof(WaitRollDice),
            typeof(PlaceInitialRoad),
            typeof(PlaceInitialSettlement),
            typeof(PlayKnight),
            typeof(PlayMonopoly),
            typeof(PlayRoadBuilding),
            typeof(PlayYearOfPlenty),
            typeof(DoTrade)
        }.ToImmutableList();
        private ImmutableDictionary<Type, dynamic> MakeStates(ImmutableList<Type> turnStateTypes)
        {
            var stateDict = new Dictionary<Type, dynamic>();
            foreach (var type in turnStateTypes)
            {
                var state = Activator.CreateInstance(type,this);
                stateDict.Add(type, state); 
            }
            return stateDict.ToImmutableDictionary();
        }
    }
}