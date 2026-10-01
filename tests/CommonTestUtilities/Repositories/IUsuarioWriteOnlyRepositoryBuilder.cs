using jogador.domain.Repositories.Usuario;
using Moq;

namespace CommonTestUtilities.Repositories;

public class IUsuarioWriteOnlyRepositoryBuilder
{
    public static IUsuarioWriteOnlyRepository Build()
    {
        var mock = new Mock<IUsuarioWriteOnlyRepository>();

        return mock.Object;
    }
}
