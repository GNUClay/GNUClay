using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class VerbPhrase_v2 : IObjectToString, IShortObjectToString, IRunTimeSessionKey
    {
        public VerbPhrase_v2(bool getKey = true)
        {
            if (getKey)
            {
                RunTimeSessionKey = RunTimeSessionKeyHelper.GeyKey();
            }
        }

        public ulong RunTimeSessionKey { get; set; }
        public ATNExtendedToken Verb { get; set; }
        public List<BaseNounLikePhrase_v2> ObjectsList { get; set; } = new List<BaseNounLikePhrase_v2>();
        public List<PrepositionalPhrase_v2> ConditionsList { get; set; } = new List<PrepositionalPhrase_v2>();

        public T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node) where T : class, IRunTimeSessionKey
        {
            return GetByRunTimeSessionKey<T>(node.RunTimeSessionKey);
        }

        public T GetByRunTimeSessionKey<T>(ulong key) where T : class, IRunTimeSessionKey
        {
            if (Verb != null)
            {
                if (Verb.RunTimeSessionKey == key)
                {
                    object obj = Verb;
                    return (T)obj;
                }
            }

            if (ObjectsList != null)
            {
                foreach(var noun in ObjectsList)
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

            return null;
        }

        public VerbPhrase_v2 Fork()
        {
            var result = new VerbPhrase_v2(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Verb = Verb;

            if(ObjectsList == null)
            {
                result.ObjectsList = null;
            }
            else
            {
                foreach (var noun in ObjectsList)
                {
                    result.ObjectsList.Add(noun.Fork());
                }
            }

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
            if (ObjectsList == null)
            {
                sb.AppendLine($"{spaces}{nameof(ObjectsList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ObjectsList)}");
                foreach (var noun in ObjectsList)
                {
                    sb.Append(noun.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(ObjectsList)}");
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
            if (ObjectsList == null)
            {
                sb.AppendLine($"{spaces}{nameof(ObjectsList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ObjectsList)}");
                foreach (var noun in ObjectsList)
                {
                    sb.Append(noun.ToShortString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(ObjectsList)}");
            }
            return sb.ToString();
        }
    }
}
