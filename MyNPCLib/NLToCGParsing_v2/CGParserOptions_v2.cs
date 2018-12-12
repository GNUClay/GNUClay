using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class CGParserOptions_v2
    {
        public IWordsDict WordsDict { get; set; }
        public string BasePath { get; set; }
    }
}
