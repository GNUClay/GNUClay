using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public enum KindOfLogicalOperator
    {
        Unknown,
        INSERT_FACT_RETURN_VALUE,
        INSERT_FACT_RETURN_THIS_FACT,
        INSERT_DISTINCT_FACT_RETURN_VALUE,
        INSERT_DISTINCT_FACT_RETURN_THIS_FACT
    }
}
