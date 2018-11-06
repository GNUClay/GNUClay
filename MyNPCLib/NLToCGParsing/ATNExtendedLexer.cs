using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing
{
    public class ATNExtendedLexer
    {
        public ATNExtendedLexer(string text, IWordsDict wordsDict)
        {
            text = text.Replace("’", "'");
            mLexer = new ATNLexer(text, true);
            mWordsDict = wordsDict;

            InitTransformsDict();
        }

        private ATNExtendedLexer()
        {
            InitTransformsDict();
        }

        private readonly object mLockObj = new object();
        private ATNLexer mLexer;
        private IWordsDict mWordsDict;
        private Queue<IList<ATNExtendedToken>> mRecoveriesTokens = new Queue<IList<ATNExtendedToken>>();

        public ATNExtendedLexer Fork()
        {
            lock(mLockObj)
            {
                var result = new ATNExtendedLexer();
                result.mWordsDict = mWordsDict;
                result.mLexer = mLexer.Fork();
                result.mRecoveriesTokens = new Queue<IList<ATNExtendedToken>>(mRecoveriesTokens.ToList());
                return result;
            }
        }

        private void InitTransformsDict()
        {
            mTransformsDict.Add("can't", new List<string>() { "can", "not" });
            mTransformsDict.Add("cannot", new List<string>() { "can", "not" });
            mTransformsDict.Add("couldn't", new List<string>() { "could", "not" });
            mTransformsDict.Add("mayn't", new List<string>() { "may", "not" });
            mTransformsDict.Add("mightn't", new List<string>() { "might", "not" });
            mTransformsDict.Add("mustn't", new List<string>() { "must", "not" });
            mTransformsDict.Add("haven't", new List<string>() { "have", "not" });
            mTransformsDict.Add("don't", new List<string>() { "do", "not" });
            mTransformsDict.Add("doesn't", new List<string>() { "does", "not" });
            mTransformsDict.Add("didn't", new List<string>() { "did", "not" });
            mTransformsDict.Add("isn't", new List<string>() { "is", "not" });
            mTransformsDict.Add("shouldn't", new List<string>() { "should", "not" });
            mTransformsDict.Add("wouldn't", new List<string>() { "would", "not" });
            mTransformsDict.Add("oughtn't", new List<string>() { "ought", "not" });
            //mTransformsDict.Add("there's", new List<string>() { "there", "is"});
            //mTransformsDict.Add(, new List<string>() { , });
        }

        private Dictionary<string, List<string>> mTransformsDict = new Dictionary<string, List<string>>();

        private bool IsTransformed(string word)
        {
#if DEBUG
            //LogInstance.Log($"word = {word}");
#endif

            if (mTransformsDict.ContainsKey(word))
            {
                return true;
            }

            return false;
        }

        private string GetTransformedContent(string word)
        {
            if (mTransformsDict.ContainsKey(word))
            {
                var list = mTransformsDict[word];

                var result = list.First();

                list = list.Skip(1).ToList();

                foreach(var item in list)
                {
                    var newToken = new ATNToken();
                    newToken.Kind = KindOfATNToken.Word;
                    newToken.Content = item;

                    mLexer.Recovery(newToken);
                }

                return result;
            }

            return string.Empty;
        }

        public IList<ATNExtendedToken> GetСlusterOfExtendedTokens()
        {
            lock (mLockObj)
            {
                if (mRecoveriesTokens.Count > 0)
                {
                    return mRecoveriesTokens.Dequeue();
                }

                var token = mLexer.GetToken();

#if DEBUG
                //LogInstance.Log($"token = {token}");
#endif

                if (token == null)
                {
                    return null;
                }

                var result = new List<ATNExtendedToken>();

                var tokenKind = token.Kind;

                if(tokenKind == KindOfATNToken.Word)
                {
                    var content = token.Content;

                    if(content.EndsWith("'ll"))
                    {
                        token.Content = token.Content.Replace("'ll", string.Empty);

                        var newToken = new ATNToken();
                        newToken.Kind = KindOfATNToken.Word;
                        newToken.Content = "will";

                        mLexer.Recovery(newToken);

                        return ProcessWordToken(token);
                    }
                    else
                    {
                        if(IsTransformed(content))
                        {
                            token.Content = GetTransformedContent(content);
                            return ProcessWordToken(token);
                        }
                        else
                        {
                            var tmpContent = content.ToLower();

                            if (IsTransformed(tmpContent))
                            {
                                token.Content = GetTransformedContent(tmpContent);
                                return ProcessWordToken(token);
                            }
                            else
                            {
                                if (content.EndsWith("'s"))
                                {
                                    var resultsList = ProcessWordToken(token);

#if DEBUG
                                    LogInstance.Log($"resultsList.Count = {resultsList.Count}");
#endif

                                    if (resultsList.Any(p => p.PartOfSpeech == GrammaticalPartOfSpeech.Noun && p.IsPossessive == true))
                                    {
                                        return resultsList;
                                    }
                                    else
                                    {
                                        content = content.ToLower();

                                        if (IsTransformed(content))
                                        {
                                            token.Content = GetTransformedContent(content);
                                            return ProcessWordToken(token);
                                        }
                                        else
                                        {
                                            token.Content = content.Replace("'s", string.Empty);

                                            var newToken = new ATNToken();
                                            newToken.Kind = KindOfATNToken.Word;
                                            newToken.Content = "is";

                                            mLexer.Recovery(newToken);

                                            return ProcessWordToken(token);
                                        }
                                    }
                                }
                                else
                                {
                                    if(content.EndsWith("'ve"))
                                    {
                                        token.Content = token.Content.Replace("'ve", string.Empty);

                                        var newToken = new ATNToken();
                                        newToken.Kind = KindOfATNToken.Word;
                                        newToken.Content = "have";

                                        mLexer.Recovery(newToken);

                                        return ProcessWordToken(token);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    result.Add(CreateExtendToken(token));
                    return FillKindOfItem(result);
                }

                return ProcessWordToken(token);
            }
        }

        private IList<ATNExtendedToken> ProcessWordToken(ATNToken token)
        {
            var result = new List<ATNExtendedToken>();

            var tokenContent = token.Content;

#if DEBUG
            //LogInstance.Log($"token = {token}");
            //LogInstance.Log($"tokenContent = {tokenContent}");
#endif

            //if (!mWordsDict.IsName(tokenContent))
            //{
            //    tokenContent = tokenContent.ToLower();
            //}

            var wordFrame = GetWordFrame(tokenContent);

            //var wordFrame = mWordsDict.GetWordFrame(tokenContent);
            
#if DEBUG
            //LogInstance.Log($"wordFrame = {wordFrame}");
#endif

            if (wordFrame == null || wordFrame.GrammaticalWordFrames.IsEmpty())
            {
                result.Add(CreateExtendToken(token));
                return result;
            }

            foreach (var grammaticalWordFrame in wordFrame.GrammaticalWordFrames)
            {
                var extendedToken = CreateExtendToken(token, grammaticalWordFrame);
                result.Add(extendedToken);
            }

            return FillKindOfItem(result);
        }

        private IList<ATNExtendedToken> FillKindOfItem(IList<ATNExtendedToken> sourceList)
        {
            var result = new List<ATNExtendedToken>();

            foreach(var extendedToken in sourceList)
            {
#if DEBUG
                //LogInstance.Log($"extendedToken = {extendedToken}");
#endif

                if (extendedToken.Kind != KindOfATNToken.Word)
                {
                    var kind = extendedToken.Kind;

                    switch(kind)
                    {
                        case KindOfATNToken.Point:
                            extendedToken.KindOfItem = KindOfItemOfSentence.Point;
                            result.Add(extendedToken);
                            continue;

                        case KindOfATNToken.QuestionMark:
                            extendedToken.KindOfItem = KindOfItemOfSentence.QuestionMark;
                            result.Add(extendedToken);
                            continue;

                        default:
                            throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
                    }                
                }

                var partOfSpeech = extendedToken.PartOfSpeech;

                switch (partOfSpeech)
                {
                    case GrammaticalPartOfSpeech.Noun:
                        {
                            extendedToken.KindOfItem = KindOfItemOfSentence.Subj;
                            result.Add(extendedToken);

                            var newExtendedToken = extendedToken.Fork();
                            newExtendedToken.KindOfItem = KindOfItemOfSentence.Obj;
                            result.Add(newExtendedToken);
                        }
                        break;

                    case GrammaticalPartOfSpeech.Pronoun:
                        {
                            if(extendedToken.IsQuestionWord)
                            {
                                throw new NotImplementedException();
                            }
                            else
                            {
                                if(extendedToken.TypeOfPronoun == TypeOfPronoun.Personal)
                                {
                                    extendedToken.KindOfItem = KindOfItemOfSentence.Subj;
                                    result.Add(extendedToken);
                                    continue;
                                }

                                throw new NotImplementedException();
                            }                        
                        }
                        //break;

                    case GrammaticalPartOfSpeech.Adjective:
                        throw new NotImplementedException();

                    case GrammaticalPartOfSpeech.Verb:
                        {
                            if (extendedToken.IsGerund)
                            {
                                extendedToken.KindOfItem = KindOfItemOfSentence.Ving;
                                result.Add(extendedToken);

                                var newExtendedToken = extendedToken.Fork();
                                newExtendedToken.KindOfItem = KindOfItemOfSentence.Subj;
                                result.Add(newExtendedToken);

                                newExtendedToken = extendedToken.Fork();
                                newExtendedToken.KindOfItem = KindOfItemOfSentence.Obj;
                                result.Add(newExtendedToken);

                                var content = extendedToken.Content;

                                if(content == "being")
                                {
                                    newExtendedToken = extendedToken.Fork();
                                    newExtendedToken.KindOfItem = KindOfItemOfSentence.Being;
                                    result.Add(newExtendedToken);
                                }
                            }
                            else
                            {
                                if(extendedToken.IsModal)
                                {
                                    extendedToken.KindOfItem = KindOfItemOfSentence.ModalVerb;
                                    result.Add(extendedToken);
                                }
                                else
                                {
                                    var verbType = extendedToken.VerbType;

                                    if(extendedToken.IsFormOfToDo)
                                    {
                                        switch (verbType)
                                        {
                                            case VerbType.BaseForm:
                                                extendedToken.KindOfItem = KindOfItemOfSentence.Verb;
                                                result.Add(extendedToken);
                                                break;

                                            case VerbType.Form_2:
                                                extendedToken.KindOfItem = KindOfItemOfSentence.Verb;
                                                result.Add(extendedToken);
                                                break;

                                            case VerbType.Form_3:
                                                extendedToken.KindOfItem = KindOfItemOfSentence.V3;
                                                result.Add(extendedToken);
                                                break;
                                        }

                                        var newExtendedToken = extendedToken.Fork();
                                        newExtendedToken.KindOfItem = KindOfItemOfSentence.FToDo;
                                        result.Add(newExtendedToken);
                                    }
                                    else
                                    {
                                        if(extendedToken.IsFormOfToHave)
                                        {
                                            switch (verbType)
                                            {
                                                case VerbType.BaseForm:
                                                    extendedToken.KindOfItem = KindOfItemOfSentence.Verb;
                                                    result.Add(extendedToken);
                                                    break;

                                                case VerbType.Form_2:
                                                    extendedToken.KindOfItem = KindOfItemOfSentence.Verb;
                                                    result.Add(extendedToken);
                                                    break;

                                                case VerbType.Form_3:
                                                    extendedToken.KindOfItem = KindOfItemOfSentence.V3;
                                                    result.Add(extendedToken);
                                                    break;
                                            }

                                            var newExtendedToken = extendedToken.Fork();
                                            newExtendedToken.KindOfItem = KindOfItemOfSentence.FToHave;
                                            result.Add(newExtendedToken);
                                        }
                                        else
                                        {
                                            if(extendedToken.Tense == GrammaticalTenses.Future)
                                            {
                                                extendedToken.KindOfItem = KindOfItemOfSentence.Will;
                                                result.Add(extendedToken);
                                            }
                                            else
                                            {
                                                if (extendedToken.IsFormOfToBe)
                                                {
                                                    var content = extendedToken.Content;

                                                    if (content == "be")
                                                    {
                                                        extendedToken.KindOfItem = KindOfItemOfSentence.Be;
                                                        result.Add(extendedToken);

                                                        var newExtendedToken = extendedToken.Fork();
                                                        newExtendedToken.KindOfItem = KindOfItemOfSentence.Verb;
                                                        result.Add(newExtendedToken);
                                                    }
                                                    else
                                                    {
                                                        if (content == "been")
                                                        {
                                                            extendedToken.KindOfItem = KindOfItemOfSentence.Been;
                                                            result.Add(extendedToken);

                                                            var newExtendedToken = extendedToken.Fork();
                                                            newExtendedToken.KindOfItem = KindOfItemOfSentence.V3;
                                                            result.Add(newExtendedToken);
                                                        }
                                                        else
                                                        {
                                                            extendedToken.KindOfItem = KindOfItemOfSentence.FToBe;
                                                            result.Add(extendedToken);

                                                            var newExtendedToken = extendedToken.Fork();
                                                            newExtendedToken.KindOfItem = KindOfItemOfSentence.Verb;
                                                            result.Add(newExtendedToken);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    switch (verbType)
                                                    {
                                                        case VerbType.BaseForm:
                                                            extendedToken.KindOfItem = KindOfItemOfSentence.Verb;
                                                            result.Add(extendedToken);
                                                            break;

                                                        case VerbType.Form_2:
                                                            extendedToken.KindOfItem = KindOfItemOfSentence.Verb;
                                                            result.Add(extendedToken);
                                                            break;

                                                        case VerbType.Form_3:
                                                            extendedToken.KindOfItem = KindOfItemOfSentence.V3;
                                                            result.Add(extendedToken);
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case GrammaticalPartOfSpeech.Adverb:
                        {
                            var content = extendedToken.Content;

                            if(content == "not")
                            {
                                extendedToken.KindOfItem = KindOfItemOfSentence.Not;
                                result.Add(extendedToken);
                            }
                            else
                            {
                                extendedToken.KindOfItem = KindOfItemOfSentence.Condition;
                                result.Add(extendedToken);
                            }
                        }
                        break;

                    case GrammaticalPartOfSpeech.Preposition:
                        {
                            extendedToken.KindOfItem = KindOfItemOfSentence.Condition;
                            result.Add(extendedToken);
                        }
                        break;

                    case GrammaticalPartOfSpeech.Postposition:
                        throw new NotImplementedException();

                    case GrammaticalPartOfSpeech.Conjunction:
                        throw new NotImplementedException();

                    case GrammaticalPartOfSpeech.Interjection:
                        throw new NotImplementedException();

                    case GrammaticalPartOfSpeech.Article:
                        {
                            extendedToken.KindOfItem = KindOfItemOfSentence.Subj;
                            result.Add(extendedToken);

                            var newExtendedToken = extendedToken.Fork();
                            newExtendedToken.KindOfItem = KindOfItemOfSentence.Obj;
                            result.Add(newExtendedToken);
                        }
                        break;

                    case GrammaticalPartOfSpeech.Numeral:
                        throw new NotImplementedException();

                    default:
                        throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
                }
            }

            return result;
        }

        private WordFrame GetWordFrame(string content)
        {
            var wordFrame = mWordsDict.GetWordFrame(content);

            if(wordFrame == null)
            {
                content = content.ToLower();
                wordFrame = mWordsDict.GetWordFrame(content);
            }

            return wordFrame;
        }

        private ATNExtendedToken CreateExtendToken(ATNToken sourceToken)
        {
            var result = new ATNExtendedToken();
            result.Kind = sourceToken.Kind;
            result.Content = sourceToken.Content;
            result.Pos = sourceToken.Pos;
            result.Line = sourceToken.Line;
            return result;
        }

        private ATNExtendedToken CreateExtendToken(ATNToken sourceToken, BaseGrammaticalWordFrame grammaticalWordFrame)
        {
            var partOfSpeech = grammaticalWordFrame.PartOfSpeech;

            switch(partOfSpeech)
            {
                case GrammaticalPartOfSpeech.Noun:
                    return CreateNounExtendToken(sourceToken, grammaticalWordFrame.AsNoun);

                case GrammaticalPartOfSpeech.Pronoun:
                    return CreatePronounExtendToken(sourceToken, grammaticalWordFrame.AsPronoun);

                case GrammaticalPartOfSpeech.Adjective:
                    return CreateAdjectiveExtendToken(sourceToken, grammaticalWordFrame.AsAdjective);

                case GrammaticalPartOfSpeech.Verb:
                    return CreateVerbExtendToken(sourceToken, grammaticalWordFrame.AsVerb);

                case GrammaticalPartOfSpeech.Adverb:
                    return CreateAdverbExtendToken(sourceToken, grammaticalWordFrame.AsAdverb);

                case GrammaticalPartOfSpeech.Preposition:
                    return CreatePrepositionExtendToken(sourceToken, grammaticalWordFrame.AsPreposition);

                case GrammaticalPartOfSpeech.Conjunction:
                    return CreateConjunctionExtendToken(sourceToken, grammaticalWordFrame.AsConjunction);

                case GrammaticalPartOfSpeech.Interjection:
                    return CreateInterjectionExtendToken(sourceToken, grammaticalWordFrame.AsInterjection);

                case GrammaticalPartOfSpeech.Article:
                    return CreateArticleExtendToken(sourceToken, grammaticalWordFrame.AsArticle);

                case GrammaticalPartOfSpeech.Numeral:
                    return CreateNumeralExtendToken(sourceToken, grammaticalWordFrame.AsNumeral);

                default:
                    return null;
            }
        }

        private ATNExtendedToken CreateNounExtendToken(ATNToken sourceToken, NounGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            result.IsName = grammaticalWordFrame.IsName;
            result.IsShortForm = grammaticalWordFrame.IsShortForm;
            result.Gender = grammaticalWordFrame.Gender;
            result.Number = grammaticalWordFrame.Number;
            result.IsCountable = grammaticalWordFrame.IsCountable;
            result.IsGerund = grammaticalWordFrame.IsGerund;
            result.IsPossessive = grammaticalWordFrame.IsPossessive;
            return result;
        }

        private ATNExtendedToken CreatePronounExtendToken(ATNToken sourceToken, PronounGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            result.Gender = grammaticalWordFrame.Gender;
            result.Number = grammaticalWordFrame.Number;
            result.Person = grammaticalWordFrame.Person;
            result.TypeOfPronoun = grammaticalWordFrame.TypeOfPronoun;
            result.CaseOfPersonalPronoun = grammaticalWordFrame.Case;
            result.IsQuestionWord = grammaticalWordFrame.IsQuestionWord;
            return result;
        }

        private ATNExtendedToken CreateAdjectiveExtendToken(ATNToken sourceToken, AdjectiveGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            result.Comparison = grammaticalWordFrame.Comparison;
            result.IsDeterminer = grammaticalWordFrame.IsDeterminer;
            return result;
        }

        private ATNExtendedToken CreateVerbExtendToken(ATNToken sourceToken, VerbGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            result.VerbType = grammaticalWordFrame.VerbType;
            result.Number = grammaticalWordFrame.Number;
            result.Person = grammaticalWordFrame.Person;
            result.Tense = grammaticalWordFrame.Tense;
            result.IsModal = grammaticalWordFrame.IsModal;
            result.IsFormOfToBe = grammaticalWordFrame.IsFormOfToBe;
            result.IsFormOfToHave = grammaticalWordFrame.IsFormOfToHave;
            result.IsFormOfToDo = grammaticalWordFrame.IsFormOfToDo;
            return result;
        }

        private ATNExtendedToken CreateAdverbExtendToken(ATNToken sourceToken, AdverbGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            result.Comparison = grammaticalWordFrame.Comparison;
            result.IsQuestionWord = grammaticalWordFrame.IsQuestionWord;
            result.IsDeterminer = grammaticalWordFrame.IsDeterminer;
            return result;
        }

        private ATNExtendedToken CreatePrepositionExtendToken(ATNToken sourceToken, PrepositionGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            return result;
        }

        private ATNExtendedToken CreateConjunctionExtendToken(ATNToken sourceToken, ConjunctionGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            return result;
        }

        private ATNExtendedToken CreateInterjectionExtendToken(ATNToken sourceToken, InterjectionGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            return result;
        }

        private ATNExtendedToken CreateArticleExtendToken(ATNToken sourceToken, ArticleGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            result.Number = grammaticalWordFrame.Number;
            result.IsDeterminer = grammaticalWordFrame.IsDeterminer;
            return result;
        }

        private ATNExtendedToken CreateNumeralExtendToken(ATNToken sourceToken, NumeralGrammaticalWordFrame grammaticalWordFrame)
        {
            var result = CreateExtendToken(sourceToken);
            FillBaseGrammaticalWordFrame(grammaticalWordFrame, result);
            result.NumeralType = grammaticalWordFrame.NumeralType;
            return result;
        }

        private void FillBaseGrammaticalWordFrame(BaseGrammaticalWordFrame source, ATNExtendedToken dest)
        {
            dest.PartOfSpeech = source.PartOfSpeech;
            dest.LogicalMeaning = source.LogicalMeaning;
            dest.FullLogicalMeaning = source.FullLogicalMeaning;
            dest.RootWord = source.RootWord;
        }

        public void Recovery(IList<ATNExtendedToken> tokensList)
        {
            lock (mLockObj)
            {
                mRecoveriesTokens.Enqueue(tokensList);
            }
        }
    }
}
