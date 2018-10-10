using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class RootVerbsWordNetSource: BaseRootWordNetSource
    {
        public RootVerbsWordNetSource()
            : base(@"Resources\WordNet\dict\data.verb", 30)
        {
        }

        public List<RootVerbSourceWordItem> ReadAll()
        {
            var resultList = new List<RootVerbSourceWordItem>();

            Read((string currentLine) => {
#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"Read currentLine = {currentLine}");
#endif

                var item = ReaderOfRootVerbSourceWordItem.Read(currentLine);

#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"Read item = {item}");
#endif

                resultList.Add(item);
            });

            return resultList;
        }

        public List<RootVerbSourceWordItem> ReadNormalWords(List<RootVerbSourceWordItem> source)
        {
            return source.Where(p => !p.Word.Contains("_") && !p.Word.Contains("-") && !char.IsDigit(p.Word[0]) && !char.IsUpper(p.Word[0])).ToList();
        }

        public List<RootVerbSourceWordItem> ReadNormalWords()
        {
            var initItemsList = ReadAll();

            return ReadNormalWords(initItemsList);
        }
    }
}
