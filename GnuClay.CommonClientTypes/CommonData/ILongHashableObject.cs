using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary>
    /// Provides methods for getting more long hashcode.
    /// </summary>
    public interface ILongHashableObject
    {
        /// <summary>
        /// Serves as the hash function that has size as ulong.
        /// </summary>
        /// <returns>Return value of the hash.</returns>
        ulong GetLongHashCode();
    }
}
