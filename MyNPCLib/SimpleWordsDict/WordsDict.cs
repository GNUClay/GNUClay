using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    public class WordsDict: IWordsDict
    {
        public WordsDict()
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;

#if DEBUG
            LogInstance.Log($"rootPath = {rootPath}");
#endif

            var workingDictLocalName = "working.dict";

            var workingDictFullName = Path.Combine(rootPath, workingDictLocalName);

#if DEBUG
            LogInstance.Log($"workingDictFullName = {workingDictFullName}");
#endif

            var serializator = new WordsDictSerializationEngine();

            var data = serializator.LoadFromFile(workingDictFullName);

            //var data = TmpFactoryOfWordsDictData.Data;//tmp
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
            LogInstance.Log($"wordFrame = {wordFrame}");
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
