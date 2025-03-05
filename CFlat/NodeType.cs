namespace CFlat;

public enum NodeType
{
  // Expressions
  NumberLiteralExpression,
  StringLiteralExpression,
  BinaryExpression,
  UnaryExpression,
  CallExpression,

  // Root
  Program,

  // Error
  Invalid,

 
}
