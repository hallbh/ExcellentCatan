using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Catan.Controller.TurnMachines;
using Catan.Controller.TurnMachines.GamePlay;
using Catan.GUI;
using Catan.Model;

namespace Catan.Controller
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            var selector = new LocaleSelector();
            selector.Activate();
            selector.ShowDialog(null);
            if (selector.DialogResult != DialogResult.OK)
            {
                return;
            }

            CultureInfo.CurrentCulture = selector.TargetCulture;
            CultureInfo.CurrentUICulture = selector.TargetCulture;
            CultureInfo.DefaultThreadCurrentCulture = selector.TargetCulture;
            CultureInfo.DefaultThreadCurrentUICulture = selector.TargetCulture;

            var rnd = new Random();
            WaitRollDice.Rnd = rnd;
            ItemContainer.Rnd = rnd;
            var view = new MainGameForm();
            // Construct the initial game data structures
            var presenter = new Presenter(view);
            var board = new GameBoard();
            var bank = new Bank();
            var playerList = new List<Player>
            {
                new Player(PlayerColor.Blue),
                new Player(PlayerColor.Orange),
                new Player(PlayerColor.Red),
                new Player(PlayerColor.White)
            };
            
            
            var gameModel = new GameModel(board, bank, playerList, presenter);
            var manager = new TurnManager(gameModel);
            presenter.RegisterTurnManager(manager);
            board.InitializeView(presenter);

            var t = new Thread(presenter.MainLoop);
            t.Start();
            Application.Run(view);
        }

    }
}
