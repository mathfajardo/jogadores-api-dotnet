using jogador.communication.Requests;
using jogador.domain.Entities;
using jogador.domain.Repositories;
using jogador.domain.Repositories.Usuario;
using jogador.domain.Security.PasswordHashing;
using jogador.exception.ExceptionsBase;
using Mapster;

namespace jogador.application.UseCases.User.Register;

public class RegistrarUsuarioContaUseCase : IRegistrarUsuarioContaUseCase
{
    private readonly IPasswordHasher _passwordHasher;
    private readonly IUsuarioWriteOnlyRepository _usuarioWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegistrarUsuarioContaUseCase(IPasswordHasher passwordHasher, IUsuarioWriteOnlyRepository usuarioWriteOnlyRepository, IUnitOfWork unitOfWork)
    {
        _passwordHasher = passwordHasher;
        _usuarioWriteOnlyRepository = usuarioWriteOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Execute(RequestRegistrarUsuarioJson request)
    {
        ValidateAndThrowOnFailures(request);

        var user = request.Adapt<domain.Entities.Usuario>();
        
        user.Senha = _passwordHasher.HashPassword(request.Senha);

        await _usuarioWriteOnlyRepository.Add(user);

        await _unitOfWork.Commit();
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
