using ProSource.Robles.Battleship.EnemyShip.Base.Interfaces;

namespace ProSource.Robles.Battleship.EnemyShip.Interfaces
{
    public interface IEnemyShipChainFactory
    {
        IEnemyShipBaseStep GetChain();
    }
}