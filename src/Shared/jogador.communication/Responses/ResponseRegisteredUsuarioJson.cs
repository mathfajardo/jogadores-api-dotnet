using System;

namespace jogador.communication.Responses;

public class ResponseRegisteredUsuarioJson
{
    public string Nome { get; set; } = string.Empty;

    public ResponseTokensJson Tokens { get; set; } = default!;
}
