using jogador.communication.Requests;
using jogador.domain.Entities;
using jogador.domain.Security.PasswordHashing;
using jogador.exception.ExceptionsBase;
using Mapster;

namespace jogador.application.UseCases.User.Register;

public class RegistrarUsuarioContaUseCase : IRegistrarUsuarioContaUseCase
{
    private readonly IPasswordHasher _passwordHasher;

    public RegistrarUsuarioContaUseCase(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }

    public void Execute(RequestRegistrarUsuarioJson request)
    {
        ValidateAndThrowOnFailures(request);

        var user = request.Adapt<domain.Entities.Usuario>();
        
        user.Senha = _passwordHasher.HashPassword(request.Senha);
    }
    private void ValidateAndThrowOnFailures(RequestRegistrarUsuarioJson request)
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
