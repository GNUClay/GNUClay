using GnuClay.CommonClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Statements
{
    public enum StatementKind
    {
        Undefined,
        Expression
    }

    public abstract class ASTStatement
    {
        protected ASTStatement(StatementKind kind)
        {
            Kind = kind;
        }

        public StatementKind Kind { get; private set; } = StatementKind.Undefined;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public virtual string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            return "ASTStatement";
        }
    }
}
