using MyNPCLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public static class OgdenListGenerator
    {
        public static List<string> Get()
        {
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Resources\Ogden.txt");

#if DEBUG
            LogInstance.Log($"path = {path}");
#endif
            var wordsList = new List<string>();

            using (var fs = File.OpenRead(path))
            {
                using (var sr = new StreamReader(fs))
                {
                    var content = sr.ReadToEnd().Replace("<P>", string.Empty).Replace("<br>", string.Empty);

#if DEBUG
                    LogInstance.Log($"content = {content}");
#endif
                    var initWordsList = content.Split('\n', ',', '.', ' ').ToList();

#if DEBUG
                    LogInstance.Log($"initWordsList.Count = {initWordsList.Count}");
#endif
                    foreach (var word in initWordsList)
                    {
                        if (string.IsNullOrWhiteSpace(word))
                        {
                            continue;
                        }

#if DEBUG
                        //LogInstance.Log($"word = {word}");
#endif
                        wordsList.Add(word);
                    }
                }
            }

            return wordsList;
        }
    }
}
