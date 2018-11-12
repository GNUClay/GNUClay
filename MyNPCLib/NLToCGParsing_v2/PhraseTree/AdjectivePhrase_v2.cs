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
        public List<AdjectivePhrase_v2> AdjectivePhrasesList { get; set; } = new List<AdjectivePhrase_v2>();
        
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

            if (AdjectivePhrasesList != null)
            {
                foreach (var adj in AdjectivePhrasesList)
                {
                    if (adj.RunTimeSessionKey == key)
                    {
                        object obj = adj;
                        return (T)obj;
                    }

                    var result = adj.GetByRunTimeSessionKey<T>(key);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }

            return null;
        }

        public AdjectivePhrase_v2 Fork()
        {
            var result = new AdjectivePhrase_v2(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Adjective = Adjective?.Fork();

            if (AdjectivePhrasesList == null)
            {
                result.AdjectivePhrasesList = null;
            }
            else
            {
                foreach (var adj in AdjectivePhrasesList)
                {
                    result.AdjectivePhrasesList.Add(adj.Fork());
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
                if(Adjective == null)
                {
                    return false;
                }

                if (!AdjectivePhrasesList.IsEmpty())
                {
                    foreach (var adj in AdjectivePhrasesList)
                    {
                        if (!adj.IsValid)
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

        public override string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortString(n));
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

            if (AdjectivePhrasesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(AdjectivePhrasesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(AdjectivePhrasesList)}");
                foreach (var adj in AdjectivePhrasesList)
                {
                    sb.Append(adj.ToShortString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(AdjectivePhrasesList)}");
            }

            return sb.ToString();
        }

        public override int GetHashCode()
        {
            var result = 0;

            if(Adjective != null)
            {
                result ^= Adjective.GetHashCode();
            }

            if (AdjectivePhrasesList != null)
            {
                foreach (var item in AdjectivePhrasesList)
                {
                    result ^= item.GetHashCode();
                }
            }

            return result;
        }

        public static bool NEquals(AdjectivePhrase_v2 left, AdjectivePhrase_v2 right)
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

    public class ComparerOfAdjectivePhrase_v2 : IEqualityComparer<AdjectivePhrase_v2>
    {
        bool IEqualityComparer<AdjectivePhrase_v2>.Equals(AdjectivePhrase_v2 left, AdjectivePhrase_v2 right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return AdjectivePhrase_v2.NEquals(left, right);
        }

        int IEqualityComparer<AdjectivePhrase_v2>.GetHashCode(AdjectivePhrase_v2 obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 0;
            }

            return obj.GetHashCode();
        }
    }
}
