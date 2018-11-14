using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    public static class DictionaryMerger
    {
        public static void Merge(WordsDictData source, WordsDictData dest)
        {
            var sourceWordsDict = source.WordsDict;

            if(sourceWordsDict.IsEmpty())
            {
                return;
            }

            var destWordsDict = dest.WordsDict;

            if(destWordsDict == null)
            {
                destWordsDict = new Dictionary<string, WordFrame>();
                dest.WordsDict = destWordsDict;
            }

#if DEBUG
            LogInstance.Log($"sourceWordsDict.Count = {sourceWordsDict.Count}");
            LogInstance.Log($"destWordsDict.Count = {destWordsDict.Count}");
#endif

            foreach(var wordsDictKVPItem in sourceWordsDict)
            {
                var word = wordsDictKVPItem.Key;
                var wordFrame = wordsDictKVPItem.Value;


            }
        }
    }
}
