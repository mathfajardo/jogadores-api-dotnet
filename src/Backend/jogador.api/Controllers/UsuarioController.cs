using jogador.application.UseCases.User.Register;
using jogador.communication.Requests;
using jogador.communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace jogador.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUsuarioJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RequestRegistrarUsuarioJson request, [FromServices] IRegistrarUsuarioContaUseCase useCase)
    {
        var result = await useCase.Execute(request);
        
        return Created(string.Empty, result);
    }
}
