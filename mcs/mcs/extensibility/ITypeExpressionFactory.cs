namespace Mono.CompilerServices.Extensibility
{
    public interface ITypeExpressionFactory
    {
        ITypeExpression CreateSimpleTypeExpression(string name, ILocation location);
    }
}

