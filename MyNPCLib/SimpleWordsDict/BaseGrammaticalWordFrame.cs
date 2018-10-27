﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    [Serializable]
    public abstract class BaseGrammaticalWordFrame : IObjectToString
    {
        public abstract GrammaticalPartOfSpeech PartOfSpeech { get; }
        public virtual bool IsNoun => false;
        public virtual NounGrammaticalWordFrame AsNoun => null;
        public virtual bool IsPronoun => false;
        public virtual PronounGrammaticalWordFrame AsPronoun => null;
        public virtual bool IsAdjective => false;
        public virtual AdjectiveGrammaticalWordFrame AsAdjective => null;
        public virtual bool IsVerb => false;
        public virtual VerbGrammaticalWordFrame AsVerb => null;
        public virtual bool IsAdverb => false;
        public virtual AdverbGrammaticalWordFrame AsAdverb => null;
        public virtual bool IsPreposition => false;
        public virtual PrepositionGrammaticalWordFrame AsPreposition => null;
        public virtual bool IsPostposition => false;
        public virtual PostpositionGrammaticalWordFrame AsPostposition => null;
        public virtual bool IsConjunction => false;
        public virtual ConjunctionGrammaticalWordFrame AsConjunction => null;
        public virtual bool IsInterjection => false;
        public virtual InterjectionGrammaticalWordFrame AsInterjection => null;
        public virtual bool IsArticle => false;
        public virtual ArticleGrammaticalWordFrame AsArticle => null;
        public virtual bool IsNumeral => false;
        public virtual NumeralGrammaticalWordFrame AsNumeral => null;
        public string RootWord { get; set; }
        public IList<string> LogicalMeaning { get; set; }
        public IList<string> FullLogicalMeaning { get; set; }
        public IDictionary<string, IList<string>> ConditionalLogicalMeaning { get; set; }
        public bool IsArchaic { get; set; }
        public bool IsDialectal { get; set; }
        public bool IsPoetic { get; set; }
        public bool IsAbbreviation { get; set; }
        public bool IsRare { get; set; }

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public virtual string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var nextNSpaces = StringHelper.Spaces(nextN);
            var nextNextN = nextN + 4;
            var nextNextNSpaces = StringHelper.Spaces(nextNextN);
            var nextNextNextN = nextNextN + 4;
            var nextNextNextNSpaces = StringHelper.Spaces(nextNextNextN);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(PartOfSpeech)} = {PartOfSpeech}");
            sb.AppendLine($"{spaces}{nameof(RootWord)} = {RootWord}");

            if (LogicalMeaning == null)
            {
                sb.AppendLine($"{spaces}{nameof(LogicalMeaning)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(LogicalMeaning)}");
                foreach (var item in LogicalMeaning)
                {
                    sb.AppendLine($"{nextNSpaces}{item}");
                }
                sb.AppendLine($"{spaces}End {nameof(LogicalMeaning)}");
            }

            if (FullLogicalMeaning == null)
            {
                sb.AppendLine($"{spaces}{nameof(FullLogicalMeaning)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(FullLogicalMeaning)}");
                foreach (var item in FullLogicalMeaning)
                {
                    sb.AppendLine($"{nextNSpaces}{item}");
                }
                sb.AppendLine($"{spaces}End {nameof(FullLogicalMeaning)}");
            }

            if(ConditionalLogicalMeaning == null)
            {
                sb.AppendLine($"{spaces}{nameof(ConditionalLogicalMeaning)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ConditionalLogicalMeaning)}");
                foreach(var kvpItems in ConditionalLogicalMeaning)
                {
                    sb.AppendLine($"{nextNSpaces}Begin Item");
                    sb.AppendLine($"{nextNextNSpaces}Key = {kvpItems.Key}");
                    sb.AppendLine($"{nextNextNSpaces}Begin Meanings");
                    var meaningsList = kvpItems.Value;
                    foreach(var meaning in meaningsList)
                    {
                        sb.AppendLine($"{nextNextNextNSpaces}{meaning}");
                    }
                    sb.AppendLine($"{nextNextNSpaces}End Meanings");
                    sb.AppendLine($"{nextNSpaces}End Item");
                }
                sb.AppendLine($"{spaces}End {nameof(ConditionalLogicalMeaning)}");
            }

            sb.AppendLine($"{spaces}{nameof(IsArchaic)} = {IsArchaic}");
            sb.AppendLine($"{spaces}{nameof(IsDialectal)} = {IsDialectal}");
            sb.AppendLine($"{spaces}{nameof(IsPoetic)} = {IsPoetic}");
            sb.AppendLine($"{spaces}{nameof(IsAbbreviation)} = {IsAbbreviation}");
            sb.AppendLine($"{spaces}{nameof(IsRare)} = {IsRare}");

            return sb.ToString();
        }
    }
}
