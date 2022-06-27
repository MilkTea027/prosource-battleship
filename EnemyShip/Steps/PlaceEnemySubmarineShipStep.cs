using ProSource.Robles.Battleship.EnemyShip.Base;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;
using ProSource.Robles.Battleship.Enums;

namespace ProSource.Robles.Battleship.EnemyShip.Steps
{
    public class PlaceEnemySubmarineShipStep : EnemyShipBaseStep, IPlaceEnemySubmarineShipStep
    {
        public override void Process(EnemyShipContext context)
        {
            var submarineButtons = this.PlaceShip(context, ShipType.Submarine);
            context.PlacedShipButtons.AddRange(submarineButtons);

            this.Next(context);
        }
    }
}
