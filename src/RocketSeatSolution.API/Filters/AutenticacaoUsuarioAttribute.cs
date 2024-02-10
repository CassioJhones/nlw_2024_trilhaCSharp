using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketSeatSolution.API.Repositories;

namespace RocketSeatSolution.API.Filters;

public class AutenticacaoUsuarioAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);
            var repositorio = new RocketSeatSolutioinDBContext();
            var email = DecodificadorBase64(token);
            var usuarioExistente = repositorio.Users.Any(x => x.Email.Equals(email));

            if (!usuarioExistente)
                context.Result = new UnauthorizedObjectResult("EMAIL OU USUÁRIO INVÁLIDO");
        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }
    }

    private string TokenOnRequest(HttpContext context)
    {
        var autenticacao = context.Request.Headers.Authorization.ToString();

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