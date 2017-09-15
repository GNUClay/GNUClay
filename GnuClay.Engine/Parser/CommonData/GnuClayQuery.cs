using GnuClay.CommonClientTypes;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.Engine.ScriptExecutor.AST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.CommonData
{
    public enum GnuClayQueryKind
    {
        Undefined,
        SELECT,
        INSERT,
        DELETE,
        CALL,
        USER_DEFINED_FUNCTION
    }

    public class GnuClayQuery
    {
        public GnuClayQueryKind Kind = GnuClayQueryKind.Undefined;

        public SelectQuery SelectQuery = null;
        public InsertQuery InsertQuery = null;
        public ASTCodeBlock ASTCodeBlock = null;
        public UserDefinedFunction UserDefinedFunction = null;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return ToString(null);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <returns>The string representation of this instance.</returns>
        public string ToString(IReadOnlyStorageDataDictionary dataDictionary)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Query: {Kind}");
            switch (Kind)
            {
                case GnuClayQueryKind.SELECT:
                    if(dataDictionary != null && SelectQuery != null)
                    {
                        sb.AppendLine(SelectQueryDebugHelper.ConvertToString(SelectQuery, dataDictionary));
                    }
                    sb.AppendLine(SelectQuery?.ToString());
                    break;

                case GnuClayQueryKind.INSERT:
                    if (dataDictionary != null && InsertQuery != null)
                    {
                        sb.AppendLine(InsertQueryDebugHelper.ConvertToString(InsertQuery, dataDictionary));
                    }
                    sb.AppendLine(InsertQuery?.ToString());
                    break;
                case GnuClayQueryKind.DELETE:
                    if (dataDictionary != null && SelectQuery != null)
                    {
                        sb.AppendLine(SelectQueryDebugHelper.ConvertToString(SelectQuery, dataDictionary));
                    }
                    sb.AppendLine(SelectQuery?.ToString());
                    break;

                case GnuClayQueryKind.CALL:
                    sb.AppendLine(ASTCodeBlock?.ToString(dataDictionary, 4));
                    break;

                case GnuClayQueryKind.USER_DEFINED_FUNCTION:
                    sb.AppendLine(UserDefinedFunction?.ToString(dataDictionary, 4));
                    break;

                default: throw new ArgumentOutOfRangeException(nameof(Kind), Kind, null);
            }
            sb.AppendLine("End Query");
            return sb.ToString();
        }
    }
}
