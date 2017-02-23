using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class TextPhraseContext
    {
        public Queue<ExtendToken> Tokens = null;
        public ATNNodeState State = ATNNodeState.Init;

        public TextPhraseContext Clone()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new TextPhraseContext();

            result.Tokens = new Queue<ExtendToken>(Tokens);
            result.State = State;

            return result;
        }
    }
}
