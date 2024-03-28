namespace BankApplication.Exceptions;

[Serializable]
internal class ValorInvalidoException : Exception
{
    public ValorInvalidoException()
    {
    }

    public ValorInvalidoException(string? message) : base(message)
    {
    }
}