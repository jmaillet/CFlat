using CFlat;

var text = """
45
""";

var parser = new Parser(text);
var ast = parser.Parse();
Console.WriteLine(ast); 
