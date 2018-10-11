using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class NounAntiStemmer : BaseAntiStemmer
    {
        public NounAntiStemmer()
            : base(new NounExceptionCasesWordNetSource())
        {
        }

        public string GetMultipleForm(string baseForm)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetMultipleForm baseForm = {baseForm}");
#endif

            var lastChar = baseForm.Last();

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetMultipleForm lastChar = {lastChar}");
#endif

            var multipleForm = string.Empty;

            switch(lastChar)
            {
                case 'h':
                case 'j':
                case 's':
                case 'x':
                case 'z':
                    multipleForm = $"{baseForm}es";
                    break;

                default:
                    multipleForm = $"{baseForm}s";
                    break;
            }

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetPastForm multipleForm = {multipleForm}");
#endif

            var listOfExeptWords = GetExceptionsList(baseForm);

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetPastForm listOfExeptWords.Count = {listOfExeptWords.Count}");
            //foreach (var exceptWord in listOfExeptWords)
            //{
            //    NLog.LogManager.GetCurrentClassLogger().Info($"GetPastForm exceptWord = {exceptWord}");
            //}
#endif
            if (listOfExeptWords.Count == 0)
            {
                return multipleForm;
            }

            var edEndsWord = listOfExeptWords.FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(edEndsWord))
            {
                return edEndsWord;
            }

            return multipleForm;
        }
    }
}
