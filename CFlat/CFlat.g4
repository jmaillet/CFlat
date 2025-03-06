grammar CFlat;



// Define number rule
NUMBER
    :
    [0-9]+ ('.' [0-9]+)?
    ;

STRING
    :
    '"' (~["\\])* '"'
    ;

OPERATOR
    : '+' | '-' | '*' | '/' | '%' | '==' | '!=' | '<' | '<=' | '>' | '>=' | '&&' | '||'
    ;

DELIMITER
    : '(' | ')' | '{' | '}' | '[' | ']' | ',' | ';' | '='
    ;



literal
    : NUMBER
    | STRING
    ;

program
    : (statement)*
    ;

statement
    : expressionStatement';'
    ;

expressionStatement
    : literal
    ;
