namespace Mono.DuctileSharp
{
  using System;
  using System.Collections.Generic;
  using Mono.CompilerServices.Extensibility;

  public sealed class AddIn : IAddIn
  {
    private bool _detype = false;

    #region IAddIn Members

    string IAddIn.Name {get {return "DuctileSharp";}}

    string IAddIn.Description {get {return "Detype your code!";}}

    bool IAddIn.ParseCommandLineOption(string arg)
    {
      if ("/detype".Equals(arg, StringComparison.InvariantCultureIgnoreCase))
      {
        _detype = true;
        return true;
      }
      return false;
    }

    void IAddIn.ApplyTypeTransform(ITypeExpressionFactory typeExprFactory, IEnumerable<ITypeInfo> types)
    {
      if (_detype)
      {
        foreach (ITypeInfo type in types)
        {
          Console.WriteLine("> {0} : {1}", type.Name, type.GetType().FullName);
          foreach (IMethodInfo method in type.Methods)
          {
            Console.WriteLine(">> {0} : {1}", method.Name, method.GetType().FullName);
            foreach (IParameterInfo parameter in method.Parameters)
            {
              Console.WriteLine(">>> {0} : {1}", parameter.Name, parameter.GetType().FullName);
            }
            if (!"Main".Equals(method.Name, StringComparison.Ordinal))
            {
              foreach (IParameterInfo parameter in method.Parameters)
              {
                Console.WriteLine("Detyped: {0} : {1} -> dynamic", parameter.Name, parameter.TypeExpression);
                ITypeExpression typeExpr = typeExprFactory.CreateSimpleTypeExpression("dynamic", parameter.TypeExpression.Location);
                parameter.TypeExpression = typeExpr;
              }
            }
          }
        }
      }
    }

    #endregion IAddIn Members

    public AddIn()
    {
    }
  }
}

