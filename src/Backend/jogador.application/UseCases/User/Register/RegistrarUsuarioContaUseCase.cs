using FluentValidation.Results;
using jogador.communication.Requests;
using jogador.communication.Responses;
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
    private readonly IUsuarioReadOnlyRepository _usuarioReadOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegistrarUsuarioContaUseCase(IPasswordHasher passwordHasher, IUsuarioWriteOnlyRepository usuarioWriteOnlyRepository, IUnitOfWork unitOfWork, IUsuarioReadOnlyRepository usuarioReadOnlyRepository)
    {
        _passwordHasher = passwordHasher;
        _usuarioWriteOnlyRepository = usuarioWriteOnlyRepository;
        _usuarioReadOnlyRepository = usuarioReadOnlyRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResponseRegisteredUsuarioJson> Execute(RequestRegistrarUsuarioJson request)
    {
        await ValidateAndThrowOnFailures(request);

        var user = request.Adapt<domain.Entities.Usuario>();
        
        user.Senha = _passwordHasher.HashPassword(request.Senha);

        await _usuarioWriteOnlyRepository.Add(user);

        await _unitOfWork.Commit();

        return new ResponseRegisteredUsuarioJson
        {
            Nome = user.Nome,
            Tokens = new ResponseTokensJson()
        };
    }
    private async Task ValidateAndThrowOnFailures(RequestRegistrarUsuarioJson request)
    {
        var validator = new RegistrarUsuarioContaValidator();

        var result = validator.Validate(request);

        var emailExist = await _usuarioReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
        if (emailExist)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, "O email já está em uso"));
        }

        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
