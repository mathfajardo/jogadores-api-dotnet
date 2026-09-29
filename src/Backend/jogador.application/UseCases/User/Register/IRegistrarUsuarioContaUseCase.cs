using System;
using jogador.communication.Requests;
using jogador.communication.Responses;

namespace jogador.application.UseCases.User.Register;

public interface IRegistrarUsuarioContaUseCase
{
    Task<ResponseRegisteredUsuarioJson> Execute(RequestRegistrarUsuarioJson request);
}
