using GnuClay.Engine.Parser;
using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
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
            mText = text;
        }

        private string mText = null;
        private List<Token> mResult = null;
        private LexerState mLexerState = LexerState.Init;

        public List<Token> Run()
        {
            mLexerState = LexerState.Init;
            mResult = new List<Token>();

            StringBuilder tmpBuffer = null;

            foreach(var tmpChar in mText)
            {
                switch(mLexerState)
                {
                    case LexerState.Init:
                        if (char.IsLetterOrDigit(tmpChar))
                        {
                            tmpBuffer = new StringBuilder();
                            tmpBuffer.Append(tmpChar);
                            mLexerState = LexerState.InWord;
                            break;
                        }

                        switch (tmpChar)
                        {
                            case '{':
                                CreateToken(TokenKind.OpenFigureBracket);
                                break;

                            case '$':
                                tmpBuffer = new StringBuilder();
                                tmpBuffer.Append(tmpChar);
                                mLexerState = LexerState.InWord;
                                break;

                            case '}':
                                CreateToken(TokenKind.CloseFigureBracket);
                                break;

                            case '(':
                                CreateToken(TokenKind.OpenRoundBracket);
                                break;

                            case ')':
                                CreateToken(TokenKind.CloseRoundBracket);
                                break;

                            case '&':
                                CreateToken(TokenKind.And);
                                break;

                            case ':':
                                CreateToken(TokenKind.Colon);
                                break;

                            case '>':
                                CreateToken(TokenKind.More);
                                break;

                            case '-':
                                CreateToken(TokenKind.Dash);
                                break;

                            case ' ':
                                break;

                            case ',':
                                CreateToken(TokenKind.Comma);
                                break;

                            default: throw new UndefinedSymbolException(tmpChar);
                        }

                        break;

                    case LexerState.InWord:
                        if(char.IsLetterOrDigit(tmpChar))
                        {
                            tmpBuffer.Append(tmpChar);
                            mLexerState = LexerState.InWord;
                            break;
                        }

                        switch (tmpChar)
                        {
                            case ' ':
                                CreateToken(TokenKind.Word, tmpBuffer.ToString());
                                mLexerState = LexerState.Init;
                                break;

                            case '{':
                                CreateToken(TokenKind.Word, tmpBuffer.ToString());
                                mLexerState = LexerState.Init;
                                CreateToken(TokenKind.OpenFigureBracket);
                                break;

                            case '(':
                                CreateToken(TokenKind.Word, tmpBuffer.ToString());
                                mLexerState = LexerState.Init;
                                CreateToken(TokenKind.OpenRoundBracket);
                                break;

                            case ',':
                                CreateToken(TokenKind.Word, tmpBuffer.ToString());
                                mLexerState = LexerState.Init;
                                CreateToken(TokenKind.Comma);
                                break;

                            case ')':
                                CreateToken(TokenKind.Word, tmpBuffer.ToString());
                                mLexerState = LexerState.Init;
                                CreateToken(TokenKind.CloseRoundBracket);
                                break;

                            default: throw new UndefinedSymbolException(tmpChar);
                        }

                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(mLexerState));
                }
            }

            return mResult;
        }

        private void CreateToken(TokenKind kind, string content = null)
        {
            Token tmpLastToken = null;
             
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

                    if (content.StartsWith("$"))
                    {
                        kind = TokenKind.Var;
                        break;
                    }
                break;

                case TokenKind.Colon:
                    tmpLastToken = mResult.Last();

                    switch(tmpLastToken.TokenKind)
                    {
                        case TokenKind.More:
                            tmpLastToken.TokenKind = TokenKind.RULE_HEAD;
                            return;
                    }
                    break;

                case TokenKind.More:
                    tmpLastToken = mResult.Last();

                    switch (tmpLastToken.TokenKind)
                    {
                        case TokenKind.Dash:
                            tmpLastToken.TokenKind = TokenKind.RULE_BODY;
                            return;
                    }
                    break;
            }

            var tmpToken = new Token();
            tmpToken.TokenKind = kind;
            tmpToken.Content = content;

            mResult.Add(tmpToken);
        }
    }
}
