namespace CFlat;

// Keywords
public static class Keywords
{
  public const string Var = "var";
  public const string Const = "const";
  public const string If = "if";
  public const string Else = "else";
  public const string While = "while";
  public const string For = "for";
  public const string Return = "return";
  public const string True = "true";
  public const string False = "false";
  public const string Null = "null";
  public static bool IsKeyword(string value) => value switch
  {
    Var => true,
    Const => true,
    If => true,
    Else => true,
    While => true,
    For => true,
    Return => true,
    True => true,
    False => true,
    Null => true,
    _ => false
  };
}
