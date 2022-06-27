using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ProSource.Robles.Battleship.Base;
using ProSource.Robles.Battleship.Consts;
using ProSource.Robles.Battleship.EnemyShip.Base.Interfaces;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.Enums;

namespace ProSource.Robles.Battleship.EnemyShip.Base
{
    public abstract class EnemyShipBaseStep : ChainStepBase<EnemyShipContext>, IEnemyShipBaseStep
    {
        protected Dictionary<ShipType, int> ShipTypeLength = new Dictionary<ShipType, int>()
        {
            { ShipType.Destroyer, ShipLength.Destroyer },
            { ShipType.Submarine, ShipLength.Submarine },
            { ShipType.Cruiser, ShipLength.Cruiser },
            { ShipType.Battleship, ShipLength.Battleship },
            { ShipType.Carrier, ShipLength.Carrier },
        };

        protected TControl GetFormValue<TControl>(EnemyShipContext context, string controlName)
            where TControl : Control
        {
            var control = context.Form.Controls.Find(controlName, true)[0] as TControl;
            return control;
        }

        /// <summary>
        /// Places the ship. Hard coded for now due to lack of time 
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="shipType">Type of the ship.</param>
        /// <returns></returns>
        public List<Button> PlaceShip(EnemyShipContext context, ShipType shipType)
        {
            var buttons = new List<Button>();
            var shipLength = this.ShipTypeLength[shipType];
            var startButtonName = $"btnBA{((int)shipType)+1*2}";

            for (var ctr = 1; ctr <= shipLength; ctr++)
            {
                var oldValue = startButtonName.Substring(4, 1).ToCharArray()[0];
                var newValue = (char)(Convert.ToUInt16(oldValue) + ctr);
                var newButtonName = new StringBuilder(startButtonName);
                newButtonName[4] = newValue;

                var button = this.GetFormValue<Button>(context, newButtonName.ToString());
                buttons.Add(button);
            }

            return buttons;
        }
    }
}