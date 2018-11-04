using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing.PhraseTree
{
    public class NounPhrase : BaseNounLikePhrase
    {
        public NounPhrase(bool getKey = true)
            : base(getKey)
        {
        }

        public override bool IsNounPhrase => true;
        public override NounPhrase AsNounPhrase => this;

        public ATNExtendedToken Noun { get; set; }
        public List<ATNExtendedToken> Determiners { get; set; } = new List<ATNExtendedToken>();

        public override T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node)
        {
            return GetByRunTimeSessionKey<T>(node.RunTimeSessionKey);
        }

        public override T GetByRunTimeSessionKey<T>(ulong key)
        {
            if(Noun != null)
            {
                if(Noun.RunTimeSessionKey == key)
                {
                    object obj = Noun;
                    return (T)obj;
                }
            }

            if(Determiners != null)
            {
                foreach(var determiner in Determiners)
                {
                    if (determiner.RunTimeSessionKey == key)
                    {
                        object obj = determiner;
                        return (T)obj;
                    }
                }
            }

            return null;
        }

        public override BaseNounLikePhrase Fork()
        {
            var result = new NounPhrase(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Noun = Noun;
            result.Determiners = Determiners.ToList();
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
            return sb.ToString();
        }
    }
}
