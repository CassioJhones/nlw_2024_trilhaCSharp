using Microsoft.AspNetCore.Mvc;
using RocketSeatSolution.API.Comunication.Request;
using RocketSeatSolution.API.Filters;
using RocketSeatSolution.API.UseCases.Offers.CreateOffer;

namespace RocketSeatSolution.API.Controllers;
[ServiceFilter(typeof(AutenticacaoUsuarioAttribute))]
public class OfferController : RocketSeatSolutionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer(
        [FromRoute] int itemId,
        [FromBody] RequestCreateOfferJson request,
        [FromServices] CreateOfferUseCase useCase)
    {
        var id = useCase.Execute(itemId, request);

        return Created(string.Empty,id);
    }
}
