//
// ITypeExpressionFactory:
//    Allows add-ins to create type expressions.
//
// Author: Richard Cook (rcook@rprodev.com)
//

namespace Mono.CompilerServices.Extensibility
{
  public interface ITypeExpressionFactory
  {
    ITypeExpression CreateSimpleTypeExpression(string name, ILocation location);
  }
}

