using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class AdjectivePhrase_v2 : IObjectToString, IShortObjectToString, IRunTimeSessionKey
    {
        public AdjectivePhrase_v2(bool getKey = true)
        {
            if (getKey)
            {
                RunTimeSessionKey = RunTimeSessionKeyHelper.GeyKey();
            }
        }

        public ulong RunTimeSessionKey { get; set; }
        public ATNExtendedToken Adjective { get; set; }

        public T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node) where T : class, IRunTimeSessionKey
        {
            return GetByRunTimeSessionKey<T>(node.RunTimeSessionKey);
        }

        public T GetByRunTimeSessionKey<T>(ulong key) where T : class, IRunTimeSessionKey
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
            return sb.ToString();
        }
    }
}
