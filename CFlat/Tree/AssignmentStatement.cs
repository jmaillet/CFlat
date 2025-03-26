namespace CFlat.Tree;

public record AssignmentStatement(Token Identifier, Expression Expression) : Statement;
