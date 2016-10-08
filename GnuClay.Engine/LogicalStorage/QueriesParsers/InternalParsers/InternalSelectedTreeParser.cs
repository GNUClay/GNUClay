using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
{
    public class InternalSelectedTreeParser: BaseInternalParser
    {
        public InternalSelectedTreeParser(InternalParserContext context)
            : base(context)
        {
        }

        protected override void OnRun()
        {
            Context.Recovery(CurrToken);

            var tmpInternalExpressionParser = new InternalExpressionParser(Context);
            tmpInternalExpressionParser.Run();

            Context.Read();
        }
    }
}
