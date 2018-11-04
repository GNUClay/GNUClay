using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing.PhraseTree
{
    public class Sentence : IObjectToString, IShortObjectToString, IRunTimeSessionKey
    {
        public Sentence(bool getKey = true)
        {
            if (getKey)
            {
                RunTimeSessionKey = RunTimeSessionKeyHelper.GeyKey();
            }
        }

        public ulong RunTimeSessionKey { get; set; }
        public GrammaticalAspect Aspect { get; set; } = GrammaticalAspect.Undefined;
        public GrammaticalTenses Tense { get; set; } = GrammaticalTenses.Undefined;
        public GrammaticalVoice Voice { get; set; } = GrammaticalVoice.Undefined;
        public GrammaticalMood Mood { get; set; } = GrammaticalMood.Undefined;
        public KindOfModal Modal { get; set; } = KindOfModal.Undefined;
        public bool IsQuestion { get; set; }
        public bool IsNegation { get; set; }
        public BaseNounLikePhrase NounPhrase { get; set; }
        public VerbPhrase VerbPhrase { get; set; }

        public T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node) where T: class, IRunTimeSessionKey
        {
            return GetByRunTimeSessionKey<T>(node.RunTimeSessionKey);
        }

        public T GetByRunTimeSessionKey<T>(ulong key) where T : class, IRunTimeSessionKey
        {
            if (NounPhrase != null)
            {
                if (NounPhrase.RunTimeSessionKey == key)
                {
                    object obj = NounPhrase;
                    return (T)obj;
                }

                var result = NounPhrase.GetByRunTimeSessionKey<T>(key);

                if (result != null)
                {
                    return result;
                }
            }

            if (VerbPhrase != null)
            {
                if (VerbPhrase.RunTimeSessionKey == key)
                {
                    object obj = VerbPhrase;
                    return (T)obj;
                }

                var result = VerbPhrase.GetByRunTimeSessionKey<T>(key);

                if (result != null)
                {
                    return result;
                }
            }

            return null;
        }

        public Sentence Fork()
        {
            var result = new Sentence(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Aspect = Aspect;
            result.Tense = Tense;
            result.Voice = Voice;
            result.Mood = Mood;
            result.Modal = Modal;
            result.IsQuestion = IsQuestion;
            result.IsNegation = IsNegation;

            result.NounPhrase = NounPhrase?.Fork();
            result.VerbPhrase = VerbPhrase?.Fork();
            return result;
        }

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(RunTimeSessionKey)} = {RunTimeSessionKey}");
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

        public string PropertiesToShortSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(Aspect)} = {Aspect}");
            sb.AppendLine($"{spaces}{nameof(Tense)} = {Tense}");
            sb.AppendLine($"{spaces}{nameof(Voice)} = {Voice}");
            sb.AppendLine($"{spaces}{nameof(Modal)} = {Modal}");
            sb.AppendLine($"{spaces}{nameof(Mood)} = {Mood}");
            if (NounPhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(NounPhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NounPhrase)}");
                sb.Append(NounPhrase.ToShortString(nextN));
                sb.AppendLine($"{spaces}End {nameof(NounPhrase)}");
            }
            if (VerbPhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(VerbPhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(VerbPhrase)}");
                sb.Append(VerbPhrase.ToShortString(nextN));
                sb.AppendLine($"{spaces}End {nameof(VerbPhrase)}");
            }
            return sb.ToString();
        }
    }
}
