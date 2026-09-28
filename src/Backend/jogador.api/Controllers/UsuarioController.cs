using jogador.application.UseCases.User.Register;
using jogador.communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace jogador.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RequestRegistrarUsuarioJson request, [FromServices] IRegistrarUsuarioContaUseCase useCase)
    {
        await useCase.Execute(request);
        
        return Created();
    }
}
