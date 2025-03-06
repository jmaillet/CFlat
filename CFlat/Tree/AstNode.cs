namespace CFlat;
public abstract record AstNode(NodeType SyntaxType)
{

}

public abstract record StatementNode(NodeType SyntaxType) : AstNode(SyntaxType)
{

}
 public record ExpressionStatementNode(NodeType SyntaxType, AstNode Expression) : StatementNode(SyntaxType);