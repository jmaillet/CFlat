namespace CFlat.Tree;

public record Root : AstNode
{
  public List<Statement> Body { get; set; } = [];
}
