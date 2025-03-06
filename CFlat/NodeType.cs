namespace CFlat;

public enum NodeType
{

  // Statements
  ExpressionStatement,
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
