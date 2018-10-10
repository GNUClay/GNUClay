using System;

namespace DictionaryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Main Begin");

            var rootNounsSource = new RootNounsWordNetSource();

            var rootNounsList = rootNounsSource.ReadAll();

            NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNounsList.Count = {rootNounsList.Count}");
            foreach(var rootNoun in rootNounsList)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"Main rootNoun = {rootNoun}");
            }
        }
    }
}
