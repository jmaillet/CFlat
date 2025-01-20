using CFlat;

var text = """
const x = 1 == 0 ? foo : " + 7.5";
""";

var lexer = new Lexer(text);

var tokens = lexer.Tokenize();
foreach (var token in tokens.Where(t => t.Type != TokenType.Whitespace))
{
  Console.WriteLine($"{token.Type}: {token.Value}");
}