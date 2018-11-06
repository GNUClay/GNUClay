using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class NounPhrase_v2 : BaseWordPhrase_v2
    {
        public NounPhrase_v2(bool getKey = true)
            : base(getKey)
        {
        }

        public override bool IsNounPhrase => true;
        public override NounPhrase_v2 AsNounPhrase => this;

        public ATNExtendedToken Noun { get; set; }
        public List<ATNExtendedToken> DeterminersList { get; set; } = new List<ATNExtendedToken>();
        public List<AdjectivePhrase_v2> AdjectivePhrasesList { get; set; } = new List<AdjectivePhrase_v2>();

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

            if (DeterminersList != null)
            {
                foreach (var determiner in DeterminersList)
                {
                    if (determiner.RunTimeSessionKey == key)
                    {
                        object obj = determiner;
                        return (T)obj;
                    }
                }
            }

            if (AdjectivePhrasesList != null)
            {
                foreach(var adj in AdjectivePhrasesList)
                {
                    if (adj.RunTimeSessionKey == key)
                    {
                        object obj = adj;
                        return (T)obj;
                    }
                }
            }

            return null;
        }

        public NounPhrase_v2 Fork()
        {
            var result = new NounPhrase_v2(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Noun = Noun?.Fork();

            foreach (var determiner in DeterminersList)
            {
                result.DeterminersList.Add(determiner.Fork());
            }

            foreach (var adj in AdjectivePhrasesList)
            {
                result.AdjectivePhrasesList.Add(adj.Fork());
            }

            return result;
        }

        public override BasePhrase_v2 ForkAsBasePhrase()
        {
            return Fork();
        }

        public override BaseWordPhrase_v2 ForkAsBaseWordPhrase()
        {
            return Fork();
        }

        public override string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToSting(n));

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

            if (DeterminersList == null)
            {
                sb.AppendLine($"{spaces}{nameof(DeterminersList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(DeterminersList)}");
                foreach (var determiner in DeterminersList)
                {
                    sb.Append(determiner.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(DeterminersList)}");
            }

            if (AdjectivePhrasesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(AdjectivePhrasesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(AdjectivePhrasesList)}");
                foreach (var adj in AdjectivePhrasesList)
                {
                    sb.Append(adj.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(AdjectivePhrasesList)}");
            }
            return sb.ToString();
        }

        public override string PropertiesToShortSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortSting(n));
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

            if (DeterminersList == null)
            {
                sb.AppendLine($"{spaces}{nameof(DeterminersList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(DeterminersList)}");
                foreach (var determiner in DeterminersList)
                {
                    sb.Append(determiner.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(DeterminersList)}");
            }

            if (AdjectivePhrasesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(AdjectivePhrasesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(AdjectivePhrasesList)}");
                foreach (var adj in AdjectivePhrasesList)
                {
                    sb.Append(adj.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(AdjectivePhrasesList)}");
            }
            return sb.ToString();
        }
    }
}
