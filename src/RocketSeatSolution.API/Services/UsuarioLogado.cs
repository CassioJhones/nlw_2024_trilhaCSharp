using RocketSeatSolution.API.Contratos;
using RocketSeatSolution.API.Entities;

namespace RocketSeatSolution.API.Services;

public class UsuarioLogado : IUsuarioLogado
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IRepositorioUsuario _repositorio;
    public UsuarioLogado(IHttpContextAccessor httpContext, IRepositorioUsuario repositorio)
    {
        _httpContextAccessor = httpContext;
        _repositorio = repositorio;
    }
    public User Usuario()
    {
        var token = TokenOnRequest();
        var email = DecodificadorBase64(token);

        return _repositorio.BuscaUsuarioPorEmail(email);
    }

    private string TokenOnRequest()
    {
        var autenticacao = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
        return autenticacao["Bearer ".Length..];
    }

    private string DecodificadorBase64(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}
