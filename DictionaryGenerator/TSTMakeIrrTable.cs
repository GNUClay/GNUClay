using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class TSTMakeIrrTable: BaseRootWordNetSource
    {
        public TSTMakeIrrTable()
            : base(@"Resources\MyDicts\irverbs.txt", 0)
        {
        }

        public void Run()
        {
            Read((string currentLine) => {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Read currentLine = {currentLine}");
#endif

                var item = TSTReaderOfIrregularVerbItem.Read(currentLine);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Read item = {item}");
#endif
            });
        }
    }

    public static class TSTReaderOfIrregularVerbItem
    {
        public static IrregularVerbItem Read(string source)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Read source = {source}");
#endif

            source = new string(source.Where(p => !char.IsDigit(p) && (int)p != 9 && (int)p < 125 && p != ',').ToArray()).Replace(" / ", "/").Replace("/ ", "/").Replace(" /", "/").Trim();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Read NEXT source = {source}");
#endif

            var n = 0;

            var result = new IrregularVerbItem();

            var sb = new StringBuilder();
            var strValue = string.Empty;

            var lastCharNum = 0;

            foreach (var ch in source)
            {
                var charNum = (int)ch;

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Read ch = {ch} charNum = {charNum}");
#endif

                if (charNum == 32)
                {
                    if (lastCharNum != charNum)
                    {
                        n++;
                    }

                    lastCharNum = charNum;

                    strValue = sb.ToString();

#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"Read strValue = {strValue}");
#endif
                    switch (n)
                    {
                        case 1:
                            result.RootWord = strValue.Trim();
                            break;

                        case 2:
                            result.PastForm = strValue.Trim();
                            break;

                        case 3:
                            result.ParticleForm = strValue.Trim();
                            return result;
                    }

                    sb = new StringBuilder();

                    continue;
                }


                lastCharNum = charNum;
                sb.Append(ch);
            }

            strValue = sb.ToString();

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Read strValue = {strValue}");
#endif

            result.ParticleForm = strValue.Trim();

            return result;
        }
    }
}
