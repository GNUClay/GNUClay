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

            if(RootNP == null)
            {
                return result;
            }

            var ptrList = new Dictionary<object, object>();

            result.RootNP = (NounPhrase)RootNP.Clone(ptrList);

            ptrList.Add(RootNP, result.RootNP);

            throw new NotImplementedException();

            return result;
        }
    }
}
