grammar CFlat;



// Define number rule
Number
    :
    [0-9]+ ('.' [0-9]+)?
    ;





// Define keywords
keywords:
    'bool' | 'false' | 'foreach' |  'number' | 'interface' | 'string' | 'match' | 'true' | 'import' | 'from'; 

// Define identifier rule
identifier:
    LetterOrUnderscore (LetterOrDigitOrUnderscore)*;

// Define letter or underscore rule
LetterOrUnderscore:
    [a-zA-Z_];

// Define letter or digit or underscore rule
LetterOrDigitOrUnderscore:
    [a-zA-Z0-9_];

// Define whitespace rule
WS:
    [ \t\r\n] -> skip;
