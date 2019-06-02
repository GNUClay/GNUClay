using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Core.Implementations.CoreCompiler.Parsers
{
    public class ParserContext: IParserContext
    {
        public ParserContext(string text, ILog logger)
        {
            mLogger = logger;
            mLexer = new Lexer(text);
        }

        private readonly ILog mLogger;
        private readonly Lexer mLexer;
        private readonly Stack<Token> mRecoveriesTokens = new Stack<Token>();

        public ILog Logger => mLogger;

        public Token GetToken()
        {
            var result = NGetToken();

            if (result == null)
            {
                return null;
            }

            var tokenKind = result.TokenKind;

            switch (tokenKind)
            {
                case TokenKind.Number:
                    {
                        var nextToken = NGetToken();
                        var nextTokenKind = nextToken.TokenKind;

#if DEBUG
                        //LogInstance.Log($"nextToken = {nextToken}");
#endif

                        switch (nextTokenKind)
                        {
                            case TokenKind.Point:
                                {
                                    var nextNextToken = NGetToken();
                                    var nextNextTokenKind = nextNextToken.TokenKind;

#if DEBUG
                                    //LogInstance.Log($"nextNextToken = {nextNextToken}");
#endif

                                    switch (nextNextTokenKind)
                                    {
                                        case TokenKind.Number:
                                            {
                                                result.Content = $"{result.Content}.{nextNextToken.Content}";
                                            }
                                            break;

                                        case TokenKind.FuzzyLogicalValue:
                                            {
                                                result.Content = $"{result.Content}.{nextNextToken.Content}";
                                                result.TokenKind = TokenKind.FuzzyLogicalValue;
                                            }
                                            break;

                                        default:
                                            Recovery(nextToken);
                                            break;
                                    }
                                }
                                break;

                            default:
                                Recovery(nextToken);
                                break;
                        }
                    }
                    break;

                case TokenKind.AtSign:
                    {
                        var nextToken = NGetToken();
                        var nextTokenKind = nextToken.TokenKind;
                        switch (nextTokenKind)
                        {
                            case TokenKind.Word:
                                nextToken.Content = $"@{nextToken.Content}";
                                nextToken.TokenKind = TokenKind.Var;
                                return nextToken;

                            default:
                                Recovery(nextToken);
                                break;
                        }
                    }
                    break;

                case TokenKind.AtSignDollar:
                    {
                        var nextToken = NGetToken();
                        var nextTokenKind = nextToken.TokenKind;
                        switch (nextTokenKind)
                        {
                            case TokenKind.Word:
                                nextToken.Content = $"@${nextToken.Content}";
                                nextToken.TokenKind = TokenKind.BindedParam;
                                return nextToken;

                            default:
                                Recovery(nextToken);
                                break;
                        }
                    }
                    break;

                case TokenKind.QuestionMark:
                    {
                        var nextToken = NGetToken();
                        var nextTokenKind = nextToken.TokenKind;
                        switch (nextTokenKind)
                        {
                            case TokenKind.Word:
                                nextToken.Content = $"?{nextToken.Content}";
                                nextToken.TokenKind = TokenKind.QuestionParam;
                                return nextToken;

                            default:
                                Recovery(nextToken);
                                break;
                        }
                    }
                    break;

                case TokenKind.Sharp:
                    {
                        var nextToken = NGetToken();
                        var nextTokenKind = nextToken.TokenKind;
                        switch (nextTokenKind)
                        {
                            case TokenKind.Word:
                            case TokenKind.Number:
                                nextToken.Content = $"#{nextToken.Content}";
                                nextToken.TokenKind = TokenKind.Entity;
                                return nextToken;

                            default:
                                Recovery(nextToken);
                                break;
                        }
                    }
                    break;
            }

            return result;
        }

        private Token NGetToken()
        {
            if (mRecoveriesTokens.Count == 0)
            {
                return mLexer.GetToken();
            }

            return mRecoveriesTokens.Pop();
        }

        public void Recovery(Token token)
        {
            mRecoveriesTokens.Push(token);

#if DEBUG
            //var tmpTokensList = mRecoveriesTokens.ToList();
            //LogInstance.Log($"tmpTokensList.Count = {tmpTokensList.Count}");
            //foreach (var tmpToken in tmpTokensList)
            //{
            //    LogInstance.Log($"tmpToken = {tmpToken}");
            //}
#endif
        }
    }
}
