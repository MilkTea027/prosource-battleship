using System;
using System.Windows.Forms;
using ProSource.Robles.Battleship.ShipPlacement.Base;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Steps
{
    public class OutOfBoundsCheckStep : ShipPlacementBaseStep, IOutOfBoundsCheckStep
    {
        public override void Process(ShipPlacementContext context)
        {
            if (IsValid(context))
            {
                context.Form.Cursor = Cursors.Default;
                this.Next(context);
            }
            else
            {
                context.Form.Cursor = Cursors.No;
            }
        }

        private bool IsValid(ShipPlacementContext context)
        {
            var name = context.ShipDisplayName;
            var length = this.GetShipLength(context);

            var isValid = 
                context.IsHorizontal ?
                    this.ValidHorizontalBounds(name, length)
                    : this.ValidVerticalBounds(name, length);

            return isValid;
        }

        private bool ValidHorizontalBounds(string name, int shipLength)
        {
            var current = Convert.ToInt32(name.Substring(2, name.Length - 2));
            var withinBounds = shipLength - 1 + current <= 10;
            return withinBounds;
        }

        private bool ValidVerticalBounds(string name, int shipLength)
        {
            var maxBounds = Convert.ToUInt16('J');
            var current = name.Substring(1, 1).ToCharArray()[0];
            var currentBounds = Convert.ToUInt16(current) + shipLength - 1;
            var withinBounds = currentBounds <= maxBounds;
            return withinBounds;
        }
    }
}
