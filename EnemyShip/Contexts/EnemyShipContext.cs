using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ProSource.Robles.Battleship.EnemyShip.Contexts
{
    public class EnemyShipContext
    {
        public EnemyShipContext(BattleshipForm form)
        {
            this.Form = form;
            this.PlacedShipButtons = new List<Button>();
        }

        public List<Button> PlayerButtons { get; set; }

        public List<Button> EnemyButtons { get; set; }

        public List<Button> PlacedShipButtons { get; set; }

        public BattleshipForm Form { get; private set; }

        public Color HitColor
        {
            get
            {
                return Color.Green;
            }
        }

        public Color MissColor
        {
            get
            {
                return Color.Red;
            }
        }

        public Color NoShipColor
        {
            get
            {
                return Color.FromKnownColor(KnownColor.ControlLight);
            }
        }
    }
}
