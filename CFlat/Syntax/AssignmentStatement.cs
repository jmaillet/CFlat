namespace CFlat.Syntax;

public record AssignmentStatement(Token Identifier, Expression Expression) : Statement;
