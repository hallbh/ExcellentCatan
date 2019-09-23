using System;
using System.Collections.Generic;
using Catan.Controller.TurnMachines.Robber;
using Catan.Model;
using Catan.Properties;

namespace Catan.Controller.TurnMachines.GamePlay
{
    public class WaitRollDice : TurnState
    {
        internal static Random Rnd { get; set; }
        
        internal override string Prompt => Resources.RollDice_Instruction;
        public WaitRollDice(GameModel model) : base(model)
        {}
        

        private int DiceRoll()
        {
            return Rnd.Next(1, 7) + Rnd.Next(1, 7);
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            if (action.Type != ActionType.RollDice)
            {
                PromptError(Resources.TurnState_GeneralInvalidInput);
                return this;
            }
            var dieValue = DiceRoll();
            Presenter.RollDiceValue(dieValue);
            if (dieValue == 7)
            {
                var ret = State<MoveRobber>();
                ret.ReturnStateType = typeof(Trade);
                return ret;
            }

            var requests = new List<ResourceRequest>();
            for (var i = 0; i < Board.NumHexes; i++)
            {
                requests.AddRange(Board.GetHex(i).DistributeDieRollResources(dieValue));
            }

            Bank.SatisfyResourceRequests(requests);

            return State<Trade>();
        }
    }
}
