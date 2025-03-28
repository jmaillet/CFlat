namespace CFlat.Syntax;

public record UnaryExpression(Token OperatorToken, AstNode Operand) : Expression;

