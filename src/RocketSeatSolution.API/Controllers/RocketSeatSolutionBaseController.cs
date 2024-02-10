using Microsoft.AspNetCore.Mvc;

namespace RocketSeatSolution.API.Controllers;
[Route("[controller]")]
[ApiController]
public class RocketSeatSolutionBaseController : ControllerBase
{//Todos os controller herdam esse controlerBase, podendo evitar duplicidade de codigo e facilitando manutenções futuras.
}
