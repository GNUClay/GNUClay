using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.LogicalStorage;
using System;
using System.Collections.Generic;
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

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.DeclaredRelationName:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.OpenRoundBracket:
                            mState = State.InputParams;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
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
                            break;

                        case TokenKind.Comma:
                            break;

                        case TokenKind.Var:
                            tmpNode = new ExpressionNode();
                            tmpNode.Kind = ExpressionNodeKind.Var;
                            tmpNode.Key = mLocalDataDictionary.GetKey(CurrToken.Content);
                            mCurrentNode.RelationParams.Add(tmpNode);
                            break;

                        case TokenKind.CloseRoundBracket:
                            mState = State.EndDeclaringRelation;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
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

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
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
