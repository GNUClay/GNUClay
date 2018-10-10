﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class RootNounsWordNetSource: BaseRootWordNetSource
    {
        public RootNounsWordNetSource()
            : base(@"Resources\WordNet\dict\data.noun", 30)
        {
        }

        public List<RootNounSourceWordItem> ReadAll()
        {
            var resultList = new List<RootNounSourceWordItem>();

            Read((string currentLine) => {
                var item = ReaderOfRootNounSourceWordItem.Read(currentLine);

#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"Read item = {item}");
#endif

                resultList.Add(item);
            });

            return resultList;
        }

        public List<RootNounSourceWordItem> ReadNormalWords(List<RootNounSourceWordItem> source)
        {
            return source.Where(p => !p.Word.Contains("_") && !p.Word.Contains("-") && !char.IsDigit(p.Word[0]) && !char.IsUpper(p.Word[0])).ToList();
        }

        public List<RootNounSourceWordItem> ReadNormalWords()
        {
            var initItemsList = ReadAll();

            return ReadNormalWords(initItemsList);
        }
    }
}
