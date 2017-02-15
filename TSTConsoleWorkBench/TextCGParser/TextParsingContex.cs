using GnuClay.Engine;
using GnuClay.Engine.CommonStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class TextParsingContex
    {
        public TextParsingContex(GnuClayEngine engine)
        {
            Engine = engine;
            DataDictionary = Engine.DataDictionary;

            InitPartOfSpeech();
            InitNumberOfWord();
            InitGrammaticalTenses();
            InitGrammaticalComparison();
            InitGrammaticalGender();
            InitCaseOfPersonalPronoun();
            InitTypeOfPronoun();
            InitGrammaticalPerson();
            InitVerbType();
            InitNumeralType();
        }

        public GnuClayEngine Engine = null;
        protected StorageDataDictionary DataDictionary = null;

        #region Root
        public ulong GetRoot(string content)
        {
            var queryStr = $"SELECT {{>: {{root({content}, $X)}}}}";

            var result = Engine.Query(queryStr);

            if (result.Success && result.HaveBeenFound)
            {
                return result.Items.First().Params.First().EntityKey;
            }

            return 0;
        }
        #endregion

        #region PartOfSpeech
        private void InitPartOfSpeech()
        {
            NounKey = DataDictionary.GetKey("noun");
            PronounKey = DataDictionary.GetKey("pronoun");
            AdjectiveKey = DataDictionary.GetKey("adjective");
            VerbKey = DataDictionary.GetKey("verb");
            AdverbKey = DataDictionary.GetKey("adverb");
            PrepositionKey = DataDictionary.GetKey("preposition");
            ConjunctionKey = DataDictionary.GetKey("conjunction");
            InterjectionKey = DataDictionary.GetKey("interjection");
            ArticleKey = DataDictionary.GetKey("article");
        }

        public ulong NounKey = 0;
        public ulong PronounKey = 0;
        public ulong AdjectiveKey = 0;
        public ulong VerbKey = 0;
        public ulong AdverbKey = 0;
        public ulong PrepositionKey = 0;
        public ulong ConjunctionKey = 0;
        public ulong InterjectionKey = 0;
        public ulong ArticleKey = 0;

        public GrammaticalPartOfSpeech KeyToPartOfSpeech(ulong key)
        {
            if (key == NounKey)
            {
                return GrammaticalPartOfSpeech.Noun;
            }

            if (key == PronounKey)
            {
                return GrammaticalPartOfSpeech.Pronoun;
            }

            if (key == AdjectiveKey)
            {
                return GrammaticalPartOfSpeech.Adjective;
            }

            if (key == VerbKey)
            {
                return GrammaticalPartOfSpeech.Verb;
            }

            if (key == AdverbKey)
            {
                return GrammaticalPartOfSpeech.Adverb;
            }

            if (key == PrepositionKey)
            {
                return GrammaticalPartOfSpeech.Preposition;
            }

            if (key == ConjunctionKey)
            {
                return GrammaticalPartOfSpeech.Conjunction;
            }

            if (key == InterjectionKey)
            {
                return GrammaticalPartOfSpeech.Interjection;
            }

            if (key == ArticleKey)
            {
                return GrammaticalPartOfSpeech.Article;
            }

            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }

        public List<GrammaticalPartOfSpeech> KeyListToPartOfSpeech(List<ulong> keys)
        {
            var result = new List<GrammaticalPartOfSpeech>();

            foreach (var item in keys)
            {
                result.Add(KeyToPartOfSpeech(item));
            }

            return result;
        }

        public List<GrammaticalPartOfSpeech> GetPartOfSpeech(string content)
        {
            var queryStr = $"SELECT {{>: {{`part of speech`({content}, $X)}}}}";

            var queryResult = Engine.Query(queryStr);

            if (queryResult.Success && queryResult.HaveBeenFound)
            {
                var result = new List<GrammaticalPartOfSpeech>();

                foreach (var item in queryResult.Items)
                {
                    result.Add(KeyToPartOfSpeech(item.Params.First().EntityKey));
                }

                return result;
            }

            return new List<GrammaticalPartOfSpeech>();
        }
        #endregion

        #region NumberOfWord
        private void InitNumberOfWord()
        {
            SingularKey = DataDictionary.GetKey("singular");
            PluralKey = DataDictionary.GetKey("plural");
        }

        public ulong SingularKey = 0;
        public ulong PluralKey = 0;

        public GrammaticalNumberOfWord KeyToNumberOfWord(ulong key)
        {
            if(key == SingularKey)
            {
                return GrammaticalNumberOfWord.Singular;
            }

            if (key == PluralKey)
            {
                return GrammaticalNumberOfWord.Plural;
            }

            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }

        public List<GrammaticalNumberOfWord> KeyListToNumberOfWord(List<ulong> keys)
        {
            var result = new List<GrammaticalNumberOfWord>();

            foreach (var item in keys)
            {
                result.Add(KeyToNumberOfWord(item));
            }

            return result;
        }

        public List<GrammaticalNumberOfWord> GetNumbers(string content)
        {
            var queryStr = $"SELECT {{>: {{number({content}, $X)}}}}";

            var queryResult = Engine.Query(queryStr);

            if (queryResult.Success && queryResult.HaveBeenFound)
            {
                var result = new List<GrammaticalNumberOfWord>();

                foreach (var item in queryResult.Items)
                {
                    result.Add(KeyToNumberOfWord(item.Params.First().EntityKey));
                }

                return result;
            }

            return new List<GrammaticalNumberOfWord>();
        }
        #endregion

        #region GrammaticalTenses
        private void InitGrammaticalTenses()
        {

        }

        /*
                Present,
        Past,
        Future,
        FutureInThePast
        */
        #endregion

        #region GrammaticalComparison
        private void InitGrammaticalComparison()
        {

        }

        /*
                None,
        Comparative,
        Superlative
        */
        #endregion

        #region GrammaticalGender
        private void InitGrammaticalGender()
        {

        }
        #endregion

        #region CaseOfPersonalPronoun
        private void InitCaseOfPersonalPronoun()
        {

        }
        #endregion

        #region TypeOfPronoun
        private void InitTypeOfPronoun()
        {

        }
        #endregion

        #region GrammaticalPerson
        private void InitGrammaticalPerson()
        {

        }
        #endregion

        #region VerbType
        private void InitVerbType()
        {

        }
        #endregion

        #region NumeralType
        private void InitNumeralType()
        {

        }
        #endregion
    }
}
