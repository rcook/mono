namespace Mono.CompilerServices.Extensibility
{
    public interface IAddIn
    {
        bool ParseCommandLineOption(string arg);
    }
}

