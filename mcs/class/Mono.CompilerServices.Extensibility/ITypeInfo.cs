namespace Mono.CompilerServices.Extensibility
{
    using System.Collections.Generic;

    public interface ITypeInfo
    {
        IEnumerable<IMethodInfo> Methods {get;}
    }
}

