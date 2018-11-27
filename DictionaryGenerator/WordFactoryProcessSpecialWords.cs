using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        private void ProcessSpecialWords()
        {
            var word = "ought";
            AddGrammaticalWordFrame(word, new VerbGrammaticalWordFrame()
            {
                Tense = GrammaticalTenses.Present,
                IsModal = true
            });

            AddGrammaticalWordFrame(word, new NounGrammaticalWordFrame
            {
                IsCountable = true,

            });
        }
    }
}
