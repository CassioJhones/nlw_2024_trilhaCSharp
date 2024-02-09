using Microsoft.AspNetCore.Mvc;
using RocketSeatSolution.API.Comunication.Request;
using RocketSeatSolution.API.Filters;

namespace RocketSeatSolution.API.Controllers;
[ServiceFilter(typeof(AuthenticationUserAttribute))]
public class OfferController : RocketSeatSolutionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute] int itemId, [FromBody] RequestCreateOfferJson request)
    {
        return Created();
    }
}
