using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Lexer
{
    public class SGFLexerEngine
    {
        public List<SGFToken> Run(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            var tmpContext = new SGFLexerContext(text.ToList());

            var tmpMainLeaf = new MainSGFLexerLeaf(tmpContext);

            tmpMainLeaf.Run();

            return tmpContext.ResultList;
        }
    }
}
