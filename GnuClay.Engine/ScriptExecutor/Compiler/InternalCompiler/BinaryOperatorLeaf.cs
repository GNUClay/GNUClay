using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class BinaryOperatorLeaf : BaseLeaf
    {
        public BinaryOperatorLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private ASTBinaryOperator BinaryOperator;
        private ASTExpression Left;
        private ASTExpression Right;

        public void Run(ASTExpression ast)
        {
            BinaryOperator = ast as ASTBinaryOperator;
            Left = BinaryOperator.Left;
            Right = BinaryOperator.Right;

            var operatorKey = BinaryOperator.OperatorKey;

            var pointKey = Context.CommonKeysEngine.PointOperatorKey;

            if(operatorKey == pointKey)
            {
                ProcessPointOperator();
                return;
            }

            ProcessUsualOperator();
        }

        private void ProcessPointOperator()
        {
            var parent = BinaryOperator.Parent;

            if(parent == null)
            {
                var leaf = new ExpressionNodeLeaf(Context);
                leaf.Run(BinaryOperator.Left);
                AddCommands(leaf.Result);        
            }
            else
            {
                var parentKind = parent.Kind;

                switch(parentKind)
                {
                    case ExpressionKind.BinaryOperator:
                        var parentExpression = parent as ASTBinaryOperator;
                        var operatorKey = parentExpression.OperatorKey;

                        if(operatorKey == Context.CommonKeysEngine.PointOperatorKey)
                        {
                            var leaf = new ExpressionNodeLeaf(Context);
                            leaf.RunMember(BinaryOperator.Left);
                            AddCommands(leaf.Result);
                        }
                        else
                        {
                            var leaf = new ExpressionNodeLeaf(Context);
                            leaf.Run(BinaryOperator.Left);
                            AddCommands(leaf.Result); 
                        }
                        break;

                    default: throw new ArgumentOutOfRangeException(nameof(parentKind), parentKind, null);
                }
            }


            var rigthKind = Right.Kind;

            switch (rigthKind)
            {
                case ExpressionKind.BinaryOperator:
                    {
                        var rightExpr = Right as ASTBinaryOperator;
                        var rightOpCode = rightExpr.OperatorKey;

                        if(rightOpCode == Context.CommonKeysEngine.PointOperatorKey)
                        {
                            var leaf = new BinaryOperatorLeaf(Context);
                            leaf.Run(rightExpr);
                            AddCommands(leaf.Result);
                        }
                        else
                        {
#if DEBUG
                            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessPointOperator rightOpCode = {rightOpCode}");
                            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessPointOperator Context.CommonKeysEngine.PointOperatorKey = {Context.CommonKeysEngine.PointOperatorKey}");
                            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessPointOperator rightOpCode = {Context.DataDictionary.GetValue(rightOpCode)}");
#endif

                            throw new NotImplementedException();
                        }
                    }
                    break;

                case ExpressionKind.CalledEntityExpression:
                    {
                        var rightExpr = Right as ASTCalledEntityExpression;
                        var leaf = new CallMemberLeaf(Context);
                        leaf.Run(rightExpr);
                        AddCommands(leaf.Result);
                    }
                    break;

                case ExpressionKind.EntityExpression:
                    {
                        var rightExpr = Right as ASTEntityExpression;
                        var leaf = new ExpressionNodeLeaf(Context);
                        leaf.RunMember(rightExpr);
                        AddCommands(leaf.Result);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(rigthKind), rigthKind, null);
            }
        }

        private void ProcessUsualOperator()
        {
            var leaf = new ExpressionNodeLeaf(Context);
            leaf.Run(Left);
            AddCommands(leaf.Result);

            leaf = new ExpressionNodeLeaf(Context);
            leaf.Run(Right);
            AddCommands(leaf.Result);

            var tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.CallBinOp;
            tmpCommand.Key = BinaryOperator.OperatorKey;
            AddCommand(tmpCommand);
        }
    }
}
