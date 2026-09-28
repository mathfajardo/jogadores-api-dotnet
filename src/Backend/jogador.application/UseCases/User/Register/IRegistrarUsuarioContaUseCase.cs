using System;
using jogador.communication.Requests;

namespace jogador.application.UseCases.User.Register;

public interface IRegistrarUsuarioContaUseCase
{
    Task Execute(RequestRegistrarUsuarioJson request);
}
