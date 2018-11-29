using MyNPCLib;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator.DictionaryDiscovering
{
    public abstract class BaseDictionaryDiscoverer
    {
        protected BaseDictionaryDiscoverer(WordsDictData dict)
        {
            mDict = dict;
        }

        private WordsDictData mDict;

        public void Run()
        {
            var resultList = new List<string>();

            var wordsDict = mDict.WordsDict;

            if (wordsDict.Count > 0)
            {
                foreach(var wordsDictKVPItem in wordsDict)
                {
                    if(ProcessFrame(wordsDictKVPItem.Value))
                    {
                        resultList.Add(wordsDictKVPItem.Key);
                    }
                }

                resultList = resultList.Distinct().OrderBy(p => p).ToList();
            }

            LogInstance.Log($"resultList.Count = {resultList.Count}");

            foreach(var word in resultList)
            {
                LogInstance.Log($"word = {word}");
            }
        }

        protected abstract bool ProcessFrame(WordFrame wordFrame);
    }
}
