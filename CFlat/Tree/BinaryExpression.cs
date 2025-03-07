namespace CFlat.Tree;

public record BinaryExpression(AstNode Left, AstNode Right, Token OperatorToken) : AstNode
{
  public override IEnumerable<AstNode> GetChildren() => [Left, OperatorToken, Right];

}

