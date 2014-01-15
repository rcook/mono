//
// ITypeInfo:
//    Enables basic manipulation of types.
//
// Author: Richard Cook (rcook@rprodev.com)
//

using System.Collections.Generic;

namespace Mono.CompilerServices.Extensibility
{
  public interface ITypeInfo
  {
    string Name {get;}
    IEnumerable<IMethodInfo> Methods {get;}
  }
}

