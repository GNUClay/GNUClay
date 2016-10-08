using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
{
    public class UndefinedTokenException: Exception
    {
        public UndefinedTokenException(TokenKind tokenKind)
            : base($"Undefined token `{tokenKind}`")
        {
        }
    }
}
