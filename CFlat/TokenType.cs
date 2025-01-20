namespace CFlat;

public enum TokenType
{
  NumberLiteral,
  Identifier,

  Keyword,
  Whitespace,
  StringLiteral,

  // Operators
  Plus,
  Minus,
  Star,
  Slash,
  Percent,
  Bang,
  LessThan,
  GreaterThan,
  LessThanOrEqual,
  GreaterThanOrEqual,
  Equal,
  DoubleEqual,
  NotEqual,
  Ampersand,
  Pipe,
  DoubleAmpersand,
  DoublePipe,
  QuestionMark,
  Colon,
  SemiColon,

  // Delimiters
  OpenParen,
  CloseParen,
  OpenBrace,
  CloseBrace,
  OpenBracket,
  CloseBracket,

  // Error
  Unknown
}
