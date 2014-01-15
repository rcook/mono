//
// IMethodInfo:
//    Enables basic manipulation of methods.
//
// Author: Richard Cook (rcook@rprodev.com)
//

using System.Collections.Generic;

namespace Mono.CompilerServices.Extensibility
{
  public interface IMethodInfo
  {
    string Name {get;}
    IEnumerable<IParameterInfo> Parameters {get;}
  }
}

