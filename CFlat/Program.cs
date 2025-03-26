using CFlat;
using CFlat.Tree;

var text = """
45 + 3 + 6;
""";

var parser = new Parser(text);
var ast = parser.Parse();
PrintAst(ast);

void PrintAst(Root ast)
{
  foreach (var node in ast.Body)
  {
    switch (node)
    {
      case AssignmentStatement assignment:
        Console.WriteLine($"Assignment: {assignment.Identifier.Text} = {assignment.Expression}");
        break;
      case ExpressionStatement expression:
        Console.WriteLine($"Expression: {expression.Expression}");
        break;
    }
  }
}