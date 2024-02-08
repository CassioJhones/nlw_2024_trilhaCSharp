using Microsoft.AspNetCore.Mvc;

namespace RocketSeatSolution.API.Controllers;

public class OfferController : RocketSeatSolutionBaseController
{
    [HttpPost]
    [Route("{itemId}")]
    public IActionResult CreateOffer([FromRoute] int itemId)
    {
        return Created();
    }
}
