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
    public class CallVarLeaf : BaseLeaf
    {
        public CallVarLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run(ASTCalledVarExpression ast)
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

            var isNamed = false;

            var parameters = ast.Params;

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
                        tmpCommand.OperationCode = OperationCode.CallAsyncN;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                    else
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallAsync;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                }
                else
                {
                    if (isNamed)
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallAsyncWTargetN;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                    else
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallAsyncWTarget;
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
                        tmpCommand.OperationCode = OperationCode.CallN;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                    else
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.Call;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                }
                else
                {
                    if (isNamed)
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallWTargetN;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                    else
                    {
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.CallWTarget;
                        tmpCommand.Key = (ulong)parameters.Count;
                        AddCommand(tmpCommand);
                    }
                }
            }
        }
    }
}
