[Serializable]
internal class ContaNaoEncerradaException : Exception
{
    public ContaNaoEncerradaException()
    {
    }

    public ContaNaoEncerradaException(string? message) : base(message)
    {
    }
}