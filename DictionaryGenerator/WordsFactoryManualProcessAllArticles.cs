using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        private void ProcessAllArticles()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Begin ProcessAllArticles");
#endif

            var wordName = "the";
            AddGrammaticalWordFrame(wordName, new ArticleGrammaticalWordFrame()
            {
                Kind = KindOfArticle.Definite
            });

            wordName = "a";
            AddGrammaticalWordFrame(wordName, new ArticleGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                Kind = KindOfArticle.Indefinite
            });

            wordName = "an";
            AddGrammaticalWordFrame(wordName, new ArticleGrammaticalWordFrame()
            {
                Number = GrammaticalNumberOfWord.Singular,
                Kind = KindOfArticle.Indefinite
            });

            wordName = "no";
            AddGrammaticalWordFrame(wordName, new ArticleGrammaticalWordFrame()
            {
                Kind = KindOfArticle.Negative
            });
        }
    }
}
