namespace CFlat;
public class Lexer
{
  private readonly string _text;
  private int _position;

  public Lexer(string text)
  {
    _text = text ?? throw new ArgumentNullException(nameof(text));
  }

  private char Peek(int offset = 0) => _position + offset < _text.Length ? _text[_position + offset] : '\0';

  private char Current => _position < _text.Length ? _text[_position] : '\0';

  public IEnumerable<Token> Tokenize()
  {
    var tokens = new List<Token>();
    while (Current != '\0')
    {
      if (char.IsDigit(Current))
      {
        tokens.Add(ReadNumber());
      }
      else if (char.IsLetter(Current))
      {
        tokens.Add(ReadIdentifier());
      }
      else if (char.IsWhiteSpace(Current))
      {
        tokens.Add(ReadWhiteSpace());
      }
      else if (Current == '"')
      {
        tokens.Add(ReadString());
      }
      else
      {
        tokens.Add(ReadToken());
      }
    }
    return tokens;
  }

  private Token ReadNumber()
  {
    var start = _position;
    while (_position < _text.Length && (char.IsDigit(_text[_position]) || _text[_position] == '.'))
    {
      _position++;
    }
    return new Token(TokenType.NumberLiteral, _text[start.._position]);
  }

  private Token ReadIdentifier()
  {
    var start = _position;
    while (_position < _text.Length && (char.IsLetterOrDigit(_text[_position]) || _text[_position] == '_'))
    {
      _position++;
    }
    var type = Keywords.IsKeyword(_text[start.._position]) ? TokenType.Keyword : TokenType.Identifier;
    return new Token(type, _text[start.._position]);
  }

  private Token ReadString()
  {
    var start = _position;
    do
    {
      _position++;

    } while (_position < _text.Length && _text[_position] != '"');
    _position++;
    return new Token(TokenType.StringLiteral, _text[start.._position]);
  }

  private Token ReadWhiteSpace()
  {
    var start = _position;
    while (_position < _text.Length && char.IsWhiteSpace(_text[_position]))
    {
      _position++;
    }
    return new Token(TokenType.Whitespace, _text[start.._position]);
  }

  private Token ReadToken()
  {
    var start = _position;
    var c = _text[_position];
    switch (c)
    {
      case '+':
        _position++;
        return new Token(TokenType.Plus, _text[start.._position]);
      case '-':
        _position++;
        return new Token(TokenType.Minus, _text[start.._position]);
      case '*':
        _position++;
        return new Token(TokenType.Star, _text[start.._position]);
      case '/':
        _position++;
        return new Token(TokenType.Slash, _text[start.._position]);
      case '%':
        _position++;
        return new Token(TokenType.Percent, _text[start.._position]);
      case '?':
        _position++;
        return new Token(TokenType.QuestionMark, _text[start.._position]);
      case ':':
        _position++;
        return new Token(TokenType.Colon, _text[start.._position]);
      case ';':
        _position++;
        return new Token(TokenType.SemiColon, _text[start.._position]);
      case '!':
        _position++;
        if (Current == '=')
        {
          _position++;
          return new Token(TokenType.NotEqual, _text[start.._position]);
        }

        return new Token(TokenType.Bang, _text[start.._position]);
      case '<':
        _position++;
        if (Current == '=')
        {
          _position++;
          return new Token(TokenType.LessThanOrEqual, _text[start.._position]);
        }

        return new Token(TokenType.LessThan, _text[start.._position]);
      case '>':
        _position++;
        if (Current == '=')
        {
          _position++;
          return new Token(TokenType.GreaterThanOrEqual, _text[start.._position]);
        }

        return new Token(TokenType.GreaterThan, _text[start.._position]);
      case '=':
        _position++;
        if (Current == '=')
        {
          _position++;
          return new Token(TokenType.DoubleEqual, _text[start.._position]);
        }

        return new Token(TokenType.Equal, _text[start.._position]);
      case '&':
        _position++;
        if (Current == '&')
        {
          _position++;
          return new Token(TokenType.DoubleAmpersand, _text[start.._position]);
        }

        return new Token(TokenType.Ampersand, _text[start.._position]);
      case '|':
        _position++;
        if (Current == '|')
        {
          _position++;
          return new Token(TokenType.DoublePipe, _text[start.._position]);
        }

        return new Token(TokenType.Pipe, _text[start.._position]);
      case '(':
        _position++;
        return new Token(TokenType.OpenParen, _text[start.._position]);
      case ')':
        _position++;
        return new Token(TokenType.CloseParen, _text[start.._position]);
      case '{':
        _position++;
        return new Token(TokenType.OpenBrace, _text[start.._position]);
      case '}':
        _position++;
        return new Token(TokenType.CloseBrace, _text[start.._position]);
      case '[':
        _position++;
        return new Token(TokenType.OpenBracket, _text[start.._position]);
      case ']':
        _position++;
        return new Token(TokenType.CloseBracket, _text[start.._position]);
      default:
        _position++;
        return new Token(TokenType.Unknown, _text[start.._position]);

    }
  }
}
