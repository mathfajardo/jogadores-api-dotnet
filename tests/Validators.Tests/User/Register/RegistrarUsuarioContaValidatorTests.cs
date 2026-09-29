using CommonTestUtilities.Requests;
using jogador.application.UseCases.User.Register;

namespace Validators.Tests.User.Register;

public class RegistrarUsuarioContaValidatorTests
{
    [Fact]
    public void Success()
    {
        // arrange
        var request = RequestRegistrarUsuarioJsonBuilder.Build();

        var validator = new RegistrarUsuarioContaValidator();

        // act
        var result = validator.Validate(request);

        // assert
        Assert.True(result.IsValid);


    }
}
