using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST
{
    public class ASTCodeBlock
    {
        public List<ASTStatement> Statements { get; set; } = new List<ASTStatement>();

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
        public string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var nextIndent = indent + 4;
            var tmpSb = new StringBuilder();
            tmpSb.AppendLine($"{spacesString}Begin ASTCodeBlock");

            foreach (var statement in Statements)
            {
                tmpSb.AppendLine(statement.ToString(dataDictionary, nextIndent));
            }

            tmpSb.AppendLine($"{spacesString}End ASTCodeBlock");
            return tmpSb.ToString();
        }
    }
}
