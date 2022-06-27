using ProSource.Robles.Battleship.EnemyShip.Base.Interfaces;
using ProSource.Robles.Battleship.EnemyShip.Interfaces;
using ProSource.Robles.Battleship.EnemyShip.Steps.Interfaces;

namespace ProSource.Robles.Battleship.EnemyShip
{
    public class EnemyShipChainFactory : IEnemyShipChainFactory
    {
        private readonly IShowEnemyShipProgressStep showEnemyShipProgressStep;
        private readonly IRetrieveAllShipButtonStep retrieveAllShipButtonStep;
        private readonly IPlaceEnemyDestroyerShipStep placeEnemyDestroyerShipStep;
        private readonly IPlaceEnemySubmarineShipStep placeEnemySubmarineShipStep;
        private readonly IPlaceEnemyCruiserShipStep placeEnemyCruiserShipStep;
        private readonly IPlaceEnemyBattleshipShipStep placeEnemyBattleshipShipStep;
        private readonly IPlaceCarrierShipStep placeCarrierShipStep;
        private readonly IEnemyAttackStartStep enemyAttackStartStep;

        private IEnemyShipBaseStep enemyShipChain;

        public EnemyShipChainFactory(
            IShowEnemyShipProgressStep showEnemyShipProgressStep,
            IRetrieveAllShipButtonStep retrieveAllShipButtonStep,
            IPlaceEnemyDestroyerShipStep placeEnemyDestroyerShipStep,
            IPlaceEnemySubmarineShipStep placeEnemySubmarineShipStep,
            IPlaceEnemyCruiserShipStep placeEnemyCruiserShipStep,
            IPlaceEnemyBattleshipShipStep placeEnemyBattleshipShipStep,
            IPlaceCarrierShipStep placeCarrierShipStep,
            IEnemyAttackStartStep enemyAttackStartStep)
        {
            this.showEnemyShipProgressStep = showEnemyShipProgressStep;
            this.retrieveAllShipButtonStep = retrieveAllShipButtonStep;
            this.placeEnemyDestroyerShipStep = placeEnemyDestroyerShipStep;
            this.placeEnemySubmarineShipStep = placeEnemySubmarineShipStep;
            this.placeEnemyCruiserShipStep = placeEnemyCruiserShipStep;
            this.placeEnemyBattleshipShipStep = placeEnemyBattleshipShipStep;
            this.placeCarrierShipStep = placeCarrierShipStep;
            this.enemyAttackStartStep = enemyAttackStartStep;
        }

        public IEnemyShipBaseStep GetChain()
        {
            if (this.enemyShipChain == null)
            {
                this.enemyShipChain = this.showEnemyShipProgressStep;
                this.enemyShipChain.SetSuccessor(this.retrieveAllShipButtonStep);
                this.enemyShipChain.SetSuccessor(this.placeEnemyDestroyerShipStep);
                this.enemyShipChain.SetSuccessor(this.placeEnemySubmarineShipStep);
                this.enemyShipChain.SetSuccessor(this.placeEnemyCruiserShipStep);
                this.enemyShipChain.SetSuccessor(this.placeEnemyBattleshipShipStep);
                this.enemyShipChain.SetSuccessor(this.placeCarrierShipStep);
                this.enemyShipChain.SetSuccessor(this.enemyAttackStartStep);
            }

            return this.enemyShipChain;
        }
    }
}
