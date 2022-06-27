using ProSource.Robles.Battleship.EnemyShip.Base;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;
using ProSource.Robles.Battleship.Enums;

namespace ProSource.Robles.Battleship.EnemyShip.Steps
{
    public class PlaceEnemyCruiserShipStep : EnemyShipBaseStep, IPlaceEnemyCruiserShipStep
    {
        public override void Process(EnemyShipContext context)
        {
            var cruiserButtons = this.PlaceShip(context, ShipType.Cruiser);
            context.PlacedShipButtons.AddRange(cruiserButtons);

            this.Next(context);
        }
    }
}
