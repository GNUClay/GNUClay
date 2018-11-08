using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    [Serializable]
    public class ArticleGrammaticalWordFrame: BaseGrammaticalWordFrame
    {
        public override GrammaticalPartOfSpeech PartOfSpeech => GrammaticalPartOfSpeech.Article;
        public override bool IsArticle => true;
        public override ArticleGrammaticalWordFrame AsArticle => this;
        public GrammaticalNumberOfWord Number { get; set; } = GrammaticalNumberOfWord.Neuter;
        public bool IsDeterminer => true;
        public KindOfArticle Kind { get; set; } = KindOfArticle.Unknown;

        public override string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.Append(base.PropertiesToString(n));
            sb.AppendLine($"{spaces}{nameof(Number)} = {Number}");
            sb.AppendLine($"{spaces}{nameof(IsDeterminer)} = {IsDeterminer}");
            sb.AppendLine($"{spaces}{nameof(Kind)} = {Kind}");
            return sb.ToString();
        }
    }
}
