using GnuClay.Engine.CommonStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalTargetOfFunctionParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            AfterTarget
        }

        public InternalTargetOfFunctionParser(InternalParserContext context)
            : base(context)
        {
            mDataDictionary = Context.MainContext.DataDictionary;
        }

        private State mState = State.Init;
        private StorageDataDictionary mDataDictionary = null;
        public InternalCodeExpressionNode Result = null;

        protected override void OnRun()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.Content = {CurrToken.Content}");
#endif

            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            Result = new InternalCodeExpressionNode();
                            Result.ClassOfNode = ClassOfNode.Leaf;
                            Result.Kind = ExpressionKind.EntityExpression;
                            Result.TypeKey = mDataDictionary.GetKey(CurrToken.Content);

                            mState = State.AfterTarget;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterTarget:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.END_TERGET:
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
        }
    }
}
