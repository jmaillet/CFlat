using CFlat.Tree;

namespace CFlat;

public record Token(TokenType Type, string Text, int Position) : AstNode
{
  public override IEnumerable<AstNode> GetChildren() => [];
}