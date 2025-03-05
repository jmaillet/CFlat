using System.Text.RegularExpressions;

namespace CFlat;
public record Rule(Regex Pattern, TokenType Type);