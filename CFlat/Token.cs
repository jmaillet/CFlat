namespace CFlat;

public record Token
{
  public TokenType Type { get; }
  public string Value { get; }

  public Token(TokenType type, string value)
  {
    Type = type;
    Value = value ?? throw new ArgumentNullException(nameof(value));
  }
}
