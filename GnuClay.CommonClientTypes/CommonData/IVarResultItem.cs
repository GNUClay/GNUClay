using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary type="i">
    /// Represents the value of the variable for the tuple in the query.
    /// </summary>
    public interface IVarResultItem
    {
        /// <summary>
        /// Gets the key of the variable.
        /// </summary>
        ulong ParamKey { get; }

        /// <summary>
        /// Gets the key of type of the value.
        /// </summary>
        ulong EntityKey { get; }

        /// <summary>
        /// Gets the kind of node in the result.
        /// </summary>
        ExpressionNodeKind Kind { get; }

        /// <summary>
        /// Gets the system value which represents on C#.
        /// </summary>
        object Value { get; }
    }
}
