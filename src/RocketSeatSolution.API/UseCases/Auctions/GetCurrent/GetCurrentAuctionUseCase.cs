using RocketSeatSolution.API.Contratos;
using RocketSeatSolution.API.Entities;

namespace RocketSeatSolution.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    private readonly IRepositorioLeilao _repositorio;
    public GetCurrentAuctionUseCase(IRepositorioLeilao repositorio) => _repositorio = repositorio;
    public Auction? Execute()
    {
        return _repositorio.GetCurrent();
    }
}
