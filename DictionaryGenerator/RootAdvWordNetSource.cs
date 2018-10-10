using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class RootAdvWordNetSource : BaseRootWordNetSource
    {
        public RootAdvWordNetSource()
            : base(@"Resources\WordNet\dict\data.adv", 30)
        {
        }

        public List<RootAdvSourceWordItem> ReadAll()
        {
            var resultList = new List<RootAdvSourceWordItem>();

            Read((string currentLine) => {
#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"Read currentLine = {currentLine}");
#endif

                var item = ReaderOfRootAdvSourceWordItem.Read(currentLine);

#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"Read item = {item}");
#endif

                resultList.Add(item);
            });

            return resultList;
        }

        public List<RootAdvSourceWordItem> ReadNormalWords(List<RootAdvSourceWordItem> source)
        {
            return source.Where(p => !p.Word.Contains("_") && !p.Word.Contains("-") && !char.IsDigit(p.Word[0]) && !char.IsUpper(p.Word[0])).ToList();
        }

        public List<RootAdvSourceWordItem> ReadNormalWords()
        {
            var initItemsList = ReadAll();

            return ReadNormalWords(initItemsList);
        }
    }
}
