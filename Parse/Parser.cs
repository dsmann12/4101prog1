// Parser -- the parser for the Scheme printer and interpreter
//
// Defines
//
//   class Parser;
//
// Parses the language
//
//   exp  ->  ( rest
//         |  #f
//         |  #t
//         |  ' exp
//         |  integer_constant
//         |  string_constant
//         |  identifier
//    rest -> )
//         |  exp+ [. exp] )
//
// and builds a parse tree.  Lists of the form (rest) are further
// `parsed' into regular lists and special forms in the constructor
// for the parse tree node class Cons.  See Cons.parseList() for
// more information.
//
// The parser is implemented as an LL(0) recursive descent parser.
// I.e., parseExp() expects that the first token of an exp has not
// been read yet.  If parseRest() reads the first token of an exp
// before calling parseExp(), that token must be put back so that
// it can be reread by parseExp() or an alternative version of
// parseExp() must be called.
//
// If EOF is reached (i.e., if the scanner returns a NULL) token,
// the parser returns a NULL tree.  In case of a parse error, the
// parser discards the offending token (which probably was a DOT
// or an RPAREN) and attempts to continue parsing with the next token.

using System;
using Tokens;
using Tree;

namespace Parse
{
    public class Parser {
	
        private Scanner scanner;

        public Parser(Scanner s) { scanner = s; }
  
        //Parses an expression token
        public Node parseExp()
        {
            // TODO: write code for parsing an exp

            Token tok = scanner.getNextToken();

            //While scanner is not empty
            //Return correct node depending on tokentype
            while (tok != null)
            {
                TokenType tt = tok.getType();

                if (tt == TokenType.IDENT)
                {
                    return new Ident(tok.getName());
                }
                else if (tt == TokenType.STRING)
                {
                    return new StringLit(tok.getStringVal());
                }
                else if (tt == TokenType.INT)
                {
                    return new IntLit(tok.getIntVal());
                }
                else if (tt == TokenType.QUOTE)
                {
                    return new Cons( new Ident("quote"), parseExp());
                }
                else if (tt == TokenType.TRUE)
                {
                    return new BoolLit(true);
                }
                else if (tt == TokenType.FALSE)
                {
                    return new BoolLit(false);
                }
                else if (tt == TokenType.LPAREN)
                {
                    return parseRest();
                }
            }
            return null;
        }

        //Parse expression with token provided
        public Node parseExp(Token tok)
        {
            // TODO: write code for parsing an exp

            while (tok != null)
            {
                TokenType tt = tok.getType();

                if (tt == TokenType.IDENT)
                {
                    return new Ident(tok.getName());
                }
                else if (tt == TokenType.STRING)
                {
                    return new StringLit(tok.getStringVal());
                }
                else if (tt == TokenType.INT)
                {
                    return new IntLit(tok.getIntVal());
                }
                else if (tt == TokenType.QUOTE)
                {
                    return new Cons(new Ident("quote"), parseExp());
                }
                else if (tt == TokenType.TRUE)
                {
                    return new BoolLit(true);
                }
                else if (tt == TokenType.FALSE)
                {
                    return new BoolLit(false);
                }
                else if (tt == TokenType.LPAREN)
                {
                    return parseRest();
                }
            }
            return null;
        }

        //Parse a rest. 
        protected Node parseRest()
        {
            // TODO: write code for parsing a rest

            //Look at next token
            Token tok = scanner.getNextToken();
            TokenType tt = tok.getType();

            //If next token is not ')'
            //Then return a list node (cons)
            if (tt != TokenType.RPAREN)
            {
                return new Cons(parseExp(tok), parseRest());
            }
            //If next token is a ')' return a Nil node
            return new Nil();
        }

        // TODO: Add any additional methods you might need.
    }
}

