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

        public InternalCodeExpressionStatementParser(InternalParserContext context, Mode mode)
            : base(context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"constructor mode = {mode}");
#endif

            var mCommonKeysEngine = Context.MainContext.CommonKeysEngine;
            mDataDictionary = Context.MainContext.DataDictionary;

            mMode = mode;

            NumberKey = mCommonKeysEngine.NumberKey;

            AddOperatorKey = mCommonKeysEngine.AddOperatorKey;
            SubOperatorKey = mCommonKeysEngine.SubOperatorKey;
            MulOperatorKey = mCommonKeysEngine.MulOperatorKey;
            DivOperatorKey = mCommonKeysEngine.DivOperatorKey;
            PointOperatorKey = mCommonKeysEngine.DivOperatorKey;

            AssingOperatorKey = mCommonKeysEngine.AssignOperatorKey;
        }

        private StorageDataDictionary mDataDictionary = null;

        public ASTExpressionStatement ASTResult = null;
        private State mState = State.Init;
        private Mode mMode = Mode.General;
        public InternalCodeExpressionNode RootNode = null;
        private InternalCodeExpressionNode mCurrentNode = null;

        private ulong NumberKey = 0;
        private ulong AddOperatorKey = 0;
        private ulong SubOperatorKey = 0;
        private ulong MulOperatorKey = 0;
        private ulong DivOperatorKey = 0;
        private ulong AssingOperatorKey = 0;
        private ulong PointOperatorKey = 0;
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

                case ClassOfNode.Leaf:
                    var result = new InternalCodeExpressionNode();
                    result.Kind = ExpressionKind.BinaryOperator;
                    result.TypeKey = SubOperatorKey;
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
            result.TypeKey = AddOperatorKey;
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
                    {
                        var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, Mode.InRoundBracketsGroup);
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
            result.TypeKey = PointOperatorKey;
            result.ClassOfNode = ClassOfNode.Point;

            SetAssingToken(result);
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
            if(mMode != Mode.General)
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
                                case ClassOfNode.Point:
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

            if(typeKey == SubOperatorKey)
            {
                return AddAndSubPriority;
            }

            if (typeKey == MulOperatorKey)
            {
                return MulAndDivPriotiry;
            }

            if(typeKey == DivOperatorKey)
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
