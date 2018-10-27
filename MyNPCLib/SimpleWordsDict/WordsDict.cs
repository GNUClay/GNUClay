using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    public class WordsDict: IWordsDict
    {
        public WordsDict()
        {
            var data = TmpFactoryOfWordsDictData.Data;//tmp
            mWordsDict = data.WordsDict;
            //mNamesList = data.NamesList;
        }

        private IDictionary<string, WordFrame> mWordsDict;
        //private IList<string> mNamesList;

        public WordFrame GetWordFrame(string word)
        {
            if(mWordsDict.ContainsKey(word))
            {
                return mWordsDict[word];
            }

            return null;
        }

        //public bool IsName(string word)
        //{
        //    if(mNamesList.Contains(word))
        //    {
        //        return true;
        //    }

        //    return false;
        //}

        public IList<string> GetConditionalLogicalMeaning(string word, string conditionalWord)
        {
#if DEBUG
            LogInstance.Log($"word = {word} conditionalWord = {conditionalWord}");
#endif

            var wordFrame = GetWordFrame(word);

            if(wordFrame == null)
            {
                return new List<string>();
            }

#if DEBUG
            LogInstance.Log($"NEXT word = {word} conditionalWord = {conditionalWord}");
#endif

            var dict = wordFrame.GrammaticalWordFrames.Where(p => !p.ConditionalLogicalMeaning.IsEmpty()).SelectMany(p => p.ConditionalLogicalMeaning).ToDictionary(p => p.Key, p => p.Value);

#if DEBUG
            LogInstance.Log($"dict.Count = {dict.Count}");
#endif

            if(dict.ContainsKey(conditionalWord))
            {
                return dict[conditionalWord];
            }

            //return wordFrame.GrammaticalWordFrames.Where(p => !p.ConditionalLogicalMeaning.IsEmpty()).;
            return new List<string>();
        }
    }
}
