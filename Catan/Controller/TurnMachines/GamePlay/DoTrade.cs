using System.Collections.Generic;
using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.GamePlay
{
    public class DoTrade : TurnState
    { 
        internal override string Prompt => ExchangeTypeSelected ? Resources.DoTrade_SelectWant : Resources.DoTrade_Instruction;
        public bool ExchangeTypeSelected;
        private Item exchangeType;
        private int exchangeRate;

        public DoTrade(GameModel model) : base(model)
        {}

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type != ActionType.Hex || action.Value == Item.Desert)
            {
                PromptError(Resources.TurnState_GeneralInvalidInput);
                return this;
            }

            var requestedResource = Board.GetHex(action.Index).Resource;
            if (ExchangeTypeSelected && exchangeType != requestedResource)
            {
                var tradeAway = new ItemContainer(new Dictionary<Item, int> {{exchangeType, exchangeRate}});
                var tradeGet = new ItemContainer(new Dictionary<Item, int> {{requestedResource, 1}});

                if (!Bank.CanTransfer(tradeGet))
                {
                    PromptError(Resources.PlayYearOfPlenty_OutOfAResource);
                    return this;
                }

                ActivePlayer.Transfer(tradeAway, Bank);
                Bank.Transfer(tradeGet, ActivePlayer);
                Presenter.DisplayPlayerResources(ActivePlayer);
                ExchangeTypeSelected = false;
                return State<Trade>();
            }
            else
            {
                var tradeAway = new ItemContainer(new Dictionary<Item, int> { { requestedResource, exchangeRate } });
                if (ActivePlayer.CanTransfer(tradeAway))
                {
                    exchangeType = requestedResource;
                    ExchangeTypeSelected = true;
                    PromptUser(Resources.DoTrade_SelectWant);
                }
                else
                {
                    PromptError(Resources.DoTrade_NotEnough);
                }
            }

            return this;
        }

        public void SetTradeType(Item type, int rate)
        {
            exchangeType = type;
            exchangeRate = rate;

            if (exchangeType != Item.Any) ExchangeTypeSelected = true;
        }
    }
}
