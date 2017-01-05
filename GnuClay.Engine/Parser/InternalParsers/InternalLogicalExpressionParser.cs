using GnuClay.CommonClientTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage;
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

        public InternalLogicalExpressionParser(InternalParserContext context, StorageDataDictionary localDataDictionary = null)
            : base(context)
        {
            mLocalDataDictionary = localDataDictionary;

            if (mLocalDataDictionary == null)
            {
                mLocalDataDictionary = new StorageDataDictionary(null);
            }
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

        private StorageDataDictionary mLocalDataDictionary = null;

        protected override void OnRun()
        {
            ExpressionNode tmpNode = null;

            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            tmpNode = new ExpressionNode();
                            tmpNode.Kind = ExpressionNodeKind.Relation;
                            tmpNode.RelationParams = new List<ExpressionNode>();
                            tmpNode.Key = Context.MainContext.DataDictionary.GetKey(CurrToken.Content);

                            if (mRootNode == null)
                            {
                                mRootNode = tmpNode;
                            }
                            else
                            {
                                mRootNode.Right = tmpNode;
                            }

                            mCurrentNode = tmpNode;
                            mState = State.DeclaredRelationName;
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
                            tmpNode.Key = Context.MainContext.DataDictionary.GetKey(CurrToken.Content);
                            mCurrentNode.RelationParams.Add(tmpNode);
                            mState = State.ParamWasEntered;
                            break;

                        case TokenKind.Var:
                            tmpNode = new ExpressionNode();
                            tmpNode.Kind = ExpressionNodeKind.Var;
                            tmpNode.Key = mLocalDataDictionary.GetKey(CurrToken.Content);
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
        }

        private void ProcessNumberToken()
        {
            var tmpVal = double.Parse(mBuffer, mFormatProvider);
            mBuffer = string.Empty;
            
            var tmpNode = new ExpressionNode();
            tmpNode = new ExpressionNode();
            tmpNode.Kind = ExpressionNodeKind.Value;
            tmpNode.Key = Context.MainContext.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);
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
