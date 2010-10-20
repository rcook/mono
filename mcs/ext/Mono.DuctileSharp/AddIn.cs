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

    void IAddIn.ApplyTypeTransform(IEnumerable<ITypeInfo> types)
    {
      foreach (ITypeInfo type in types)
      {
        Console.WriteLine("> {0}:{1}", type.Name, type.GetType().FullName);
        foreach (IMethodInfo method in type.Methods)
        {
          Console.WriteLine(">> {0}:{1}", method.Name, method.GetType().FullName);
          foreach (IParameterInfo parameter in method.Parameters)
          {
            Console.WriteLine(">>> {0}:{1}", parameter.Name, parameter.GetType().FullName);
          }
          if (!"Main".Equals(method.Name, StringComparison.Ordinal))
          {
          }
        }
      }
/*
        foreach (Method method in @class.Methods)
        {
          // TODO: Determine a better way to determine if this is the "Main" method.
          if (!"Main".Equals(method.Name, StringComparison.Ordinal))
          {
            Console.WriteLine("  {0}: {1}", method.GetType().FullName, method.Name);
            foreach (Parameter parameter in method.ParameterInfo.FixedParameters)
            {
              SimpleName dynamicTypeExpr = new SimpleName("dynamic", parameter.TypeExpression.LocationX);
              parameter.TypeExpression = dynamicTypeExpr;
              Console.WriteLine("Hooray!");
              Console.WriteLine("    {0}: {1}:{2} [{3}]",
                parameter.GetType().FullName,
                parameter.Name,
                parameter.TypeExpression.GetSignatureForError(),
                null == parameter.TypeExpression.Type ? "(null type)" : "(non-null type)");
            }
          }
        }
*/
    }

    #endregion IAddIn Members

    public AddIn()
    {
    }
  }
}

