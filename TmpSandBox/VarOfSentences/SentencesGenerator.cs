using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.VarOfSentences
{
    public class SentencesGenerator
    {
        public void Run()
        {
            LogInstance.Log("Begin");

            var sentence = new TstSentence();
            sentence.WordsList.Add(new TstItemOfSentence() {
                Kind = TstKindOfItemOfSentence.Subject
            });

            sentence.WordsList.Add(new TstItemOfSentence()
            {
                Kind = TstKindOfItemOfSentence.Verb,
                IsMutable = true
            });

            LogInstance.Log($"sentence = {sentence}");

            LogInstance.Log("End");
        }
    }
}
