using CFlat.Syntax;

namespace CFlat.Binding;

internal class Binder
{
}

public abstract record BoundExpression();

public record class BoundIntegerLiteralExpression(Expression Expression, int Value) : BoundExpression;
public record BoundUnaryExpression(BoundUnaryOperator Operator, BoundExpression Operand) : BoundExpression;
public record BoundBinaryOperator;

public record BoundBinaryExpression(BoundExpression Left, BoundBinaryOperator Operator, BoundExpression Right) : BoundExpression;
