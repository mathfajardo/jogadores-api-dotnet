using jogador.domain.Repositories.Usuario;
using Moq;

namespace CommonTestUtilities.Repositories;

public class IUsuarioReadOnlyRepositoryBuilder
{
    private readonly Mock<IUsuarioReadOnlyRepository> _mock;

    public IUsuarioReadOnlyRepositoryBuilder()
    {
        _mock = new Mock<IUsuarioReadOnlyRepository>();
    }

    public void ExistActiveUserWithEmail(string email)
    {
        _mock.Setup(repository => repository.ExistActiveUserWithEmail(email)).ReturnsAsync(true);
    }

    public IUsuarioReadOnlyRepository Build() => _mock.Object;

}
