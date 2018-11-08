using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    [Serializable]
    public class PostpositionGrammaticalWordFrame : BaseGrammaticalWordFrame
    {
        public override GrammaticalPartOfSpeech PartOfSpeech => GrammaticalPartOfSpeech.Postposition;
        public override bool IsPostposition => true;
        public override PostpositionGrammaticalWordFrame AsPostposition => this;

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToString(n));
            return sb.ToString();
        }
    }
}
