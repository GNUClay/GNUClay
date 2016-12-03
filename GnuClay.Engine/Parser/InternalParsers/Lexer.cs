using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class Lexer
    {
        private enum LexerState
        {
            Init,
            InWord
        }

        public Lexer(string text)
        {
            mItems = new Queue<char>(text.ToList());
        }

        private string mText = null;
        private Queue<char> mItems = null;
        private LexerState mLexerState = LexerState.Init;
        private Queue<Token> mRecoveriesTokens = new Queue<Token>();
        private CultureInfo mCultureInfo = new CultureInfo("en-GB");

        public Token GetToken()
        {
            if(mRecoveriesTokens.Count > 0)
            {
                return mRecoveriesTokens.Dequeue();
            }

            StringBuilder tmpBuffer = null;

            while(mItems.Count > 0)
            {
                var tmpChar = mItems.Dequeue();

                switch (mLexerState)
                {
                    case LexerState.Init:
                        if (char.IsLetterOrDigit(tmpChar))
                        {
                            tmpBuffer = new StringBuilder();
                            tmpBuffer.Append(tmpChar);

                            if(char.IsLetterOrDigit(mItems.Peek()))
                            {
                                mLexerState = LexerState.InWord;
                            }
                            else
                            {
                                return CreateToken(TokenKind.Word, tmpBuffer.ToString());
                            }                      
                            break;
                        }

                        switch (tmpChar)
                        {
                            case '{':
                                return CreateToken(TokenKind.OpenFigureBracket);

                            case '$':
                                tmpBuffer = new StringBuilder();
                                tmpBuffer.Append(tmpChar);
                                mLexerState = LexerState.InWord;
                                break;

                            case '}':
                                return CreateToken(TokenKind.CloseFigureBracket);

                            case '(':
                                return CreateToken(TokenKind.OpenRoundBracket);

                            case ')':
                                return CreateToken(TokenKind.CloseRoundBracket);

                            case '&':
                                return CreateToken(TokenKind.And);

                            case ':':
                                return CreateToken(TokenKind.Colon);

                            case '>':
                                return CreateToken(TokenKind.More);

                            case '-':
                                return CreateToken(TokenKind.Dash);

                            case ' ':
                                break;

                            case ',':
                                return CreateToken(TokenKind.Comma);

                            case '+':
                                return CreateToken(TokenKind.Plus);

                            case ';':
                                return CreateToken(TokenKind.Semicolon);

                            case '.':
                                return CreateToken(TokenKind.Point);

                            default: throw new UnexpectedSymbolException(tmpChar);
                        }
                        break;

                    case LexerState.InWord:
                        tmpBuffer.Append(tmpChar);
                        mLexerState = LexerState.InWord;

                        if (!char.IsLetterOrDigit(mItems.Peek()))
                        {
                            mLexerState = LexerState.Init;
                            return CreateToken(TokenKind.Word, tmpBuffer.ToString());
                        }
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(mLexerState));
                }
            }

            return null;
        }

        private Token CreateToken(TokenKind kind, string content = null)
        {
            char tmpNextChar;
            int id;

            switch (kind)
            {
                case TokenKind.Word:
                    if (string.Compare(content, "SELECT", true) == 0)
                    {
                        kind = TokenKind.SELECT;
                        content = null;
                        break;
                    }

                    if (string.Compare(content, "INSERT", true) == 0)
                    {
                        kind = TokenKind.INSERT;
                        content = null;
                        break;
                    }

                    if (string.Compare(content, "CALL", true) == 0)
                    {
                        kind = TokenKind.CALL;
                        content = null;
                        break;
                    }

                    if (content.StartsWith("$"))
                    {
                        kind = TokenKind.Var;
                        break;
                    }

                    if(int.TryParse(content, out id))
                    {
                        kind = TokenKind.Number;
                        break;
                    }
                break;

                case TokenKind.More:
                    tmpNextChar = mItems.Peek();

                    switch(tmpNextChar)
                    {
                        case ':':
                            kind = TokenKind.RULE_HEAD;
                            mItems.Dequeue();
                            break;
                    }
                    break;

                case TokenKind.Dash:
                    tmpNextChar = mItems.Peek();

                    switch(tmpNextChar)
                    {
                        case '>':
                            kind = TokenKind.RULE_BODY;
                            mItems.Dequeue();
                            break;
                    }
                    break;
            }

            var result = new Token();
            result.TokenKind = kind;
            result.Content = content;
            return result;
        }
    }
}
