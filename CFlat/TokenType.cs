namespace CFlat;

public enum TokenType
{

  Number,
  Identifier,
  Whitespace,
  String,

  //Keywords
  Let,
  Fn,
  Return,
  If,
  Else,
  True,
  False,

  // Operators
  Plus,
  Minus,
  Star,
  Slash,
  // Percent,
  // Bang,
  //LessThan,
  //GreaterThan,
  //LessThanOrEqual,
  //GreaterThanOrEqual,
  Equal,
  // DoubleEqual,
  // NotEqual,
  // Ampersand,
  // Pipe,
  // DoubleAmpersand,
  // DoublePipe,
  // QuestionMark,
  // Colon,
  SemiColon,

  // Delimiters
  OpenParen,
  CloseParen,
  // OpenBrace,
  // CloseBrace,
  // OpenBracket,
  // CloseBracket,
  BadToken,

  // End of file
  Eof
}