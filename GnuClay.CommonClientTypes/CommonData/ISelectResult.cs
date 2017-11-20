using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary type="i">
    /// Contains information about result of executing query.
    /// </summary>
    public interface ISelectResult
    {
        /// <summary>
        /// Gets a text of the error of executing. It is always empty if 'Success' = true.
        /// </summary>
        string ErrorText { get; }

        /// <summary>
        /// Gets flag about successful of executing query.
        /// </summary>
        bool Success { get; }

        /// <summary>
        /// Gets flag about result of searching anything by SELECT query. It is always equals false after non select query.
        /// </summary>
        bool HaveBeenFound { get; }

        /// <summary>
        /// Gets the list of tuples of found values.
        /// </summary>
        List<ISelectResultItem> Items { get; }
    }
}
