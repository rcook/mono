namespace Mono.CompilerServices.Extensibility
{
    public interface IAddIn
    {
        string Name {get;}
        string Description {get;}
        bool ParseCommandLineOption(string arg);
    }
}

