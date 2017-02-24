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
        public ExtendTextLexer(string text, TextParsingLexerContex context)
        {
            mContext = context;
            Engine = mContext.Engine;
            DataDictionary = Engine.DataDictionary;
            mLexer = new TextLexer(text);
        }

        private TextParsingLexerContex mContext = null;
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

            var content = token.Content;

            result.Content = content;
            result.Key = DataDictionary.GetKey(content);
            result.PartOfSpeech = mContext.GetPartOfSpeech(content);

            if(result.PartOfSpeech.Count == 0)
            {
                throw new UnknownWordException(content);
            }

            result.RootKey = mContext.GetRoot(content);

            if(result.RootKey == 0)
            {
                result.RootKey = result.Key;
            }

            var isVerb = result.Is(GrammaticalPartOfSpeech.Verb);
            var isNoun = result.Is(GrammaticalPartOfSpeech.Noun);
            var isPronoun = result.Is(GrammaticalPartOfSpeech.Pronoun);
            var isAdjective = result.Is(GrammaticalPartOfSpeech.Adjective);
            var isAdverb = result.Is(GrammaticalPartOfSpeech.Adverb);
            var isArticle = result.Is(GrammaticalPartOfSpeech.Article);

            if (isVerb || isNoun || isPronoun || isArticle)
            {
                result.Number = mContext.GetNumbers(content);

                if(isVerb || isArticle)
                {
                    result.Number = mContext.FillToAllIfEmpty(result.Number);
                }
            }
            
            if(isNoun || isPronoun)
            {
                result.Gender = mContext.GetGenders(content);
            }

            if(isPronoun)
            {
                result.TypeOfPronoun = mContext.GetTypesOfPronoun(content);
            }

            var isPersonalPronoun = false;

            if(isPronoun && result.Is(TypeOfPronoun.Personal))
            {
                isPersonalPronoun = true;
            }

            if(isPersonalPronoun)
            {
                result.CaseOfPersonalPronoun = mContext.GetCasesOfPersonalPronoun(content);
            }

            if (isVerb || isPersonalPronoun)
            {
                result.Person = mContext.GetPersons(content);
            }

            if (isVerb)
            {
                result.Tenses = mContext.GetTenses(content);
                result.VerbType = mContext.GetVerbTypes(content);

                //result.IsModality = mContext.IsModality(content);
            }

            if(isAdjective || isAdverb)
            {
                result.Comparison = mContext.GetComparisons(content);
            }

            return result;
        }
    }
}
