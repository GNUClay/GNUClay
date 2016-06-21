using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CG;
using GnuClay.CGConverters.Helpers.ToStringHelpers;
using GnuClay.CGConverters.SGF.FromStringHelpers.Lexer;
using GnuClay.CommonUtils.TypeHelpers;

namespace GnuClay.CGConverters.SGF
{
    public class SGFConverter : BaseConverter<SGFContext>
    {
        public override IConceptualNode ConvertFromString(string source)
        {
            var tmpLexer = new SGFLexerEngine();

            var tmpTokensList = tmpLexer.Run(source);

            NLog.LogManager.GetCurrentClassLogger().Info(_ListHelper._ToString(tmpTokensList, nameof(tmpTokensList)));

            //throw new NotImplementedException();
            return null;
        }
    }
}
