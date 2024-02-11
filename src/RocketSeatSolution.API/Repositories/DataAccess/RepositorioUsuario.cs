using RocketSeatSolution.API.Contratos;
using RocketSeatSolution.API.Entities;

namespace RocketSeatSolution.API.Repositories.DataAccess;

public class RepositorioUsuario : IRepositorioUsuario
{
    private readonly RocketSeatSolutioinDBContext _dbContext;
    public RepositorioUsuario(RocketSeatSolutioinDBContext dBContext) => _dbContext = dBContext;

    public bool ExisteUsuarioComEmail(string email)
    {
        return _dbContext.Users.Any(x => x.Email.Equals(email));
    }

    public User BuscaUsuarioPorEmail(string email) {
        return _dbContext.Users.First
            (x => x.Email.Equals(email));
    }
}
