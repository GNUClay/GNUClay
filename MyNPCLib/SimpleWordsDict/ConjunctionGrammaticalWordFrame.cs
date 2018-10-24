using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    [Serializable]
    public class ConjunctionGrammaticalWordFrame: BaseGrammaticalWordFrame
    {
        public override GrammaticalPartOfSpeech PartOfSpeech => GrammaticalPartOfSpeech.Conjunction;
        public override bool IsConjunction => true;
        public override ConjunctionGrammaticalWordFrame AsConjunction => this;
        public KindOfConjunction Kind { get; set; } = KindOfConjunction.Unknown;
        public SecondKindOfConjunction SecondKind { get; set; } = SecondKindOfConjunction.Unknown;
        public bool IsQuestionWord { get; set; }
        public bool IsNegation { get; set; }

        public override string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToSting(n));
            sb.AppendLine($"{spaces}{nameof(Kind)} = {Kind}");
            sb.AppendLine($"{spaces}{nameof(SecondKind)} = {SecondKind}");
            sb.AppendLine($"{spaces}{nameof(IsQuestionWord)} = {IsQuestionWord}");
            sb.AppendLine($"{spaces}{nameof(IsNegation)} = {IsNegation}");
            return sb.ToString();
        }
    }
}
