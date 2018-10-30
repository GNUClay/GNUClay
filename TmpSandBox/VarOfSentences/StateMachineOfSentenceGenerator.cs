using MyNPCLib;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TmpSandBox.VarOfSentences
{
    public class StateMachineOfSentenceGenerator
    {
        public void Run(List<TstSentence> sentencesList)
        {
            LogInstance.Log("Begin");

            var maxLength = sentencesList.Max(p => p.WordsList.Count);

            LogInstance.Log($"maxLength = {maxLength}");

            var flatTable = new List<List<TstKindOfItemOfSentence>>();

            foreach(var item in sentencesList)
            {
                var itemList = new List<TstKindOfItemOfSentence>();

                var wordsList = item.WordsList;

                for (var i = 0; i < maxLength + 1; i++)
                {
                    LogInstance.Log($"i = {i}");

                    if(i >= wordsList.Count)
                    {
                        itemList.Add(TstKindOfItemOfSentence.Unknown);
                    }
                    else
                    {
                        itemList.Add(wordsList[i].Kind);
                    }
                }

                flatTable.Add(itemList);
            }

            DisplayTable(flatTable);

            var orderedFlatTable = flatTable.OrderBy(p => p[0]);

            for (var i = 1; i < maxLength; i++)
            {
                orderedFlatTable = orderedFlatTable.ThenBy(p => p[i]);
            }

            flatTable = orderedFlatTable.ToList();

            DisplayTable(flatTable);

            LogInstance.Log("End");
        }

        public void DisplayTable(List<List<TstKindOfItemOfSentence>> flatTable)
        {
            LogInstance.Log("Begin");

            var sb = new StringBuilder();

            foreach(var item in flatTable)
            {
                var sbOfItem = new StringBuilder();
                foreach(var cell in item)
                {
                    sbOfItem.Append($"{cell}|");
                }
                sb.AppendLine(sbOfItem.ToString());
            }

            LogInstance.Log($"sb.ToString() = {sb.ToString()}");

            LogInstance.Log("End");
        }
    }
}
