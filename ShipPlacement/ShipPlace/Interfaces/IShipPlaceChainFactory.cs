using ProSource.Robles.Battleship.ShipPlacement.Base.Interfaces;

namespace ProSource.Robles.Battleship.ShipPlacement.ShipPlace.Interfaces
{
    public interface IShipPlaceChainFactory
    {
        IShipPlacementBaseStep GetChain();
    }
}