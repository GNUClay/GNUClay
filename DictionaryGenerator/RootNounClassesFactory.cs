using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class RootNounClassesFactory
    {
        public RootNounClassesFactory(List<RootNounSourceWordItem> source)
        {
            Result = new Dictionary<string, List<string>>();

            mWordIdDict = source.ToDictionary(p => p.WordNum, p => p);

            foreach (var rootNoun in source)
            {
#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"RootNounClassesFactory rootNoun = {rootNoun}");
#endif
                var fullClassesList = new List<string>();

                var parentWordNumsList = rootNoun.ParentWordNumsList;
                foreach(var parentWordNum in parentWordNumsList)
                {
                    NFillFullClasses(parentWordNum, ref fullClassesList);
                }

                fullClassesList = fullClassesList.Distinct().ToList();

#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"RootNounClassesFactory fullClassesList.Count = {fullClassesList.Count}");

                //foreach (var className in fullClassesList)
                //{
                //    NLog.LogManager.GetCurrentClassLogger().Info($"RootNounClassesFactory className = {className}");
                //}
#endif
                Result[rootNoun.Word] = fullClassesList;
            }
        }

        public Dictionary<string, List<string>> Result { get; private set; }
        private Dictionary<int, RootNounSourceWordItem> mWordIdDict;

        private void NFillFullClasses(int wordNum, ref List<string> fullClassesList)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"NFillFullClasses wordNum = {wordNum}");
#endif
            if (wordNum == 0)
            {
                return;
            }

            var targetWord = mWordIdDict[wordNum];
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"NFillFullClasses targetWord = {targetWord}");
#endif
            //if (fullClassesList.Contains(targetWord.Word))
            //{
            //    return;
            //}

            fullClassesList.Add(targetWord.Word);
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"NFillFullClasses targetWordVar = {targetWordVar}");
#endif
            var parentWordNumsList = targetWord.ParentWordNumsList;

            foreach (var parentWordNum in parentWordNumsList)
            {
                NFillFullClasses(parentWordNum, ref fullClassesList);
            }
        }
    }
}
