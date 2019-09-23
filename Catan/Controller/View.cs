using Catan.Model;

namespace Catan.Controller
{
    public interface View
    {

        bool HasNextPlayerAction();
        PlayerAction GetNextPlayerAction();

        void SetPromptLabel(string prompt);
        void SetErrorPromptLabel(string prompt);
        void SetPlayerName(string name);
        void SetResource(Item r, string resourceLabel);
        void SetupHex(int index, string hexLabel, Item color);
        void SetupHarbor(int index, string hexLabel, Item color);
        void ColorSettlement(PlayerColor color, int index);
        void ColorRoad(PlayerColor color, int index);
        void SetRobberPosition(int index);
        void SetCity(int index);
        void SetDiceRoll(string value);
        void DisplayPlayerVictory(PlayerColor color, string message);
        void SetLongestRoadOwner(string owner);
        void SetLargestArmyOwner(string owner);
    }
}