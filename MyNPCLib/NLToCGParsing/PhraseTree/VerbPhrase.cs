using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing.PhraseTree
{
    public class VerbPhrase: IObjectToString, IShortObjectToString, IRunTimeSessionKey
    {
        public VerbPhrase(bool getKey = true)
        {
            if (getKey)
            {
                RunTimeSessionKey = RunTimeSessionKeyHelper.GeyKey();
            }
        }

        public ulong RunTimeSessionKey { get; set; }
        public ATNExtendedToken Verb { get; set; }
        public BaseNounLikePhrase Object { get; set; }

        public T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node) where T : class, IRunTimeSessionKey
        {
            return GetByRunTimeSessionKey<T>(node.RunTimeSessionKey);
        }

        public T GetByRunTimeSessionKey<T>(ulong key) where T : class, IRunTimeSessionKey
        {
            if(Verb != null)
            {
                if(Verb.RunTimeSessionKey == key)
                {
                    object obj = Verb;
                    return (T)obj;
                }
            }

            if(Object != null)
            {
                if(Object.RunTimeSessionKey == key)
                {
                    object obj = Object;
                    return (T)obj;
                }
            }

            return null;
        }

        public VerbPhrase Fork()
        {
            var result = new VerbPhrase(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Verb = Verb;
            result.Object = Object?.Fork();
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

        public string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(RunTimeSessionKey)} = {RunTimeSessionKey}");
            if (Verb == null)
            {
                sb.AppendLine($"{spaces}{nameof(Verb)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Verb)}");
                sb.Append(Verb.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Verb)}");
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

        public string ToShortString()
        {
            return ToShortString(0u);
        }

        public string ToShortString(uint n)
        {
            return this.GetDefaultToShortStringInformation(n);
        }

        public string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            if (Verb == null)
            {
                sb.AppendLine($"{spaces}{nameof(Verb)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Verb)}");
                sb.Append(Verb.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Verb)}");
            }
            if (Object == null)
            {
                sb.AppendLine($"{spaces}{nameof(Object)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Object)}");
                sb.Append(Object.ToShortString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Object)}");
            }
            return sb.ToString();
        }
    }
}
