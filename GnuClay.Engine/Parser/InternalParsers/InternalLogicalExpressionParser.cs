using GnuClay.CommonClientTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalLogicalExpressionParser : BaseInternalParser
    {
        private enum State
        {
            Init,
            DeclaredRelationName,
            InputParams,
            InputIntNumberParam,
            InputSemiNumberParam,
            InputDoubleNumberParam,
            ParamWasEntered,
            EndDeclaringRelation
        }

        public InternalLogicalExpressionParser(InternalParserContext context)
            : base(context)
        {
            mDataDictionary = context.MainContext.DataDictionary;
        }

        private State mState = State.Init;

        private ExpressionNode mRootNode = null;
        private ExpressionNode mCurrentNode = null;
        private string mBuffer = string.Empty;
        private CultureInfo mFormatProvider = new CultureInfo("en-GB");

        public ExpressionNode Result
        {
            get
            {
                return mRootNode;
            }
        }

        private StorageDataDictionary mDataDictionary = null;

        protected override void OnRun()
        {
            ExpressionNode tmpNode = null;

            //NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind}");

            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            tmpNode = new ExpressionNode();
                            
                            tmpNode.Kind = ExpressionNodeKind.Relation;
                            tmpNode.RelationParams = new List<ExpressionNode>();
                            tmpNode.Key = mDataDictionary.GetKey(CurrToken.Content);

                            if (mRootNode == null)
                            {
                                mRootNode = tmpNode;
                            }
                            else
                            {
                                mRootNode.Left = tmpNode;
                            }

                            mCurrentNode = tmpNode;
                            mState = State.DeclaredRelationName;
                            break;

                        case TokenKind.Not:
                            tmpNode = new ExpressionNode();
                            tmpNode.Kind = ExpressionNodeKind.Not;

                            if (mRootNode == null)
                            {
                                mRootNode = tmpNode;
                            }
                            else
                            {
                                mRootNode.Left = tmpNode;
                            }

                            mCurrentNode = tmpNode;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.DeclaredRelationName:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenRoundBracket:
                            mState = State.InputParams;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.InputParams:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            tmpNode = new ExpressionNode();
                            tmpNode.Kind = ExpressionNodeKind.Entity;
                            tmpNode.Key = mDataDictionary.GetKey(CurrToken.Content);
                            mCurrentNode.RelationParams.Add(tmpNode);
                            mState = State.ParamWasEntered;
                            break;

                        case TokenKind.Var:
                            tmpNode = new ExpressionNode();
                            tmpNode.Kind = ExpressionNodeKind.Var;
                            tmpNode.Key = mDataDictionary.GetKey(CurrToken.Content);

                            NLog.LogManager.GetCurrentClassLogger().Info($"TokenKind.Var tmpNode.Key = {tmpNode.Key}");

                            mCurrentNode.RelationParams.Add(tmpNode);
                            mState = State.ParamWasEntered;
                            break;

                        case TokenKind.Number:
                            mBuffer = CurrToken.Content;
                            mState = State.InputIntNumberParam;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.InputIntNumberParam:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Point:
                            mBuffer += ".";
                            mState = State.InputSemiNumberParam;
                            break;

                        case TokenKind.CloseRoundBracket:
                            Context.Recovery(CurrToken);
                            ProcessNumberToken();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.InputSemiNumberParam:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            mBuffer += CurrToken.Content;
                            ProcessNumberToken();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.ParamWasEntered:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Comma:
                            mState = State.InputParams;
                            break;

                        case TokenKind.CloseRoundBracket:
                            mState = State.EndDeclaringRelation;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.EndDeclaringRelation:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            Context.Recovery(CurrToken);
                            Exit();
                            break;

                        case TokenKind.And:
                            tmpNode = new ExpressionNode();
                            tmpNode.Kind = ExpressionNodeKind.And;
                            tmpNode.Left = mCurrentNode;
                            mCurrentNode = tmpNode;
                            mRootNode = tmpNode;
                            mState = State.Init;
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState.ToString());
            }

            //NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mRootNode = `{ExpressionNodeDebugHelper.ConvertToString(mRootNode, mLocalDataDictionary, mLocalDataDictionary)}`");
        }

        private void ProcessNumberToken()
        {
            var tmpVal = double.Parse(mBuffer, mFormatProvider);
            mBuffer = string.Empty;
            
            var tmpNode = new ExpressionNode();
            tmpNode = new ExpressionNode();
            tmpNode.Kind = ExpressionNodeKind.Value;
            tmpNode.Key = mDataDictionary.GetKey(StandartTypeNamesConstants.NumberName);
            tmpNode.Value = tmpVal;
            mCurrentNode.RelationParams.Add(tmpNode);
            mState = State.ParamWasEntered;
        }

        protected override void OnExit()
        {
            if (Context.IsEmpty())
            {
                throw new AbnormalTerminationException();
            }
        }
    }
}
