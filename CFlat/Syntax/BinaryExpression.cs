namespace CFlat.Syntax;

public record BinaryExpression(Expression Left, Token OperatorToken, Expression Right) : Expression;

