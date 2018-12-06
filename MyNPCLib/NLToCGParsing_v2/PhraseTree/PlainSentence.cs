using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class PlainSentence : IObjectToString, IShortObjectToString
    {
        public GrammaticalAspect Aspect { get; set; } = GrammaticalAspect.Undefined;
        public GrammaticalTenses Tense { get; set; } = GrammaticalTenses.Undefined;
        public GrammaticalVoice Voice { get; set; } = GrammaticalVoice.Undefined;
        public GrammaticalMood Mood { get; set; } = GrammaticalMood.Undefined;
        public KindOfModal Modal { get; set; } = KindOfModal.Undefined;
        public bool IsQuestion { get; set; }
        public bool IsNegation { get; set; }
        public NounPhrase_v2 NounPhrase { get; set; }
        public VerbPhrase_v2 VerbPhrase { get; set; }
        public List<BaseWordPhrase_v2> ConditionsList { get; set; } = new List<BaseWordPhrase_v2>();
        public List<BaseWordPhrase_v2> QuestionToObjectsList { get; set; } = new List<BaseWordPhrase_v2>();
        public List<NounPhrase_v2> VocativePhrasesList { get; set; } = new List<NounPhrase_v2>();

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(Aspect)} = {Aspect}");
            sb.AppendLine($"{spaces}{nameof(Tense)} = {Tense}");
            sb.AppendLine($"{spaces}{nameof(Voice)} = {Voice}");
            sb.AppendLine($"{spaces}{nameof(Modal)} = {Modal}");
            sb.AppendLine($"{spaces}{nameof(Mood)} = {Mood}");
            sb.AppendLine($"{spaces}{nameof(IsQuestion)} = {IsQuestion}");
            sb.AppendLine($"{spaces}{nameof(IsNegation)} = {IsNegation}");

            if (NounPhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(NounPhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NounPhrase)}");
                sb.Append(NounPhrase.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(NounPhrase)}");
            }

            if (VerbPhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(VerbPhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(VerbPhrase)}");
                sb.Append(VerbPhrase.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(VerbPhrase)}");
            }

            if (ConditionsList == null)
            {
                sb.AppendLine($"{spaces}{nameof(ConditionsList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ConditionsList)}");
                foreach (var condition in ConditionsList)
                {
                    sb.Append(condition.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(ConditionsList)}");
            }

            if (QuestionToObjectsList == null)
            {
                sb.AppendLine($"{spaces}{nameof(QuestionToObjectsList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(QuestionToObjectsList)}");
                foreach (var item in QuestionToObjectsList)
                {
                    sb.Append(item.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(QuestionToObjectsList)}");
            }

            if (VocativePhrasesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(VocativePhrasesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(VocativePhrasesList)}");
                foreach (var item in VocativePhrasesList)
                {
                    sb.Append(item.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(VocativePhrasesList)}");
            }
            return sb.ToString();
        }

        public string ToShortString()
        {
            return ToShortString(0u);
        }

        public string ToShortString(uint n)
        {
            return this.GetDefaultToShortStringInformation(n);
        }

        public string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(Aspect)} = {Aspect}");
            sb.AppendLine($"{spaces}{nameof(Tense)} = {Tense}");
            sb.AppendLine($"{spaces}{nameof(Voice)} = {Voice}");
            sb.AppendLine($"{spaces}{nameof(Modal)} = {Modal}");
            sb.AppendLine($"{spaces}{nameof(Mood)} = {Mood}");
            sb.AppendLine($"{spaces}{nameof(IsQuestion)} = {IsQuestion}");
            sb.AppendLine($"{spaces}{nameof(IsNegation)} = {IsNegation}");

            if (NounPhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(NounPhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NounPhrase)}");
                sb.Append(NounPhrase.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(NounPhrase)}");
            }

            if (VerbPhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(VerbPhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(VerbPhrase)}");
                sb.Append(VerbPhrase.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(VerbPhrase)}");
            }

            if (ConditionsList == null)
            {
                sb.AppendLine($"{spaces}{nameof(ConditionsList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ConditionsList)}");
                foreach (var condition in ConditionsList)
                {
                    sb.Append(condition.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(ConditionsList)}");
            }

            if (QuestionToObjectsList == null)
            {
                sb.AppendLine($"{spaces}{nameof(QuestionToObjectsList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(QuestionToObjectsList)}");
                foreach (var item in QuestionToObjectsList)
                {
                    sb.Append(item.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(QuestionToObjectsList)}");
            }

            if (VocativePhrasesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(VocativePhrasesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(VocativePhrasesList)}");
                foreach (var item in VocativePhrasesList)
                {
                    sb.Append(item.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(VocativePhrasesList)}");
            }
            return sb.ToString();
        }
    }
}
