[Serializable]
internal class ContaNaoEncontradaException : Exception
{
    public ContaNaoEncontradaException()
    {
    }

    public ContaNaoEncontradaException(string? message) : base(message)
    {
    }
}