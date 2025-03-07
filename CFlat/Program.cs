using CFlat;
using CFlat.Tree;
var text = """
45+3+6;
""";

var parser = new Parser(text);
var ast = parser.Parse();
PrintAst(ast);

static void PrintAst(AstNode node, int indent = 0)
{
  var text = node switch
  {
    Token token => $"{token.Type} {token.Text}",
    NumberLiteralExpression number => number.Value.ToString(),
    AstNode => node.GetType().Name
  };
  Console.WriteLine($"{new string(' ', indent)}{text}");
  foreach (var child in node.GetChildren())
  {
    PrintAst(child, indent + 2);
  }
}