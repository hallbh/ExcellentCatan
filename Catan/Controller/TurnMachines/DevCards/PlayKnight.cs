using Catan.Model;
using Catan.Properties;
using Catan.Controller.TurnMachines.Robber;

namespace Catan.Controller.TurnMachines.DevCards
{
    public class PlayKnight : MoveRobber
    {
        private readonly ItemContainer largestArmyContainer = Item.LargestArmyCard.Count();

        public PlayKnight(GameModel model) : base(model)
        {
            OnEnterList.Add(CheckLargestArmy);
        }

        protected void CheckLargestArmy()
        {
            if (ActivePlayer.HasLargestArmy) return; // Vacuously true
            if (Bank.GetAmount(Item.LargestArmyCard) == 1 && 
                ActivePlayer.DiscardPile.GetAmount(Item.KnightCard) == 3) // Bank case
            {
                ChangeLargestArmyOwner(Bank);
            }
            // Player to Player
            foreach (var player in Players)
            {
                if (player.HasLargestArmy)
                {
                    var owner = player;

                    var knights = ActivePlayer.DiscardPile.GetAmount(Item.KnightCard);
                    var ownersKnights = owner.DiscardPile.GetAmount(Item.KnightCard);
                    if (knights >= 3 && ownersKnights < knights)
                    {
                        ChangeLargestArmyOwner(owner);
                    }
                    return;
                }
            }
        }

        private void ChangeLargestArmyOwner(ItemContainer source)
        {
            PromptError(Resources.PlayKnightCard_ReceivedLargestArmy);
            source.Transfer(largestArmyContainer, ActivePlayer);
            Presenter.DisplayLargestArmyOwner(ActivePlayer.Color.LocalizedString());
        }
    }
}