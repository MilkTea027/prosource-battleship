using ProSource.Robles.Battleship.EnemyShip.Base.Interfaces;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.EnemyShip.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.Base;
using ProSource.Robles.Battleship.ShipPlacement.Contexts;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps
{
    public class PlaceEnemyShipStep : ShipPlacementBaseStep, IPlaceEnemyShipStep
    {
        private readonly IEnemyShipBaseStep enemyShipChain;

        public PlaceEnemyShipStep(IEnemyShipChainFactory enemyShipChain)
        {
            this.enemyShipChain = enemyShipChain.GetChain();
        }

        public override void Process(ShipPlacementContext context)
        {
            this.enemyShipChain.Process(context.EnemyShipContext);
            this.Next(context);
        }
    }
}