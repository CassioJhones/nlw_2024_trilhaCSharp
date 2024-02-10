using RocketSeatSolution.API.Entities;
using RocketSeatSolution.API.Repositories;

namespace RocketSeatSolution.API.Services;

public class UsuarioLogado
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public UsuarioLogado(IHttpContextAccessor httpContext)
    {
        _httpContextAccessor = httpContext;
    }
    public User Usuario()
    {
        var repositorio = new RocketSeatSolutioinDBContext();

        var token = TokenOnRequest();
        var email = DecodificadorBase64(token);

        return repositorio.Users.First
            (x => x.Email.Equals(email));
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
