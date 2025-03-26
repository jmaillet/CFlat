namespace CFlat.Tree;

public record UnaryExpression(Token OperatorToken, AstNode Operand) : Expression;

