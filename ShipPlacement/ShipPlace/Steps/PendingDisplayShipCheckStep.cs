using System.Linq;
using ProSource.Robles.Battleship.ShipPlacement.Base;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps
{
    public class PendingDisplayShipCheckStep : ShipPlacementBaseStep, IPendingDisplayShipCheckStep
    {
        public override void Process(ShipPlacementContext context)
        {
            if (context.DisplayedShipTiles.Any())
            {
                this.Next(context);
            }
        }
    }
}
