using GnuClay.Engine.CommonStorages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalParamsOfFunctionParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            GotValue,
            AfterParamName,
            WaitParamValue,
            AfterParam
        }

        public InternalParamsOfFunctionParser(InternalParserContext context)
            : base(context)
        {
            mDataDictionary = Context.MainContext.DataDictionary;
        }

        private State mState = State.Init;
        private StorageDataDictionary mDataDictionary = null;
        public List<InternalCodeParamNode> Result = new List<InternalCodeParamNode>();

        private bool? mIsNamed = null;

        private InternalCodeExpressionNode tmpNode = null;
        private InternalCodeExpressionNode tmpName = null;

        protected override void OnRun()
        {
            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            ProcessParam();
                            break;

                        case TokenKind.Var:
                        case TokenKind.SystemVar:
                            ProcessParam();
                            break;

                        case TokenKind.Number:
                            ProcessParam();
                            break;

                        case TokenKind.Tilde:
                            ProcessParam();
                            break;

                        case TokenKind.Dash:
                            ProcessParam();
                            break;

                        case TokenKind.CloseRoundBracket:
                            ProcessCloseRoundBracket();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.GotValue:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Colon:
                            ProcessColon();
                            break;

                        case TokenKind.CloseRoundBracket:
                            ProcessCloseRoundBracket();
                            break;

                        case TokenKind.Comma:
                            ProcessComma();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.WaitParamValue:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            ProcessParam();
                            break;

                        case TokenKind.Var:
                        case TokenKind.SystemVar:
                            ProcessParam();
                            break;

                        case TokenKind.Number:
                            ProcessParam();
                            break;

                        case TokenKind.Tilde:
                            ProcessParam();
                            break;

                        case TokenKind.Dash:
                            ProcessParam();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.AfterParam:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            ProcessParam();
                            break;

                        case TokenKind.Var:
                        case TokenKind.SystemVar:
                            ProcessParam();
                            break;

                        case TokenKind.Number:
                            ProcessParam();
                            break;

                        case TokenKind.Tilde:
                            ProcessParam();
                            break;

                        case TokenKind.Dash:
                            ProcessParam();
                            break;

                        case TokenKind.CloseRoundBracket:
                            ProcessCloseRoundBracket();
                            break;

                        case TokenKind.Comma:
                            ProcessComma();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
        }

        private void ProcessParam()
        {
            Context.Recovery(CurrToken);
            var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, InternalCodeExpressionStatementParser.Mode.IsParameterOfFunction, false);
            tmpInternalCodeExpressionStatementParser.Run();

            tmpNode = tmpInternalCodeExpressionStatementParser.RootNode;

            switch(mState)
            {
                case State.Init:
                    mState = State.GotValue;
                    break;

                case State.WaitParamValue:
                    CreateNamedParam();
                    mState = State.AfterParam;
                    break;

                case State.AfterParam:
                    mState = State.GotValue;
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }            
        }

        private void ProcessColon()
        {
            if(mIsNamed == null)
            {
                mIsNamed = true;
            }
            else
            {
                if(mIsNamed == false)
                {
                    throw new MixingKindOfArgumentsException(CurrToken);
                }
            }

            tmpName = tmpNode;
            tmpNode = null;
            mState = State.WaitParamValue;
        }

        private void ProcessComma()
        {
            switch (mState)
            {
                case State.GotValue:
                    CreatedPositionedParam();
                    mState = State.AfterParam;
                    break;

                case State.AfterParam:
                    CreateNamedParam();
                    mState = State.AfterParam;
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }      
        }

        private void ProcessCloseRoundBracket()
        {
            if(mState == State.GotValue)
            {
                CreatedPositionedParam();
            }

            Exit();
        }

        private void CreateNamedParam()
        {
            if(tmpName == null && tmpNode == null)
            {
                return;
            }

            var param = new InternalCodeParamNode();
            param.IsNamed = true;
            param.Name = tmpName;
            param.Value = tmpNode;
            Result.Add(param);
            tmpName = null;
            tmpNode = null;
        }

        private void CreatedPositionedParam()
        {
            if (mIsNamed == null)
            {
                mIsNamed = false;
            }
            else
            {
                if (mIsNamed == true)
                {
                    throw new MixingKindOfArgumentsException(CurrToken);
                }
            }

            var param = new InternalCodeParamNode();
            param.IsNamed = false;
            param.Value = tmpNode;
            Result.Add(param);
            tmpName = null;
            tmpNode = null;
        }
    }
}
