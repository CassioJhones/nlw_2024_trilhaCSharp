using RocketSeatSolution.API.Entities;

namespace RocketSeatSolution.API.Contratos;

public interface IRepositorioUsuario
{
    bool ExisteUsuarioComEmail(string email);
    User BuscaUsuarioPorEmail(string email);
}
