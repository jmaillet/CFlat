namespace CFlat.Tree;

internal record RootNode(AstNode Body) : AstNode
{
  public override IEnumerable<AstNode> GetChildren() => [Body];
}