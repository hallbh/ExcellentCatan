using Catan.Model;

namespace Catan.Controller.TurnMachines.GamePlay
{
    public class EndGame : TurnState
    {
        // Special default no prompt for EndGame
        internal override string Prompt => "";
        public EndGame(GameModel model) : base(model)
        {
            OnEnterList.Add(EndGameOnEnter);
        }

        protected void EndGameOnEnter()
        {
            Presenter.DisplayPlayerVictory(ActivePlayer);
        }

        public override TurnState HandleInput(PlayerAction action)
        {
            return this;
        }
    }
}