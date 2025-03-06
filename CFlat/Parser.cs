
namespace CFlat;

public class Parser
{
  private readonly Tokenizer _tokenizer;
  private List<Token> _tokens;
  private int _position;

  private Token Current => Peek();
  private Token Peek(int offset = 0) => _position + offset < _tokens.Count ? _tokens[_position + offset] : new Token(TokenType.Eof, string.Empty);

  public Parser(string source)
  {
    _tokenizer = new Tokenizer(source);
    _tokens = _tokenizer.Tokenize();
  }

  public AstNode Parse()
  {
    return ParseProgram();
    throw new Exception($"Unexpected token: {Current.Text}");
  }

  /// <summary>
  /// Program
  //    : StatementList -> Statement*
  ///   ;
  ///  
  /// </summary>
  /// <returns></returns>
  private RootNode ParseProgram()
  {
    return new RootNode(ParseStatementList());
  }

  private List<AstNode> ParseStatementList()
  {
    
    var statements = new List<AstNode>();
    while (Current.Type != TokenType.Eof)
    {
      statements.Add(ParseStatement());
    }
    return statements;
  }

    private AstNode ParseStatement()
    {
        return ParseExpressionStatement();

    }

    private AstNode ParseExpressionStatement()
    {
        var expression = ParseNumberLiteral();
        _ = Match(TokenType.SemiColon);
        return new ExpressionStatementNode(NodeType.ExpressionStatement, expression);
    }

    private AstNode ParseNumberLiteral()
  {
    var token = Match(TokenType.Number);
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
