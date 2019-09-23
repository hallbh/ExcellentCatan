using System.Linq;
using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.GamePlay
{
    public class Trade : TurnState
    { 
        internal override string Prompt => Resources.Trade_Instruction;
        public Trade(GameModel model) : base(model)
        {
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type == ActionType.RequestTradeBasic)
            {
                if (Bank.GetMatchingItems(ItemHelper.ResourceCards).All(pair => pair.Value == 0))
                {
                    PromptError(Resources.Trade_BankCantTrade);
                    return this;
                }
                if (!CanActivePlayerTrade(4, Item.Any))
                {
                    PromptError(Resources.Trade_NotEnoughToTrade);
                    return this;
                }
                var doTrade = State<DoTrade>();
                doTrade.SetTradeType(Item.Any, 4);
                return State<DoTrade>();
            }

            if (action.Type == ActionType.RequestTradeHarbor)
            {

                var harbor = Model.Board.GetHarbor(action.Index);

                if (Bank.GetMatchingItems(ItemHelper.ResourceCards).Any(pair => pair.Value == 0))
                {
                    PromptError(Resources.Trade_BankCantTrade);
                    return this;
                }
                if (harbor.GetOwner() == ActivePlayer)
                {
                    var doTrade = State<DoTrade>();
                    var exchangeRate = harbor.Resource == Item.Any ? 3 : 2;
                    if (!CanActivePlayerTrade(exchangeRate, harbor.Resource))
                    {
                        PromptError(Resources.Trade_NotEnoughToTrade);
                    }
                    else
                    {
                        doTrade.SetTradeType(harbor.Resource, exchangeRate);
                        return doTrade;
                    }
                }

                PromptError(Resources.Trade_InvalidHarbor);
            }

            if (action.Type == ActionType.Build)
            {
                return State<Build>();
            }
            PromptError(Resources.TurnState_GeneralInvalidInput);
            return this;
        }
        
        public bool CanActivePlayerTrade(int amount, Item tradeType)
        {
            if (tradeType == Item.Any)
            {
                return ActivePlayer.GetMatchingItems(ItemHelper.ResourceCards).Any(pair => pair.Value >= amount);
            }

            return ActivePlayer.GetAmount(tradeType) >= amount;
        }
    }
}
