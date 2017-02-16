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
            PresentKey = DataDictionary.GetKey("present");
            PastKey = DataDictionary.GetKey("past");
            FutureKey = DataDictionary.GetKey("future");
            FutureInThePastKey = DataDictionary.GetKey("future in the past");           
        }

        public ulong PresentKey = 0;
        public ulong PastKey = 0;
        public ulong FutureKey = 0;
        public ulong FutureInThePastKey = 0;

        public GrammaticalTenses KeyToTense(ulong key)
        {
            if(key == PresentKey)
            {
                return GrammaticalTenses.Present;
            }

            if (key == PastKey)
            {
                return GrammaticalTenses.Past;
            }

            if (key == FutureKey)
            {
                return GrammaticalTenses.Future;
            }

            if (key == FutureInThePastKey)
            {
                return GrammaticalTenses.FutureInThePast;
            }

            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }
        #endregion

        #region GrammaticalComparison
        private void InitGrammaticalComparison()
        {
            NoneKey = DataDictionary.GetKey("none");
            ComparativeKey = DataDictionary.GetKey("comparative");
            SuperlativeKey = DataDictionary.GetKey("superlative");
        }

        public ulong NoneKey = 0;
        public ulong ComparativeKey = 0;
        public ulong SuperlativeKey = 0;

        public GrammaticalComparison KeyToComparison(ulong key)
        {
            if (key == NoneKey)
            {
                return GrammaticalComparison.None;
            }

            if (key == ComparativeKey)
            {
                return GrammaticalComparison.Comparative;
            }

            if (key == SuperlativeKey)
            {
                return GrammaticalComparison.Superlative;
            }

            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }
        #endregion

        #region GrammaticalGender
        private void InitGrammaticalGender()
        {
            MasculineKey = DataDictionary.GetKey("masculine");
            FeminineKey = DataDictionary.GetKey("feminine");
            NeuterKey = DataDictionary.GetKey("neuter");
        }

        public ulong MasculineKey = 0;
        public ulong FeminineKey = 0;
        public ulong NeuterKey = 0; 
        
        public GrammaticalGender KeyToGender(ulong key)
        {
            if (key == MasculineKey)
            {
                return GrammaticalGender.Masculine;
            }

            if (key == FeminineKey)
            {
                return GrammaticalGender.Feminine;
            }

            if (key == NeuterKey)
            {
                return GrammaticalGender.Neuter;
            }

            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }
        #endregion

        #region CaseOfPersonalPronoun
        private void InitCaseOfPersonalPronoun()
        {
            SubjectKey = DataDictionary.GetKey("subject");
            ObjectKey = DataDictionary.GetKey("object");
        }

        public ulong SubjectKey = 0;
        public ulong ObjectKey = 0;

        public CaseOfPersonalPronoun KeyToCaseOfPersonalPronoun(ulong key)
        {
            if (key == SubjectKey)
            {
                return CaseOfPersonalPronoun.Subject;
            }

            if (key == ObjectKey)
            {
                return CaseOfPersonalPronoun.Object;
            }

            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }
        #endregion

        #region TypeOfPronoun
        private void InitTypeOfPronoun()
        {
            PersonalKey = DataDictionary.GetKey("personal");
            ReflexiveKey = DataDictionary.GetKey("reflexive");
            PossessiveKey = DataDictionary.GetKey("possessive");
            DemonstrativeKey = DataDictionary.GetKey("demonstrative");
            IndefiniteKey = DataDictionary.GetKey("indefinite");
            RelativeKey = DataDictionary.GetKey("relative");
            InterrogativeKey = DataDictionary.GetKey("interrogative");
        }

        public ulong PersonalKey = 0;
        public ulong ReflexiveKey = 0;
        public ulong PossessiveKey = 0;
        public ulong DemonstrativeKey = 0;
        public ulong IndefiniteKey = 0;
        public ulong RelativeKey = 0;
        public ulong InterrogativeKey = 0;

        public TypeOfPronoun KeyToTypeOfPronoun(ulong key)
        {
            if (key == PersonalKey)
            {
                return TypeOfPronoun.Personal;
            }

            if (key == ReflexiveKey)
            {
                return TypeOfPronoun.Reflexive;
            }

            if (key == PossessiveKey)
            {
                return TypeOfPronoun.Possessive;
            }

            if (key == DemonstrativeKey)
            {
                return TypeOfPronoun.Demonstrative;
            }

            if (key == IndefiniteKey)
            {
                return TypeOfPronoun.Indefinite;
            }

            if (key == RelativeKey)
            {
                return TypeOfPronoun.Relative;
            }

            if (key == InterrogativeKey)
            {
                return TypeOfPronoun.Interrogative;
            }
            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }
        #endregion

        #region GrammaticalPerson
        private void InitGrammaticalPerson()
        {
            FirstKey = DataDictionary.GetKey("first");
            SecondKey = DataDictionary.GetKey("second");
            ThirdKey = DataDictionary.GetKey("third");
        }

        public ulong FirstKey = 0;
        public ulong SecondKey = 0;
        public ulong ThirdKey = 0;

        public GrammaticalPerson KeyToPerson(ulong key)
        {
            if (key == FirstKey)
            {
                return GrammaticalPerson.First;
            }

            if (key == SecondKey)
            {
                return GrammaticalPerson.Second;
            }

            if (key == ThirdKey)
            {
                return GrammaticalPerson.Third;
            }

            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }
        #endregion

        #region VerbType
        private void InitVerbType()
        {
            BaseFormKey = DataDictionary.GetKey("base form");
            Form_2Key = DataDictionary.GetKey("form 2");
            Form_3Key = DataDictionary.GetKey("form 3");
            IngFormKey = DataDictionary.GetKey("ing-form");
        }

        public ulong BaseFormKey = 0;
        public ulong Form_2Key = 0;
        public ulong Form_3Key = 0;
        public ulong IngFormKey = 0;

        public VerbType KeyToVerbType(ulong key)
        {
            if (key == BaseFormKey)
            {
                return VerbType.BaseForm;
            }

            if (key == Form_2Key)
            {
                return VerbType.Form_2;
            }

            if (key == Form_3Key)
            {
                return VerbType.Form_3;
            }

            if (key == IngFormKey)
            {
                return VerbType.IngForm;
            }

            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }
        #endregion

        #region NumeralType
        private void InitNumeralType()
        {
            CardinalKey = DataDictionary.GetKey("cardinal");
            OrdinalKey = DataDictionary.GetKey("ordinal");
        }

        public ulong CardinalKey = 0;
        public ulong OrdinalKey = 0;

        public NumeralType KeyToNumeralType(ulong key)
        {
            if (key == CardinalKey)
            {
                return NumeralType.Cardinal;
            }

            if (key == OrdinalKey)
            {
                return NumeralType.Ordinal;
            }

            throw new ArgumentOutOfRangeException(nameof(key), key.ToString());
        }
        #endregion
    }
}
