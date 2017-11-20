using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary type="i">
    /// Represents definition of the parameter of the function.
    /// </summary>
    public interface IExternalCommandFilterParam: ILongHashableObject, ISmartToString
    {
        /// <summary>
        /// Gets flag which allows using any type for this parameter.
        /// </summary>
        bool IsAnyType { get; }

        /// <summary>
        /// Gets the key of type of this parameters. Uses if IsAnyType = false.
        /// </summary>
        ulong TypeKey { get; }
    }
}
