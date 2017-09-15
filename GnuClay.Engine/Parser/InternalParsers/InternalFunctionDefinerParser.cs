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
            AfterParametersBlock,
            WaitReturnType,
            AfterReturnType,
            WaitSubjColon,
            WaitSubj,
            GotSubj,
            GotBody
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
                        case TokenKind.Var:
                            CurrentParamNameKey = mDataDictionary.GetKey(CurrToken.Content);
                            mState = State.AfterParameterName;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterParameterName:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Colon:
                            mState = State.WaitParameterType;
                            break;

                        case TokenKind.CloseRoundBracket:
                            ImpementCurrentParameter();
                            mState = State.AfterParametersBlock;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitParameterType:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            CurrentParamTypeKey = mDataDictionary.GetKey(CurrToken.Content);
                            mState = State.AfterParameterType;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterParameterType:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Comma:
                            ImpementCurrentParameter();
                            mState = State.WaitParameterName;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterParametersBlock:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Colon:
                            mState = State.WaitReturnType;
                            break;

                        default:
                            Context.Recovery(CurrToken);
                            mState = State.AfterReturnType;
                            break;
                    }
                    break;

                case State.WaitReturnType:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            Result.ReturnTypeKey = mDataDictionary.GetKey(CurrToken.Content);
                            mState = State.AfterReturnType;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterReturnType:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            switch(CurrToken.KeyWordTokenKind)
                            {
                                case TokenKind.SUBJ:
                                    mState = State.WaitSubjColon;
                                    break;

                                default: throw new UnexpectedTokenException(CurrToken);
                            }
                            break;

                        case TokenKind.OpenFigureBracket:
                            Context.Recovery(CurrToken);
                            var tmpInternalFunctionBodyParser = new InternalFunctionBodyParser(Context);
                            tmpInternalFunctionBodyParser.Run();
                            Result.Body = tmpInternalFunctionBodyParser.Result;
                            mState = State.GotBody;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitSubjColon:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Colon:
                            mState = State.WaitSubj;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitSubj:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            Result.HolderKey = mDataDictionary.GetKey(CurrToken.Content);
                            mState = State.GotSubj;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotSubj:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Semicolon:
                            mState = State.AfterReturnType;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotBody:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            Exit();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
        }

        private ulong CurrentParamNameKey;
        private ulong CurrentParamTypeKey;

        private void ImpementCurrentParameter()
        {
            var paramItem = new ParamOfUserDefinedFunction();
            paramItem.NameKey = CurrentParamNameKey;
            paramItem.TypeKey = CurrentParamTypeKey;

            Result.Params.Add(paramItem);

            CurrentParamNameKey = 0;
            CurrentParamTypeKey = 0;
        }
    }
}
