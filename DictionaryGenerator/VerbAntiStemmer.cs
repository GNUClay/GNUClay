using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator
{
    public class VerbAntiStemmer: BaseAntiStemmer
    {
        public VerbAntiStemmer()
            : base(new VerbsExceptionCasesWordNetSource())
        {
            var irregularVerbsSource = new IrregularVerbsSource();
            var irregularItemsList = irregularVerbsSource.ReadAll();

            foreach(var irregularItem in irregularItemsList)
            {
                var rootWord = irregularItem.RootWord;

                var pastFormsList = irregularItem.PastForm.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                mIrregularPastFormsDict[rootWord] = pastFormsList;

                var particleFormsList = irregularItem.ParticleForm.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList();
                mIrregularParticlesDict[rootWord] = particleFormsList;
            }
        }

        private Dictionary<string, List<string>> mIrregularPastFormsDict = new Dictionary<string, List<string>>();
        private Dictionary<string, List<string>> mIrregularParticlesDict = new Dictionary<string, List<string>>();

        public List<string> GetPastForms(string baseForm)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetPastForms baseForm = {baseForm}");
#endif

            if(baseForm == "be")
            {
                throw new NotSupportedException("The verb `be` is a very special word");
            }

            return new List<string>() { GetRegularPastOrParticleForm(baseForm) };
        }

        private string GetRegularPastOrParticleForm(string baseForm)
        {
            var lastChar = baseForm.Last();
            var pastForm = string.Empty;

            if (lastChar == 'e')
            {
                pastForm = $"{baseForm}d";
            }
            else
            {
                pastForm = $"{baseForm}ed";
            }

#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"GetPastForm pastForm = {pastForm}");
#endif

            var listOfExeptWords = GetExceptionsList(baseForm);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"GetPastForm listOfExeptWords.Count = {listOfExeptWords.Count}");
            foreach (var exceptWord in listOfExeptWords)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"GetPastForm exceptWord = {exceptWord}");
            }
#endif

            if (listOfExeptWords.Count == 0)
            {
                return pastForm;
            }

            var edEndsWord = listOfExeptWords.Where(p => p.EndsWith("ed")).FirstOrDefault();

            if(!string.IsNullOrWhiteSpace(edEndsWord))
            {
                return edEndsWord;
            }

            return pastForm;
        }
    }
}
