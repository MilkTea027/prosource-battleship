using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ProSource.Robles.Battleship.Consts;
using ProSource.Robles.Battleship.Enums;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using System.Linq;
using ProSource.Robles.Battleship.Base;
using ProSource.Robles.Battleship.ShipPlacement.Base.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.Base
{
    public abstract class ShipPlacementBaseStep : ChainStepBase<ShipPlacementContext>, IShipPlacementBaseStep
    {
        protected Color noShipColor = Color.FromKnownColor(KnownColor.ControlLight);

        protected Dictionary<ShipType, Color> ShipColors = new Dictionary<ShipType, Color>()
        {
            { ShipType.Destroyer, Color.FromArgb(192, 192, 0) },
            { ShipType.Submarine, Color.FromArgb(0, 192, 192) },
            { ShipType.Cruiser, Color.FromArgb(0, 0, 192) },
            { ShipType.Battleship, Color.FromArgb(192, 0, 192) },
            { ShipType.Carrier, Color.FromKnownColor(KnownColor.Maroon) },
        };

        protected Dictionary<ShipType, int> ShipTypeLength = new Dictionary<ShipType, int>()
        {
            { ShipType.Destroyer, ShipLength.Destroyer },
            { ShipType.Submarine, ShipLength.Submarine },
            { ShipType.Cruiser, ShipLength.Cruiser },
            { ShipType.Battleship, ShipLength.Battleship },
            { ShipType.Carrier, ShipLength.Carrier },
        };

        protected int GetShipLength(ShipPlacementContext context)
        {
            return this.ShipTypeLength[context.ShipType];
        }

        protected List<Button> ChangeButtonColors(ShipPlacementContext context, Color shipColor)
        {
            var buttons = this.GetButtonPlacements(context);
            buttons.ForEach(button => button.BackColor = shipColor);
            return buttons;
        }

        protected List<Button> GetButtonPlacements(ShipPlacementContext context)
        {
            var buttons = new List<Button>();
            var shipLength = this.ShipTypeLength[context.ShipType];

            for (var ctr = 0; ctr < shipLength; ctr++)
            {
                var incrementName = context.IsHorizontal ?
                    this.GetHorizontalIncrement(context.ShipDisplayName, ctr) :
                    this.GetVerticalIncrement(context.ShipDisplayName, ctr);

                var controlName = $"btn{incrementName}";
                var controls = context.Form.Controls.Find(controlName, true);

                if (controls.Any())
                {
                    var button = controls[0] as Button;
                    buttons.Add(button);
                }
            }

            return buttons;
        }

        protected TControl GetFormValue<TControl>(ShipPlacementContext context, string controlName)
            where TControl : Control
        {
            var control = context.Form.Controls.Find(controlName, true)[0] as TControl;
            return control;
        }

        private string GetHorizontalIncrement(string name, int increment)
        {
            var toReplace = name.Substring(2, name.Length - 2);
            var newValue = (Convert.ToInt32(toReplace) + increment).ToString();
            var result = name.Replace(toReplace, newValue);
            return result;
        }

        private string GetVerticalIncrement(string name, int increment)
        {
            var oldValue = name.Substring(1, 1).ToCharArray()[0];
            var newValue = (char)(Convert.ToUInt16(oldValue) + increment);
            var result = new StringBuilder(name);
            result[1] = newValue;
            return result.ToString();
        }
    }
}