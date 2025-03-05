namespace CFlat;

public record BinaryExpression(AstNode Left, AstNode Right, Token Operator) : AstNode(NodeType.BinaryExpression);

