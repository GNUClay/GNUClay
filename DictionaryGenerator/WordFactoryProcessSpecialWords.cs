using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        private void AddUsualSpecialWords(ref List<string> usualWordsList)
        {
            var word = "ought";
            AddSpecialWordToUsualWords(word, ref usualWordsList);
            AddSpecialWordToRootNounDict(word);
            AddSpecialWordToRootVerbsDict(word);
        }

        private void ProcessSpecialWords()
        {
        }
    }
}
