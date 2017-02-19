using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    /// <summary>
    /// AP
    /// </summary>
    public class AdjectivePhrase: IPhrase
    {
        public ExtendToken Adjective = null;
        public ExtendToken Adverb = null;
    }
}
