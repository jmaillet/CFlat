namespace CFlat.Tree;
public abstract record AstNode()
{
  public abstract IEnumerable<AstNode> GetChildren();
}

