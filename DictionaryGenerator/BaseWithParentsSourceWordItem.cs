using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public abstract class BaseWithParentsSourceWordItem : IObjectToString
    {
        public int WordNum { get; set; }
        public string Word { get; set; }
        public int ParentWordNum { get; set; }

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
            sb.AppendLine($"{spaces}{nameof(WordNum)} = {WordNum}");
            sb.AppendLine($"{spaces}{nameof(Word)} = {Word}");
            sb.AppendLine($"{spaces}{nameof(ParentWordNum)} = {ParentWordNum}");
            return sb.ToString();
        }
    }
}
