using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.VarOfSentences
{
    public class TstItemOfSentence : IObjectToString
    {
        public TstKindOfItemOfSentence Kind { get; set; } = TstKindOfItemOfSentence.Unknown;
        public bool IsVerb { get; set; }
        public bool IsWill { get; set; }
        public bool IsMutable { get; set; }
        public bool IsMainAdditional { get; set; }
        public bool IsSecondAdditional { get; set; }

        public TstItemOfSentence Fork()
        {
            var result = new TstItemOfSentence();
            result.Kind = Kind;
            result.IsVerb = IsVerb;
            result.IsWill = IsWill;
            result.IsMutable = IsMutable;
            result.IsMainAdditional = IsMainAdditional;
            result.IsSecondAdditional = IsSecondAdditional;
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
            sb.AppendLine($"{spaces}{nameof(Kind)} = {Kind}");
            sb.AppendLine($"{spaces}{nameof(IsVerb)} = {IsVerb}");
            sb.AppendLine($"{spaces}{nameof(IsWill)} = {IsWill}");
            sb.AppendLine($"{spaces}{nameof(IsMutable)} = {IsMutable}");
            sb.AppendLine($"{spaces}{nameof(IsMainAdditional)} = {IsMainAdditional}");
            sb.AppendLine($"{spaces}{nameof(IsSecondAdditional)} = {IsSecondAdditional}");
            return sb.ToString();
        }

        public static TstItemOfSentence CreateSubject()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.Subj
            };

            return result;
        }

        public static TstItemOfSentence CreateWill()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.Will,
                IsMainAdditional = true,
                IsWill = true
            };
            return result;
        }

        public static TstItemOfSentence CreateNot()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.Not
            };

            return result;
        }

        public static TstItemOfSentence CreateNo()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.Not
            };

            return result;
        }

        public static TstItemOfSentence CreateFToBe()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.FToBe,
                IsMainAdditional = true
            };
            return result;
        }

        public static TstItemOfSentence CreateFToDo()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.FToDo,
                IsMainAdditional = true
            };
            return result;
        }

        public static TstItemOfSentence CreateFToHave()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.FToHave,
                IsMainAdditional = true
            };
            return result;
        }

        public static TstItemOfSentence CreateVIng()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.Ving
            };

            return result;
        }

        public static TstItemOfSentence CreateV3()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.V3
            };

            return result;
        }

        public static TstItemOfSentence CreateBeen()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.Been
            };

            return result;
        }

        public static TstItemOfSentence CreateBeing()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.Being
            };

            return result;
        }

        public static TstItemOfSentence CreateQWObj()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.QWObj
            };

            return result;
        }

        public static TstItemOfSentence CreateVerb()
        {
            var result = new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.Verb,
                IsVerb = true
            };

            return result;
        }
    }
}
