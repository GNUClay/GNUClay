using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary>
    /// The tuple of found values.
    /// </summary>
    public interface ISelectResultItem
    {
        /// <summary>
        /// Gets the key to used fact.
        /// </summary>
        ulong Key { get; }

        /// <summary>
        /// Gets the list of values of the variables for the tuple in the query.
        /// </summary>
        List<IVarResultItem> Params { get; }
    }
}
