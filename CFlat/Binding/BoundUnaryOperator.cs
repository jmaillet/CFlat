namespace CFlat.Binding;

public abstract record BoundUnaryOperator;

public record BoundNegationUnaryOperator(Type OperandType) : BoundUnaryOperator
{
  public TokenType TokenType { get; } = OperandType == typeof(int) ? TokenType.Minus : TokenType.Bang;
}
