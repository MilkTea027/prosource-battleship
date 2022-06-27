using ProSource.Robles.Battleship.ShipPlacement.Base.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipDisplay
{
    public class ShipDisplayChainFactory : IShipDisplayChainFactory
    {
        private readonly IOutOfBoundsCheckStep outOfBoundsCheckStep;
        private readonly IShipOverlapCheckStep shipOverlapCheckStep;
        private readonly IValidShipDisplayStep validShipDisplayStep;
        private IShipPlacementBaseStep shipDisplayChain;

        public ShipDisplayChainFactory(
            IOutOfBoundsCheckStep outOfBoundsCheckStep,
            IShipOverlapCheckStep shipOverlapCheckStep,
            IValidShipDisplayStep validShipDisplayStep)
        {
            this.outOfBoundsCheckStep = outOfBoundsCheckStep;
            this.shipOverlapCheckStep = shipOverlapCheckStep;
            this.validShipDisplayStep = validShipDisplayStep;
        }

        public IShipPlacementBaseStep GetChain()
        {
            if (this.shipDisplayChain == null)
            {
                this.shipDisplayChain = this.outOfBoundsCheckStep;
                this.shipDisplayChain.SetSuccessor(this.shipOverlapCheckStep);
                this.shipDisplayChain.SetSuccessor(this.validShipDisplayStep);
            }

            return this.shipDisplayChain;
        }
    }
}