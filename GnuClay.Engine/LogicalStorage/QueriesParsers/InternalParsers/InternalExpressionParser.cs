using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.LogicalStorage.InternalStorage;
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
            Init,
            DeclaredRelationName,
            InputParams,
            EndDeclaringRelation
        }

        public InternalExpressionParser(InternalParserContext context)
            : base(context)
        {
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

        private StorageDataDictionary mLocalDataDictionary = new StorageDataDictionary();

        protected override void OnRun()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CurrToken = {CurrToken.TokenKind} mState = {mState}");

            ExpressionNode tmpNode = null;

            switch (mState)
            {
                case State.Init:
                    switch(CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            tmpNode = new ExpressionNode();
                            tmpNode.Kind = ExpressionNodeKind.Relation;
                            tmpNode.RelationParams = new List<ExpressionNode>();
                            tmpNode.Key = Context.DataDictionary.GetKey(CurrToken.Content);
                            mRootNode = tmpNode;
                            mCurrentNode = mRootNode;
                            mState = State.DeclaredRelationName;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.DeclaredRelationName:
                    switch(CurrToken.TokenKind)
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
                            tmpNode.Key = Context.DataDictionary.GetKey(CurrToken.Content);
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
                    switch(CurrToken.TokenKind)
                    {
                        case TokenKind.CloseFigureBracket:
                            Context.Recovery(CurrToken);
                            Exit();
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"mRootNode = `{ExpressionNodeDebugHelper.ConvertToString(mRootNode, Context.DataDictionary, mLocalDataDictionary)}`");
            NLog.LogManager.GetCurrentClassLogger().Info($"mCurrentNode = `{ExpressionNodeDebugHelper.ConvertToString(mCurrentNode, Context.DataDictionary, mLocalDataDictionary)}`");
        }

        protected override void OnExit()
        {
            if(Context.IsEmpty())
            {
                throw new AbnormalTerminationException();
            }
        }
    }
}
