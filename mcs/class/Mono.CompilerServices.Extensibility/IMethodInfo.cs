namespace Mono.CompilerServices.Extensibility
{
    using System.Collections.Generic;

    public interface IMethodInfo
    {
        string Name {get;}
        IEnumerable<IParameterInfo> Parameters {get;}
    }
}

