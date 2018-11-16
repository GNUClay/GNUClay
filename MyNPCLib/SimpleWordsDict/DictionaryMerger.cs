using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MyNPCLib.SimpleWordsDict
{
    public static class DictionaryMerger
    {
        public static void Merge(WordsDictData source, WordsDictData dest, IList<string> tagretWorsList = null)
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

            var needTargetWords = !tagretWorsList.IsEmpty();

#if DEBUG
            LogInstance.Log($"sourceWordsDict.Count = {sourceWordsDict.Count}");
            LogInstance.Log($"destWordsDict.Count = {destWordsDict.Count}");
            LogInstance.Log($"needTargetWords = {needTargetWords}");
#endif

            foreach (var wordsDictKVPItem in sourceWordsDict)
            {
                var word = wordsDictKVPItem.Key;

                if(needTargetWords)
                {
                    if(!tagretWorsList.Contains(word))
                    {
                        continue;
                    }
                }

                var wordFrame = wordsDictKVPItem.Value;

                var sourceGrammaticalWordFramesList = wordFrame.GrammaticalWordFrames.ToList();

                if (destWordsDict.ContainsKey(word))
                {
                    if(sourceGrammaticalWordFramesList.IsEmpty())
                    {
                        continue;
                    }

                    var destItem = destWordsDict[word];

                    var targetGrammaticalWordFrames = destItem.GrammaticalWordFrames.ToList();
                    targetGrammaticalWordFrames.AddRange(sourceGrammaticalWordFramesList.Select(p => p.Fork()).ToList());

                    destItem.GrammaticalWordFrames = targetGrammaticalWordFrames.Distinct(new ComparerOfBaseGrammaticalWordFrame()).ToList();
                    continue;
                }

                destWordsDict[word] = wordFrame.Fork();
            }

#if DEBUG
            LogInstance.Log($"after sourceWordsDict.Count = {sourceWordsDict.Count}");
            LogInstance.Log($"after destWordsDict.Count = {destWordsDict.Count}");
#endif
        }
    }
}
