using GnuClay.Engine.LogicalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalSelectedTreeParser : BaseInternalParser
    {
        public InternalSelectedTreeParser(InternalParserContext context)
            : base(context)
        {
        }

        private ExpressionNode mRootNode = null;

        public ExpressionNode Result
        {
            get
            {
                return mRootNode;
            }
        }

        protected override void OnRun()
        {
            Context.Recovery(CurrToken);

            var tmpInternalExpressionParser = new InternalLogicalExpressionParser(Context);
            tmpInternalExpressionParser.Run();

            mRootNode = tmpInternalExpressionParser.Result;

            Context.GetToken();
        }
    }
}
