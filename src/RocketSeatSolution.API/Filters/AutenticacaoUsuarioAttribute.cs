using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketSeatSolution.API.Contratos;

namespace RocketSeatSolution.API.Filters;

public class AutenticacaoUsuarioAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    private IRepositorioUsuario _repositorio;
    public AutenticacaoUsuarioAttribute(IRepositorioUsuario repositorio) => _repositorio = repositorio; 
    public void OnAuthorization(AuthorizationFilterContext contexto)
    {
        try
        {
            var token = TokenOnRequest(contexto.HttpContext);
            var email = DecodificadorBase64(token);
            var usuarioExistente = _repositorio.ExisteUsuarioComEmail(email);

            if (!usuarioExistente)
                contexto.Result = new UnauthorizedObjectResult("EMAIL OU USUÁRIO INVÁLIDO");
        }
        catch (Exception ex)
        {
            contexto.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }
    private string TokenOnRequest(HttpContext contexto)
    {
        var autenticacao = contexto.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(autenticacao))
            throw new Exception("TOKEN AUSENTE OU INVÁLIDO");

        return autenticacao["Bearer ".Length..];
    }
    private string DecodificadorBase64(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }

}
//Y2Fzc2lvLmJqaG9uZXNAZ21haWwuY29t
//Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20=