using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using ProSource.Robles.Battleship.Configurations;
using ProSource.Robles.Battleship.EnemyShip.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipHide.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Interfaces;

namespace ProSource.Robles.Battleship
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RunApplication();
        }

        static void RunApplication()
        {
            var serviceProvider = InjectionConfiguration.GetBuiltConfiguredServices();
            var shipDisplayChainFactory = serviceProvider.GetService<IShipDisplayChainFactory>();
            var shipHideChainFactory = serviceProvider.GetService<IShipHideChainFactory>();
            var shipPlaceChainFactory = serviceProvider.GetService<IShipPlaceChainFactory>();

            var battleshipForm = new BattleshipForm(
                                        shipDisplayChainFactory,
                                        shipHideChainFactory,
                                        shipPlaceChainFactory);

            Application.Run(battleshipForm);
        }
    }
}