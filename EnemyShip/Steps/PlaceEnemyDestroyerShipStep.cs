using ProSource.Robles.Battleship.EnemyShip.Base;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;
using ProSource.Robles.Battleship.Enums;

namespace ProSource.Robles.Battleship.EnemyShip.Steps
{
    public class PlaceEnemyDestroyerShipStep : EnemyShipBaseStep, IPlaceEnemyDestroyerShipStep
    {
        public override void Process(EnemyShipContext context)
        {
            var destroyerButtons = this.PlaceShip(context, ShipType.Destroyer);
            context.PlacedShipButtons.AddRange(destroyerButtons);

            this.Next(context);
        }
    }
}
