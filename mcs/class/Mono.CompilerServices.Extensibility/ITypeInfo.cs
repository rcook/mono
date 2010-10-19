namespace Mono.CompilerServices.Extensibility
{
    using System.Collections.Generic;

    public interface ITypeInfo
    {
        string Name {get;}
        IEnumerable<IMethodInfo> Methods {get;}
    }
}

