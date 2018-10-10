using System;
using System.Linq;

namespace DictionaryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Main Begin");

            //var rootNounsSource = new RootNounsWordNetSource();

            //var rootNounsList = rootNounsSource.ReadAll();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNounsList.Count = {rootNounsList.Count}");

            //var namesList = rootNounsSource.ReadNormalWords(rootNounsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            //NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            //foreach (var rootNoun in namesList)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootNoun}");
            //}

            var rootVerbsSource = new RootVerbsWordNetSource();
            var rootVerbsList = rootVerbsSource.ReadAll();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main rootVerbsList.Count = {rootVerbsList.Count}");

            var namesList = rootVerbsSource.ReadNormalWords(rootVerbsList).Select(p => p.Word).Distinct().OrderBy(p => p).ToList();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main namesList.Count = {namesList.Count}");

            foreach (var rootVerb in namesList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootVerb}");
            }
        }
    }
}
