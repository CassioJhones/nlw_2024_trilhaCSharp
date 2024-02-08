using Microsoft.EntityFrameworkCore;
using RocketSeatSolution.API.Entities;
using RocketSeatSolution.API.Repositories;

namespace RocketSeatSolution.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{
    public Auction? Execute()
    {
        var repositorio = new RocketSeatSolutioinDBContext();

        var dataHoje = DateTime.Now;
        var dataTeste = new DateTime(2024,01,22);

        return repositorio
            .Auctions
            .Include(x => x.Items)
            .FirstOrDefault(x => dataTeste >= x.Starts && dataTeste <= x.Ends);
    }
}
