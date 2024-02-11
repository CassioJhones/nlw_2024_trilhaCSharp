using Microsoft.AspNetCore.Mvc;
using RocketSeatSolution.API.Entities;
using RocketSeatSolution.API.UseCases.Auctions.GetCurrent;

namespace RocketSeatSolution.API.Controllers;

public class AuctionController : RocketSeatSolutionBaseController
{
    //mostra no swagger o tipo de retorno [Auction com code 200] documentacao
    //mostra no swagger o tipo de retorno [Auction com code 204] documentacao
    [HttpGet]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult GetCurrentAuction([FromServices] GetCurrentAuctionUseCase useCase)
    {
        var resultado = useCase.Execute;

        if (resultado is null)
            return NoContent();

        return Ok(resultado);
    }


}


//TODO:
//Dividir o projeto em camadas(arquitetura)
//Usar tasks assincronas