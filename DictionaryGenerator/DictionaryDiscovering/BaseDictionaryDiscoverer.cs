using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace DictionaryGenerator.DictionaryDiscovering
{
    public abstract class BaseDictionaryDiscoverer
    {
        protected BaseDictionaryDiscoverer(WordsDictData dict)
        {
            mDict = dict;
        }

        private WordsDictData mDict;

        public void Run()
        {

        }
    }
}
