using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ProSource.Robles.Battleship.ShipPlacement.Base;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Steps
{
    public class ShipOverlapCheckStep : ShipPlacementBaseStep, IShipOverlapCheckStep
    {
        public override void Process(ShipPlacementContext context)
        {
            var displayedButtons = this.GetButtonPlacements(context);
            var displayedNames = displayedButtons.Select(button => button.Name);

            var isOverlapping = context.PlacedShipButtons
                        .Where(placed => displayedNames.Contains(placed.Name))
                        .Any();

            if (isOverlapping)
            {
                context.Form.Cursor = Cursors.No;
            }
            else
            {
                context.Form.Cursor = Cursors.Default;
                this.Next(context);
            }
        }
    }
}
