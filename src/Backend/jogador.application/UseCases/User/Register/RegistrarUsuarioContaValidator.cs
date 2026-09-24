using FluentValidation;
using jogador.communication.Requests;
using jogador.exception;

namespace jogador.application.UseCases.User.Register;

public class RegistrarUsuarioContaValidator : AbstractValidator<RequestRegistrarUsuarioJson>
{
    public RegistrarUsuarioContaValidator()
    {
        RuleFor(usuario => usuario.Nome).NotEmpty().WithMessage(ResourceMessagesException.VALIDATION_NOME_REQUIRED);
        RuleFor(usuario => usuario.Email).NotEmpty().WithMessage(ResourceMessagesException.VALIDATION_EMAIL_REQUIRED);
        RuleFor(usuario => usuario.Senha).NotEmpty().WithMessage(ResourceMessagesException.VALIDATION_SENHA_REQUIRED);
        When(usuario => string.IsNullOrWhiteSpace(usuario.Email) == false, () =>
        {
            RuleFor(usuario => usuario.Email).EmailAddress().WithMessage(ResourceMessagesException.VALIDATION_EMAIL_INVALID);
        });
    }
}
