using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class NounPhrase_v2 : BaseNounLikePhrase_v2
    {
        public NounPhrase_v2(bool getKey = true)
            : base(getKey)
        {
        }

        public override bool IsNounPhrase => true;
        public override NounPhrase_v2 AsNounPhrase => this;

        public ATNExtendedToken Noun { get; set; }
        public List<ATNExtendedToken> Determiners { get; set; } = new List<ATNExtendedToken>();
        public AdjectivePhrase_v2 AdjectivePhrase { get; set; }

        public override T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node)
        {
            return GetByRunTimeSessionKey<T>(node.RunTimeSessionKey);
        }

        public override T GetByRunTimeSessionKey<T>(ulong key)
        {
            if (Noun != null)
            {
                if (Noun.RunTimeSessionKey == key)
                {
                    object obj = Noun;
                    return (T)obj;
                }
            }

            if (Determiners != null)
            {
                foreach (var determiner in Determiners)
                {
                    if (determiner.RunTimeSessionKey == key)
                    {
                        object obj = determiner;
                        return (T)obj;
                    }
                }
            }

            if (AdjectivePhrase != null)
            {
                if (AdjectivePhrase.RunTimeSessionKey == key)
                {
                    object obj = AdjectivePhrase;
                    return (T)obj;
                }
            }

            return null;
        }

        public override BaseNounLikePhrase_v2 Fork()
        {
            var result = new NounPhrase_v2(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Noun = Noun?.Fork();
            result.Determiners = Determiners.ToList();
            result.AdjectivePhrase?.Fork();
            return result;
        }

        public override string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(RunTimeSessionKey)} = {RunTimeSessionKey}");

            if (Noun == null)
            {
                sb.AppendLine($"{spaces}{nameof(Noun)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Noun)}");
                sb.Append(Noun.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Noun)}");
            }

            if (Determiners == null)
            {
                sb.AppendLine($"{spaces}{nameof(Determiners)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Determiners)}");
                foreach (var determiner in Determiners)
                {
                    sb.Append(determiner.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(Determiners)}");
            }

            if (AdjectivePhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(AdjectivePhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(AdjectivePhrase)}");
                sb.Append(AdjectivePhrase.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(AdjectivePhrase)}");
            }
            return sb.ToString();
        }

        public override string PropertiesToShortSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            if (Noun == null)
            {
                sb.AppendLine($"{spaces}{nameof(Noun)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Noun)}");
                sb.Append(Noun.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Noun)}");
            }

            if (Determiners == null)
            {
                sb.AppendLine($"{spaces}{nameof(Determiners)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Determiners)}");
                foreach (var determiner in Determiners)
                {
                    sb.Append(determiner.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(Determiners)}");
            }

            if (AdjectivePhrase == null)
            {
                sb.AppendLine($"{spaces}{nameof(AdjectivePhrase)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(AdjectivePhrase)}");
                sb.Append(AdjectivePhrase.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(AdjectivePhrase)}");
            }
            return sb.ToString();
        }
    }
}
