using GnuClay.Engine.CommonStorages;
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
        //public enum State
        //{
        //    Init,
        //    DeclareIntNumber,
        //    MaybeDeclareFloatNumber,
        //}

        public enum State
        {
            Init
        }

        public InternalCodeExpressionStatementParser(InternalParserContext context, bool isSlave)
            : base(context)
        {
            mIsSlave = isSlave;
            var mCommonKeysEngine = Context.MainContext.CommonKeysEngine;
            mDataDictionary = Context.MainContext.DataDictionary;

            NumberKey = mCommonKeysEngine.NumberKey;
            AddOperatorKey = mCommonKeysEngine.AddOperatorKey;
            MulOperatorKey = mCommonKeysEngine.MulOperatorKey;
            AssingOperatorKey = mCommonKeysEngine.AssignOperatorKey;
        }

        private StorageDataDictionary mDataDictionary = null;

        private bool mIsSlave = false;
        public ASTExpressionStatement ASTResult = null;
        private State mState = State.Init;

        public InternalCodeExpressionNode RootNode = null;
        private InternalCodeExpressionNode mCurrentNode = null;
        //private Associativity mAddTo = Associativity.Undefined;

        private ulong NumberKey = 0;
        private ulong AddOperatorKey = 0;
        private ulong MulOperatorKey = 0;
        private ulong AssingOperatorKey = 0;
        private int MulAndDivPriotiry = 2;
        private int AddAndSubPriority = 1;

        protected override void OnRun()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.Content = {CurrToken.Content}");
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun RootNode = {RootNode?.ToString(mDataDictionary, 0)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mCurrentNode = {mCurrentNode?.ToString(mDataDictionary, 0)}");
#endif
            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Var:
                            ProcessVarToken();
                            break;

                        case TokenKind.Assing:
                            ProcessAssingToken();
                            break;

                        case TokenKind.Number:
                            ProcessNumberToken();
                            break;

                        case TokenKind.Mul:
                            ProcessMulToken();
                            break;

                        case TokenKind.Dash:
                            ProcessDashToken();
                            break;

                        case TokenKind.Plus:
                            ProcessPlusToken();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
            //switch (mState)
            //{
            //    case State.Init:
            //        switch (CurrToken.TokenKind)
            //        {
            //            case TokenKind.Number:
            //                mCurrentNumberContent = CurrToken.Content;
            //                mFullCurrentNumberContent = mCurrentNumberContent;
            //                mState = State.DeclareIntNumber;
            //                break;

            //            case TokenKind.Assing:
            //                ProcessAssingToken();
            //                break;

            //            case TokenKind.Plus:
            //                ProcessPlusToken();
            //                break;

            //            case TokenKind.Var:
            //                ProcessVarToken();
            //                break;

            //            default: throw new UnexpectedTokenException(CurrToken);
            //        }
            //        break;

            //    case State.DeclareIntNumber:
            //        switch (CurrToken.TokenKind)
            //        {
            //            case TokenKind.Point:
            //                mFullCurrentNumberContent += ".";
            //                mState = State.MaybeDeclareFloatNumber;
            //                break;

            //            case TokenKind.Plus:
            //                ProcessNumberToken();
            //                ProcessPlusToken();
            //                break;

            //            case TokenKind.Semicolon:
            //                ProcessNumberToken();
            //                ProcessSemicolonToken();
            //                break;

            //            default: throw new UnexpectedTokenException(CurrToken);
            //        }
            //        break;

            //    case State.MaybeDeclareFloatNumber:
            //        switch (CurrToken.TokenKind)
            //        {
            //            case TokenKind.Number:
            //                ProcessNumberToken();
            //                break;

            //            default: throw new UnexpectedTokenException(CurrToken);
            //        }
            //        break;

            //    default: throw new ArgumentOutOfRangeException(nameof(mState));
            //}
        }

        private void ProcessVarToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessVarToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.VarExpression;
            result.TypeKey = mDataDictionary.GetKey(CurrToken.Content);
            result.ClassOfNode = ClassOfNode.Leaf;

            SetLeafToken(result);
        }

        private void ProcessAssingToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessAssingToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = AssingOperatorKey;
            result.ClassOfNode = ClassOfNode.Assing;

            SetAssingToken(result);
        }

        private void ProcessNumberToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessNumberToken");
#endif
            Context.Recovery(CurrToken);
            var tmpInternalNumberParser = new InternalNumberParser(Context);
            tmpInternalNumberParser.Run();

            var numberResult = tmpInternalNumberParser.Result;
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun numberResult = {numberResult}");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.ConstExpression;
            result.TypeKey = NumberKey;
            result.Value = numberResult;
            result.ClassOfNode = ClassOfNode.Leaf;

            SetLeafToken(result);
        }

        private void ProcessMulToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessMulToken");
#endif

            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = MulOperatorKey;
            result.ClassOfNode = ClassOfNode.Arithmetic;

            SetArithmeticToken(result);
        }

        private void ProcessDashToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessDashToken");
#endif

            var classOfCurrentNode = mCurrentNode.ClassOfNode;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLeafToken classOfCurrentNode = {classOfCurrentNode}");
#endif

            switch(classOfCurrentNode)
            {
                case ClassOfNode.Arithmetic:
                    ProcessNumberToken();
                    return;

                default: throw new ArgumentOutOfRangeException(nameof(classOfCurrentNode), classOfCurrentNode, null);
            }

            throw new NotImplementedException();
        }

        private void ProcessPlusToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessMulToken");
#endif

            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = AddOperatorKey;
            result.ClassOfNode = ClassOfNode.Arithmetic;

            SetArithmeticToken(result);
        }

        //private void ProcessNumberToken()
        //{
        //    mFullCurrentNumberContent += CurrToken.Content;
        //    var token = new Token();
        //    token.TokenKind = TokenKind.Number;
        //    token.Content = mFullCurrentNumberContent;
        //    SetNode(GetNodeByToken(token), token);
        //    mState = State.Init;
        //}

        //private void ProcessAssingToken()
        //{
        //    SetNode(GetNodeByToken(CurrToken), CurrToken);
        //}

        //private void ProcessPlusToken()
        //{
        //    SetNode(GetNodeByToken(CurrToken), CurrToken);
        //}

        //private void ProcessVarToken()
        //{
        //    SetNode(GetNodeByToken(CurrToken), CurrToken);
        //}

        private void ProcessSemicolonToken()
        {
            Exit();
        }

//        public void SetNode(InternalCodeExpressionNode node, Token token)
//        {
//#if DEBUG
//            NLog.LogManager.GetCurrentClassLogger().Info($"SetNode node = {node}");
//#endif

//            //switch(node.Kind)
//            //{
//            //    case ExpressionKind.Undefined:
//            //        throw new ArgumentException("I can not process undefined InternalCodeExpressionNode.");

//            //    case ExpressionKind.BinaryOperator:
//            //        switch (mAddTo)
//            //        {
//            //            case Associativity.Undefined:
//            //                break;

//            //            case Associativity.Right:
//            //                if(mCurrentNode.Left == null || mCurrentNode.Right == null)
//            //                {
//            //                    throw new UnexpectedTokenException(token);
//            //                }
//            //                break;

//            //            default: throw new ArgumentOutOfRangeException(nameof(mAddTo), $"Argument value `{mAddTo}` out of range.");
//            //        }
//            //    break;

//            //    case ExpressionKind.ConstExpression:
//            //        switch(mAddTo)
//            //        {
//            //            case Associativity.Undefined:
//            //                if(RootNode == null)
//            //                {
//            //                    break;
//            //                }
//            //                throw new UnexpectedTokenException(token);

//            //            case Associativity.Right:
//            //                break;

//            //            case Associativity.Left:
//            //                break;

//            //            default: throw new ArgumentOutOfRangeException(nameof(mAddTo), $"Argument value `{mAddTo}` out of range.");
//            //        }
//            //        break;

//            //    case ExpressionKind.VarExpression:
//            //        switch (mAddTo)
//            //        {
//            //            case Associativity.Undefined:
//            //                if (RootNode == null)
//            //                {
//            //                    break;
//            //                }
//            //                throw new UnexpectedTokenException(token);

//            //            case Associativity.Right:
//            //                break;

//            //            case Associativity.Left:
//            //                break;

//            //            default: throw new ArgumentOutOfRangeException(nameof(mAddTo), $"Argument value `{mAddTo}` out of range.");
//            //        }
//            //        break;

//            //    default: throw new ArgumentOutOfRangeException(nameof(node.Kind), $"Argument value `{node.Kind}` out of range.");
//            //}

//            if (RootNode == null)
//            {
//                RootNode = node;
//                mCurrentNode = node;
//                return;
//            }

//            var tmpNode = mCurrentNode;

//            var currentNodePriority = int.MaxValue;
//            var nodePriority = node.Priority;

//            while (true)
//            {
//                if (tmpNode != null)
//                {
//                    currentNodePriority = tmpNode.Priority;
//                }

//#if DEBUG
//                NLog.LogManager.GetCurrentClassLogger().Info($"SetNode currentNodePriority = {currentNodePriority} nodePriority = {nodePriority}");
//                NLog.LogManager.GetCurrentClassLogger().Info($"SetNode tmpNode = {tmpNode?.ToString(mDataDictionary, 0)}");
//#endif

//                //if (nodePriority < currentNodePriority)
//                //{
//                //    NLog.LogManager.GetCurrentClassLogger().Info("SetNode nodePriority < currentNodePriority");

//                //    if(currentNodePriority > 0)
//                //    {
//                //        tmpNode = tmpNode.Parent;
//                //        continue;
//                //    }

//                //    throw new NotImplementedException();
//                //}

//                throw new NotImplementedException();
//            }

//            NLog.LogManager.GetCurrentClassLogger().Info($"SetNode End RootNode = {RootNode?.ToString(mDataDictionary, 0)}");

//            //CalculateAddTo(node);

//            //if (mCurrentNode.Priority < node.Priority)
//            //{
//            //    SetMajorPriorityNode(node);
//            //    return;
//            //}

//            //SetMinorPriorityNode(node);
//        }

//        private void SetMajorPriorityNode(InternalCodeExpressionNode node)
//        {
//#if DEBUG
//            NLog.LogManager.GetCurrentClassLogger().Info($"SetMajorPriorityNode node = {node}");
//#endif

//            var tmpNode = mCurrentNode;

//            while (true)
//            {
//                var tmpParent = tmpNode.Parent;

//#if DEBUG
//                NLog.LogManager.GetCurrentClassLogger().Info($"SetMajorPriorityNode tmpParent = {tmpParent?.ToString(mDataDictionary, 0)}");
//#endif

//                if (tmpParent == null)
//                {
//                    SetBetweenNodes(node, null, tmpNode);
//                    return;
//                }

//                if(tmpNode.Priority <= node.Priority)
//                {
//                    tmpNode = tmpParent;
//                    continue;
//                }

//                throw new NotImplementedException();
//            }
//        }

//        private void SetBetweenNodes(InternalCodeExpressionNode targetNode, InternalCodeExpressionNode parentNode, InternalCodeExpressionNode childNode)
//        {
//            if(parentNode == null)
//            {
//                RootNode = targetNode;           
//            }
//            else
//            {
//                throw new NotImplementedException();
//            }

//            mCurrentNode = targetNode;
//            childNode.Parent = targetNode;

//            var associativity = targetNode.Associativity;

//            switch (associativity)
//            {
//                case Associativity.Left:
//                    targetNode.Left = childNode;
//                    break;

//                case Associativity.Right:
//                    targetNode.Right = childNode;
//                    break;

//                default: throw new ArgumentOutOfRangeException(nameof(associativity), associativity, null);
//            }
//        }

//        private void CalculateAddTo(InternalCodeExpressionNode node)
//        {
//            var associativity = node.Associativity;

//            switch (associativity)
//            {
//                case Associativity.Left:
//                    mAddTo = Associativity.Right;
//                    break;

//                case Associativity.Right:
//                    mAddTo = Associativity.Left;
//                    break;

//                case Associativity.Undefined:
//                    mAddTo = Associativity.Undefined;
//                    break;

//                default: throw new ArgumentOutOfRangeException(nameof(associativity), associativity, null);
//            }
//        }

//        private void SetMinorPriorityNode(InternalCodeExpressionNode node)
//        {
//#if DEBUG
//            NLog.LogManager.GetCurrentClassLogger().Info($"SetMinorPriorityNode node = {node}");
//#endif
//            switch (mAddTo)
//            {
//                case Associativity.Right:
//                    node.Parent = mCurrentNode;
//                    mCurrentNode.Right = node;
//                    mCurrentNode = node;
//                    SetAddToByNodeAssociativity(node.Associativity);
//                    break;

//                case Associativity.Left:
//                    node.Parent = mCurrentNode;
//                    mCurrentNode.Left = node;
//                    mCurrentNode = node;
//                    SetAddToByNodeAssociativity(node.Associativity);
//                    break;

//                default: throw new ArgumentOutOfRangeException(nameof(mAddTo), mAddTo, null);
//            }
//        }

//        private void SetAddToByNodeAssociativity(Associativity associativity)
//        {
//            switch(associativity)
//            {
//                case Associativity.Undefined:
//                    mAddTo = Associativity.Undefined;
//                    break;

//                case Associativity.Right:
//                    mAddTo = Associativity.Left;
//                    break;

//                case Associativity.Left:
//                    mAddTo = Associativity.Right;
//                    break;
//            }
//        }

//        private InternalCodeExpressionNode GetNodeByToken(Token token)
//        {
//#if DEBUG
//            NLog.LogManager.GetCurrentClassLogger().Info($"GetNodeByToken token = {token}");
//#endif

//            var result = new InternalCodeExpressionNode();

//            switch(token.TokenKind)
//            {
//                case TokenKind.Number:
//                    result.Kind = ExpressionKind.ConstExpression;
//                    result.TypeKey = NumberKey;
//                    result.Value = double.Parse(token.Content, mFormatProvider);
//                    result.Priority = ConstValPriority;
//                    break;

//                case TokenKind.Assing:
//                    result.Kind = ExpressionKind.BinaryOperator;
//                    result.TypeKey = AssingOperatorKey;
//                    result.Priority = StandartOperatorPrioritiesConstants.Assing;
//                    result.Associativity = Associativity.Left;
//                    break;

//                case TokenKind.Plus:
//                    result.Kind = ExpressionKind.BinaryOperator;
//                    result.TypeKey = AddOperatorKey;
//                    result.Priority = StandartOperatorPrioritiesConstants.Add;
//                    result.Associativity = Associativity.Right;
//                    break;

//                case TokenKind.Var:
//                    result.Kind = ExpressionKind.VarExpression;
//                    result.TypeKey = mDataDictionary.GetKey(token.Content);
//                    result.Priority = VarPriority;
//                    break;

//                default: throw new UnexpectedTokenException(CurrToken);
//            }

//#if DEBUG
//            NLog.LogManager.GetCurrentClassLogger().Info($"GetNodeByToken result = {result?.ToString(mDataDictionary, 0)}");
//#endif

//            return result;
//        }

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
            //ASTResult.Expression = CreateExpressionNode(RootNode);
        }

        private void SetLeafToken(InternalCodeExpressionNode node)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLeafToken node = {node.ToString(mDataDictionary, 0)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLeafToken mCurrentNode = {mCurrentNode?.ToString(mDataDictionary, 0)}");
#endif
            if (RootNode == null)
            {
                RootNode = node;
                mCurrentNode = node;

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"SetLeafToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif
                return;
            }

            var classOfCurrentNode = mCurrentNode.ClassOfNode;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLeafToken classOfCurrentNode = {classOfCurrentNode}");
#endif
            switch (classOfCurrentNode)
            {
                case ClassOfNode.Assing:
                case ClassOfNode.Arithmetic:
                    if(mCurrentNode.Left == null)
                    {
                        throw new NotSupportedException();
                    }

                    if(mCurrentNode.Right != null)
                    {
                        throw new NotSupportedException();
                    }

                    mCurrentNode.Right = node;
                    node.Parent = mCurrentNode;
                    mCurrentNode = node;
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(classOfCurrentNode), classOfCurrentNode, null);
            }
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLeafToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif
        }

        private void SetAssingToken(InternalCodeExpressionNode node)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetAssingToken node = {node.ToString(mDataDictionary, 0)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"SetAssingToken mCurrentNode = {mCurrentNode?.ToString(mDataDictionary, 0)}");
#endif

            var classOfCurrentNode = mCurrentNode.ClassOfNode;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetAssingToken classOfCurrentNode = {classOfCurrentNode}");
#endif

            switch (classOfCurrentNode)
            {
                case ClassOfNode.Leaf:
                    {
                        var tmpNode = mCurrentNode;
                        mCurrentNode = node;

                        if(ReferenceEquals(tmpNode, RootNode))
                        {
                            RootNode = mCurrentNode;
                        }

                        mCurrentNode.Left = tmpNode;
                        var tmpOldParent = tmpNode.Parent;
                        tmpNode.Parent = mCurrentNode;

                        if(tmpOldParent != null)
                        {
#if DEBUG
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetAssingToken tmpOldParent = {tmpOldParent}");
#endif
                            var classOfOldParent = tmpOldParent.ClassOfNode;

#if DEBUG
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetAssingToken classOfOldParent = {classOfOldParent}");
#endif

                            switch(classOfOldParent)
                            {
                                case ClassOfNode.Assing:
                                    if(ReferenceEquals(tmpOldParent.Right, tmpNode))
                                    {
#if DEBUG
                                        NLog.LogManager.GetCurrentClassLogger().Info("SetAssingToken ReferenceEquals(tmpOldParent.Right, tmpNode)");
#endif
                                        mCurrentNode.Parent = tmpOldParent;
                                        tmpOldParent.Right = mCurrentNode;
                                        break;
                                    }
                                    throw new NotSupportedException();

                                default: throw new ArgumentOutOfRangeException(nameof(classOfOldParent), classOfOldParent, null);
                            }
                        }
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(classOfCurrentNode), classOfCurrentNode, null);
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetAssingToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif
        }

        private int GetArithmeticNodePriority(ulong typeKey)
        {
            if (typeKey == AddOperatorKey)
            {
                return AddAndSubPriority;
            }

            if (typeKey == MulOperatorKey)
            {
                return MulAndDivPriotiry;
            }

            throw new NotImplementedException();
        }

        private void SetArithmeticToken(InternalCodeExpressionNode node)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken node = {node.ToString(mDataDictionary, 0)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken mCurrentNode = {mCurrentNode?.ToString(mDataDictionary, 0)}");
#endif

            var nodePriority = GetArithmeticNodePriority(node.TypeKey);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken nodePriority = {nodePriority}");
#endif

            var currentNode = mCurrentNode;

            while(true)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken currentNode = {currentNode.ToString(mDataDictionary, 0)}");
#endif

                var classOfCurrentNode = currentNode.ClassOfNode;

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken classOfCurrentNode = {classOfCurrentNode}");
#endif

                switch (classOfCurrentNode)
                {
                    case ClassOfNode.Leaf:
                        currentNode = currentNode.Parent;
                        break;

                    case ClassOfNode.Assing:
                        {
                            var tmpNode = currentNode.Right;
                            tmpNode.Parent = node;
                            node.Left = tmpNode;
                            currentNode.Right = node;
                            node.Parent = currentNode;
                            mCurrentNode = node;
#if DEBUG
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif
                        }
                        return;

                    case ClassOfNode.Arithmetic:
                        {
                            var currentNodePriority = GetArithmeticNodePriority(currentNode.TypeKey);

#if DEBUG
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken currentNodePriority = {currentNodePriority} nodePriority = {nodePriority}");
#endif

                            if(nodePriority < currentNodePriority)
                            {
                                currentNode = currentNode.Parent;
                                break;
                            }

                            var tmpNode = currentNode.Right;
                            tmpNode.Parent = node;
                            node.Left = tmpNode;
                            currentNode.Right = node;
                            node.Parent = currentNode;
                            mCurrentNode = node;
#if DEBUG
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif

                            return;
                        }

                    default: throw new ArgumentOutOfRangeException(nameof(classOfCurrentNode), classOfCurrentNode, null);
                }
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif

            throw new NotImplementedException();
        }

        //private ASTExpression CreateExpressionNode(InternalCodeExpressionNode node)
        //{
        //    switch(node.Kind)
        //    {
        //        case ExpressionKind.BinaryOperator:
        //            return CreateBinaryOperator(node);

        //        case ExpressionKind.ConstExpression:
        //            return CreateConstExpression(node);

        //        default: throw new ArgumentOutOfRangeException(nameof(node.Kind), $"Argument value `{node.Kind}` out of range.");
        //    }
        //}

        //private ASTExpression CreateBinaryOperator(InternalCodeExpressionNode node)
        //{
        //    var result = new ASTBinaryOperator();
        //    result.OperatorKey = node.TypeKey;
        //    result.Left = CreateExpressionNode(node.Left);
        //    result.Right = CreateExpressionNode(node.Right);
        //    return result;
        //}

        //private ASTExpression CreateConstExpression(InternalCodeExpressionNode node)
        //{
        //    var result = new ASTConstExpression();
        //    result.TypeKey = node.TypeKey;
        //    result.Value = node.Value;
        //    return result;
        //}
    }
}
