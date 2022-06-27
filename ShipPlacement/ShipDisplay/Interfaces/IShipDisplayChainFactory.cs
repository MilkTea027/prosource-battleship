using ProSource.Robles.Battleship.ShipPlacement.Base.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipDisplay.Interfaces
{
    public interface IShipDisplayChainFactory
    {
        IShipPlacementBaseStep GetChain();
    }
}