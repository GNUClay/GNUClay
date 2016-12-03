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
            AddOperatorKey = Context.MainContext.DataDictionary.GetKey(StandartOperatorNamesConstants.Add);
        }

        private bool mIsSlave = false;
        public ASTExpressionStatement ASTResult = null;
        private State mState = State.Init;

        public InternalCodeExpressionNode RootNode = null;
        private InternalCodeExpressionNode mCurrentNode = null;
        private Associativity mAddTo = Associativity.Undefined;

        private string mCurrentNumberContent = string.Empty;
        private string mFullCurrentNumberContent = string.Empty;

        private int NumberKey = 0;
        private int AddOperatorKey = 0;

        private int ConstValPriority = 1;
        private CultureInfo mFormatProvider = new CultureInfo("en-GB");

        protected override void OnRun()
        {
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

                        case TokenKind.Plus:
                            ProcessPlusToken();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.DeclareIntNumber:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Point:
                            mFullCurrentNumberContent += ".";
                            mState = State.MaybeDeclareFloatNumber;
                            break;

                        case TokenKind.Plus:
                            ProcessNumberToken();
                            ProcessPlusToken();
                            break;

                        case TokenKind.Semicolon:
                            ProcessNumberToken();
                            ProcessSemicolonToken();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.MaybeDeclareFloatNumber:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Number:
                            ProcessNumberToken();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState));
            }
        }

        private void ProcessNumberToken()
        {
            mFullCurrentNumberContent += CurrToken.Content;
            var token = new Token();
            token.TokenKind = TokenKind.Number;
            token.Content = mFullCurrentNumberContent;
            SetNode(GetNodeByToken(token), token);
            mState = State.Init;
        }

        private void ProcessPlusToken()
        {
            SetNode(GetNodeByToken(CurrToken), CurrToken);
        }

        private void ProcessSemicolonToken()
        {
            Exit();
        }

        public void SetNode(InternalCodeExpressionNode node, Token token)
        {
            switch(node.Kind)
            {
                case ExpressionKind.Undefined:
                    throw new ArgumentException("I can not process undefined InternalCodeExpressionNode.");

                case ExpressionKind.BinaryOperator:
                    switch (mAddTo)
                    {
                        case Associativity.Undefined:
                            break;

                        case Associativity.Right:
                            if(mCurrentNode.Left == null || mCurrentNode.Right == null)
                            {
                                throw new UnexpectedTokenException(token);
                            }
                            break;

                        default: throw new ArgumentOutOfRangeException(nameof(mAddTo), $"Argument value `{mAddTo}` out of range.");
                    }
                break;

                case ExpressionKind.ConstExpression:
                    switch(mAddTo)
                    {
                        case Associativity.Undefined:
                            if(RootNode == null)
                            {
                                break;
                            }
                            throw new UnexpectedTokenException(token);

                        case Associativity.Right:
                            break;

                        case Associativity.Left:
                            break;

                        default: throw new ArgumentOutOfRangeException(nameof(mAddTo), $"Argument value `{mAddTo}` out of range.");
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(node.Kind), $"Argument value `{node.Kind}` out of range.");
            }

            if(RootNode == null)
            {
                RootNode = node;
                mCurrentNode = node;
                return;
            }

            if(mCurrentNode.Priority < node.Priority)
            {
                SetMajorPriorityNode(node);
                return;
            }

            SetMinorPriorityNode(node);
        }

        private void SetMajorPriorityNode(InternalCodeExpressionNode node)
        {
            var tmpNode = mCurrentNode;

            while (true)
            {
                var tmpParent = tmpNode.Parent;

                if(tmpParent == null)
                {
                    SetBetweenNodes(node, null, tmpNode);
                    return;
                }

                if(tmpNode.Priority <= node.Priority)
                {
                    tmpNode = tmpParent;
                    continue;
                }

                throw new NotImplementedException();
            }
        }

        private void SetBetweenNodes(InternalCodeExpressionNode targetNode, InternalCodeExpressionNode parentNode, InternalCodeExpressionNode childNode)
        {
            if(parentNode == null)
            {
                RootNode = targetNode;           
            }
            else
            {
                throw new NotImplementedException();
            }

            mCurrentNode = targetNode;
            childNode.Parent = targetNode;
            switch(targetNode.Associativity)
            {
                case Associativity.Left:
                    targetNode.Left = childNode;
                    mAddTo = Associativity.Right;
                    break;

                case Associativity.Right:
                    targetNode.Right = childNode;
                    mAddTo = Associativity.Left;
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(targetNode.Associativity));
            }
        }

        private void SetMinorPriorityNode(InternalCodeExpressionNode node)
        {
            switch(mAddTo)
            {
                case Associativity.Right:
                    node.Parent = mCurrentNode;
                    mCurrentNode.Right = node;
                    mCurrentNode = node;
                    SetAddToByNodeAssociativity(node.Associativity);
                    break;

                case Associativity.Left:
                    node.Parent = mCurrentNode;
                    mCurrentNode.Left = node;
                    mCurrentNode = node;
                    SetAddToByNodeAssociativity(node.Associativity);
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mAddTo));
            }
        }

        private void SetAddToByNodeAssociativity(Associativity associativity)
        {
            switch(associativity)
            {
                case Associativity.Undefined:
                    mAddTo = Associativity.Undefined;
                    break;

                case Associativity.Right:
                    mAddTo = Associativity.Left;
                    break;

                case Associativity.Left:
                    mAddTo = Associativity.Right;
                    break;
            }
        }

        private InternalCodeExpressionNode GetNodeByToken(Token token)
        {
            var result = new InternalCodeExpressionNode();

            switch(token.TokenKind)
            {
                case TokenKind.Number:
                    result.Kind = ExpressionKind.ConstExpression;
                    result.TypeKey = NumberKey;
                    result.Value = double.Parse(token.Content, mFormatProvider);
                    result.Priority = ConstValPriority;
                    break;

                case TokenKind.Plus:
                    result.Kind = ExpressionKind.BinaryOperator;
                    result.TypeKey = AddOperatorKey;
                    result.Priority = StandartOperatorPrioritiesConstants.Add;
                    result.Associativity = Associativity.Left;
                    break;

                default: throw new UnexpectedTokenException(CurrToken);
            }

            return result;
        }

        protected override void OnFinish()
        {
            if(mIsSlave)
            {
                return;
            }

            if(RootNode == null)
            {
                return;
            }

            ASTResult = new ASTExpressionStatement();
            ASTResult.Expression = CreateExpressionNode(RootNode);
        }

        private ASTExpression CreateExpressionNode(InternalCodeExpressionNode node)
        {
            switch(node.Kind)
            {
                case ExpressionKind.BinaryOperator:
                    return CreateBinaryOperator(node);

                case ExpressionKind.ConstExpression:
                    return CreateConstExpression(node);

                default: throw new ArgumentOutOfRangeException(nameof(node.Kind), $"Argument value `{node.Kind}` out of range.");
            }
        }

        private ASTExpression CreateBinaryOperator(InternalCodeExpressionNode node)
        {
            var result = new ASTBinaryOperator();
            result.OperatorKey = node.TypeKey;
            result.Left = CreateExpressionNode(node.Left);
            result.Right = CreateExpressionNode(node.Right);
            return result;
        }

        private ASTExpression CreateConstExpression(InternalCodeExpressionNode node)
        {
            var result = new ASTConstExpression();
            result.TypeKey = node.TypeKey;
            result.Value = node.Value;
            return result;
        }
    }
}
