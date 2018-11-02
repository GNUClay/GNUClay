using MyNPCLib;
using MyNPCLib.NLToCGParsing;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TmpSandBox.VarOfSentences
{
    public class TstSentence : IObjectToString
    {    
        public GrammaticalTenses Tense { get; set; } = GrammaticalTenses.Undefined;
        public GrammaticalAspect Aspect { get; set; } = GrammaticalAspect.Undefined;
        public GrammaticalVoice Voice { get; set; } = GrammaticalVoice.Undefined;
        public GrammaticalMood Mood { get; set; } = GrammaticalMood.Undefined;
        public List<TstItemOfSentence> WordsList { get; set; } = new List<TstItemOfSentence>();

        public bool HasMainAdditional
        {
            get
            {
                return WordsList.Any(p => p.IsMainAdditional);
            }
        }

        public int IndexOfMainAdditional
        {
            get
            {
                var mainAdditional = WordsList.FirstOrDefault(p => p.IsMainAdditional);

                if (mainAdditional == null)
                {
                    return -1;
                }

                return WordsList.IndexOf(mainAdditional);
            }
        }

        public int IndexOfSubject
        {
            get
            {
                var subject = WordsList.FirstOrDefault(p => p.Kind == KindOfItemOfSentence.Subj);

                if(subject == null)
                {
                    return -1;
                }

                return WordsList.IndexOf(subject);
            }
        }

        public bool HasNegation
        {
            get
            {
                return WordsList.Any(p => p.Kind == KindOfItemOfSentence.No || p.Kind == KindOfItemOfSentence.Not);
            }
        }

        public int IndexOfMainVerb
        {
            get
            {
                var verb = WordsList.FirstOrDefault(p => p.Kind == KindOfItemOfSentence.Verb || p.Kind == KindOfItemOfSentence.V3 || p.Kind == KindOfItemOfSentence.Ving);

                if(verb == null)
                {
                    return -1;
                }

                return WordsList.IndexOf(verb);
            }
        }

        public TstSentence Fork()
        {
            var result = new TstSentence();
            result.Tense = Tense;
            result.Aspect = Aspect;
            result.Voice = Voice;
            result.Mood = Mood;
            foreach(var word in WordsList)
            {
                result.WordsList.Add(word.Fork());
            }
            return result;
        }

        public string ToDisplayStr()
        {
            var sb = new StringBuilder();
            foreach(var word in WordsList)
            {
                sb.Append($"{word.Kind}_");
            }
            sb.Remove(sb.Length - 1, 1);
            return sb.ToString();
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
            sb.AppendLine($"{spaces}{nameof(Tense)} = {Tense}");
            sb.AppendLine($"{spaces}{nameof(Aspect)} = {Aspect}");
            sb.AppendLine($"{spaces}{nameof(Voice)} = {Voice}");
            sb.AppendLine($"{spaces}{nameof(Mood)} = {Mood}");
            sb.AppendLine($"{spaces}Begin {nameof(WordsList)}");
            foreach (var child in WordsList)
            {
                sb.Append(child.ToString(nextN));
            }
            sb.AppendLine($"{spaces}End {nameof(WordsList)}");
            return sb.ToString();
        }
    }
}
