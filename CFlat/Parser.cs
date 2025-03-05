
namespace CFlat;

public class Parser
{
  private readonly Tokenizer _lexer;
  private List<Token> _tokens;
  private int _position;

  private Token Current => Peek();
  private Token Peek(int offset = 0) => _position + offset < _tokens.Count ? _tokens[_position + offset] : new Token(TokenType.Eof, string.Empty);

  public Parser(string source)
  {
    _lexer = new Tokenizer(source);
    _tokens = _lexer.Tokenize();
  }

  public AstNode Parse()
  {
    return ParseProgram();
    throw new Exception($"Unexpected token: {Current.Text}");
  }
  private RootNode ParseProgram()
  {
    var body = new List<AstNode>();

    return new RootNode(ParseNumberLiteral());
  }

  private 


  private AstNode ParseNumberLiteral()
  {
    var token = Match(TokenType.NumberLiteral);
    return new NumberLiteralExpression(int.Parse(token.Text));
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
