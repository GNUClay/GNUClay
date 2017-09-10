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
            InWord,
            InRichWord
        }

        public Lexer(string text, LexerOptions options = null)
        {
            mItems = new Queue<char>(text.ToList());

            if(options != null)
            {
                DetectSpecialWords = options.DetectSpecialWords;
            }
        }

        private string mText = null;
        private Queue<char> mItems = null;
        private LexerState mLexerState = LexerState.Init;
        private Queue<Token> mRecoveriesTokens = new Queue<Token>();
        private CultureInfo mCultureInfo = new CultureInfo(GeneralConstants.DefaultCulture);
        public bool DetectSpecialWords = true;

        public virtual Token GetToken()
        {
            if(mRecoveriesTokens.Count > 0)
            {
                return mRecoveriesTokens.Dequeue();
            }

            StringBuilder tmpBuffer = null;

            while(mItems.Count > 0)
            {
                var tmpChar = mItems.Dequeue();

#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"GetToken tmpChar = {tmpChar} (int)tmpChar = {(int)tmpChar} mLexerState = {mLexerState}");
#endif
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
                            case '#':
                                tmpBuffer = new StringBuilder();
                                tmpBuffer.Append(tmpChar);

                                if (char.IsLetterOrDigit(mItems.Peek()))
                                {
                                    mLexerState = LexerState.InWord;
                                }
                                else
                                {
                                    return CreateToken(TokenKind.Word, tmpBuffer.ToString());
                                }
                                break;

                            case '_':
                                tmpBuffer = new StringBuilder();
                                tmpBuffer.Append(tmpChar);

                                if (char.IsLetterOrDigit(mItems.Peek()))
                                {
                                    mLexerState = LexerState.InWord;
                                }
                                else
                                {
                                    return CreateToken(TokenKind.Word, tmpBuffer.ToString());
                                }
                                break;

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

                            case '<':
                                return CreateToken(TokenKind.Less);

                            case '-':
                                return CreateToken(TokenKind.Dash);

                            case ' ':
                                break;

                            case ',':
                                return CreateToken(TokenKind.Comma);

                            case '+':
                                return CreateToken(TokenKind.Plus);

                            case '*':
                                return CreateToken(TokenKind.Mul);

                            case '/':
                                return CreateToken(TokenKind.Div);

                            case ';':
                                return CreateToken(TokenKind.Semicolon);

                            case '.':
                                return CreateToken(TokenKind.Point);

                            case '!':
                                return CreateToken(TokenKind.Not);

                            case '=':
                                return CreateToken(TokenKind.Assing);

                            case '~':
                                return CreateToken(TokenKind.Tilde);

                            case '`':
                                tmpBuffer = new StringBuilder();
                                mLexerState = LexerState.InRichWord;
                                break;

                            default:
                                {
                                    var intCharCode = (int)tmpChar;

                                    if(intCharCode == 13)
                                    {
                                        break;
                                    }

                                    if(intCharCode == 10)
                                    {
                                        break;
                                    }

                                    throw new UnexpectedSymbolException(tmpChar);
                                }                    
                        }
                        break;

                    case LexerState.InWord:
                        {
                            tmpBuffer.Append(tmpChar);
                            mLexerState = LexerState.InWord;

                            if (mItems.Count == 0)
                            {
                                mLexerState = LexerState.Init;
                                return CreateToken(TokenKind.Word, tmpBuffer.ToString());
                            }

                            var tmpNextChar = mItems.Peek();

                            if (!char.IsLetterOrDigit(tmpNextChar) && tmpNextChar != '_')
                            {
                                mLexerState = LexerState.Init;
                                return CreateToken(TokenKind.Word, tmpBuffer.ToString());
                            }
                        }
                        break;

                    case LexerState.InRichWord:
                        switch(tmpChar)
                        {
                            case '`':
                                mLexerState = LexerState.Init;
                                return CreateToken(TokenKind.Word, tmpBuffer.ToString());

                            default:
                                tmpBuffer.Append(tmpChar);
                                break;
                        }
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(mLexerState), mLexerState, null);
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
                    if(DetectSpecialWords)
                    {
                        if (string.Compare(content, "READ", true) == 0)
                        {
                            kind = TokenKind.READ;
                            content = null;
                            break;
                        }

                        if (string.Compare(content, "WRITE", true) == 0)
                        {
                            kind = TokenKind.WRITE;
                            content = null;
                            break;
                        }

                        if(string.Compare(content, "REWRITE", true) == 0)
                        {
                            kind = TokenKind.REWRITE;
                            content = null;
                            break;
                        }

                        if (string.Compare(content, "DELETE", true) == 0)
                        {
                            kind = TokenKind.DELETE;
                            content = null;
                            break;
                        }

                        if (string.Compare(content, "CALL", true) == 0)
                        {
                            kind = TokenKind.CALL;
                            content = null;
                            break;
                        }
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

                        case '=':
                            kind = TokenKind.MoreOrEqual;
                            mItems.Dequeue();
                            break;
                    }
                    break;

                case TokenKind.Less:
                    tmpNextChar = mItems.Peek();

                    switch (tmpNextChar)
                    {
                        case '!':
                            kind = TokenKind.BEGIN_TARGET;
                            mItems.Dequeue();
                            break;

                        case '<':
                            kind = TokenKind.AssingFact;
                            mItems.Dequeue();
                            break;

                        case '=':
                            kind = TokenKind.LessOrEqual;
                            mItems.Dequeue();
                            break;
                    }
                    break;

                case TokenKind.Plus:
                    tmpNextChar = mItems.Peek();

                    switch (tmpNextChar)
                    {
                        case '=':
                            kind = TokenKind.PlusAssing;
                            mItems.Dequeue();
                            break;

                        case '<':
                            mItems.Dequeue();
                            tmpNextChar = mItems.Peek();
                            switch (tmpNextChar)
                            {
                                case '<':
                                    kind = TokenKind.PlusAssingFact;
                                    mItems.Dequeue();
                                    break;

                                default: throw new UnexpectedSymbolException(tmpNextChar);
                            }
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

                        case '=':
                            kind = TokenKind.MinusAssing;
                            mItems.Dequeue();
                            break;
                    }
                    break;

                case TokenKind.Mul:
                    tmpNextChar = mItems.Peek();

                    switch (tmpNextChar)
                    {
                        case '=':
                            kind = TokenKind.MulAssing;
                            mItems.Dequeue();
                            break;
                    }
                    break;

                case TokenKind.Div:
                    tmpNextChar = mItems.Peek();

                    switch (tmpNextChar)
                    {
                        case '=':
                            kind = TokenKind.DivAssing;
                            mItems.Dequeue();
                            break;
                    }
                    break;

                case TokenKind.Not:
                    tmpNextChar = mItems.Peek();

                    switch (tmpNextChar)
                    {
                        case '>':
                            kind = TokenKind.END_TERGET;
                            mItems.Dequeue();
                            break;

                        case '=':
                            kind = TokenKind.NotEqual;
                            mItems.Dequeue();
                            break;
                    }
                    break;

                case TokenKind.Assing:
                    tmpNextChar = mItems.Peek();

                    switch (tmpNextChar)
                    {
                        case '=':
                            kind = TokenKind.Equal;
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

        public void Recovery(Token token)
        {
            mRecoveriesTokens.Enqueue(token);
        }
    }
}
