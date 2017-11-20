using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary type="i">
    /// Provides methods for more convenient string information.
    /// </summary>
    public interface ISmartToString
    {
        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent);
    }
}
