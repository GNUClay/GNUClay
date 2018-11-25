using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class CustomWordsFactory
    {
        public void Run()
        {
            var wordsList = new List<string>();

            var ogdensWordsList = OgdenListGenerator.Get();

            wordsList.AddRange(ogdensWordsList);

            var irVerbsWordsList = IrVerbsListGenerator.Get();
            wordsList.AddRange(irVerbsWordsList);

            var customWordsList = CustomListGenerator.Get();
            wordsList.AddRange(customWordsList);

            wordsList = wordsList.OrderBy(p => p).ToList();

#if DEBUG
            LogInstance.Log($"wordsList.Count = {wordsList.Count}");

            foreach (var word in wordsList)
            {
                LogInstance.Log($"word = {word}");
            }
#endif

            var wordsFactory = new WordsFactory();
            wordsFactory.Run(wordsList);
        }
    }
}
