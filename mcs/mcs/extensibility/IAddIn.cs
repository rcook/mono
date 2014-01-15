//
// IAddIn:
//    Provides main entry points for a compiler add-in.
//
// Author: Richard Cook (rcook@rprodev.com)
//

using System.Collections.Generic;

namespace Mono.CompilerServices.Extensibility
{
  public interface IAddIn
  {
    string Name {get;}
    string Description {get;}
    bool ParseCommandLineOption(string arg);
    void ApplyTypeTransform(ITypeExpressionFactory typeExprFactory, IEnumerable<ITypeInfo> types);
  }
}

