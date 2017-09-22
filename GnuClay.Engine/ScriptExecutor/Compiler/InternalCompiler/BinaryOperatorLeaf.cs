using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
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
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Run ast = {ast.ToString(Context.DataDictionary, 0)}");
#endif

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

            throw new NotImplementedException();
        }

        private void ProcessPointOperator()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("ProcessPointOperator");
#endif

            var rigthKind = Right.Kind;

            switch(rigthKind)
            {
                //case ExpressionKind.CalledEntityExpression:
                //    {
                //        var leaf = new CallMemberLeaf(Context);
                //        leaf.Run(BinaryOperator);
                //        AddCommands(leaf.Result);
                //    }
                //    break;

                //case ExpressionKind.EntityExpression:
                //    {
                //        var leaf = new PropertyLeaf(Context);
                //        leaf.Run(BinaryOperator);
                //        AddCommands(leaf.Result);
                //    }
                //    break;

                default: throw new ArgumentOutOfRangeException(nameof(rigthKind), rigthKind, null);
            }
        }
    }
}
