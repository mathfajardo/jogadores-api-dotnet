using CommonTestUtilities.Requests;
using jogador.application.UseCases.User.Register;
using Shouldly;

namespace Validators.Tests.User.Register;

public class RegistrarUsuarioContaValidatorTests
{
    [Fact]
    public void Success()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();

        var validator = new RegistrarUsuarioContaValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeTrue();
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenNomeIsEmpty()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();
        request.Nome = string.Empty;

        var validator = new RegistrarUsuarioContaValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsEmpty()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();
        request.Email = string.Empty;

        var validator = new RegistrarUsuarioContaValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenSenhaIsEmpty()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();
        request.Senha = string.Empty;

        var validator = new RegistrarUsuarioContaValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
        });
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenEmailIsInvalid()
    {
        var request = RequestRegistrarUsuarioJsonBuilder.Build();
        request.Email = "email.com";

        var validator = new RegistrarUsuarioContaValidator();

        var result = validator.Validate(request);

        result.IsValid.ShouldBeFalse();
        result.Errors.ShouldSatisfyAllConditions(errors =>
        {
            errors.Count.ShouldBe(1);
        });
    }
}
