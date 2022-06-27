using ProSource.Robles.Battleship.ShipPlacement.Base.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Interfaces;
using ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Steps.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipPlace
{
    public class ShipPlaceChainFactory : IShipPlaceChainFactory
    {
        private readonly IAllShipAddedCheckStep allShipAddedCheckStep;
        private readonly IPendingDisplayShipCheckStep pendingDisplayShipCheckStep;
        private readonly IPlaceEnemyShipStep placeEnemyShipStep;
        private readonly IValidShipPlaceStep validShipPlaceStep;
        private IShipPlacementBaseStep shipPlaceChain;

        public ShipPlaceChainFactory(
            IAllShipAddedCheckStep allShipAddedCheckStep,
            IPendingDisplayShipCheckStep pendingDisplayShipCheckStep,
            IPlaceEnemyShipStep placeEnemyShipStep,
            IValidShipPlaceStep validShipPlaceStep)
        {
            this.allShipAddedCheckStep = allShipAddedCheckStep;
            this.pendingDisplayShipCheckStep = pendingDisplayShipCheckStep;
            this.placeEnemyShipStep = placeEnemyShipStep;
            this.validShipPlaceStep = validShipPlaceStep;
        }

        public IShipPlacementBaseStep GetChain()
        {
            if (this.shipPlaceChain == null)
            {
                this.shipPlaceChain = this.pendingDisplayShipCheckStep;
                this.shipPlaceChain.SetSuccessor(this.validShipPlaceStep);
                this.shipPlaceChain.SetSuccessor(this.allShipAddedCheckStep);
                this.shipPlaceChain.SetSuccessor(this.placeEnemyShipStep);
            }

            return this.shipPlaceChain;
        }
    }
}