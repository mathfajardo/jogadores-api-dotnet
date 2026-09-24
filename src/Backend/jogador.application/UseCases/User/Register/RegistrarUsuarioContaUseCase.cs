using jogador.communication.Requests;

namespace jogador.application.UseCases.User.Register;

public class RegistrarUsuarioContaUseCase
{
    public void Execute(RequestRegistrarUsuarioJson request)
    {
        var validator = new RegistrarUsuarioContaValidator();

        var result = validator.Validate(request);
    }
}
