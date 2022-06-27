using System.Windows.Forms;
using ProSource.Robles.Battleship.ShipPlacement.Base;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps
{
    public class ValidShipPlaceStep : ShipPlacementBaseStep, IValidShipPlaceStep
    {
        public override void Process(ShipPlacementContext context)
        {
            context.DisplayedShipTiles.ForEach(d => d.Cursor = Cursors.No);
            context.PlacedShipButtons.AddRange(context.DisplayedShipTiles);
            context.DisplayedShipTiles.Clear();

            this.Next(context);
        }
    }
}
