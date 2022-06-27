using System.Linq;
using System.Windows.Forms;
using ProSource.Robles.Battleship.ShipPlacement.Base;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using ProSource.Robles.Battleship.ShipPlacement.ShipHide.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipHide.Steps
{
    public class ValidHideShipStep : ShipPlacementBaseStep, IValidHideShipStep
    {
        public override void Process(ShipPlacementContext context)
        {
            //// RETURN DEFAULT VALUES
            context.Form.Cursor = Cursors.Default;

            if (context.DisplayedShipTiles.Count() > 0)
            {
                context.DisplayedShipTiles.Clear();
                this.ChangeButtonColors(context, this.noShipColor);
            }

            this.Next(context);
        }
    }
}