﻿using MyNPCLib;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryGenerator.DictionaryDiscovering
{
    public class AdjWithoutClassesDictionaryDiscoverer: BaseDictionaryDiscoverer
    {
        public AdjWithoutClassesDictionaryDiscoverer(WordsDictData dict)
            : base(dict)
        {
        }

        protected override bool ProcessFrame(WordFrame wordFrame)
        {
#if DEBUG
            //LogInstance.Log($"wordFrame = {wordFrame}");
#endif

            return wordFrame.GrammaticalWordFrames.Count(p => p.PartOfSpeech == GrammaticalPartOfSpeech.Adjective && p.LogicalMeaning.IsEmpty()) > 0;
        }
    }
}
