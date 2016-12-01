using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalCodeExpressionStatementParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            DeclareIntNumber,
            MaybeDeclareFloatNumber,
        }

        public InternalCodeExpressionStatementParser(InternalParserContext context, bool isSlave)
            :base(context)
        {
            mIsSlave = isSlave;
            NumberKey = Context.MainContext.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);
        }

        private bool mIsSlave = false;
        public ASTExpressionStatement Result = null;
        private State mState = State.Init;

        public InternalCodeExpressionNode RootNode = null;
        private InternalCodeExpressionNode mCurrentNode = null;

        private string mCurrentNumberContent = string.Empty;
        private string mFullCurrentNumberContent = string.Empty;

        private int NumberKey = 0;
        private int ConstValPriority = 1;
        private CultureInfo mFormatProvider = new CultureInfo("en-GB");

        protected override void OnRun()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun {CurrToken} {mState} {mCurrentNumberContent} {mFullCurrentNumberContent}");

            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            mCurrentNumberContent = CurrToken.Content;
                            mFullCurrentNumberContent = mCurrentNumberContent;
                            mState = State.DeclareIntNumber;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.DeclareIntNumber:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Point:
                            mFullCurrentNumberContent += ".";
                            mState = State.MaybeDeclareFloatNumber;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                case State.MaybeDeclareFloatNumber:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            mFullCurrentNumberContent += CurrToken.Content;
                            var token = new Token();
                            token.TokenKind = TokenKind.Number;
                            token.Content = mFullCurrentNumberContent;
                            SetNode(GetNodeByToken(token));
                            mState = State.Init;
                            break;

                        default: throw new UndefinedTokenException(CurrToken.TokenKind);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun RootNode = `{RootNode}`");
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mCurrentNode = `{mCurrentNode}`");
        }

        public void SetNode(InternalCodeExpressionNode node)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SetNode node = `{node}`");

            if(node.Kind == ExpressionKind.Undefined)
            {
                throw new ArgumentException("I can not process undefined InternalCodeExpressionNode.");
            }

            if(RootNode == null)
            {
                RootNode = node;
                mCurrentNode = node;
                return;
            }

            throw new NotImplementedException();
        }

        private InternalCodeExpressionNode GetNodeByToken(Token token)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"GetNodeByToken token = `{token}`");

            var result = new InternalCodeExpressionNode();

            switch(token.TokenKind)
            {
                case TokenKind.Number:
                    result.Kind = ExpressionKind.ConstExpression;
                    result.TypeKey = NumberKey;
                    result.Value = float.Parse(token.Content, mFormatProvider);
                    result.Priority = ConstValPriority;
                    break;

                default: throw new UndefinedTokenException(CurrToken.TokenKind);
            }

            return result;
        }

        protected override void OnFinish()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("OnFinish");
        }
    }
}
