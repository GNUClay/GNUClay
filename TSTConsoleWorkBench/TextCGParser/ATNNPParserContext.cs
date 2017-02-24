using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ATNNPParserContext: BaseATNParserContext
    {
        public ATNNPParserContext(BaseATNParserContext source)
            : base(source)
        {
        }

        public NounPhrase RootNP = null;
        public NounPhrase CurrentNP = null;

        public ATNNPParserContext Clone()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            var result = new ATNNPParserContext(this);

            throw new NotImplementedException();

            return result;
        }
    }
}
