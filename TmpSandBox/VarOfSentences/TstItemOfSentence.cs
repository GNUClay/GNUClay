using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.VarOfSentences
{
    public class TstItemOfSentence : IObjectToString
    {
        public TstKindOfItemOfSentence Kind { get; set; } = TstKindOfItemOfSentence.Unknown;
        public bool IsMutable { get; set; }

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
            sb.AppendLine($"{spaces}{nameof(IsMutable)} = {IsMutable}");
            return sb.ToString();
        }
    }
}
