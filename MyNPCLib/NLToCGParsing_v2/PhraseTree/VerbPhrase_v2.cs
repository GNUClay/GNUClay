using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class VerbPhrase_v2 : BaseWordPhrase_v2
    {
        public VerbPhrase_v2(bool getKey = true)
            : base(getKey)
        {
        }

        public ATNExtendedToken Verb { get; set; }
        public List<NounPhrase_v2> ObjectsList { get; set; } = new List<NounPhrase_v2>();
        public List<BaseWordPhrase_v2> ConditionsList { get; set; } = new List<BaseWordPhrase_v2>();

        public override T GetByRunTimeSessionKey<T>(ulong key)
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

            if(ConditionsList != null)
            {
                foreach(var condition in ConditionsList)
                {
                    if (condition.RunTimeSessionKey == key)
                    {
                        object obj = condition;
                        return (T)obj;
                    }

                    var result = condition.GetByRunTimeSessionKey<T>(key);

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
            result.Verb = Verb?.Fork();

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

            if(ConditionsList == null)
            {
                result.ConditionsList = null;
            }
            else
            {
                foreach (var condition in ConditionsList)
                {
                    result.ConditionsList.Add(condition.ForkAsBaseWordPhrase());
                }
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

        public override bool IsValid
        {
            get
            {
                if(Verb == null)
                {
                    return false;
                }

                if(!ObjectsList.IsEmpty())
                {
                    foreach (var noun in ObjectsList)
                    {
                        if(!noun.IsValid)
                        {
                            return false;
                        }
                    }
                }

                if(!ConditionsList.IsEmpty())
                {
                    foreach (var condition in ConditionsList)
                    {
                        if(!condition.IsValid)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
        }

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToString(n));
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

            if (ConditionsList == null)
            {
                sb.AppendLine($"{spaces}{nameof(ConditionsList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ConditionsList)}");
                foreach (var condition in ConditionsList)
                {
                    sb.Append(condition.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(ConditionsList)}");
            }
            return sb.ToString();
        }

        public override string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortString(n));
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

            if (ConditionsList == null)
            {
                sb.AppendLine($"{spaces}{nameof(ConditionsList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ConditionsList)}");
                foreach (var condition in ConditionsList)
                {
                    sb.Append(condition.ToShortString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(ConditionsList)}");
            }
            return sb.ToString();
        }

        public override int GetHashCode()
        {

        }

        public static bool NEquals(VerbPhrase_v2 left, VerbPhrase_v2 right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }
        }
    }

    public class ComparerOfVerbPhrase_v2 : IEqualityComparer<VerbPhrase_v2>
    {
        bool IEqualityComparer<VerbPhrase_v2>.Equals(VerbPhrase_v2 left, VerbPhrase_v2 right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return VerbPhrase_v2.NEquals(left, right);
        }

        int IEqualityComparer<VerbPhrase_v2>.GetHashCode(VerbPhrase_v2 obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 0;
            }

            return obj.GetHashCode();
        }
    }
}
