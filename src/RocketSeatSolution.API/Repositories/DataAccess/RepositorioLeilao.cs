using Microsoft.EntityFrameworkCore;
using RocketSeatSolution.API.Contratos;
using RocketSeatSolution.API.Entities;

namespace RocketSeatSolution.API.Repositories.DataAccess;

public class RepositorioLeilao : IRepositorioLeilao
{
    private readonly RocketSeatSolutioinDBContext _dbContext;
    public RepositorioLeilao(RocketSeatSolutioinDBContext dBContext) => _dbContext=dBContext;   

    public Auction? GetCurrent()
    {
        var dataHoje = DateTime.Now;
        var dataTeste = new DateTime(2024, 01, 22);
        return _dbContext
            .Auctions
            .Include(x => x.Items)
            .FirstOrDefault
            (x => dataTeste >= x.Starts && dataTeste <= x.Ends);
    }
}
