using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing.PhraseTree
{
    public class AdjectivePhrase : BaseNounLikePhrase
    {
        public AdjectivePhrase(bool getKey = true)
            :base(getKey)
        {
        }

        public override bool IsAdjectivePhrase => true;
        public override AdjectivePhrase AsAdjectivePhrase => this;

        public ATNExtendedToken Adjective { get; set; }

        public override T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node)
        {
            return GetByRunTimeSessionKey<T>(node.RunTimeSessionKey);
        }

        public override T GetByRunTimeSessionKey<T>(ulong key)
        {
            if (Adjective != null)
            {
                if (Adjective.RunTimeSessionKey == key)
                {
                    object obj = Adjective;
                    return (T)obj;
                }
            }

            return null;
        }

        public override BaseNounLikePhrase Fork()
        {
            var result = new AdjectivePhrase(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Adjective = Adjective;
            result.Object = Object?.Fork();
            return result;
        }

        public override string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(RunTimeSessionKey)} = {RunTimeSessionKey}");
            if (Adjective == null)
            {
                sb.AppendLine($"{spaces}{nameof(Adjective)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Adjective)}");
                sb.Append(Adjective.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Adjective)}");
            }
            if (Object == null)
            {
                sb.AppendLine($"{spaces}{nameof(Object)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Object)}");
                sb.Append(Object.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Object)}");
            }
            return sb.ToString();
        }

        public override string PropertiesToShortSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            return sb.ToString();
        }
    }
}
