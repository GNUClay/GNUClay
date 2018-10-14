using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace DictionaryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Main Begin");

            //TSTRemoveRoundBreackets();
            TSTWordsFactory();
            //TSTMakeIrrTable();
            //TSTAdvAntiStemmer();
            //TSTAdjAntiStemmer();
            //TSTNounAntiStemmer();
            //TSTVerbAntiStemmer();
            //TSTReadWordNetSources();
        }

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

            var multipleForms = nounAntiStemmer.GetMultipleForm(baseForm);

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

            var namesList = rootNounsSource.ReadNormalWords(rootNounsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            totalNamesList.AddRange(namesList);

            //foreach (var rootNoun in namesList)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootNoun}");
            //}

            var rootVerbsSource = new RootVerbsWordNetSource();
            var rootVerbsList = rootVerbsSource.ReadAll();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main rootVerbsList.Count = {rootVerbsList.Count}");

            namesList = rootVerbsSource.ReadNormalWords(rootVerbsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            totalNamesList.AddRange(namesList);

            //foreach (var rootVerb in namesList)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootVerb}");
            //}

            var rootAdjSource = new RootAdjWordNetSource();
            var rootAdjsList = rootAdjSource.ReadAll();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main rootAdjsList.Count = {rootAdjsList.Count}");

            namesList = rootAdjSource.ReadNormalWords(rootAdjsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            totalNamesList.AddRange(namesList);

            //foreach (var rootVerb in namesList)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootVerb}");
            //}

            var rootAdvSource = new RootAdvWordNetSource();
            var rootAdvsList = rootAdvSource.ReadAll();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main rootAdvsList.Count = {rootAdvsList.Count}");

            namesList = rootAdvSource.ReadNormalWords(rootAdvsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            totalNamesList.AddRange(namesList);

            NLog.LogManager.GetCurrentClassLogger().Info($"Main totalNamesList.Count = {totalNamesList.Count}");

            totalNamesList = totalNamesList.Distinct().OrderBy(p => p).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main totalNamesList.Count (2) = {totalNamesList.Count}");

            foreach (var rootVerb in totalNamesList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootVerb}");
            }
        }
    }
}
