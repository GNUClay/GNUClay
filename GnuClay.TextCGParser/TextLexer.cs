using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.TextCGParser
{
    public class TextLexer : Lexer
    {
        public enum State
        {
            Init,
            Number,
            MayBeFloatNumber
        }

        public TextLexer(string text)
            : base(text)
        {
        }

        private State mState = State.Init;

        private Token Token_1 = null;
        private Token Token_2 = null;
        //private Token Token_3 = null;

        public override Token GetToken()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetToken Enter");

            while (true)
            {
                var token = base.GetToken();

                //NLog.LogManager.GetCurrentClassLogger().Info($"GetToken mState = {mState} token = {token}");

                if (token == null)
                {
                    return null;
                }

                switch (mState)
                {
                    case State.Init:
                        switch (token.TokenKind)
                        {
                            case TokenKind.Word:
                                return token;

                            case TokenKind.Number:
                                Token_1 = token;
                                mState = State.Number;
                                break;

                            default:
                                return token;
                        }
                        break;

                    case State.Number:
                        switch (token.TokenKind)
                        {
                            case TokenKind.Point:
                                mState = State.MayBeFloatNumber;
                                Token_2 = token;
                                break;

                            default:
                                Recovery(token);
                                mState = State.Init;
                                return Token_1;
                        }
                        break;

                    case State.MayBeFloatNumber:
                        switch (token.TokenKind)
                        {
                            case TokenKind.Number:
                                var result = new Token();
                                result.TokenKind = TokenKind.Number;
                                result.Content = $"{Token_1.Content}.{token.Content}";
                                mState = State.Init;
                                return result;

                            default:
                                Recovery(token);
                                Recovery(Token_2);
                                mState = State.Init;
                                return Token_1;
                        }

                    default: throw new ArgumentOutOfRangeException(nameof(mState), mState.ToString());
                }
            }
        }
    }
}
