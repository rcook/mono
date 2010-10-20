namespace Mono.DuctileSharp
{
  using Mono.CompilerServices.Extensibility;

  public sealed class AddIn : IAddIn
  {
    #region IAddIn Members

    string IAddIn.Name {get {return "DuctileSharp";}}

    string IAddIn.Description {get {return "Detype your code!";}}

    bool IAddIn.ParseCommandLineOption(string arg)
    {
      return false;
    }

    #endregion IAddIn Members

    public AddIn()
    {
    }
  }
}

