namespace CFlat.Syntax;

public record Root : AstNode
{
  public List<Statement> Body { get; set; } = [];
}
