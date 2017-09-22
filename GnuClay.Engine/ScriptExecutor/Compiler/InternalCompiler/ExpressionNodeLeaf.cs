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
    public class ExpressionNodeLeaf : BaseLeaf
    {
        public ExpressionNodeLeaf(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void Run(ASTExpression ast)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run ast = {ast.ToString(Context.DataDictionary, 0)}");
#endif

            var kind = ast.Kind;

            switch (kind)
            {
                case ExpressionKind.BinaryOperator:
                    {
                        var leaf = new BinaryOperatorLeaf(Context);
                        leaf.Run(ast);
                        AddCommands(leaf.Result);
                    }
                    return;

                case ExpressionKind.ConstExpression:
                    {
                        var expression = ast as ASTConstExpression;
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.PushConst;
                        tmpCommand.Key = expression.TypeKey;
                        tmpCommand.Value = expression.Value;

                        AddCommand(tmpCommand);
                    }
                    return;

                case ExpressionKind.EntityExpression:
                    {
                        var expression = ast as ASTEntityExpression;
                        AddCommand(CreatePushEntityCommand(expression.TypeKey));
                    }
                    return;

                case ExpressionKind.VarExpression:
                    {
                        var expression = ast as ASTVarExpression;
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.PushVar;
                        tmpCommand.Key = expression.TypeKey;

                        AddCommand(tmpCommand);
                    }
                    return;

                case ExpressionKind.CalledVarExpression:
                    {
                        var expression = ast as ASTCalledVarExpression;
                        var leaf = new CallVarLeaf(Context);
                        leaf.Run(expression);
                        AddCommands(leaf.Result);
                    }
                    return;

                default: throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }
        }

        public void RunMember(ASTExpression ast)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"RunMember ast = {ast.ToString(Context.DataDictionary, 0)}");
#endif
            var kind = ast.Kind;

            switch (kind)
            {
                case ExpressionKind.EntityExpression:
                    {
                        var expression = ast as ASTEntityExpression;
                        var tmpCommand = new ScriptCommand();
                        tmpCommand.OperationCode = OperationCode.PushProp;
                        tmpCommand.Key = expression.TypeKey;
                        AddCommand(tmpCommand);
                    }
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(kind), kind, null);
            }    
        }
    }
}
