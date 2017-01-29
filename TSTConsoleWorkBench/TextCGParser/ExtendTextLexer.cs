using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ExtendTextLexer
    {
        public ExtendTextLexer(string text, TextParsingContex context)
        {
            mContext = context;
            mLexer = new TextLexer(text);
        }

        private TextParsingContex mContext = null;
        private TextLexer mLexer = null;

        public ExtendToken GetToken()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GetToken");

            var token = mLexer.GetToken();

            if(token == null)
            {
                return null;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"GetToken token.TokenKind = {token.TokenKind} token.Content = {token.Content}");

            switch (token.TokenKind)
            {
                case TokenKind.Word:
                    return CreateWordToken(token);

                default:
                    var result = new ExtendToken();
                    result.TokenKind = token.TokenKind;
                    result.Content = token.Content;
                    return result;
            }

            throw new NotImplementedException();
        }

        private ExtendToken CreateWordToken(Token token)
        {
            var result = new ExtendToken();
            result.TokenKind = TokenKind.Word;
            result.Content = token.Content;

            return result;
        }
    }
}
