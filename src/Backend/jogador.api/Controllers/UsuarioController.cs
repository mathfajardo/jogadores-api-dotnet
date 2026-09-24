using jogador.application.UseCases.User.Register;
using jogador.communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace jogador.api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    [HttpPost]

    public IActionResult Register([FromBody] RequestRegistrarUsuarioJson request)
    {
        var useCase = new RegistrarUsuarioContaUseCase();

        useCase.Execute(request);
        
        return Created();
    }
}
