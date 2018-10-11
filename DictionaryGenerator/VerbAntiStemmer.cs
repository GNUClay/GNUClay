using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator
{
    public class VerbAntiStemmer
    {
        public string GetPastForm(string baseForm)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetPastForm baseForm = {baseForm}");
#endif

            return string.Empty;
        }
    }
}
