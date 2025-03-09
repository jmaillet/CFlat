using CFlat.Tree;

namespace CFlat;

internal class Parser
{
  private readonly Tokenizer _tokenizer;
  private List<Token> _tokens;
  private int _position;
  private readonly string _source;

  private Token Current => Peek();
  private Token Peek(int offset = 0) => _position + offset < _tokens.Count
    ? _tokens[_position + offset]
    : new Token(TokenType.Eof, string.Empty, _source.Length);

  public Parser(string source)
  {
    _tokenizer = new Tokenizer(source);
    _tokens = _tokenizer.Tokenize();
    _source = source;
  }

  public AstNode Parse()
  {
    return ParseProgram();
    throw new Exception($"Unexpected token: {Current.Text}");
  }

  private RootNode ParseProgram()
  {
    return new RootNode(ParseExpression());
  }

  private AstNode ParseExpression()
  {
    var left = ParseNumberLiteral();
    if (Current.Type == TokenType.SemiColon)
    {
      return left;
    }
    var operatorToken = ParseOperator();
    var right = ParseExpression();

    return new BinaryExpression(left, right, operatorToken);
  }

  private AstNode ParseNumberLiteral()
  {
    var token = Match(TokenType.Number);
    return new NumberLiteralExpression(int.Parse(token.Text));
  }

  private Token ParseOperator()
  {
    if (Current.Type is TokenType.Plus or TokenType.Minus or TokenType.Star or TokenType.Slash)
    {
      return NextToken();
    }
    throw new Exception($"Unexpected token: {Current.Text}");

  }

  private Token NextToken()
  {
    var token = Current;
    _position++;
    return token;
  }

  private Token Match(TokenType type)
  {
    if (Current.Type != type)
    {
      throw new Exception($"Expected token of type {type}, but got {Current.Type}");
    }
    return NextToken();
  }
}
