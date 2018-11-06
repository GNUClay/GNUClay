﻿using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class Sentence_v2 : BasePhrase_v2
    {
        public Sentence_v2(bool getKey = true)
            : base(getKey)
        {
        }

        public override bool IsSentence => true;
        public override Sentence_v2 AsSentence => this;

        public GrammaticalAspect Aspect { get; set; } = GrammaticalAspect.Undefined;
        public GrammaticalTenses Tense { get; set; } = GrammaticalTenses.Undefined;
        public GrammaticalVoice Voice { get; set; } = GrammaticalVoice.Undefined;
        public GrammaticalMood Mood { get; set; } = GrammaticalMood.Undefined;
        public KindOfModal Modal { get; set; } = KindOfModal.Undefined;
        public bool IsQuestion { get; set; }
        public bool IsNegation { get; set; }
        public List<NounPhrase_v2> NounPhrasesList { get; set; } = new List<NounPhrase_v2>();
        public List<VerbPhrase_v2> VerbPhrasesList { get; set; } = new List<VerbPhrase_v2>();

        public void AddVerbPhrase(VerbPhrase_v2 verb)
        {
            VerbPhrasesList.Add(verb);
            LastVerbPhrase = verb;
        }

        public VerbPhrase_v2 LastVerbPhrase { get; private set; }

        public override T GetByRunTimeSessionKey<T>(ulong key)
        {
            if (NounPhrasesList != null)
            {
                foreach (var noun in NounPhrasesList)
                {
                    if (noun.RunTimeSessionKey == key)
                    {
                        object obj = noun;
                        return (T)obj;
                    }

                    var result = noun.GetByRunTimeSessionKey<T>(key);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            if (VerbPhrasesList != null)
            {
                foreach(var verb in VerbPhrasesList)
                {
                    if (verb.RunTimeSessionKey == key)
                    {
                        object obj = verb;
                        return (T)obj;
                    }

                    var result = verb.GetByRunTimeSessionKey<T>(key);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        public Sentence_v2 Fork()
        {
            var result = new Sentence_v2(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Aspect = Aspect;
            result.Tense = Tense;
            result.Voice = Voice;
            result.Mood = Mood;
            result.Modal = Modal;
            result.IsQuestion = IsQuestion;
            result.IsNegation = IsNegation;

            if (NounPhrasesList == null)
            {
                result.NounPhrasesList = null;
            }
            else
            {
                foreach (var noun in NounPhrasesList)
                {
                    result.NounPhrasesList.Add(noun.Fork());
                }
            }

            if(VerbPhrasesList == null)
            {
                result.VerbPhrasesList = null;
            }
            else
            {
                foreach (var verb in VerbPhrasesList)
                {
                    var newVerb = verb.Fork();

                    if(verb == LastVerbPhrase)
                    {
                        result.LastVerbPhrase = newVerb;
                    }

                    result.VerbPhrasesList.Add(newVerb);
                }
            }

            return result;
        }

        public override BasePhrase_v2 ForkAsBasePhrase()
        {
            return Fork();
        }

        public override string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToSting(n));
            sb.AppendLine($"{spaces}{nameof(Aspect)} = {Aspect}");
            sb.AppendLine($"{spaces}{nameof(Tense)} = {Tense}");
            sb.AppendLine($"{spaces}{nameof(Voice)} = {Voice}");
            sb.AppendLine($"{spaces}{nameof(Modal)} = {Modal}");
            sb.AppendLine($"{spaces}{nameof(Mood)} = {Mood}");
            sb.AppendLine($"{spaces}{nameof(IsQuestion)} = {IsQuestion}");
            sb.AppendLine($"{spaces}{nameof(IsNegation)} = {IsNegation}");
            if (NounPhrasesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(NounPhrasesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NounPhrasesList)}");
                foreach (var noun in NounPhrasesList)
                {
                    sb.Append(noun.ToString(nextN));
                }               
                sb.AppendLine($"{spaces}End {nameof(NounPhrasesList)}");
            }
            if (VerbPhrasesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(VerbPhrasesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(VerbPhrasesList)}");
                foreach (var verb in VerbPhrasesList)
                {
                    sb.Append(verb.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(VerbPhrasesList)}");
            }
            if (LastVerbPhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(LastVerbPhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(LastVerbPhrase)}");
                sb.Append(LastVerbPhrase.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(LastVerbPhrase)}");
            }
            return sb.ToString();
        }

        public override string PropertiesToShortSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortSting(n));
            sb.AppendLine($"{spaces}{nameof(Aspect)} = {Aspect}");
            sb.AppendLine($"{spaces}{nameof(Tense)} = {Tense}");
            sb.AppendLine($"{spaces}{nameof(Voice)} = {Voice}");
            sb.AppendLine($"{spaces}{nameof(Modal)} = {Modal}");
            sb.AppendLine($"{spaces}{nameof(Mood)} = {Mood}");
            if (NounPhrasesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(NounPhrasesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NounPhrasesList)}");
                foreach (var noun in NounPhrasesList)
                {
                    sb.Append(noun.ToShortString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(NounPhrasesList)}");
            }

            if (VerbPhrasesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(VerbPhrasesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(VerbPhrasesList)}");
                foreach (var verb in VerbPhrasesList)
                {
                    sb.Append(verb.ToShortString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(VerbPhrasesList)}");
            }
            if (LastVerbPhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(LastVerbPhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(LastVerbPhrase)}");
                sb.Append(LastVerbPhrase.ToShortString(nextN));
                sb.AppendLine($"{spaces}End {nameof(LastVerbPhrase)}");
            }
            return sb.ToString();
        }
    }
}
