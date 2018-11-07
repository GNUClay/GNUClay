using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public class PrepositionalPhrase_v2 : BaseWordPhrase_v2
    {
        public PrepositionalPhrase_v2(bool getKey = true)
            : base(getKey)
        {
        }
       
        public override bool IsPrepositionalPhrase => true;
        public override PrepositionalPhrase_v2 AsPrepositionalPhrase => this;

        public ATNExtendedToken Preposition { get; set; }
        public List<BaseWordPhrase_v2> ChildrenNodesList { get; set; } = new List<BaseWordPhrase_v2>();

        public override T GetByRunTimeSessionKey<T>(ulong key)
        {
            if (Preposition != null)
            {
                if (Preposition.RunTimeSessionKey == key)
                {
                    object obj = Preposition;
                    return (T)obj;
                }
            }

            if(ChildrenNodesList != null)
            {
                foreach(var child in ChildrenNodesList)
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

        public PrepositionalPhrase_v2 Fork()
        {
            var result = new PrepositionalPhrase_v2(false);
            result.RunTimeSessionKey = RunTimeSessionKey;
            result.Preposition = Preposition;

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
                if(Preposition == null)
                {
                    return false;
                }

                if(ChildrenNodesList.IsEmpty())
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

        public override string PropertiesToShortSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToShortSting(n));
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
    }
}
