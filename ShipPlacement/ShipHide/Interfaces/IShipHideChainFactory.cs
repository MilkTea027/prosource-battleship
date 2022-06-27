using ProSource.Robles.Battleship.ShipPlacement.Base.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipHide.Interfaces
{
    public interface IShipHideChainFactory
    {
        IShipPlacementBaseStep GetChain();
    }
}