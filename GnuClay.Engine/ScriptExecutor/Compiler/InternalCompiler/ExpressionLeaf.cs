﻿using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class ExpressionLeaf : BaseLeaf
    {
        public ExpressionLeaf(CompilerContext context)
            : base(context)
        {
        }

        public void Run(ASTExpressionStatement ast)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            ProcessNode(ast.Expression);
        }

        private void ProcessNode(ASTExpression expression)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessNode {expression.Kind}");

            switch(expression.Kind)
            {
                case ExpressionKind.BinaryOperator:
                    ProcessBinaryOperator(expression as ASTBinaryOperator);
                    break;

                case ExpressionKind.ConstExpression:
                    ProcessConstExpression(expression as ASTConstExpression);
                    break;

                default: throw new NotSupportedException($"`{expression.Kind}` is not supported.");
            }
        }

        private void ProcessBinaryOperator(ASTBinaryOperator expression)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessBinaryOperator");

            ProcessNode(expression.Left);
            ProcessNode(expression.Right);

            Context.Result.AddCommand(new ScriptCommand()
            {
                OperationCode = OperationCode.CallBinOp,
                Key = expression.OperatorKey
            });
        }

        private void ProcessConstExpression(ASTConstExpression expression)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessConstExpression");

            var tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushConst;
            tmpCommand.Key = expression.TypeKey;
            tmpCommand.Value = expression.Value;

            Context.Result.AddCommand(tmpCommand);
        }
    }
}
