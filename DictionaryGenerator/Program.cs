using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Main Begin");

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
