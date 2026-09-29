using Bogus;
using jogador.communication.Requests;

namespace CommonTestUtilities.Requests;

public class RequestRegistrarUsuarioJsonBuilder
{
    public static RequestRegistrarUsuarioJson Build()
    {
        return new Faker<RequestRegistrarUsuarioJson>()
            .RuleFor(request => request.Nome, f => f.Person.FirstName)
            .RuleFor(request => request.Email, (f, user) => f.Internet.Email(user.Nome))
            .RuleFor(request => request.Senha, f => f.Internet.Password());
    }
}
