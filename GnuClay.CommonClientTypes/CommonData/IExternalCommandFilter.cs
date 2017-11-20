using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary type="d">
    /// Type of the handler which will be executed during the calling of the function.
    /// </summary>
    /// <param name="action">Reference to the handler.</param>
    public delegate void ExternalCommandHandler(IExternalEntityAction action);

    /// <summary type="i">
    /// Represents signature of the function.
    /// </summary>
    public interface IExternalCommandFilter: ILongHashableObject, ISmartToString
    {
        /// <summary>
        /// Gets the key of the function.
        /// </summary>
        ulong FunctionKey { get; }

        /// <summary>
        /// Gets the target of the function.
        /// </summary>
        ulong TargetKey { get; }

        /// <summary>
        /// Gets the holder of the function.
        /// </summary>
        ulong HolderKey { get; }

        /// <summary>
        /// Gets definitions of parameters of the function.
        /// </summary>
        Dictionary<ulong, IExternalCommandFilterParam> Params { get; }

        /// <summary>
        /// Gets the handler of the function.
        /// </summary>
        ExternalCommandHandler Handler { get; }
    }
}
