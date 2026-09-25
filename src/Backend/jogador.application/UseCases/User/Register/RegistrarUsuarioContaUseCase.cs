using jogador.communication.Requests;
using jogador.exception.ExceptionsBase;

namespace jogador.application.UseCases.User.Register;

public class RegistrarUsuarioContaUseCase
{
    public void Execute(RequestRegistrarUsuarioJson request)
    {
        var validator = new RegistrarUsuarioContaValidator();

        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
