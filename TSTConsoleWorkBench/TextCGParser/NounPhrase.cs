using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    /// <summary>
    /// NP
    /// </summary>
    public class NounPhrase: IPhrase
    {
        public ExtendToken Determiner = null;
        public IPhrase Noun = null;
        public PrepositionalPhrase Prepositional = null;
        public IPhrase Adjective = null;
    }
}
