// Scanner -- The lexical analyzer for the Scheme printer and interpreter

using System;
using System.IO;
using Tokens;

namespace Parse
{
    public class Scanner
    {
        private TextReader In;

        // maximum length of strings and identifier
        private const int BUFSIZE = 1000;
        private char[] buf = new char[BUFSIZE];

        public Scanner(TextReader i) { In = i; }
  
        // TODO: Add any other methods you need

        //Checks if current ch is a blank character (whitespace, newline, carriage return, tab, etc)
        public Boolean isBlank(int ch)
        {
            if ((ch == '\n') || (ch == '\t') || (ch == '\r') || (ch == ' '))
            {
                return true;
            }
            else if (ch == ';')
            {
                In.ReadLine();
                return true;
            }
            else
            {
                return false;
            }

        }

        //Retrieves the next token from the input stream
        public Token getNextToken()
        {
            int ch;

            try
            {
                // It would be more efficient if we'd maintain our own
                // input buffer and read characters out of that
                // buffer, but reading individual characters from the
                // input stream is easier.
                ch = In.Read();
   
                // TODO: skip white space and comments
                //Skips white space
                if (isBlank(ch))
                {
                    return getNextToken();
                }

                //Null if stream has no tokens left
                if (ch == -1)
                    return null;
        
                // Special characters
                else if (ch == '\'')
                    return new Token(TokenType.QUOTE);
                else if (ch == '(')
                    return new Token(TokenType.LPAREN);
                else if (ch == ')')
                    return new Token(TokenType.RPAREN);
                else if (ch == '.')
                    // We ignore the special identifier `...'.
                    return new Token(TokenType.DOT);
                
                // Boolean constants
                else if (ch == '#')
                {
                    ch = In.Read();

                    if (ch == 't')
                        return new Token(TokenType.TRUE);
                    else if (ch == 'f')
                        return new Token(TokenType.FALSE);
                    else if (ch == -1)
                    {
                        Console.Error.WriteLine("Unexpected EOF following #");
                        return null;
                    }
                    else
                    {
                        Console.Error.WriteLine("Illegal character '" +
                                                (char)ch + "' following #");
                        return getNextToken();
                    }
                }

                // String constants
                else if (ch == '"')
                {
                    // TODO: scan a string into the buffer variable buf
                    //stores first character of string in buffer[0]
                    buf[0] = (char)ch; 
                    int chNext = In.Peek();
                    int size = 1;

                    //If next character is not a ", add the character to the string
                    for (int i = 1; (chNext != '\"') && (chNext != '\r') && (chNext != '\n'); i++, size++)
                    {
                        ch = In.Read();
                        buf[i] = (char)ch;
                        chNext = In.Peek();
                    }

                    if(chNext == '\"')
                    {
                        ch = In.Read();
                        buf[size++] = (char)ch;
                    }
                    else
                    {
                        ch = In.Read();
                        Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                        return getNextToken();
                    }

                    return new StringToken(new String(buf, 0, size));
                }

    
                // Integer constants
                else if (ch >= '0' && ch <= '9')
                {
                    int i = ch - '0';
                    // TODO: scan the number and convert it to an integer

                    // make sure that the character following the integer
                    // is not removed from the input stream

                    //Peeks at next character to see if it is a digit.
                    //Calculates integer if iNext is a digit
                    int iNext = In.Peek();
                    while (iNext >= '0' && iNext <= '9')
                    {
                        ch = In.Read();
                        i = (i * 10) + (ch - '0');
                        iNext = In.Peek();
                    }

                    if(!isBlank(iNext) && iNext != ')')
                    {
                        throw new IOException();
                    }

                    return new IntToken(i);
                }
        
                // Identifiers
                else if ( (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z')
                         // or ch is some other valid first character
                         // for an identifier
                         ) {
                    // TODO: scan an identifier into the buffer

                    // make sure that the character following the integer
                    // is not removed from the input stream

                    //Stores first character of identifier in buf[0]. 
                    //Peeks to next to see if identifier string continues
                    //If so, adds identifier string characters to buf[] until
                    //chNext encounters whitespace
                    buf[0] = (char)ch;
                    int chNext = In.Peek();
                    int size = 1;

                    for (int i = 1; !isBlank(chNext); i++, size++)
                    {
                        ch = In.Read();
                        buf[i] = (char) ch;
                        chNext = In.Peek();
                    }

                    return new IdentToken(new String(buf, 0, size));
                }
    
                // Illegal character
                else
                {
                    Console.Error.WriteLine("Illegal input character '"
                                            + (char)ch + '\'');
                    return getNextToken();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("IOException: " + e.Message);
                return null;
            }
        }
    }

}

