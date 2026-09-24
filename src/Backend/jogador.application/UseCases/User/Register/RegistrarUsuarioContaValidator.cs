using FluentValidation;
using jogador.communication.Requests;

namespace jogador.application.UseCases.User.Register;

public class RegistrarUsuarioContaValidator : AbstractValidator<RequestRegistrarUsuarioJson>
{
    public RegistrarUsuarioContaValidator()
    {
        RuleFor(usuario => usuario.Nome).NotEmpty().WithMessage("O nome não pode ser vazio");
        RuleFor(usuario => usuario.Email).NotEmpty().WithMessage("O email não pode ser vazio");
        RuleFor(usuario => usuario.Senha).NotEmpty().WithMessage("A senha não pode ser vazia");
        When(usuario => string.IsNullOrWhiteSpace(usuario.Email) == false, () =>
        {
            RuleFor(usuario => usuario.Email).EmailAddress().WithMessage("O email deve ser valido");
        });
    }
}
