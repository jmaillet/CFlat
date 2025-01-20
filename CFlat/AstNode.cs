namespace CFlat;
internal abstract class AstNode(AstNode parent, string value)
{
  public AstNode Parent { get; } = parent;
  public List<AstNode> Children { get; } = [];
  public string Value { get; } = value;


  public void Print(int indent = 0)
  {
    Console.WriteLine($"{new string(' ', indent)}{Value}");
    foreach (var child in Children)
    {
      child.Print(indent + 2);
    }
  }
}
