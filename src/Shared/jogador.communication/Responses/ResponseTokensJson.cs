using System;

namespace jogador.communication.Responses;

public class ResponseTokensJson
{
    public string AccessToken { get; set; } = string.Empty;

    public string RefreshToken { get; set; } = string.Empty;
}
