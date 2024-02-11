using RocketSeatSolution.API.Entities;

namespace RocketSeatSolution.API.Contratos;

public interface IRepositorioLeilao
{
    Auction? GetCurrent();
}
