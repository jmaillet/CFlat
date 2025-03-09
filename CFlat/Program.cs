using CFlat;
var text = """
45+3+6;
""";

var parser = new Parser(text);
var ast = parser.Parse();
//PrintAst(ast);

