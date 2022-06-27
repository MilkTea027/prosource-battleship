using ProSource.Robles.Battleship.EnemyShip.Base;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;
using ProSource.Robles.Battleship.Enums;

namespace ProSource.Robles.Battleship.EnemyShip.Steps
{
    public class PlaceEnemyBattleshipShipStep : EnemyShipBaseStep, IPlaceEnemyBattleshipShipStep
    {
        public override void Process(EnemyShipContext context)
        {
            var battleshipButtons = this.PlaceShip(context, ShipType.Battleship);
            context.PlacedShipButtons.AddRange(battleshipButtons);

            this.Next(context);
        }
    }
}