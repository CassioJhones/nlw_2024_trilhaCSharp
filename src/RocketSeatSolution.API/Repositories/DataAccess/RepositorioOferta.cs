using RocketSeatSolution.API.Contratos;
using RocketSeatSolution.API.Entities;

namespace RocketSeatSolution.API.Repositories.DataAccess;

public class RepositorioOferta : IRepositorioOferta
{
    private readonly RocketSeatSolutioinDBContext _dbContext;
    public RepositorioOferta(RocketSeatSolutioinDBContext dBContext) => _dbContext = dBContext;
    public void Adicionar(Offer oferta)
    {
        _dbContext.Offers.Add(oferta);
        _dbContext.SaveChanges();
    }

}
