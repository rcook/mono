//
// AddInManager:
//    Manages compiler add-ins based on Mono.CompilerServices.Extensibility
//    interfaces.
//
// Author: Richard Cook (rcook@rprodev.com)
//

using System;
using System.Collections.Generic;
using System.Configuration;
using Mono.CSharp;
using Mono.CompilerServices.Extensibility;

namespace Mono.CSharp
{
  internal static class AddInManager
  {
    private sealed class TypeExpressionFactory : ITypeExpressionFactory
    {
      #region ITypeExpressionFactory Members

      ITypeExpression ITypeExpressionFactory.CreateSimpleTypeExpression(string name, ILocation location)
      {
        return new SimpleName(name, (Location)location);
      }

      #endregion ITypeExpressionFactory Members

      internal TypeExpressionFactory()
      {
      }
    }

    private static IAddIn[] _addIns = _addIns = new IAddIn[0];

    internal static void LoadAddIns()
    {
      if (!IsSafeMode)
      {
        string addInTypeNamesString = ConfigurationSettings.AppSettings["add-ins"];
        if (!string.IsNullOrEmpty(addInTypeNamesString))
        {
          string[] addInTypeNames = addInTypeNamesString.Split(';');
          List<IAddIn> addIns = new List<IAddIn>();
          for (int i = 0; i < addInTypeNames.Length; ++i)
          {
            try
            {
              Type addInType = Type.GetType(addInTypeNames[i], true, false);
              object addInObj = Activator.CreateInstance(addInType, false);
              IAddIn addIn = (IAddIn)addInObj;
              addIns.Add(addIn);
            }
            catch (Exception)
            {
              Console.WriteLine("Add-in manager: add-in failed to load.");
            }
          }
          _addIns = addIns.ToArray();
        }
      }
    }

    internal static bool ParseCommandLineOption(string arg)
    {
			foreach (IAddIn addIn in _addIns)
			{
        try
        {
				  if (addIn.ParseCommandLineOption(arg))
				  {
					  return true;
				  }
        }
        catch (Exception)
        {
          Console.WriteLine("Add-in manager: add-in failed to parse command line.");
        }
			}
      return false;
    }

    internal static void ApplyTypeTransforms(IList<TypeContainer> types)
    {
      TypeExpressionFactory typeExprFactory = new TypeExpressionFactory();
      foreach (IAddIn addIn in _addIns)
      {
        try
        {
          addIn.ApplyTypeTransform(typeExprFactory, Adapt(types));
        }
        catch (Exception)
        {
          Console.WriteLine("Add-in manager: add-in failed to apply type transform.");
        }
      }
    }

    private static bool IsSafeMode
    {
      get
      {
        string value = Environment.GetEnvironmentVariable("MCS_SAFE_MODE");
        return "true".Equals(value, StringComparison.InvariantCultureIgnoreCase);
      }
    }

    private static IEnumerable<ITypeInfo> Adapt(IList<TypeContainer> types)
    {
      foreach (ITypeInfo type in types)
      {
        yield return type;
      }
    }
  }
}

