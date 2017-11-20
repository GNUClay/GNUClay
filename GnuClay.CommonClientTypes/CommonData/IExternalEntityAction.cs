using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary type="i">
    /// Represents an action in the GnuClay engine.
    /// The action equals task on C#.
    /// </summary>
    public interface IExternalEntityAction : ISmartToString
    {
        /// <summary>
        /// Gets key of the action.
        /// </summary>
        ulong Key { get; }

        /// <summary>
        /// Gets command of the action.
        /// </summary>
        IExternalCommand Command { get; }

        /// <summary>
        /// Gets initiator of the action.
        /// </summary>
        ulong Initiator { get; }
    }
}
