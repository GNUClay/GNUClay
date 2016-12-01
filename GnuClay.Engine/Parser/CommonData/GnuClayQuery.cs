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
        CALL
    }

    public class GnuClayQuery
    {
        public GnuClayQueryKind Kind = GnuClayQueryKind.Undefined;

        public SelectQuery SelectQuery = null;
        public InsertQuery InsertQuery = null;
        public ASTCodeBlock ASTCodeBlock = null;

        public override string ToString()
        {
            return $"Query: {Kind}";
        }
    }
}
