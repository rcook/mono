using System;
using System.Reflection;
using System.Reflection.Emit;
using Mono.CSharp;

namespace Instrumentation
{
  internal static class Helpers
  {
    internal static void EmitPrologue(ILGenerator ilGenerator, string methodName)
    {
      EmitConsoleWriteLine(ilGenerator, string.Format("PROLOGUE: {0}", methodName));
    }

    internal static void EmitEpilogue(EmitContext emitContext)
    {
      if (emitContext.MemberContext.CurrentMemberDefinition is Method)
      {
        ILGenerator ilGenerator = emitContext.ig;
        string methodName = emitContext.MemberContext.CurrentMemberDefinition.Name;
        EmitConsoleWriteLine(ilGenerator, string.Format("EPILOGUE: {0}", methodName));
      }
    }

    private static void EmitConsoleWriteLine(ILGenerator ilGenerator, string message)
    {
      ilGenerator.Emit(OpCodes.Ldstr, message);
      MethodInfo writeLineMethod = typeof(Console).GetMethod(
        "WriteLine",
        BindingFlags.Public | BindingFlags.Static,
        null,
        new Type[] {typeof(string)},
        null
      );
      ilGenerator.Emit(OpCodes.Call, writeLineMethod);
    }
  }
}

