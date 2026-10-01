using CommonTestUtilities.Repositories;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Security;
using jogador.application.UseCases.User.Register;

namespace UseCases.Tests.User.Register;

public class RegistrarUsuarioContaUseCaseTests
{
    [Fact]
    public async Task Success()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();

        var useCase = CreateUseCase();
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
