using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DictionaryGenerator
{
    public class WordsFactory
    {
        public WordsFactory()
        {
            mRootNounsSource = new RootNounsWordNetSource();
            mRootVerbsSource = new RootVerbsWordNetSource();
            mRootAdjSource = new RootAdjWordNetSource();
            mRootAdvSource = new RootAdvWordNetSource();

            mNounAntiStemmer = new NounAntiStemmer();
            mVerbAntiStemmer = new VerbAntiStemmer();
            mAdjAntiStemmer = new AdjAntiStemmer();
            mAdvAntiStemmer = new AdvAntiStemmer();
        }

        private RootNounsWordNetSource mRootNounsSource;
        private RootVerbsWordNetSource mRootVerbsSource;
        private RootAdjWordNetSource mRootAdjSource;
        private RootAdvWordNetSource mRootAdvSource;

        private NounAntiStemmer mNounAntiStemmer;
        private VerbAntiStemmer mVerbAntiStemmer;
        private AdjAntiStemmer mAdjAntiStemmer;
        private AdvAntiStemmer mAdvAntiStemmer;

        private Dictionary<string, List<RootNounSourceWordItem>> mRootNounDict;
        private Dictionary<string, List<RootVerbSourceWordItem>> mRootVerbsDict;
        private Dictionary<string, List<RootAdjSourceWordItem>> mRootAdjsDict;
        private Dictionary<string, List<RootAdvSourceWordItem>> mRootAdvsDict;

        private int mTotalCount;

        private WordsDictData mWordsDictData;

        public void Run()
        {
            var totalNamesList = new List<string>();

            var rootNounsList = mRootNounsSource.ReadAll();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run rootNounsList.Count = {rootNounsList.Count}");
#endif
            var namesList = mRootNounsSource.ReadNormalWords(rootNounsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run namesList.Count = {namesList.Count}");
#endif
            totalNamesList.AddRange(namesList);

            mRootNounDict = rootNounsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

            var rootVerbsList = mRootVerbsSource.ReadAll();

            namesList = mRootVerbsSource.ReadNormalWords(rootVerbsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run namesList.Count = {namesList.Count}");
#endif
            totalNamesList.AddRange(namesList);

            mRootVerbsDict = rootVerbsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

            var rootAdjsList = mRootAdjSource.ReadAll();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run rootAdjsList.Count = {rootAdjsList.Count}");
#endif
            namesList = mRootAdjSource.ReadNormalWords(rootAdjsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run namesList.Count = {namesList.Count}");
#endif
            totalNamesList.AddRange(namesList);

            mRootAdjsDict = rootAdjsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

            var rootAdvsList = mRootAdvSource.ReadAll();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run rootAdvsList.Count = {rootAdvsList.Count}");
#endif
            namesList = mRootAdvSource.ReadNormalWords(rootAdvsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run namesList.Count = {namesList.Count}");
#endif
            totalNamesList.AddRange(namesList);

            mRootAdvsDict = rootAdvsList.GroupBy(p => p.Word).ToDictionary(p => p.Key, p => p.ToList());

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run totalNamesList.Count = {totalNamesList.Count}");
#endif
            totalNamesList = totalNamesList.Distinct().OrderBy(p => p).ToList();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run totalNamesList.Count (2) = {totalNamesList.Count}");
#endif

            mWordsDictData = new WordsDictData();
            mWordsDictData.WordsDict = new Dictionary<string, WordFrame>();

            foreach (var rootName in totalNamesList)
            {
                ProcessRootWordName(rootName);
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run mTotalCount = {mTotalCount}");
#endif
        }

        private void ProcessRootWordName(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessRootWordName rootWord = {rootWord}");
#endif

            var rez = Regex.Match(rootWord, @"\(\w+\)");
            var rezStr = rez.ToString();

            if (!string.IsNullOrWhiteSpace(rezStr))
            {
                rootWord = rootWord.Replace(rezStr, string.Empty);
            }

            if (mRootNounDict.ContainsKey(rootWord))
            {
                ProcessNoun(rootWord);
            }

            if (mRootVerbsDict.ContainsKey(rootWord))
            {
                if(rootWord == "be")
                {
                    ProcessBe();
                    return;
                }

                if (rootWord == "have")
                {
                    ProcessHave();
                    return;
                }

                ProcessVerb(rootWord);
            }

            if (mRootAdjsDict.ContainsKey(rootWord))
            {
                ProcessAdj(rootWord);
            }

            if (mRootAdvsDict.ContainsKey(rootWord))
            {
                ProcessAdv(rootWord);
            }
        }

        private void ProcessNoun(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun rootWord = {rootWord}");
#endif
            mTotalCount++;

            var multipleForms = mNounAntiStemmer.GetMultipleForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNoun multipleForms = {multipleForms}");

            mTotalCount++;
        }

        private void ProcessVerb(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb rootWord = {rootWord}");
#endif
            mTotalCount++;

            var pastFormsList = mVerbAntiStemmer.GetPastForms(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb pastFormsList = {string.Join(',', pastFormsList)}");

            var particleFormsList = mVerbAntiStemmer.GetParticleForms(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb particleFormsList = {string.Join(',', particleFormsList)}");

            mTotalCount += particleFormsList.Count;

            var ingForm = mVerbAntiStemmer.GetIngForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb ingForm = {ingForm}");

            mTotalCount++;

            var presentThirdPersonForm = mVerbAntiStemmer.GetThirdPersonSingularPresent(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessVerb presentThirdPersonForm = {presentThirdPersonForm}");

            mTotalCount++;
        }

        private void ProcessBe()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessBe");
#endif
        }

        private void ProcessHave()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessHave");
#endif
        }

        private void ProcessAdj(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdj rootWord = {rootWord}");
#endif
            mTotalCount++;

            var comparativeForm = mAdjAntiStemmer.GetComparativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdj comparativeForm = {comparativeForm}");
            mTotalCount++;

            var superlativeForm = mAdjAntiStemmer.GetSuperlativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdj superlativeForm = {superlativeForm}");
            mTotalCount++;
        }

        private void ProcessAdv(string rootWord)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdv rootWord = {rootWord}");
#endif
            mTotalCount++;

            var comparativeForm = mAdvAntiStemmer.GetComparativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdv comparativeForm = {comparativeForm}");

            if(string.IsNullOrWhiteSpace(comparativeForm))
            {
                mTotalCount++;
            }

            var superlativeForm = mAdvAntiStemmer.GetSuperlativeForm(rootWord);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAdv superlativeForm = {superlativeForm}");

            if (string.IsNullOrWhiteSpace(superlativeForm))
            {
                mTotalCount++;
            }
        }
    }
}
