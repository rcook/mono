namespace Mono.CompilerServices.Extensibility
{
    public interface IParameterInfo
    {
        string Name {get;}
        ITypeExpression TypeExpression {get; set;}
    }
}

