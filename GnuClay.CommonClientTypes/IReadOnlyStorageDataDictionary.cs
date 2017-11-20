using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes
{
    /// <summary type="i">
    /// Provides access to data dictionary.
    /// </summary>
    public interface IReadOnlyStorageDataDictionary
    {
        /// <summary>
        /// Get the string value which is associated with that key.
        /// </summary>
        /// <param name="key">Key of the value</param>
        /// <returns>Associated string value.</returns>
        string GetValue(ulong key);
    }
}
