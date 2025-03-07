namespace CFlat;
public class Tokenizer(string text)
{
  private readonly string _text = text ?? throw new ArgumentNullException(nameof(text));

  private readonly List<Rule> _rules = [
    new Rule(new(@"\d+(\.\d+)?"), TokenType.Number),
    new Rule(new(@"\s+"), TokenType.Whitespace),
   // new Rule(new Regex(@"""[^""]*"""), TokenType.String),
    new Rule(new(@"\+"), TokenType.Plus),
    new Rule(new(@"-"), TokenType.Minus),
    new Rule(new(@"\*"), TokenType.Star),
    new Rule(new(@"/"), TokenType.Slash),
    new Rule(new(@";"), TokenType.SemiColon),
  ];

  private int _position;

  private char Peek(int offset = 0) => _position + offset < _text.Length ? _text[_position + offset] : '\0';

  private char Current => Peek();

  public List<Token> Tokenize()
  {
    var tokens = new List<Token>();
    while (Current != '\0')
    {
      var found = false;
      foreach (var rule in _rules)
      {
        var match = rule.Pattern.Match(_text, _position);
        if (match.Success && match.Index == _position)
        {
          found = true;
          tokens.Add(new Token(rule.Type, match.Value, _position));
          _position += match.Length;
          break;
        }
      }
      if (!found)
      {
        throw new Exception($"Unexpected character: `{Current}` at position {_position}");
      }
    }

    return tokens;
  }

  // private Token ReadNumber()
  // {
  //   var start = _position;
  //   while (_position < _text.Length && (char.IsDigit(_text[_position]) || _text[_position] == '.'))
  //   {
  //     _position++;
  //   }
  //   var number = _text[start.._position];


  //   return new Token(TokenType.NumberLiteral, number);
  // }

  // private Token ReadIdentifier()
  // {
  //   var start = _position;
  //   while (_position < _text.Length && (char.IsLetterOrDigit(_text[_position]) || _text[_position] == '_'))
  //   {
  //     _position++;
  //   }
  //   var type = Keywords.IsKeyword(_text[start.._position]) ? TokenType.Keyword : TokenType.Identifier;
  //   return new Token(type, _text[start.._position]);
  // }

  // private Token ReadString()
  // {
  //   var start = _position;
  //   do
  //   {
  //     _position++;

  //   } while (_position < _text.Length && _text[_position] != '"');
  //   _position++;
  //   return new Token(TokenType.StringLiteral, _text[start.._position]);
  // }

  // private Token ReadWhiteSpace()
  // {
  //   var start = _position;
  //   while (_position < _text.Length && char.IsWhiteSpace(_text[_position]))
  //   {
  //     _position++;
  //   }
  //   return new Token(TokenType.Whitespace, _text[start.._position]);
  // }

  // private Token ReadToken()
  // {
  //   var start = _position;
  //   var c = _text[_position];
  //   switch (c)
  //   {
  //     case '+':
  //       _position++;
  //       return new Token(TokenType.Plus, _text[start.._position]);
  //     case '-':
  //       _position++;
  //       return new Token(TokenType.Minus, _text[start.._position]);
  //     case '*':
  //       _position++;
  //       return new Token(TokenType.Star, _text[start.._position]);
  //     case '/':
  //       _position++;
  //       return new Token(TokenType.Slash, _text[start.._position]);
  //     case '%':
  //       _position++;
  //       return new Token(TokenType.Percent, _text[start.._position]);
  //     case '?':
  //       _position++;
  //       return new Token(TokenType.QuestionMark, _text[start.._position]);
  //     case ':':
  //       _position++;
  //       return new Token(TokenType.Colon, _text[start.._position]);
  //     case ';':
  //       _position++;
  //       return new Token(TokenType.SemiColon, _text[start.._position]);
  //     case '!':
  //       _position++;
  //       if (Current == '=')
  //       {
  //         _position++;
  //         return new Token(TokenType.NotEqual, _text[start.._position]);
  //       }

  //       return new Token(TokenType.Bang, _text[start.._position]);
  //     case '<':
  //       _position++;
  //       if (Current == '=')
  //       {
  //         _position++;
  //         return new Token(TokenType.LessThanOrEqual, _text[start.._position]);
  //       }

  //       return new Token(TokenType.LessThan, _text[start.._position]);
  //     case '>':
  //       _position++;
  //       if (Current == '=')
  //       {
  //         _position++;
  //         return new Token(TokenType.GreaterThanOrEqual, _text[start.._position]);
  //       }

  //       return new Token(TokenType.GreaterThan, _text[start.._position]);
  //     case '=':
  //       _position++;
  //       if (Current == '=')
  //       {
  //         _position++;
  //         return new Token(TokenType.DoubleEqual, _text[start.._position]);
  //       }

  //       return new Token(TokenType.Equal, _text[start.._position]);
  //     case '&':
  //       _position++;
  //       if (Current == '&')
  //       {
  //         _position++;
  //         return new Token(TokenType.DoubleAmpersand, _text[start.._position]);
  //       }

  //       return new Token(TokenType.Ampersand, _text[start.._position]);
  //     case '|':
  //       _position++;
  //       if (Current == '|')
  //       {
  //         _position++;
  //         return new Token(TokenType.DoublePipe, _text[start.._position]);
  //       }

  //       return new Token(TokenType.Pipe, _text[start.._position]);
  //     case '(':
  //       _position++;
  //       return new Token(TokenType.OpenParen, _text[start.._position]);
  //     case ')':
  //       _position++;
  //       return new Token(TokenType.CloseParen, _text[start.._position]);
  //     case '{':
  //       _position++;
  //       return new Token(TokenType.OpenBrace, _text[start.._position]);
  //     case '}':
  //       _position++;
  //       return new Token(TokenType.CloseBrace, _text[start.._position]);
  //     case '[':
  //       _position++;
  //       return new Token(TokenType.OpenBracket, _text[start.._position]);
  //     case ']':
  //       _position++;
  //       return new Token(TokenType.CloseBracket, _text[start.._position]);
  //     default:
  //       _position++;
  //       return new Token(TokenType.Invalid, _text[start.._position]);

  //   }
  // }
}
