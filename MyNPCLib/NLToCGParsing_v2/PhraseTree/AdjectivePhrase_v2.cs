using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class AdjectivePhrase_v2 : BaseWordPhrase_v2
    {
        public AdjectivePhrase_v2(bool getKey = true)
            : base(getKey)
        {
        }

        public override bool IsAdjectivePhrase => true;
        public override AdjectivePhrase_v2 AsAdjectivePhrase => this;

        public ATNExtendedToken Adjective { get; set; }

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

        public AdjectivePhrase_v2 Fork()
        {
            var result = new AdjectivePhrase_v2(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Adjective = Adjective;
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

        public override bool IsValid
        {
            get
            {
                if(Adjective == null)
                {
                    return false;
                }

                return true;
            }
        }

        public override string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToSting(n));
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

            return sb.ToString();
        }

        public override string PropertiesToShortSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortSting(n));
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
            return sb.ToString();
        }
    }
}
