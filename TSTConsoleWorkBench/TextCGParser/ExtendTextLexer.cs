using GnuClay.Engine;
using GnuClay.Engine.CommonStorages;
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
            Engine = mContext.Engine;
            DataDictionary = Engine.DataDictionary;
            mLexer = new TextLexer(text);
        }

        private TextParsingContex mContext = null;
        private GnuClayEngine Engine = null;
        private StorageDataDictionary DataDictionary = null;
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
            result.Key = DataDictionary.GetKey(result.Content);
            result.PartOfSpeech = GetPartOfSpeech(result.Content);
            result.RootKey = GetRoot(result.Content);
            result.Number = GetNumbers(result.Content);
            return result;
        }

        private List<PartOfSpeech> GetPartOfSpeech(string content)
        {
            var queryStr = $"SELECT {{>: {{`part of speech`({content}, $X)}}}}";

            var queryResult = Engine.Query(queryStr);

            if (queryResult.Success && queryResult.HaveBeenFound)
            {
                var result = new List<PartOfSpeech>();

                var context = mContext.PartOfSpeechContext;

                foreach (var item in queryResult.Items)
                {
                    result.Add(context.KeyToPartOfSpeech(item.Params.First().EntityKey));
                }

                return result;
            }

            return new List<PartOfSpeech>();
        }

        private ulong GetRoot(string content)
        {
            var queryStr = $"SELECT {{>: {{root({content}, $X)}}}}";

            var result = Engine.Query(queryStr);

            if (result.Success && result.HaveBeenFound)
            {
                return result.Items.First().Params.First().EntityKey;
            }

            return 0;
        }

        private List<ulong> GetNumbers(string content)
        {
            var queryStr = $"SELECT {{>: {{number({content}, $X)}}}}";

            var queryResult = Engine.Query(queryStr);

            if (queryResult.Success && queryResult.HaveBeenFound)
            {
                var result = new List<ulong>();

                foreach(var item in queryResult.Items)
                {
                    result.Add(item.Params.First().EntityKey);
                }

                return result;
            }

            return new List<ulong>();
        }
    }
}
