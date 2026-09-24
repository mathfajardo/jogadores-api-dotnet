using Microsoft.AspNetCore.Mvc;
using jogador.communication.Requests;

namespace jogador.api.Controllers;

[Route("api/[controller]")]
[ApiController]

public class JogadorController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody] RequestRegistrarJogadorJson request)
    {
        return Created();
    }
}

