using CFlat.Syntax;

namespace CFlat;

internal class Parser(string source)
{
  private readonly Tokenizer _tokenizer = new(source);
  private List<Token> _tokens = [];
  private int _position;
  private readonly string _source = source;

  private Token Current => Peek();
  private Token Peek(int offset = 0) => _position + offset < _tokens.Count
    ? _tokens[_position + offset]
    : new Token(TokenType.Eof, string.Empty, _source.Length);

  public Root Parse()
  {

    _tokens = _tokenizer.Tokenize().Where(t => t.Type != TokenType.Whitespace).ToList();
    var root = new Root();
    while (Current.Type != TokenType.Eof)
    {
      var statement = ParseStatement();
      if (statement != null)
      {
        root.Body.Add(statement);
      }
    }
    return root;
  }

  private Statement ParseStatement()
  {
    return Current.Type switch
    {
      TokenType.Let => ParseAssignment(),
      _ => ParseExpressionStatement()

    };
  }

  private AssignmentStatement ParseAssignment()
  {
    _ = Match(TokenType.Let);
    var identifier = Match(TokenType.Identifier);
    _ = Match(TokenType.Equal);
    var expression = ParseExpression();
    _ = Match(TokenType.SemiColon);
    return new AssignmentStatement(identifier, expression);
  }

  private ExpressionStatement ParseExpressionStatement()
  {
    var expression = ParseExpression();
    _ = Match(TokenType.SemiColon);
    return new ExpressionStatement(expression);
  }

  private Expression ParsePrimaryExpression()
  {
    return Current.Type switch
    {
      TokenType.Number => ParseNumberLiteral(),
      TokenType.String => ParseStringLiteral(),
      TokenType.OpenParen => ParseParenthesizedExpression(),
      TokenType.Minus => ParseUnaryExpression(),
      TokenType.Identifier => ParseIdentifier(),
      _ => throw new Exception($"Unexpected token {Current.Type}")
    };
  }

  private IdentifierExpression ParseIdentifier() => new(Match(TokenType.Identifier));

  private UnaryExpression ParseUnaryExpression()
  {
    var operatorToken = Match(TokenType.Minus);
    var operand = ParsePrimaryExpression();
    return new UnaryExpression(operatorToken, operand);
  }

  private Expression ParseParenthesizedExpression()
  {
    _ = Match(TokenType.OpenParen);
    var expression = ParseExpression();
    _ = Match(TokenType.CloseParen);
    return expression;
  }

  private StringLiteralExpression ParseStringLiteral()
  {
    var token = Match(TokenType.String);
    return new StringLiteralExpression(token, token.Text);
  }

  private Expression ParseExpression() => ParseAdditiveExpression();

  private Expression ParseAdditiveExpression()
  {
    var left = ParseMultiplicativeExpression();
    while (Current.Type is TokenType.Plus or TokenType.Minus)
    {
      var op = Match(TokenType.Plus, TokenType.Minus);
      var right = ParseMultiplicativeExpression();
      left = new BinaryExpression(left, op, right);
    }

    return left;
  }

  private Expression ParseMultiplicativeExpression()
  {
    var left = ParsePrimaryExpression();

    while (Current.Type is TokenType.Star or TokenType.Slash)
    {
      var token = Match(TokenType.Slash);
      var right = ParsePrimaryExpression();
      left = new BinaryExpression(left, token, right);
    }

    return left;

  }

  private Expression ParseNumberLiteral()
  {
    var token = Match(TokenType.Number);
    return new IntegerLiteralExpression(token, int.Parse(token.Text));
  }

  private Token Eat()
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

    return Eat();
  }

  private Token Match(params TokenType[] types)
  {
    if (!types.Contains(Current.Type))
    {
      throw new Exception($"Expected one of {string.Join(", ", types)}, but got {Current.Type}");
    }

    return Eat();
  }
}
