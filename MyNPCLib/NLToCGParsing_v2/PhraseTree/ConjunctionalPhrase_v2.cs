using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class ConjunctionalPhrase_v2 : BaseWordPhrase_v2
    {
        public ConjunctionalPhrase_v2(bool getKey = true)
            : base(getKey)
        {
        }

        public override bool IsConjunctionalPhrase => true;
        public override ConjunctionalPhrase_v2 AsConjunctionalPhrase => this;

        public ATNExtendedToken Conjunction { get; set; }
        public List<BaseWordPhrase_v2> ChildrenNodesList { get; set; } = new List<BaseWordPhrase_v2>();

        public override T GetByRunTimeSessionKey<T>(ulong key)
        {
            if (Conjunction != null)
            {
                if (Conjunction.RunTimeSessionKey == key)
                {
                    object obj = Conjunction;
                    return (T)obj;
                }
            }

            if (ChildrenNodesList != null)
            {
                foreach (var child in ChildrenNodesList)
                {
                    if (child.RunTimeSessionKey == key)
                    {
                        object obj = child;
                        return (T)obj;
                    }

                    var result = child.GetByRunTimeSessionKey<T>(key);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        public ConjunctionalPhrase_v2 Fork()
        {
            var result = new ConjunctionalPhrase_v2(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Conjunction = Conjunction;

            if (ChildrenNodesList == null)
            {
                result.ChildrenNodesList = null;
            }
            else
            {
                foreach (var child in ChildrenNodesList)
                {
                    result.ChildrenNodesList.Add(child.ForkAsBaseWordPhrase());
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
                if (Conjunction == null)
                {
                    return false;
                }

                if (ChildrenNodesList.IsEmpty())
                {
                    return false;
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
            if (Conjunction == null)
            {
                sb.AppendLine($"{spaces}{nameof(Conjunction)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Conjunction)}");
                sb.Append(Conjunction.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Conjunction)}");
            }

            if (ChildrenNodesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(ChildrenNodesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ChildrenNodesList)}");
                foreach (var child in ChildrenNodesList)
                {
                    sb.Append(child.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(ChildrenNodesList)}");
            }
            return sb.ToString();
        }

        public override string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortString(n));
            if (Conjunction == null)
            {
                sb.AppendLine($"{spaces}{nameof(Conjunction)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Conjunction)}");
                sb.Append(Conjunction.ToString(nextN));
                sb.AppendLine($"{spaces}End {nameof(Conjunction)}");
            }

            if (ChildrenNodesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(ChildrenNodesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(ChildrenNodesList)}");
                foreach (var child in ChildrenNodesList)
                {
                    sb.Append(child.ToShortString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(ChildrenNodesList)}");
            }
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            var result = 0;

            if (Conjunction != null)
            {
                result ^= Conjunction.GetHashCode();
            }

            if (ChildrenNodesList != null)
            {
                foreach (var item in ChildrenNodesList)
                {
                    result ^= item.GetHashCode();
                }
            }

            return result;
        }

        public static bool NEquals(ConjunctionalPhrase_v2 left, ConjunctionalPhrase_v2 right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return left.GetHashCode() == right.GetHashCode();
        }
    }

    public class ComparerOfConjunctionalPhrase_v2: IEqualityComparer<ConjunctionalPhrase_v2>
    {
        bool IEqualityComparer<ConjunctionalPhrase_v2>.Equals(ConjunctionalPhrase_v2 left, ConjunctionalPhrase_v2 right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return ConjunctionalPhrase_v2.NEquals(left, right);
        }

        int IEqualityComparer<ConjunctionalPhrase_v2>.GetHashCode(ConjunctionalPhrase_v2 obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 0;
            }

            return obj.GetHashCode();
        }
    }
}
