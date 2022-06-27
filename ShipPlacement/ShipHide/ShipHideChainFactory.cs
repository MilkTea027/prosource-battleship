using ProSource.Robles.Battleship.ShipPlacement.Base.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipHide.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipHide.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipHide
{
    public class ShipHideChainFactory : IShipHideChainFactory
    {
        private readonly IValidHideShipStep validHideShipStep;

        public ShipHideChainFactory(IValidHideShipStep validHideShipStep)
        {
            this.validHideShipStep = validHideShipStep;
        }

        public IShipPlacementBaseStep GetChain()
        {
            return this.validHideShipStep;
        }
    }
}