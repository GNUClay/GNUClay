using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
{
    public class InternalExpressionParser: BaseInternalParser
    {
        private enum State
        {
            Init
        }

        public InternalExpressionParser(InternalParserContext context)
            : base(context)
        {
        }

        private State mState = State.Init;

        protected override void OnRun()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CurrToken = {CurrToken.TokenKind} mState = {mState}");

            switch(mState)
            {
                case State.Init:
                    NLog.LogManager.GetCurrentClassLogger().Info("Init");
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }
    }
}
