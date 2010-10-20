namespace Mono.CompilerServices.Extensibility
{
    using System.Collections.Generic;

    public interface IAddIn
    {
        string Name {get;}
        string Description {get;}
        bool ParseCommandLineOption(string arg);
        void ApplyTypeTransform(IEnumerable<ITypeInfo> types);
    }
}

