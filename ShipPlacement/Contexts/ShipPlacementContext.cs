using System.Collections.Generic;
using System.Windows.Forms;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.Enums;

namespace ProSource.Robles.Battleship.ShipPlacement.Contexts
{
    public class ShipPlacementContext
    {
        public ShipPlacementContext(BattleshipForm form)
        {
            this.Form = form;
            this.ShipType = ShipType.Destroyer;
            this.ShipDirection = ShipDirection.Horizontal;
            this.DisplayedShipTiles = new List<Button>();
            this.PlacedShipButtons = new List<Button>();
            this.EnemyShipContext = new EnemyShipContext(this.Form);
        }

        public List<Button> DisplayedShipTiles { get; set; }

        public List<Button> PlacedShipButtons { get; set; }

        public BattleshipForm Form { get; private set; }

        public ShipType ShipType { get; set; }

        public ShipDirection ShipDirection { get; set; }

        public string ShipDisplayName { get; set; }

        public EnemyShipContext EnemyShipContext { get; set; }

        public bool IsHorizontal
        {
            get
            {
                return this.ShipDirection == ShipDirection.Horizontal;
            }
        }
    }
}
