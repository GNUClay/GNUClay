using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DictionaryGenerator
{
    public partial class WordsFactory
    {
        private void ProcessComplexPhrases(List<string> totalNamesList)
        {
            ProcessAllComplexPronouns();
            ProcessAllComplexPrepositions();
            ProcessAllComplexConjunctions();
            ProcessAllComplexNumerals();

            foreach (var rootName in totalNamesList)
            {
                ProcessComplexRootWordName(rootName);
            }
        }

        private void ProcessComplexRootWordName(string rootWord)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRootWordName rootWord = {rootWord}");
#endif

            var rez = Regex.Match(rootWord, @"\(\w+\)");
            var rezStr = rez.ToString();

            if (!string.IsNullOrWhiteSpace(rezStr))
            {
                rootWord = rootWord.Replace(rezStr, string.Empty);
            }

            if (mRootNounDict.ContainsKey(rootWord))
            {
                ProcessComplexNoun(rootWord);
            }

            if (mRootVerbsDict.ContainsKey(rootWord))
            {
                ProcessComplexVerb(rootWord);
            }

            if (mRootAdjsDict.ContainsKey(rootWord))
            {
                ProcessComplexAdj(rootWord);
            }

            if (mRootAdvsDict.ContainsKey(rootWord))
            {
                ProcessComplexAdv(rootWord);
            }
        }

        private void ProcessComplexNoun(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessComplexNoun rootWord = {rootWord}");
#endif

            if (IsNumeral(rootWord))
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessComplexNoun IsNumeral(rootWord) return; !!!!!");
#endif
                return;
            }
        }

        private void ProcessComplexVerb(string rootWord)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessComplexVerb rootWord = {rootWord}");
#endif
        }

        private void ProcessComplexAdj(string rootWord)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessComplexAdj rootWord = {rootWord}");
#endif
        }

        private void ProcessComplexAdv(string rootWord)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessComplexAdv rootWord = {rootWord}");
#endif

            if (IsNumeral(rootWord))
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info("ProcessComplexAdv IsNumeral(rootWord) return; !!!!!");
#endif
                return;
            }


        }
    }
}
