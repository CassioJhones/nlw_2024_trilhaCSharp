using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketSeatSolution.API.Repositories;

namespace RocketSeatSolution.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {
            var token = TokenOnRequest(context.HttpContext);
            var repositorio = new RocketSeatSolutioinDBContext();
            var email = FromBase64String(token);
            var usuarioExistente = repositorio.Users.Any(x => x.Email.Equals(""));

            if (!usuarioExistente)
                context.Result = new UnauthorizedObjectResult("EMAIL OU USUARIO INVALIDO");
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
            throw new Exception("TOKEN INVALIDO");

        return autenticacao["Bearer ".Length..];
    }
    private string FromBase64String(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }

}
//Y2Fzc2lvLmJqaG9uZXNAZ21haWwuY29t