using MyNPCLib;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace DictionaryGenerator
{
    class Program
    {
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CurrentDomain_UnhandledException e.ExceptionObject = {e.ExceptionObject}");
        }

        static void Main(string[] args)
        {
            var logProxy = new LogProxyForNLog();
            LogInstance.SetLogProxy(logProxy);

            LogInstance.Log("Begin");

            //TSTSeparateWords();
            //TSTLogicalMeaningsSource();
            //TSTClasses();
            //TSTRemoveRoundBreackets();
            //TSTWordsFactory();
            //TSTMergeDictionaries();
            TSTDiscoverDictionary();
            //TSTMakeIrrTable();
            //TSTAdvAntiStemmer();
            //TSTAdjAntiStemmer();
            //TSTNounAntiStemmer();
            //TSTVerbAntiStemmer();
            //TSTReadWordNetSources();
        }

        private static void TSTSeparateWords()
        {
            var rootNounsSource = new RootNounsWordNetSource();

            var rootNounsList = rootNounsSource.ReadAll();

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords rootNounsList.Count = {rootNounsList.Count}");

            var usualWordsList = new List<string>();
            var namesWordsList = new List<string>();
            var digitsWordsList = new List<string>();
            var complexWordsList = new List<string>();

            ReaderOfRootSourceWordItemHelper.SeparateWords(rootNounsList, ref usualWordsList, ref namesWordsList, ref digitsWordsList, ref complexWordsList);

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords usualWordsList.Count = {usualWordsList.Count}");

            foreach (var word in usualWordsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords word = {word}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords namesWordsList.Count = {namesWordsList.Count}");

            foreach (var word in namesWordsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords word = {word}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords digitsWordsList.Count = {digitsWordsList.Count}");

            foreach (var word in digitsWordsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords word = {word}");
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords complexWordsList.Count = {complexWordsList.Count}");

            foreach (var word in complexWordsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"TSTSeparateWords word = {word}");
            }
        }

        private static void TSTLogicalMeaningsSource()
        {
            var verbLogicalMeaningsSource = new VerbLogicalMeaningsSource();

            var word = "know";

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTLogicalMeaningsSource word = {word}");

            var result = verbLogicalMeaningsSource.GetLogicalMeanings(word);

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTLogicalMeaningsSource result.Count = {result.Count}");

            foreach (var className in result)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"TSTLogicalMeaningsSource className = {className}");
            }

            word = "run";

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTLogicalMeaningsSource word = {word}");

            result = verbLogicalMeaningsSource.GetLogicalMeanings(word);

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTLogicalMeaningsSource result.Count = {result.Count}");

            foreach (var className in result)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"TSTLogicalMeaningsSource className = {className}");
            }
        }

        private static void TSTClasses()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin TSTClasses");

            //var rootVerbsSource = new RootVerbsWordNetSource();
            //var rootNounsList = rootVerbsSource.ReadAll().Select(p => (BaseWithParentsSourceWordItem)p).ToList();

            var rootNounsSource = new RootNounsWordNetSource();

            var rootNounsList = rootNounsSource.ReadAll();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNounsList.Count = {rootNounsList.Count}");

            var rootNounClassesFactory = new RootNounClassesFactory(rootNounsList);

            NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNounClassesFactory.Result.Count = {rootNounClassesFactory.Result.Count}");

            //mWordIdDict = rootNounsList.ToDictionary(p => p.WordNum, p => p);

            //foreach(var rootNoun in rootNounsList)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootNoun}");

            //    var fullClassesList = new List<string>();

            //    NFillFullClasses(rootNoun.ParentWordNum, ref fullClassesList);

            //    NLog.LogManager.GetCurrentClassLogger().Info($"Main fullClassesList.Count = {fullClassesList.Count}");

            //    foreach (var className in fullClassesList)
            //    {
            //        NLog.LogManager.GetCurrentClassLogger().Info($"Main className = {className}");
            //    }
            //}

            //var namesList = rootNounsSource.ReadNormalWords(rootNounsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            //foreach (var rootNoun in namesList)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootNoun}");
            //}
        }

        //private static Dictionary<int, BaseWithParentsSourceWordItem> mWordIdDict;
        //private static Dictionary<int, List<string>> mFullClassesDict = new Dictionary<int, List<string>>();

        //private static void NFillFullClasses(int wordNum, ref List<string> fullClassesList)
        //{
        //    //NLog.LogManager.GetCurrentClassLogger().Info($"NFillFullClasses wordNum = {wordNum}");

        //    if(wordNum == 0)
        //    {
        //        return;
        //    }

        //    //if(mFullClassesDict.ContainsKey(wordNum))
        //    //{
        //    //    var targetClassesList = mFullClassesDict[wordNum];
        //    //    fullClassesList.AddRange(targetClassesList);
        //    //    return;
        //    //}

        //    var targetWord = mWordIdDict[wordNum];

        //    //NLog.LogManager.GetCurrentClassLogger().Info($"NFillFullClasses targetWord = {targetWord}");

        //    if (fullClassesList.Contains(targetWord.Word))
        //    {
        //        return;
        //    }

        //    fullClassesList.Add(targetWord.Word);

        //    //NLog.LogManager.GetCurrentClassLogger().Info($"NFillFullClasses targetWordVar = {targetWordVar}");

        //    NFillFullClasses(targetWord.ParentWordNum, ref fullClassesList);
        //}

        private static void TSTRemoveRoundBreackets()
        {
            var str = "beaten(a)";

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTRemoveRoundBreackets str = {str}");

            var rez = Regex.Match(str, @"\(\w+\)");

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTRemoveRoundBreackets rez = {rez}");

            var rezStr = rez.ToString();

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTRemoveRoundBreackets string.IsNullOrWhiteSpace(rezStr) = {string.IsNullOrWhiteSpace(rezStr)}");

            if(!string.IsNullOrWhiteSpace(rezStr))
            {
                var index = rez.Index;

                NLog.LogManager.GetCurrentClassLogger().Info($"TSTRemoveRoundBreackets index = {index}");

                var length = rez.Length;

                NLog.LogManager.GetCurrentClassLogger().Info($"TSTRemoveRoundBreackets length = {length}");

                str = str.Replace(rezStr, string.Empty);
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"TSTRemoveRoundBreackets str = {str}");
        }

        private static void TSTWordsFactory()
        {
            var wordsFactory = new WordsFactory();
            wordsFactory.Run();
        }

        private static void TSTMergeDictionaries()
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTMergeDictionaries rootPath = {rootPath}");
#endif

            var serializator = new WordsDictSerializationEngine();

            var mainDictLocalName = "main.dict";

            var mainDictFullPath = Path.Combine(rootPath, mainDictLocalName);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTMergeDictionaries mainDictFullPath = {mainDictFullPath}");
#endif

            var mainDict = serializator.LoadFromFile(mainDictFullPath);

            var namesDictLocalName = "names.dict";

            var namesDictFullPath = Path.Combine(rootPath, namesDictLocalName);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTMergeDictionaries namesDictFullPath = {namesDictFullPath}");
#endif

            var namesDict = serializator.LoadFromFile(namesDictFullPath);

            //var mainDict = TmpFactoryOfWordsDictData.Data;

            var workingDict = new WordsDictData();
            workingDict.WordsDict = new Dictionary<string, WordFrame>();

            var tagretWorsList = new List<string>() { "dog", "shower" };
            //tagretWorsList.Clear();

            DictionaryMerger.Merge(mainDict, workingDict, tagretWorsList);
            DictionaryMerger.Merge(namesDict, workingDict, tagretWorsList);

            var workingDictLocalName = "working.dict";

            var workingDictFullName = Path.Combine(rootPath, workingDictLocalName);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTMergeDictionaries workingDictFullName = {workingDictFullName}");
#endif

            serializator.SaveToFile(workingDict, workingDictFullName);
        }

        private static void TSTDiscoverDictionary()
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTMergeDictionaries rootPath = {rootPath}");
#endif

            var serializator = new WordsDictSerializationEngine();

            //var mainDictLocalName = "main.dict";
            var mainDictLocalName = "working.dict";

            var mainDictFullPath = Path.Combine(rootPath, mainDictLocalName);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTMergeDictionaries mainDictFullPath = {mainDictFullPath}");
#endif

            var mainDict = serializator.LoadFromFile(mainDictFullPath);

            var wordFrame = mainDict.WordsDict["shower"];

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTMergeDictionaries wordFrame = {wordFrame}");
#endif

            wordFrame = mainDict.WordsDict["dogs"];

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"TSTMergeDictionaries wordFrame = {wordFrame}");
#endif
        }

        private static void TSTMakeIrrTable()
        {
            //var tstMakeIrrTable = new TSTMakeIrrTable();
            //tstMakeIrrTable.Run();
        }

        private static void TSTAdvAntiStemmer()
        {
            var baseForm = "early";

            NTSTAdvAntiStemmer(baseForm);

            baseForm = "well";
            NTSTAdvAntiStemmer(baseForm);

            baseForm = "fast";
            NTSTAdvAntiStemmer(baseForm);

            baseForm = "clearly";
            NTSTAdvAntiStemmer(baseForm);
        }

        private static void NTSTAdvAntiStemmer(string baseForm)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTAdvAntiStemmer baseForm = {baseForm}");

            var advAntiStemmer = new AdvAntiStemmer();

            var comparativeForm = advAntiStemmer.GetComparativeForm(baseForm);

            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTAdvAntiStemmer comparativeForm = {comparativeForm}");

            var superlativeForm = advAntiStemmer.GetSuperlativeForm(baseForm);

            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTAdvAntiStemmer superlativeForm = {superlativeForm}");
        }

        private static void TSTAdjAntiStemmer()
        {
            var baseForm = "green";

            NTSTAdjAntiStemmer(baseForm);

            baseForm = "good";

            NTSTAdjAntiStemmer(baseForm);

            baseForm = "acer";

            NTSTAdjAntiStemmer(baseForm);
        }

        private static void NTSTAdjAntiStemmer(string baseForm)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTAdjAntiStemmer baseForm = {baseForm}");

            var adjAntiStemmer = new AdjAntiStemmer();

            var comparativeForm = adjAntiStemmer.GetComparativeForm(baseForm);

            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTAdjAntiStemmer comparativeForm = {comparativeForm}");

            var superlativeForm = adjAntiStemmer.GetSuperlativeForm(baseForm);

            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTAdjAntiStemmer superlativeForm = {superlativeForm}");
        }

        private static void TSTNounAntiStemmer()
        {
            var baseForm = "boy";

            NTSTNounAntiStemmer(baseForm);

            baseForm = "man";

            NTSTNounAntiStemmer(baseForm);

            baseForm = "boss";

            NTSTNounAntiStemmer(baseForm);

            baseForm = "aircraft";

            NTSTNounAntiStemmer(baseForm);
        }

        private static void NTSTNounAntiStemmer(string baseForm)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTNounAntiStemmer baseForm = {baseForm}");

            var nounAntiStemmer = new NounAntiStemmer();

            var multipleForms = nounAntiStemmer.GetPluralForm(baseForm);

            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTNounAntiStemmer multipleForms = {multipleForms}");
        }

        private static void TSTVerbAntiStemmer()
        {
            var baseForm = "help";
            NTSTVerbAntiStemmer(baseForm);

            baseForm = "like";
            NTSTVerbAntiStemmer(baseForm);

            //baseForm = "be";
            //NTSTVerbAntiStemmer(baseForm);

            baseForm = "do";
            NTSTVerbAntiStemmer(baseForm);

            baseForm = "ship";
            NTSTVerbAntiStemmer(baseForm);

            baseForm = "have";
            NTSTVerbAntiStemmer(baseForm);
        }

        private static void NTSTVerbAntiStemmer(string baseForm)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTVerbAntiStemmer baseForm = {baseForm}");

            var verbAntiStemmer = new VerbAntiStemmer();

            var pastFormsList = verbAntiStemmer.GetPastForms(baseForm);

            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTVerbAntiStemmer pastFormsList = {string.Join(',', pastFormsList)}");

            var particleFormsList = verbAntiStemmer.GetParticleForms(baseForm);

            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTVerbAntiStemmer particleFormsList = {string.Join(',', particleFormsList)}");

            var ingForm = verbAntiStemmer.GetIngForm(baseForm);

            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTVerbAntiStemmer ingForm = {ingForm}");

            var presentThirdPersonForm = verbAntiStemmer.GetThirdPersonSingularPresent(baseForm);

            NLog.LogManager.GetCurrentClassLogger().Info($"NTSTVerbAntiStemmer presentThirdPersonForm = {presentThirdPersonForm}");
        }

        private static void TSTReadWordNetSources()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin TSTReadWordNetSources");

            var totalNamesList = new List<string>();

            var rootNounsSource = new RootNounsWordNetSource();

            var rootNounsList = rootNounsSource.ReadAll();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNounsList.Count = {rootNounsList.Count}");

            foreach (var rootNoun in rootNounsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootNoun}");
            }

            //var namesList = rootNounsSource.ReadNormalWords(rootNounsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            //totalNamesList.AddRange(namesList);

            ////foreach (var rootNoun in namesList)
            ////{
            ////    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootNoun}");
            ////}

            //var rootVerbsSource = new RootVerbsWordNetSource();
            //var rootVerbsList = rootVerbsSource.ReadAll();

            ////NLog.LogManager.GetCurrentClassLogger().Info($"Main rootVerbsList.Count = {rootVerbsList.Count}");

            //namesList = rootVerbsSource.ReadNormalWords(rootVerbsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            //totalNamesList.AddRange(namesList);

            ////foreach (var rootVerb in namesList)
            ////{
            ////    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootVerb}");
            ////}

            //var rootAdjSource = new RootAdjWordNetSource();
            //var rootAdjsList = rootAdjSource.ReadAll();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main rootAdjsList.Count = {rootAdjsList.Count}");

            //namesList = rootAdjSource.ReadNormalWords(rootAdjsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            //totalNamesList.AddRange(namesList);

            ////foreach (var rootVerb in namesList)
            ////{
            ////    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootVerb}");
            ////}

            //var rootAdvSource = new RootAdvWordNetSource();
            //var rootAdvsList = rootAdvSource.ReadAll();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main rootAdvsList.Count = {rootAdvsList.Count}");

            //namesList = rootAdvSource.ReadNormalWords(rootAdvsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            //totalNamesList.AddRange(namesList);

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main totalNamesList.Count = {totalNamesList.Count}");

            //totalNamesList = totalNamesList.Distinct().OrderBy(p => p).ToList();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main totalNamesList.Count (2) = {totalNamesList.Count}");

            //foreach (var rootVerb in totalNamesList)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootVerb}");
            //}
        }
    }
}
