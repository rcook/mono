//
// IParameterInfo:
//    Enables basic manipulation of parameters.
//
// Author: Richard Cook (rcook@rprodev.com)
//

namespace Mono.CompilerServices.Extensibility
{
  public interface IParameterInfo
  {
    string Name {get;}
    ITypeExpression TypeExpression {get; set;}
  }
}

