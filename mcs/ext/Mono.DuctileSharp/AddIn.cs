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
      if (arg.Equals("/detype", StringComparison.InvariantCultureIgnoreCase))
      {
        _detype = true;
        return true;
      }
      return false;
    }

    void IAddIn.ApplyTypeTransform(IEnumerable<ITypeInfo> types)
    {
    }

    #endregion IAddIn Members

    public AddIn()
    {
    }
  }
}

