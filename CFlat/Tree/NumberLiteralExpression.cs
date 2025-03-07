namespace CFlat.Tree;

public record NumberLiteralExpression(int Value) : AstNode
{
  public override IEnumerable<AstNode> GetChildren() => [];

}
