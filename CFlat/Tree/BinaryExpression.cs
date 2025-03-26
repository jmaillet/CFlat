namespace CFlat.Tree;

public record BinaryExpression(Expression Left, Token OperatorToken, Expression Right) : Expression;

