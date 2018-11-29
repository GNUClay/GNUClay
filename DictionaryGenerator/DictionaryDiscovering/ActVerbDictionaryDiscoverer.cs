using MyNPCLib;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator.DictionaryDiscovering
{
    public class ActVerbDictionaryDiscoverer : BaseDictionaryDiscoverer
    {
        public ActVerbDictionaryDiscoverer(WordsDictData dict)
            : base(dict)
        {
        }

        protected override bool ProcessFrame(WordFrame wordFrame)
        {
#if DEBUG
            //LogInstance.Log($"wordFrame = {wordFrame}");
#endif

            return wordFrame.GrammaticalWordFrames.Count(p => p.PartOfSpeech == GrammaticalPartOfSpeech.Verb && p.LogicalMeaning.Contains("act")) > 0;
        }
    }
}
