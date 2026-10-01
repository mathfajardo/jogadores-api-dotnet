using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Security;
using jogador.application.UseCases.User.Register;
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

    private RegistrarUsuarioContaUseCase CreateUseCase()
    {
        var unitOfWork = IUnitOfWorkBuilder.Build();
        var usuarioWriteOnlyRepository = IUsuarioWriteOnlyRepositoryBuilder.Build();
        var usuarioReadOnlyRepository = new IUsuarioReadOnlyRepositoryBuilder().Build();
        var passwordHasher = new IPasswordHasherBuilder().Build();

        return new RegistrarUsuarioContaUseCase(passwordHasher, usuarioWriteOnlyRepository, unitOfWork, usuarioReadOnlyRepository);
    }
}
