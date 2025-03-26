namespace CFlat;
public class Tokenizer(string text)
{
  private readonly string _text = text ?? throw new ArgumentNullException(nameof(text));

  private int _position;

  private char Peek(int offset = 0) => _position + offset < _text.Length ? _text[_position + offset] : '\0';

  private char Current => Peek();

  public List<Token> Tokenize()
  {
    var tokens = new List<Token>();
    while (Current != '\0')
    {
      var token = Current switch
      {
        var c when char.IsDigit(c) => ReadNumber(),
        var c when char.IsLetter(c) => ReadIdentifierOrKeyword(),
        var c when char.IsWhiteSpace(c) => ReadWhiteSpace(),
        '"' => ReadString(),
        '+' => new Token(TokenType.Plus, "+", _position++),
        '-' => new Token(TokenType.Minus, "-", _position++),
        '*' => new Token(TokenType.Star, "*", _position++),
        '/' => new Token(TokenType.Slash, "/", _position++),
        '(' => new Token(TokenType.OpenParen, "(", _position++),
        ')' => new Token(TokenType.CloseParen, ")", _position++),
        ';' => new Token(TokenType.SemiColon, ";", _position++),
        '=' => new Token(TokenType.Equal, "=", _position++),
        _ => new Token(TokenType.BadToken, _text[_position++].ToString(), _position)

      };
      tokens.Add(token);
    }
    tokens.Add(new Token(TokenType.Eof, string.Empty, _position));
    return tokens;
  }

  private Token ReadNumber()
  {
    var start = _position;
    while (_position < _text.Length && (char.IsDigit(_text[_position]) || _text[_position] == '.'))
    {
      _position++;
    }
    var number = _text[start.._position];

    return new Token(TokenType.Number, number, _position);
  }

  private Token ReadIdentifierOrKeyword()
  {
    var start = _position;
    while (_position < _text.Length && (char.IsLetterOrDigit(_text[_position]) || _text[_position] == '_'))
    {
      _position++;
    }

    var kind = _text[start.._position] switch
    {
      "let" => TokenType.Let,
      "fn" => TokenType.Fn,
      "if" => TokenType.If,
      "else" => TokenType.Else,
      "return" => TokenType.Return,
      "true" => TokenType.True,
      "false" => TokenType.False,
      _ => TokenType.Identifier
    };

    return new Token(kind, _text[start.._position], _position);
  }

  private Token ReadString()
  {
    var start = _position;
    do
    {
      _position++;

    } while (_position < _text.Length && _text[_position] != '"');
    _position++;
    return new Token(TokenType.String, _text[start.._position], _position);
  }

  private Token ReadWhiteSpace()
  {
    var start = _position;
    while (_position < _text.Length && char.IsWhiteSpace(_text[_position]))
    {
      _position++;
    }
    return new Token(TokenType.Whitespace, _text[start.._position], _position);
  }

  //private Token ReadToken()
  //{
  //  var start = _position;
  //  var c = _text[_position];
  //  switch (c)
  //  {
  //    case '+':
  //      _position++;
  //      return new Token(TokenType.Plus, _text[start.._position]);
  //    case '-':
  //      _position++;
  //      return new Token(TokenType.Minus, _text[start.._position]);
  //    case '*':
  //      _position++;
  //      return new Token(TokenType.Star, _text[start.._position]);
  //    case '/':
  //      _position++;
  //      return new Token(TokenType.Slash, _text[start.._position]);
  //    case '%':
  //      _position++;
  //      return new Token(TokenType.Percent, _text[start.._position]);
  //    case '?':
  //      _position++;
  //      return new Token(TokenType.QuestionMark, _text[start.._position]);
  //    case ':':
  //      _position++;
  //      return new Token(TokenType.Colon, _text[start.._position]);
  //    case ';':
  //      _position++;
  //      return new Token(TokenType.SemiColon, _text[start.._position]);
  //    case '!':
  //      _position++;
  //      if (Current == '=')
  //      {
  //        _position++;
  //        return new Token(TokenType.NotEqual, _text[start.._position]);
  //      }

  //      return new Token(TokenType.Bang, _text[start.._position]);
  //    case '<':
  //      _position++;
  //      if (Current == '=')
  //      {
  //        _position++;
  //        return new Token(TokenType.LessThanOrEqual, _text[start.._position]);
  //      }

  //      return new Token(TokenType.LessThan, _text[start.._position]);
  //    case '>':
  //      _position++;
  //      if (Current == '=')
  //      {
  //        _position++;
  //        return new Token(TokenType.GreaterThanOrEqual, _text[start.._position]);
  //      }

  //      return new Token(TokenType.GreaterThan, _text[start.._position]);
  //    case '=':
  //      _position++;
  //      if (Current == '=')
  //      {
  //        _position++;
  //        return new Token(TokenType.DoubleEqual, _text[start.._position]);
  //      }

  //      return new Token(TokenType.Equal, _text[start.._position]);
  //    case '&':
  //      _position++;
  //      if (Current == '&')
  //      {
  //        _position++;
  //        return new Token(TokenType.DoubleAmpersand, _text[start.._position]);
  //      }

  //      return new Token(TokenType.Ampersand, _text[start.._position]);
  //    case '|':
  //      _position++;
  //      if (Current == '|')
  //      {
  //        _position++;
  //        return new Token(TokenType.DoublePipe, _text[start.._position]);
  //      }

  //      return new Token(TokenType.Pipe, _text[start.._position]);
  //    case '(':
  //      _position++;
  //      return new Token(TokenType.OpenParen, _text[start.._position]);
  //    case ')':
  //      _position++;
  //      return new Token(TokenType.CloseParen, _text[start.._position]);
  //    case '{':
  //      _position++;
  //      return new Token(TokenType.OpenBrace, _text[start.._position]);
  //    case '}':
  //      _position++;
  //      return new Token(TokenType.CloseBrace, _text[start.._position]);
  //    case '[':
  //      _position++;
  //      return new Token(TokenType.OpenBracket, _text[start.._position]);
  //    case ']':
  //      _position++;
  //      return new Token(TokenType.CloseBracket, _text[start.._position]);
  //    default:
  //      _position++;
  //      return new Token(TokenType.Invalid, _text[start.._position]);

  //  }
}

