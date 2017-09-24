﻿using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Statements
{
    public class ASTReturnStatement : ASTStatement
    {
        public ASTReturnStatement()
            : base(StatementKind.Return)
        {
        }

        public ASTExpression Expression { get; set; }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var nextIndent = indent + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spacesString}Begin ReturnStatement");
            if (Expression == null)
            {
                sb.AppendLine($"{spacesString}{nameof(Expression)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}{nameof(Expression)} = ");
                sb.AppendLine(Expression.ToString(dataDictionary, nextIndent));
            }
            sb.AppendLine($"{spacesString}End ReturnStatement");
            return sb.ToString();
        }
    }
}
