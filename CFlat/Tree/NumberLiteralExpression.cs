namespace CFlat;

public record NumberLiteralExpression(int Value) : AstNode(NodeType.NumberLiteralExpression);
