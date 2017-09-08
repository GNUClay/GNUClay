using GnuClay.CommonClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Expressions
{
    public enum ExpressionKind
    {
        Undefined,
        BinaryOperator,
        ConstExpression,
        VarExpression,
        EntityExpression,
        CalledEntityExpression,
        CalledVarExpression
    }

    public abstract class ASTExpression
    {
        protected ASTExpression(ExpressionKind kind)
        {
            Kind = kind;
        }

        public ExpressionKind Kind { get; private set; } = ExpressionKind.Undefined;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return ToString(null, 0);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public virtual string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            return "ASTExpression";
        }
    }
}
