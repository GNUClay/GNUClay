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
    public class CallMemberLeaf : BaseLeaf
    {
        public CallMemberLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run(ASTBinaryOperator ast)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run ast = {ast.ToString(Context.DataDictionary, 0)}");
#endif

            var right = ast.Right as ASTCalledEntityExpression;

            var isNamed = false;

            var leftKind = ast.Left.Kind;

            switch (leftKind)
            {
                case ExpressionKind.EntityExpression:
                    {
                        var subjectLeaf = new ExpressionNodeLeaf(Context);
                        subjectLeaf.Run(ast.Left);
                        AddCommands(subjectLeaf.Result);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(leftKind), leftKind, null);
            }

#if DEBUG
            ShowCommands();
#endif

            var functionKey = right.TypeKey;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run functionKey = {functionKey}");
#endif

            AddCommand(CreatePushEntityCommand(functionKey));

            var target = right.Target;

            if (target != null)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Run target = {target.ToString(Context.DataDictionary, 0)}");
#endif

                var targetLeaf = new ExpressionNodeLeaf(Context);
                targetLeaf.Run(target);
                AddCommands(targetLeaf.Result);

#if DEBUG
                ShowCommands();
#endif
            }

            var parameters = right.Params;

            foreach (var parameter in parameters)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Run parameter = {parameter.ToString(Context.DataDictionary, 0)}");
#endif

                var paramExpr = parameter as ASTParamExpression;

                isNamed = paramExpr.IsNamed;

                if(isNamed)
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

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run isNamed = {isNamed}");
            ShowCommands();
#endif

            if(right.IsAsync)
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
                if(target == null)
                {
                    if(isNamed)
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

#if DEBUG
            ShowCommands();
#endif
        }
    }
}
