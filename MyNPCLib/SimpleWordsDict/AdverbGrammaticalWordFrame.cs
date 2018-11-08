﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    [Serializable]
    public class AdverbGrammaticalWordFrame : BaseGrammaticalWordFrame
    {
        public override GrammaticalPartOfSpeech PartOfSpeech => GrammaticalPartOfSpeech.Adverb;
        public override bool IsAdverb => true;
        public override AdverbGrammaticalWordFrame AsAdverb => this;
        public GrammaticalComparison Comparison { get; set; } = GrammaticalComparison.None;
        public bool IsQuestionWord { get; set; }
        public bool IsDeterminer { get; set; }
        public bool IsNegation { get; set; }

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToString(n));
            sb.AppendLine($"{spaces}{nameof(Comparison)} = {Comparison}");
            sb.AppendLine($"{spaces}{nameof(IsQuestionWord)} = {IsQuestionWord}");
            sb.AppendLine($"{spaces}{nameof(IsDeterminer)} = {IsDeterminer}");
            sb.AppendLine($"{spaces}{nameof(IsNegation)} = {IsNegation}");
            return sb.ToString();
        }
    }
}
