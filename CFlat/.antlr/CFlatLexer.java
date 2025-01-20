// Generated from c:\Users\maill\source\repos\CFlat\CFlat\CFlat.g4 by ANTLR 4.9.2
import org.antlr.v4.runtime.Lexer;
import org.antlr.v4.runtime.CharStream;
import org.antlr.v4.runtime.Token;
import org.antlr.v4.runtime.TokenStream;
import org.antlr.v4.runtime.*;
import org.antlr.v4.runtime.atn.*;
import org.antlr.v4.runtime.dfa.DFA;
import org.antlr.v4.runtime.misc.*;

@SuppressWarnings({"all", "warnings", "unchecked", "unused", "cast"})
public class CFlatLexer extends Lexer {
	static { RuntimeMetaData.checkVersion("4.9.2", RuntimeMetaData.VERSION); }

	protected static final DFA[] _decisionToDFA;
	protected static final PredictionContextCache _sharedContextCache =
		new PredictionContextCache();
	public static final int
		T__0=1, T__1=2, T__2=3, T__3=4, T__4=5, T__5=6, T__6=7, T__7=8, T__8=9, 
		T__9=10, Number=11, LetterOrUnderscore=12, LetterOrDigitOrUnderscore=13, 
		WS=14;
	public static String[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static String[] modeNames = {
		"DEFAULT_MODE"
	};

	private static String[] makeRuleNames() {
		return new String[] {
			"T__0", "T__1", "T__2", "T__3", "T__4", "T__5", "T__6", "T__7", "T__8", 
			"T__9", "Number", "LetterOrUnderscore", "LetterOrDigitOrUnderscore", 
			"WS"
		};
	}
	public static final String[] ruleNames = makeRuleNames();

	private static String[] makeLiteralNames() {
		return new String[] {
			null, "'bool'", "'false'", "'foreach'", "'number'", "'interface'", "'string'", 
			"'match'", "'true'", "'import'", "'from'"
		};
	}
	private static final String[] _LITERAL_NAMES = makeLiteralNames();
	private static String[] makeSymbolicNames() {
		return new String[] {
			null, null, null, null, null, null, null, null, null, null, null, "Number", 
			"LetterOrUnderscore", "LetterOrDigitOrUnderscore", "WS"
		};
	}
	private static final String[] _SYMBOLIC_NAMES = makeSymbolicNames();
	public static final Vocabulary VOCABULARY = new VocabularyImpl(_LITERAL_NAMES, _SYMBOLIC_NAMES);

	/**
	 * @deprecated Use {@link #VOCABULARY} instead.
	 */
	@Deprecated
	public static final String[] tokenNames;
	static {
		tokenNames = new String[_SYMBOLIC_NAMES.length];
		for (int i = 0; i < tokenNames.length; i++) {
			tokenNames[i] = VOCABULARY.getLiteralName(i);
			if (tokenNames[i] == null) {
				tokenNames[i] = VOCABULARY.getSymbolicName(i);
			}

			if (tokenNames[i] == null) {
				tokenNames[i] = "<INVALID>";
			}
		}
	}

	@Override
	@Deprecated
	public String[] getTokenNames() {
		return tokenNames;
	}

	@Override

	public Vocabulary getVocabulary() {
		return VOCABULARY;
	}


	public CFlatLexer(CharStream input) {
		super(input);
		_interp = new LexerATNSimulator(this,_ATN,_decisionToDFA,_sharedContextCache);
	}

	@Override
	public String getGrammarFileName() { return "CFlat.g4"; }

	@Override
	public String[] getRuleNames() { return ruleNames; }

	@Override
	public String getSerializedATN() { return _serializedATN; }

	@Override
	public String[] getChannelNames() { return channelNames; }

	@Override
	public String[] getModeNames() { return modeNames; }

	@Override
	public ATN getATN() { return _ATN; }

	public static final String _serializedATN =
		"\3\u608b\ua72a\u8133\ub9ed\u417c\u3be7\u7786\u5964\2\20v\b\1\4\2\t\2\4"+
		"\3\t\3\4\4\t\4\4\5\t\5\4\6\t\6\4\7\t\7\4\b\t\b\4\t\t\t\4\n\t\n\4\13\t"+
		"\13\4\f\t\f\4\r\t\r\4\16\t\16\4\17\t\17\3\2\3\2\3\2\3\2\3\2\3\3\3\3\3"+
		"\3\3\3\3\3\3\3\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\4\3\5\3\5\3\5\3\5\3\5\3\5"+
		"\3\5\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\6\3\7\3\7\3\7\3\7\3\7\3\7\3"+
		"\7\3\b\3\b\3\b\3\b\3\b\3\b\3\t\3\t\3\t\3\t\3\t\3\n\3\n\3\n\3\n\3\n\3\n"+
		"\3\n\3\13\3\13\3\13\3\13\3\13\3\f\6\fc\n\f\r\f\16\fd\3\f\3\f\6\fi\n\f"+
		"\r\f\16\fj\5\fm\n\f\3\r\3\r\3\16\3\16\3\17\3\17\3\17\3\17\2\2\20\3\3\5"+
		"\4\7\5\t\6\13\7\r\b\17\t\21\n\23\13\25\f\27\r\31\16\33\17\35\20\3\2\6"+
		"\3\2\62;\5\2C\\aac|\6\2\62;C\\aac|\5\2\13\f\17\17\"\"\2x\2\3\3\2\2\2\2"+
		"\5\3\2\2\2\2\7\3\2\2\2\2\t\3\2\2\2\2\13\3\2\2\2\2\r\3\2\2\2\2\17\3\2\2"+
		"\2\2\21\3\2\2\2\2\23\3\2\2\2\2\25\3\2\2\2\2\27\3\2\2\2\2\31\3\2\2\2\2"+
		"\33\3\2\2\2\2\35\3\2\2\2\3\37\3\2\2\2\5$\3\2\2\2\7*\3\2\2\2\t\62\3\2\2"+
		"\2\139\3\2\2\2\rC\3\2\2\2\17J\3\2\2\2\21P\3\2\2\2\23U\3\2\2\2\25\\\3\2"+
		"\2\2\27b\3\2\2\2\31n\3\2\2\2\33p\3\2\2\2\35r\3\2\2\2\37 \7d\2\2 !\7q\2"+
		"\2!\"\7q\2\2\"#\7n\2\2#\4\3\2\2\2$%\7h\2\2%&\7c\2\2&\'\7n\2\2\'(\7u\2"+
		"\2()\7g\2\2)\6\3\2\2\2*+\7h\2\2+,\7q\2\2,-\7t\2\2-.\7g\2\2./\7c\2\2/\60"+
		"\7e\2\2\60\61\7j\2\2\61\b\3\2\2\2\62\63\7p\2\2\63\64\7w\2\2\64\65\7o\2"+
		"\2\65\66\7d\2\2\66\67\7g\2\2\678\7t\2\28\n\3\2\2\29:\7k\2\2:;\7p\2\2;"+
		"<\7v\2\2<=\7g\2\2=>\7t\2\2>?\7h\2\2?@\7c\2\2@A\7e\2\2AB\7g\2\2B\f\3\2"+
		"\2\2CD\7u\2\2DE\7v\2\2EF\7t\2\2FG\7k\2\2GH\7p\2\2HI\7i\2\2I\16\3\2\2\2"+
		"JK\7o\2\2KL\7c\2\2LM\7v\2\2MN\7e\2\2NO\7j\2\2O\20\3\2\2\2PQ\7v\2\2QR\7"+
		"t\2\2RS\7w\2\2ST\7g\2\2T\22\3\2\2\2UV\7k\2\2VW\7o\2\2WX\7r\2\2XY\7q\2"+
		"\2YZ\7t\2\2Z[\7v\2\2[\24\3\2\2\2\\]\7h\2\2]^\7t\2\2^_\7q\2\2_`\7o\2\2"+
		"`\26\3\2\2\2ac\t\2\2\2ba\3\2\2\2cd\3\2\2\2db\3\2\2\2de\3\2\2\2el\3\2\2"+
		"\2fh\7\60\2\2gi\t\2\2\2hg\3\2\2\2ij\3\2\2\2jh\3\2\2\2jk\3\2\2\2km\3\2"+
		"\2\2lf\3\2\2\2lm\3\2\2\2m\30\3\2\2\2no\t\3\2\2o\32\3\2\2\2pq\t\4\2\2q"+
		"\34\3\2\2\2rs\t\5\2\2st\3\2\2\2tu\b\17\2\2u\36\3\2\2\2\6\2djl\3\b\2\2";
	public static final ATN _ATN =
		new ATNDeserializer().deserialize(_serializedATN.toCharArray());
	static {
		_decisionToDFA = new DFA[_ATN.getNumberOfDecisions()];
		for (int i = 0; i < _ATN.getNumberOfDecisions(); i++) {
			_decisionToDFA[i] = new DFA(_ATN.getDecisionState(i), i);
		}
	}
}