using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary>
    /// Represents the information for calling a function.
    /// </summary>
    public interface IExternalCommand: ISmartToString
    {
        /// <summary>
        /// Gets information about called function.
        /// </summary>
        IExternalValue Function { get; }

        /// <summary>
        /// Gets descriptor of the called function.
        /// </summary>
        ulong DescriptorOfFunction { get; }

        /// <summary>
        /// Gets the holder subject of the called function.
        /// </summary>
        IExternalValue Holder { get; }

        /// <summary>
        /// Gets the key of type of target.
        /// </summary>
        ulong TargetKey { get; }

        /// <summary>
        /// Gets the list of all params.
        /// </summary>
        List<IExternalParamInfo> Params { get; }

        /// <summary>
        /// Gets the value of the param by it key.
        /// </summary>
        /// <param name="key">The key that corresponds with name of the param.</param>
        /// <returns>The value of the param by it key.</returns>
        IExternalValue GetParamValue(ulong key);
    }
}
