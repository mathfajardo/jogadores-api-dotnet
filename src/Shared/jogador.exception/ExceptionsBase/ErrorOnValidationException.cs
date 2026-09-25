using System;

namespace jogador.exception.ExceptionsBase;

public class ErrorOnValidationException : jogadorException
{
    private readonly List<string> _errors;
    public ErrorOnValidationException(List<string> errorMessages)
    {
        _errors = errorMessages;
    }

    public List<string> GetErrorMessages() => _errors;
}
