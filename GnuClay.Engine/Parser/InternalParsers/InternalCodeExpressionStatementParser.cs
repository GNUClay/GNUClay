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
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mState = {mState} CurrToken.TokenKind = {CurrToken.TokenKind} CurrToken.KeyWordTokenKind = {CurrToken.KeyWordTokenKind} CurrToken.Content = '{CurrToken.Content}'");
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun RootNode = {RootNode?.ToString(mDataDictionary, 0)}");
            NLog.LogManager.GetCurrentClassLogger().Info($"OnRun mCurrentNode = {mCurrentNode?.ToString(mDataDictionary, 0)} ");
#endif
            switch (mState)
            {
                case State.Init:
                    switch (CurrToken.TokenKind)
                    {
                        case TokenKind.Var:
                        case TokenKind.SystemVar:
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

                        case TokenKind.Colon:
                            if (mMode == Mode.IsParameterOfFunction)
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
                        case TokenKind.SystemVar:
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
            var result = new InternalCodeExpressionNode();

            switch (CurrToken.TokenKind)
            {
                case TokenKind.Var:
                    result.Kind = ExpressionKind.VarExpression;
                    break;

                case TokenKind.SystemVar:
                    result.Kind = ExpressionKind.SystemVarExpression;
                    break;

                default: throw new UnexpectedTokenException(CurrToken);
            }
            
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
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.AssignOperatorKey;
            result.ClassOfNode = ClassOfNode.Assing;

            SetAssingToken(result);
        }

        private void ProcessNumberToken()
        {
            Context.Recovery(CurrToken);
            var tmpInternalNumberParser = new InternalNumberParser(Context);
            tmpInternalNumberParser.Run();

            var numberResult = tmpInternalNumberParser.Result;

            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.ConstExpression;
            result.TypeKey = mCommonKeysEngine.NumberKey;
            result.Value = numberResult;
            result.ClassOfNode = ClassOfNode.Leaf;

            SetLeafToken(result);
        }

        private void ProcessMulToken()
        {
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.MulOperatorKey;
            result.ClassOfNode = ClassOfNode.Arithmetic;

            SetArithmeticToken(result);
        }

        private void ProcessDashToken()
        {
            if(mCurrentNode == null)
            {
                ProcessNumberToken();
                return;
            }

            var classOfCurrentNode = mCurrentNode.ClassOfNode;

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
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.AddOperatorKey;
            result.ClassOfNode = ClassOfNode.Arithmetic;

            SetArithmeticToken(result);
        }

        private void ProcessOpenRoundBracket()
        {
            var classOfCurrentNode = mCurrentNode.ClassOfNode;

            switch(classOfCurrentNode)
            {
                case ClassOfNode.Arithmetic:
                case ClassOfNode.Logical:
                    {
                        var tmpInternalCodeExpressionStatementParser = new InternalCodeExpressionStatementParser(Context, Mode.InRoundBracketsGroup, false);
                        tmpInternalCodeExpressionStatementParser.Run();
                        var tmpNode = tmpInternalCodeExpressionStatementParser.RootNode;

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
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(classOfCurrentNode), classOfCurrentNode, null);
            }
        }

        private void ProcessCloseRoundBracket()
        {
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
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.PointOperatorKey;
            result.ClassOfNode = ClassOfNode.Point;

            SetAssingToken(result);
        }

        private void ProcessEqualToken()
        {
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.EqualOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessNotEqualToken()
        {
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.NotEqualOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessMoreToken()
        {
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.MoreOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessMoreOrEqualToken()
        {
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.MoreOrEqualOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessLessToken()
        {
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.LessOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessLessOrEqualToken()
        {
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.LessOrEqualOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessAndToken()
        {
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.AndOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessOrToken()
        {
            var result = new InternalCodeExpressionNode();
            result.Kind = ExpressionKind.BinaryOperator;
            result.TypeKey = mCommonKeysEngine.OrOperatorKey;
            result.ClassOfNode = ClassOfNode.Logical;

            SetLogicalToken(result);
        }

        private void ProcessBeginTarget()
        {
            var tmpParser = new InternalTargetOfFunctionParser(Context);
            tmpParser.Run();

            var tmpTarget = tmpParser.Result;

            mCurrentNode.Target = tmpTarget;
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
            if (RootNode == null)
            {
                RootNode = node;
                mCurrentNode = node;
                return;
            }

            var classOfCurrentNode = mCurrentNode.ClassOfNode;

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
        }

        private void SetAssingToken(InternalCodeExpressionNode node)
        {
            var classOfCurrentNode = mCurrentNode.ClassOfNode;

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
                            var classOfOldParent = tmpOldParent.ClassOfNode;

                            switch(classOfOldParent)
                            {
                                case ClassOfNode.Assing:
                                case ClassOfNode.Point:
                                case ClassOfNode.Logical:
                                case ClassOfNode.Arithmetic:
                                    if(ReferenceEquals(tmpOldParent.Right, tmpNode))
                                    {
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
            NLog.LogManager.GetCurrentClassLogger().Info($"SetArithmeticToken node = {node?.ToString(mDataDictionary, 0)}");
#endif
            var nodePriority = GetArithmeticNodePriority(node.TypeKey);

            var currentNode = mCurrentNode;
            InternalCodeExpressionNode prevNode = null;

            while(true)
            {
                if(currentNode == null)
                {
                    if(prevNode == null)
                    {
                        throw new NotSupportedException();
                    }

                    mCurrentNode = node;
                    prevNode.Parent = node;
                    node.Left = prevNode;
                    RootNode = mCurrentNode;
                    return;
                }

                var classOfCurrentNode = currentNode.ClassOfNode;

                switch (classOfCurrentNode)
                {
                    case ClassOfNode.Leaf:
                    case ClassOfNode.Point:
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
                        }
                        return;

                    case ClassOfNode.Arithmetic:
                        {
                            var currentNodePriority = GetArithmeticNodePriority(currentNode.TypeKey);

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
                            return;
                        }

                    default: throw new ArgumentOutOfRangeException(nameof(classOfCurrentNode), classOfCurrentNode, null);
                }
            }

            throw new NotImplementedException();
        }

        private void SetLogicalToken(InternalCodeExpressionNode node)
        {
            var nodePriority = GetLogicalNodePriority(node.TypeKey);

            var currentNode = mCurrentNode;
            InternalCodeExpressionNode prevNode = null;

            while (true)
            {
                if (currentNode == null)
                {
                    if (prevNode == null)
                    {
                        throw new NotSupportedException();
                    }

                    mCurrentNode = node;
                    prevNode.Parent = node;
                    node.Left = prevNode;
                    RootNode = mCurrentNode;
                    return;
                }

                var classOfCurrentNode = currentNode.ClassOfNode;

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
                        }
                        return;

                    case ClassOfNode.Logical:
                        {
                            var currentNodePriority = GetLogicalNodePriority(currentNode.TypeKey);

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

        private ASTExpression CreateExpressionNode(InternalCodeParamNode node)
        {
            var result = new ASTParamExpression();
            result.IsNamed = node.IsNamed;
            if(node.Name != null)
            {
                result.Name = CreateExpressionNode(node.Name);
                result.Name.Parent = result;
            }
            
            result.Value = CreateExpressionNode(node.Value);
            result.Value.Parent = result;

            return result;
        }

        private ASTExpression CreateExpressionNode(InternalCodeExpressionNode node)
        {
            switch (node.Kind)
            {
                case ExpressionKind.BinaryOperator:
                    return CreateBinaryOperator(node);

                case ExpressionKind.ConstExpression:
                    return CreateConstExpression(node);

                case ExpressionKind.VarExpression:
                case ExpressionKind.SystemVarExpression:
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
            result.Left.Parent = result;
            result.Right = CreateExpressionNode(node.Right);
            result.Right.Parent = result;
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
            if (node.Target != null || node.Params != null)
            {
                var calledResult = new ASTCalledVarExpression();
                calledResult.TypeKey = node.TypeKey;
                calledResult.IsAsync = node.IsAsync;
                if (node.Target != null)
                {
                    calledResult.Target = CreateExpressionNode(node.Target);
                    calledResult.Target.Parent = calledResult;
                }

                if (!_ListHelper.IsEmpty(node.Params))
                {
                    foreach (var paramItem in node.Params)
                    {
                        var param = CreateExpressionNode(paramItem);
                        param.Parent = calledResult;
                        calledResult.Params.Add(param);
                    }
                }

                return calledResult;
            }

            var result = new ASTVarExpression();
            result.TypeKey = node.TypeKey;
            if(node.Kind == ExpressionKind.SystemVarExpression)
            {
                result.IsSystem = true;
            }
            return result;
        }

        private ASTExpression CreateEntityExpression(InternalCodeExpressionNode node)
        {
            if(node.Target != null || node.Params != null)
            {
                var calledResult = new ASTCalledEntityExpression();
                calledResult.TypeKey = node.TypeKey;
                calledResult.IsAsync = node.IsAsync;
                if(node.Target != null)
                {
                    calledResult.Target = CreateExpressionNode(node.Target);
                    calledResult.Target.Parent = calledResult;
                }
                
                if(!_ListHelper.IsEmpty(node.Params))
                {
                    foreach (var paramItem in node.Params)
                    {
                        var param = CreateExpressionNode(paramItem);
                        param.Parent = calledResult;
                        calledResult.Params.Add(param);
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
