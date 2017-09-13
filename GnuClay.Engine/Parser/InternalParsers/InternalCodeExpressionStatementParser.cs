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
using GnuClay.CommonUtils.TypeHelpers;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public class InternalCodeExpressionStatementParser : BaseInternalParser
    {
        public enum State
        {
            Init,
            HasTilde
        }

        public enum Mode
        {
            General,
            InRoundBracketsGroup,
            IsParameterOfFunction
        }

        public InternalCodeExpressionStatementParser(InternalParserContext context, Mode mode, bool createASTResult)
            : base(context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"constructor mode = {mode}");
#endif

            mCommonKeysEngine = Context.MainContext.CommonKeysEngine;
            mDataDictionary = Context.MainContext.DataDictionary;

            mMode = mode;
            mCreateASTResult = createASTResult;
        }

        private CommonKeysEngine mCommonKeysEngine = null;
        private StorageDataDictionary mDataDictionary = null;

        public ASTExpressionStatement ASTResult = null;
        private State mState = State.Init;
        private Mode mMode = Mode.General;
        private bool mCreateASTResult;
        public InternalCodeExpressionNode RootNode = null;
        private InternalCodeExpressionNode mCurrentNode = null;

        private int MulAndDivPriotiry = 2;
        private int AddAndSubPriority = 1;

        /// <summary>
        /// &lt; > &lt;= >=
        /// </summary>
        private int RelationalPriority = 4;

        /// <summary>
        /// == !=
        /// </summary>
        private int EqualityPriority = 3;

        /// <summary>
        /// &amp;
        /// </summary>
        private int LogicalAndPriority = 2;

        /// <summary>
        /// |
        /// </summary>
        private int LogicalOrPriority = 1;

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

                        case TokenKind.OpenRoundBracket:
                            ProcessOpenRoundBracket();
                            break;

                        case TokenKind.CloseRoundBracket:
                            ProcessCloseRoundBracket();
                            break;

                        case TokenKind.Semicolon:
                            ProcessSemicolonToken();
                            break;

                        case TokenKind.Word:
                            ProcessWordToken();
                            break;

                        case TokenKind.Point:
                            ProcessPointToken();
                            break;

                        case TokenKind.Comma:
                            if(mMode == Mode.IsParameterOfFunction)
                            {
                                Context.Recovery(CurrToken);
                                Exit();
                                return;
                            }
                            throw new UnexpectedTokenException(CurrToken);

                        case TokenKind.BEGIN_TARGET:
                            ProcessBeginTarget();
                            break;

                        case TokenKind.Tilde:
                            mState = State.HasTilde;
                            break;

                        case TokenKind.Equal:
                            ProcessEqualToken();
                            break;

                        case TokenKind.NotEqual:
                            ProcessNotEqualToken();
                            break;

                        case TokenKind.More:
                            ProcessMoreToken();
                            break;

                        case TokenKind.MoreOrEqual:
                            ProcessMoreOrEqualToken();
                            break;

                        case TokenKind.Less:
                            ProcessLessToken();
                            break;

                        case TokenKind.LessOrEqual:
                            ProcessLessOrEqualToken();
                            break;

                        case TokenKind.And:
                            ProcessAndToken();
                            break;

                        case TokenKind.Or:
                            ProcessOrToken();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                case State.HasTilde:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Word:
                            ProcessWordToken();
                            break;

                        case TokenKind.Var:
                            ProcessVarToken();
                            break;

                        default: throw new UnexpectedTokenException(CurrToken);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(mState), mState, null);
            }
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

            if (mState == State.HasTilde)
            {
                result.IsAsync = true;
                mState = State.Init;
            }

            SetLeafToken(result);
        }

        private void ProcessWordToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessVarToken");
#endif

            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.EntityExpression;
            result.TypeKey = mDataDictionary.GetKey(CurrToken.Content);
            result.ClassOfNode = ClassOfNode.Leaf;

            if(mState == State.HasTilde)
            {
                result.IsAsync = true;
                mState = State.Init;
            }

            SetLeafToken(result);
        }

        private void ProcessAssingToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessAssingToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.AssignOperatorKey;
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
            result.TypeKey = mCommonKeysEngine.NumberKey;
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
            result.TypeKey = mCommonKeysEngine.MulOperatorKey;
            result.ClassOfNode = ClassOfNode.Arithmetic;

            SetArithmeticToken(result);
        }

        private void ProcessDashToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessDashToken");
#endif

            if(mCurrentNode == null)
            {
                ProcessNumberToken();
                return;
            }

            var classOfCurrentNode = mCurrentNode.ClassOfNode;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLeafToken classOfCurrentNode = {classOfCurrentNode}");
#endif

            switch(classOfCurrentNode)
            {
                case ClassOfNode.Arithmetic:
                    ProcessNumberToken();
                    return;

                case ClassOfNode.Leaf:
                    var result = new InternalCodeExpressionNode();
                    result.Kind = ExpressionKind.BinaryOperator;
                    result.TypeKey = mCommonKeysEngine.SubOperatorKey;
                    result.ClassOfNode = ClassOfNode.Arithmetic;

                    SetArithmeticToken(result);
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
            result.TypeKey = mCommonKeysEngine.AddOperatorKey;
            result.ClassOfNode = ClassOfNode.Arithmetic;

            SetArithmeticToken(result);
        }

        private void ProcessOpenRoundBracket()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessOpenRoundBracket");
#endif

            var classOfCurrentNode = mCurrentNode.ClassOfNode;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessOpenRoundBracket classOfCurrentNode = {classOfCurrentNode}");
#endif

            switch(classOfCurrentNode)
            {
                case ClassOfNode.Arithmetic:
                case ClassOfNode.Logical:
                    {
                        var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, Mode.InRoundBracketsGroup, false);
                        tmpInternalCodeExpressionStatementParser.Run();
                        var tmpNode = tmpInternalCodeExpressionStatementParser.RootNode;

#if DEBUG
                        NLog.LogManager.GetCurrentClassLogger().Info($"ProcessOpenRoundBracket tmpNode = {tmpNode?.ToString(mDataDictionary, 0)}");
#endif
                        var result = new InternalCodeExpressionNode();
                        result.ClassOfNode = ClassOfNode.RoundBracketsGroup;
                        result.GroupedNode = tmpNode;

                        SetLeafToken(result);
                    }
                    break;

                case ClassOfNode.Leaf:
                    {
                        var tmpInternalParamsOfFunctionParser = new InternalParamsOfFunctionParser(Context);
                        tmpInternalParamsOfFunctionParser.Run();
                        mCurrentNode.Params = tmpInternalParamsOfFunctionParser.Result;
#if DEBUG
                        NLog.LogManager.GetCurrentClassLogger().Info($"ProcessOpenRoundBracket mCurrentNode = {mCurrentNode?.ToString(mDataDictionary, 0)}");
#endif
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(classOfCurrentNode), classOfCurrentNode, null);
            }
        }

        private void ProcessCloseRoundBracket()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessCloseRoundBracket");
#endif

            if(mMode == Mode.InRoundBracketsGroup)
            {
                Exit();
                return;
            }

            if(mMode == Mode.IsParameterOfFunction)
            {
                Context.Recovery(CurrToken);
                Exit();
                return;
            }

            throw new UnexpectedTokenException(CurrToken);
        }

        private void ProcessSemicolonToken()
        {
            if(mMode == Mode.General)
            {
                Exit();
                return;
            }
          
            throw new UnexpectedTokenException(CurrToken);
        }

        private void ProcessPointToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessPointToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.PointOperatorKey;
            result.ClassOfNode = ClassOfNode.Point;

            SetAssingToken(result);
        }

        private void ProcessEqualToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessEqualToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.EqualOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessNotEqualToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessNotEqualToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.NotEqualOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessMoreToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessMoreToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.MoreOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessMoreOrEqualToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessMoreOrEqualToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.MoreOrEqualOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessLessToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessLessToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.LessOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessLessOrEqualToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessLessOrEqualToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.LessOrEqualOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessAndToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessAndToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.AndOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessOrToken()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessOrToken");
#endif
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.OrOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessBeginTarget()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessBeginTarget");
#endif

            var tmpParser = new InternalTargetOfFunctionParser(Context);
            tmpParser.Run();

            var tmpTarget = tmpParser.Result;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessBeginTarget tmpTarget = {tmpTarget?.ToString(mDataDictionary, 0)}");
#endif

            mCurrentNode.Target = tmpTarget;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessOpenRoundBracket mCurrentNode = {mCurrentNode?.ToString(mDataDictionary, 0)}");
#endif
        }

        protected override void OnFinish()
        {
            if(mCreateASTResult)
            {
                if (RootNode == null)
                {
                    return;
                }

                ASTResult = new ASTExpressionStatement();
                ASTResult.Expression = CreateExpressionNode(RootNode);
            }
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
                case ClassOfNode.Point:
                case ClassOfNode.Logical:
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
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetAssingToken tmpOldParent = {tmpOldParent?.ToString(mDataDictionary, 0)}");
#endif
                            var classOfOldParent = tmpOldParent.ClassOfNode;

#if DEBUG
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetAssingToken classOfOldParent = {classOfOldParent}");
#endif

                            switch(classOfOldParent)
                            {
                                case ClassOfNode.Assing:
                                case ClassOfNode.Point:
                                case ClassOfNode.Logical:
                                case ClassOfNode.Arithmetic:
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
            if (typeKey == mCommonKeysEngine.AddOperatorKey)
            {
                return AddAndSubPriority;
            }

            if(typeKey == mCommonKeysEngine.SubOperatorKey)
            {
                return AddAndSubPriority;
            }

            if (typeKey == mCommonKeysEngine.MulOperatorKey)
            {
                return MulAndDivPriotiry;
            }

            if(typeKey == mCommonKeysEngine.DivOperatorKey)
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
            InternalCodeExpressionNode prevNode = null;

            while(true)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken currentNode = {currentNode?.ToString(mDataDictionary, 0)}");
#endif

                if(currentNode == null)
                {
                    if(prevNode == null)
                    {
                        throw new NotSupportedException();
                    }

#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken currentNode == null prevNode = {prevNode.ToString(mDataDictionary, 0)}");
#endif

                    mCurrentNode = node;
                    prevNode.Parent = node;
                    node.Left = prevNode;
                    RootNode = mCurrentNode;

#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif

                    return;
                }

                var classOfCurrentNode = currentNode.ClassOfNode;

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken classOfCurrentNode = {classOfCurrentNode}");
#endif

                switch (classOfCurrentNode)
                {
                    case ClassOfNode.Leaf:
                        prevNode = currentNode;
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
                                prevNode = currentNode;
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

            throw new NotImplementedException();
        }

        private void SetLogicalToken(InternalCodeExpressionNode node)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken node = {node.ToString(mDataDictionary, 0)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken mCurrentNode = {mCurrentNode?.ToString(mDataDictionary, 0)}");
#endif

            var nodePriority = GetLogicalNodePriority(node.TypeKey);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken nodePriority = {nodePriority}");
#endif
            var currentNode = mCurrentNode;
            InternalCodeExpressionNode prevNode = null;

            while (true)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken currentNode = {currentNode?.ToString(mDataDictionary, 0)}");
#endif

                if (currentNode == null)
                {
                    if (prevNode == null)
                    {
                        throw new NotSupportedException();
                    }

#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken currentNode == null prevNode = {prevNode.ToString(mDataDictionary, 0)}");
#endif

                    mCurrentNode = node;
                    prevNode.Parent = node;
                    node.Left = prevNode;
                    RootNode = mCurrentNode;

#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif

                    return;
                }

                var classOfCurrentNode = currentNode.ClassOfNode;

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken classOfCurrentNode = {classOfCurrentNode}");
#endif
                switch (classOfCurrentNode)
                {
                    case ClassOfNode.Leaf:
                        prevNode = currentNode;
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
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif
                        }
                        return;

                    case ClassOfNode.Logical:
                        {
                            var currentNodePriority = GetLogicalNodePriority(currentNode.TypeKey);

#if DEBUG
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken currentNodePriority = {currentNodePriority} nodePriority = {nodePriority}");
#endif

                            if (nodePriority < currentNodePriority)
                            {
                                prevNode = currentNode;
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
                            NLog.LogManager.GetCurrentClassLogger().Info($"SetLogicalToken RootNode = {RootNode.ToString(mDataDictionary, 0)}");
#endif

                            return;
                        }

                    default: throw new ArgumentOutOfRangeException(nameof(classOfCurrentNode), classOfCurrentNode, null);
                }
            }

            throw new NotImplementedException();
        }

        private int GetLogicalNodePriority(ulong typeKey)
        {
            if(typeKey == mCommonKeysEngine.MoreOperatorKey)
            {
                return RelationalPriority;
            }

            if (typeKey == mCommonKeysEngine.LessOperatorKey)
            {
                return RelationalPriority;
            }

            if (typeKey == mCommonKeysEngine.MoreOrEqualOperatorKey)
            {
                return RelationalPriority;
            }

            if (typeKey == mCommonKeysEngine.LessOrEqualOperatorKey)
            {
                return RelationalPriority;
            }

            if (typeKey == mCommonKeysEngine.EqualOperatorKey)
            {
                return EqualityPriority;
            }

            if (typeKey == mCommonKeysEngine.NotEqualOperatorKey)
            {
                return EqualityPriority;
            }

            if (typeKey == mCommonKeysEngine.AndOperatorKey)
            {
                return LogicalAndPriority;
            }

            if (typeKey == mCommonKeysEngine.OrOperatorKey)
            {
                return LogicalOrPriority;
            }

            throw new NotImplementedException();
        }

        private ASTExpression CreateExpressionNode(InternalCodeExpressionNode node)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"CreateExpressionNode node = {node.ToString(mDataDictionary, 0)}");
#endif

            switch (node.Kind)
            {
                case ExpressionKind.BinaryOperator:
                    return CreateBinaryOperator(node);

                case ExpressionKind.ConstExpression:
                    return CreateConstExpression(node);

                case ExpressionKind.VarExpression:
                    return CreateVarExpression(node);

                case ExpressionKind.EntityExpression:
                    return CreateEntityExpression(node);

                case ExpressionKind.Undefined:
                    if(node.ClassOfNode == ClassOfNode.RoundBracketsGroup)
                    {
                        return CreateExpressionNode(node.GroupedNode);
                    }
                    throw new ArgumentOutOfRangeException(nameof(node.Kind), $"Argument value `{node.Kind}` out of range.");

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

        private ASTExpression CreateVarExpression(InternalCodeExpressionNode node)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"CreateVarExpression node = {node.ToString(mDataDictionary, 0)}");
#endif
            if (node.Target != null || node.Params != null)
            {
#if DEBUG
                //NLog.LogManager.GetCurrentClassLogger().Info($"CreateVarExpression node = {node.ToString(mDataDictionary, 0)}");
#endif

                var calledResult = new ASTCalledVarExpression();
                calledResult.TypeKey = node.TypeKey;
                calledResult.IsAsync = node.IsAsync;
                if (node.Target != null)
                {
                    calledResult.Target = CreateExpressionNode(node.Target);
                }

                if (!_ListHelper.IsEmpty(node.Params))
                {
                    foreach (var paramItem in node.Params)
                    {
                        calledResult.Params.Add(CreateExpressionNode(paramItem));
                    }
                }

                return calledResult;
            }

            var result = new ASTVarExpression();
            result.TypeKey = node.TypeKey;
            return result;
        }

        private ASTExpression CreateEntityExpression(InternalCodeExpressionNode node)
        {
#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"CreateEntityExpression node = {node.ToString(mDataDictionary, 0)}");
#endif
            if(node.Target != null || node.Params != null)
            {
                var calledResult = new ASTCalledEntityExpression();
                calledResult.TypeKey = node.TypeKey;
                calledResult.IsAsync = node.IsAsync;
                if(node.Target != null)
                {
                    calledResult.Target = CreateExpressionNode(node.Target);
                }
                
                if(!_ListHelper.IsEmpty(node.Params))
                {
                    foreach (var paramItem in node.Params)
                    {
                        calledResult.Params.Add(CreateExpressionNode(paramItem));
                    }
                }

                return calledResult;
            }

            var result = new ASTEntityExpression();
            result.TypeKey = node.TypeKey;

            return result;
        }
    }
}
