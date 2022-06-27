using ProSource.Robles.Battleship.EnemyShip.Base;
using ProSource.Robles.Battleship.EnemyShip.Contexts;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;
using ProSource.Robles.Battleship.Enums;

namespace ProSource.Robles.Battleship.EnemyShip.Steps
{
    public class PlaceCarrierShipStep : EnemyShipBaseStep, IPlaceCarrierShipStep
    {
        public override void Process(EnemyShipContext context)
        {
            var carrierButtons = this.PlaceShip(context, ShipType.Carrier);
            context.PlacedShipButtons.AddRange(carrierButtons);

            this.Next(context);
        }
    }
}