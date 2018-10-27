using MyNPCLib.Serialization;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.SimpleWordsDict
{
    public class WordsDictSerializationEngine: SerializationEngine<WordsDictData>
    {
        public WordsDictSerializationEngine()
            : base("WordsDict", 0.1M, true)
        {
        }
    }
}
