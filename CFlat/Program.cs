using CFlat;
using System.Text.Json;
var text = """
45;
""";

var parser = new Parser(text);
var ast = parser.Parse();

var options = new JsonSerializerOptions
{
    WriteIndented = true
};

Console.WriteLine(JsonSerializer.Serialize(ast, options)); 
