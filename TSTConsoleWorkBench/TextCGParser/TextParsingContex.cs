using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class TextParsingContex
    {
        public GnuClayEngine Engine = null;

        public TextParsingPartOfSpeechContext PartOfSpeechContext = null;
        public TextParsingNumberContext NumberContext = null;
        public TextParsingTenseContext TenseContext = null;
        public TextParsingAspectContext AspectContext = null;
    }
}
