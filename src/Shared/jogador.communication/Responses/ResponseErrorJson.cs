using System;

namespace jogador.communication.Responses;

public class ResponseErrorJson
{
    public List<string> Errors { get; private set; }

    public ResponseErrorJson(List<string> errorMessages) => Errors = errorMessages;

    public ResponseErrorJson(string errorMessage) => Errors = [errorMessage];
}
