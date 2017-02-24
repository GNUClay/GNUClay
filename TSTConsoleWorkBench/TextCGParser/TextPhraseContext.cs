using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class TextPhraseContext: BaseATNParserContext
    {
        public TextPhraseContext(List<ExtendToken> tokens)
            : base(tokens)
        {    
        }

        public TextPhraseContext(BaseATNParserContext source)
            : base(source)
        {
        }

        public ATNNodeState State = ATNNodeState.Init;

        public TextPhraseContext Clone()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new TextPhraseContext(this);

            result.State = State;

            return result;
        }
    }
}
