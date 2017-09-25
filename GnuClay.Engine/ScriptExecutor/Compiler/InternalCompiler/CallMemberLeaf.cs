﻿using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler
{
    public class CallMemberLeaf : BaseLeaf
    {
        public CallMemberLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run(ASTCalledEntityExpression ast)
        {
            var functionKey = ast.TypeKey;
            AddCommand(CreatePushEntityCommand(functionKey));

            var target = ast.Target;

            if (target != null)
            {
                var targetLeaf = new ExpressionNodeLeaf(Context);
                targetLeaf.Run(target);
                AddCommands(targetLeaf.Result);
            }

            var parameters = ast.Params;

            var isNamed = false;

            foreach (var parameter in parameters)
            {
                var paramExpr = parameter as ASTParamExpression;

                isNamed = paramExpr.IsNamed;

                if (isNamed)
                {
                    var paramLeaf = new ExpressionNodeLeaf(Context);
                    paramLeaf.Run(paramExpr.Name);
                    AddCommands(paramLeaf.Result);
                    paramLeaf = new ExpressionNodeLeaf(Context);
                    paramLeaf.Run(paramExpr.Value);
                    AddCommands(paramLeaf.Result);
                }
                else
                {
                    var paramLeaf = new ExpressionNodeLeaf(Context);
                    paramLeaf.Run(paramExpr.Value);
                    AddCommands(paramLeaf.Result);
                }
            }

            if (ast.IsAsync)
            {
                if (target == null)
                {
                    if (isNamed)
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallMAsyncN;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                    else
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallMAsync;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                }
                else
                {
                    if (isNamed)
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallMAsyncWTargetN;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                    else
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallMAsyncWTarget;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                }
            }
            else
            {
                if (target == null)
                {
                    if (isNamed)
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallMN;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                    else
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallM;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                }
                else
                {
                    if (isNamed)
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallMWTargetN;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                    else
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallMWTarget;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                }
            }
        }
    }
}
