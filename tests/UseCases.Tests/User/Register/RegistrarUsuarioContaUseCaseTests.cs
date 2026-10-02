using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Security;
using jogador.application.UseCases.User.Register;
using jogador.domain.Extensions;
using jogador.exception.ExceptionsBase;
using Shouldly;

namespace UseCases.Tests.User.Register;

public class RegistrarUsuarioContaUseCaseTests
{
    [Fact]
    public async Task Success()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();

        var useCase = CreateUseCase();
        
        var result = await useCase.Execute(request);

        result.ShouldNotBeNull();
        result.Tokens.ShouldNotBeNull();
        result.Nome.ShouldBe(request.Nome);
        result.Tokens.AccessToken.ShouldBeNullOrEmpty();
        result.Tokens.RefreshToken.ShouldBeNullOrEmpty();
    }

    [Fact]
    public async Task Validate_ShouldThrowException_WhenNameIsEmpty()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();
        request.Nome = string.Empty;

        var useCase = CreateUseCase();

        var exception = await useCase.Execute(request).ShouldThrowAsync<ErrorOnValidationException>();
        exception.GetErrorMessages().ShouldSatisfyAllConditions(errorMessages =>
        {
            errorMessages.Count.ShouldBe(1);
        });
    }

    [Fact]
    public async Task Validate_ShouldThrowException_WhenEmailAlreadyExists()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();

        var useCase = CreateUseCase(request.Email);

        var exception = await useCase.Execute(request).ShouldThrowAsync<ErrorOnValidationException>();
        exception.GetErrorMessages().ShouldSatisfyAllConditions(errorMessages =>
        {
            errorMessages.Count.ShouldBe(1);
        });
    }


    private RegistrarUsuarioContaUseCase CreateUseCase(string? emailThatAlreadyExists = null)
    {
        var unitOfWork = IUnitOfWorkBuilder.Build();
        var usuarioWriteOnlyRepository = IUsuarioWriteOnlyRepositoryBuilder.Build();
        var passwordHasher = new IPasswordHasherBuilder().Build();
        var usuarioReadOnlyRepositoryBuilder = new IUsuarioReadOnlyRepositoryBuilder();
        if(emailThatAlreadyExists.IsNotEmpty())
        {
          usuarioReadOnlyRepositoryBuilder.ExistActiveUserWithEmail(emailThatAlreadyExists);
        }

        return new RegistrarUsuarioContaUseCase(passwordHasher, usuarioWriteOnlyRepository, unitOfWork, usuarioReadOnlyRepositoryBuilder.Build());
    }
}
