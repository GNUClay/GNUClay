using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing.PhraseTree
{
    public class PrepositionalPhrase : BaseNounLikePhrase
    {
        public PrepositionalPhrase(bool getKey = true)
            :base(getKey)
        {
        }

        public ATNExtendedToken Preposition { get; set; }
        public override bool IsPrepositionalPhrase => true;
        public override PrepositionalPhrase AsPrepositionalPhrase => this;

        public override T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node)
        {
            return GetByRunTimeSessionKey<T>(node.RunTimeSessionKey);
        }

        public override T GetByRunTimeSessionKey<T>(ulong key)
        {
            if(Preposition != null)
            {
                if(Preposition.RunTimeSessionKey == key)
                {
                    object obj = Preposition;
                    return (T)obj;
                }
            }

            return null;
        }

        public override BaseNounLikePhrase Fork()
        {
            var result = new PrepositionalPhrase(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Preposition = Preposition;
            result.Object = Object?.Fork();
            return result;
        }

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(RunTimeSessionKey)} = {RunTimeSessionKey}");
            if (Preposition == null)
            {
                sb.AppendLine($"{spaces}{nameof(Preposition)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Preposition)}");
                sb.Append(Preposition.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Preposition)}");
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

        public override string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            if (Preposition == null)
            {
                sb.AppendLine($"{spaces}{nameof(Preposition)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Preposition)}");
                sb.Append(Preposition.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Preposition)}");
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
    }
}
