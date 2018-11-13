using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class NounPhrase_v2 : BaseWordPhrase_v2
    {
        public NounPhrase_v2(bool getKey = true)
            : base(getKey)
        {
        }

        public override bool IsNounPhrase => true;
        public override NounPhrase_v2 AsNounPhrase => this;

        public ATNExtendedToken Noun { get; set; }
        public List<ATNExtendedToken> DeterminersList { get; set; } = new List<ATNExtendedToken>();
        public List<AdjectivePhrase_v2> AdjectivePhrasesList { get; set; } = new List<AdjectivePhrase_v2>();
        public float? NumberValue { get; set; }
        public List<BaseWordPhrase_v2> PossesiveList { get; set; } = new List<BaseWordPhrase_v2>();
        public List<BaseWordPhrase_v2> AdditionalInfoList { get; set; } = new List<BaseWordPhrase_v2>();


        public override T GetByRunTimeSessionKey<T>(ulong key)
        {
            if (Noun != null)
            {
                if (Noun.RunTimeSessionKey == key)
                {
                    object obj = Noun;
                    return (T)obj;
                }
            }

            if (DeterminersList != null)
            {
                foreach (var determiner in DeterminersList)
                {
                    if (determiner.RunTimeSessionKey == key)
                    {
                        object obj = determiner;
                        return (T)obj;
                    }
                }
            }

            if (AdjectivePhrasesList != null)
            {
                foreach(var adj in AdjectivePhrasesList)
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

            if(PossesiveList != null)
            {
                foreach(var item in PossesiveList)
                {
                    if (item.RunTimeSessionKey == key)
                    {
                        object obj = item;
                        return (T)obj;
                    }

                    var result = item.GetByRunTimeSessionKey<T>(key);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }
         
            if (AdditionalInfoList != null)
            {
                foreach (var item in AdditionalInfoList)
                {
                    if (item.RunTimeSessionKey == key)
                    {
                        object obj = item;
                        return (T)obj;
                    }

                    var result = item.GetByRunTimeSessionKey<T>(key);

                    if (result != null)
                    {
                        return result;
                    }
                }
            }
            return null;
        }

        public NounPhrase_v2 Fork()
        {
            var result = new NounPhrase_v2(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Noun = Noun?.Fork();

            if(DeterminersList == null)
            {
                result.DeterminersList = null;
            }
            else
            {
                foreach (var determiner in DeterminersList)
                {
                    result.DeterminersList.Add(determiner.Fork());
                }
            }

            if(AdjectivePhrasesList == null)
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

            result.NumberValue = NumberValue;

            if(PossesiveList == null)
            {
                result.PossesiveList = null;
            }
            else
            {
                foreach(var item in PossesiveList)
                {
                    result.PossesiveList.Add(item.ForkAsBaseWordPhrase());
                }
            }
      
            if (AdditionalInfoList == null)
            {
                result.AdditionalInfoList = null;
            }
            else
            {
                foreach (var item in AdditionalInfoList)
                {
                    result.AdditionalInfoList.Add(item.ForkAsBaseWordPhrase());
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
                if(Noun == null)
                {
                    return false;
                }

                if(!AdjectivePhrasesList.IsEmpty())
                {
                    foreach (var adj in AdjectivePhrasesList)
                    {
                        if(!adj.IsValid)
                        {
                            return false;
                        }
                    }
                }

                if(!PossesiveList.IsEmpty())
                {
                    foreach(var item in PossesiveList)
                    {
                        if (!item.IsValid)
                        {
                            return false;
                        }
                    }
                }
        
                if (!AdditionalInfoList.IsEmpty())
                {
                    foreach (var item in AdditionalInfoList)
                    {
                        if (!item.IsValid)
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

            if (DeterminersList == null)
            {
                sb.AppendLine($"{spaces}{nameof(DeterminersList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(DeterminersList)}");
                foreach (var determiner in DeterminersList)
                {
                    sb.Append(determiner.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(DeterminersList)}");
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
            sb.AppendLine($"{spaces}{nameof(NumberValue)} = {NumberValue}");

            if(PossesiveList == null)
            {
                sb.AppendLine($"{spaces}{nameof(PossesiveList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(PossesiveList)}");
                foreach (var item in PossesiveList)
                {
                    sb.Append(item.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(PossesiveList)}");
            }
            
            if (AdditionalInfoList == null)
            {
                sb.AppendLine($"{spaces}{nameof(AdditionalInfoList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(AdditionalInfoList)}");
                foreach (var item in AdditionalInfoList)
                {
                    sb.Append(item.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(AdditionalInfoList)}");
            }
            return sb.ToString();
        }

        public override string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortString(n));
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

            if (DeterminersList == null)
            {
                sb.AppendLine($"{spaces}{nameof(DeterminersList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(DeterminersList)}");
                foreach (var determiner in DeterminersList)
                {
                    sb.Append(determiner.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(DeterminersList)}");
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
            sb.AppendLine($"{spaces}{nameof(NumberValue)} = {NumberValue}");

            if (PossesiveList == null)
            {
                sb.AppendLine($"{spaces}{nameof(PossesiveList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(PossesiveList)}");
                foreach (var item in PossesiveList)
                {
                    sb.Append(item.ToShortString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(PossesiveList)}");
            }
            
            if (AdditionalInfoList == null)
            {
                sb.AppendLine($"{spaces}{nameof(AdditionalInfoList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(AdditionalInfoList)}");
                foreach (var item in AdditionalInfoList)
                {
                    sb.Append(item.ToShortString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(AdditionalInfoList)}");
            }
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            var result = 0;

            if(Noun != null)
            {
                result ^= Noun.GetHashCode();
            }

            result ^= GetHashCodeOfDeterminersList();

            result ^= GetHashCodeOfAdjectivePhrasesList();

            if(NumberValue.HasValue)
            {
                result ^= NumberValue.Value.GetHashCode();
            }

            result ^= GetHashCodeOfPossesiveList();
    
            if (AdditionalInfoList != null)
            {
                foreach (var item in AdditionalInfoList)
                {
                    result ^= item.GetHashCode();
                }
            }

            return result;
        }

        private int GetHashCodeOfDeterminersList()
        {
            var result = 0;

            if (DeterminersList != null)
            {
                foreach (var item in DeterminersList)
                {
                    result ^= item.GetHashCode();
                }
            }

            return result;
        }

        private int GetHashCodeOfAdjectivePhrasesList()
        {
            var result = 0;

            if (AdjectivePhrasesList != null)
            {
                foreach (var item in AdjectivePhrasesList)
                {
                    result ^= item.GetHashCode();
                }
            }

            return result;
        }

        private int GetHashCodeOfPossesiveList()
        {
            var result = 0;

            if (PossesiveList != null)
            {
                foreach (var item in PossesiveList)
                {
                    result ^= item.GetHashCode();
                }
            }

            return result;
        }

        public static bool NEquals(NounPhrase_v2 left, NounPhrase_v2 right)
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

    public class ComparerOfNounPhrase_v2 : IEqualityComparer<NounPhrase_v2>
    {
        bool IEqualityComparer<NounPhrase_v2>.Equals(NounPhrase_v2 left, NounPhrase_v2 right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return NounPhrase_v2.NEquals(left, right);
        }

        int IEqualityComparer<NounPhrase_v2>.GetHashCode(NounPhrase_v2 obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 0;
            }

            return obj.GetHashCode();
        }
    }
}
