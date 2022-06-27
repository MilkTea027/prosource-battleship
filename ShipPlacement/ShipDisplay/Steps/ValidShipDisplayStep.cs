using ProSource.Robles.Battleship.ShipPlacement.Base;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Steps
{
    public class ValidShipDisplayStep : ShipPlacementBaseStep, IValidShipDisplayStep
    {
        public override void Process(ShipPlacementContext context)
        {
            var color = this.ShipColors[context.ShipType];
            context.DisplayedShipTiles = this.ChangeButtonColors(context, color);

            this.Next(context);
        }
    }
}