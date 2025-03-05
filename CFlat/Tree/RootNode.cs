namespace CFlat;

internal record RootNode(List<AstNode> Body) : AstNode(NodeType.Program);



