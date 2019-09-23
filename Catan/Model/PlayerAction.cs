using Catan.Properties;

namespace Catan.Model
{
    public enum ActionType {
        Path,
        Intersection,
        EndTurn,
        Hex,
        NoOp,
        Build,
        RollDice,
        Exit,
        RequestRoad,
        RequestSettlement,
        RequestCity,
        RequestDevCard,
        RequestTradeBasic,
        RequestTradeHarbor,
        PlayDevCard
    }

    public static class ActionTypeHelper 
    {
        public static string LocalizedString(this ActionType action)
        {
            return Resources.ResourceManager.GetString(@"ActionType_" + action);
        }
    }
    public class PlayerAction
    {
        public readonly ActionType Type;
        public readonly int Index;
        public readonly Item Value;
        
        public PlayerAction(ActionType actionType, int index = -1, Item value = Item.Any)
        {
            Type = actionType;
            Index = index;
            Value = value;
        }
    }
}
