using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers
{
    public class UndefinedSymbolException: Exception
    {
        public UndefinedSymbolException(char symbol)
            : base($"Undefined symbol `{symbol}`")
        {
        }
    }
}
