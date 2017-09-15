using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Parser.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalFunctionDefinerParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            WaitName,
            GotName,
            WaitTargetValue,
            GotTargetValue,
            AfterTarget,
            WaitParameterName,
            AfterParameterName,
            WaitParameterType,
            AfterParameterType,
            WaitDefaultValue,
            AfterDefaultValue,
            AfterParametersBlock,
            WaitReturnType,
            AfterReturnType,
            WaitSubj,
            GotSubj
        }

        public InternalFunctionDefinerParser(InternalParserContext context)
            : base(context)
        {
            mDataDictionary = Context.MainContext.DataDictionary;
        }

        private StorageDataDictionary mDataDictionary = null;

        private State mState = State.Init;
        public UserDefinedFunction Result = new UserDefinedFunction();

        protected override void OnRun()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.KeyWordTokenKind = {CurrToken.KeyWordTokenKind} CurrToken.Content = {CurrToken.Content}");
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun Result = {Result?.ToString(mDataDictionary, 0)}");
#endif

            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            switch (CurrToken.KeyWordTokenKind)
                            {
                                case TokenKind.FUN:
                                    mState = State.WaitName;
                                    break;

                                default: throw new UnexpectedTokenException(CurrToken);
                            }
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitName:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            Result.FunctionKey = mDataDictionary.GetKey(CurrToken.Content);
                            mState = State.GotName;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotName:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.BEGIN_TARGET:
                            mState = State.WaitTargetValue;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitTargetValue:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            Result.TargetKey = mDataDictionary.GetKey(CurrToken.Content);
                            mState = State.GotTargetValue;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotTargetValue:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.END_TERGET:
                            mState = State.AfterTarget;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterTarget:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenRoundBracket:
                            mState = State.WaitParameterName;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitParameterName:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterParameterName:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitParameterType:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterParameterType:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitDefaultValue:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterDefaultValue:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterParametersBlock:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitReturnType:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterReturnType:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitSubj:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotSubj:
                    switch (CurrToken.TokenKind)
                    {
                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
        }
    }
}
