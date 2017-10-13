using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes.CommonData
{
    /// <summary>
    /// Kind of external value.
    /// </summary>
    public enum ExternalValueKind
    {
        /// <summary>
        /// Represents entity.
        /// </summary>
        Entity,

        /// <summary>
        /// Represents system value type.
        /// </summary>
        Value
    }

    /// <summary>
    /// Interface of value which may go beyond GnuClayEngine.
    /// </summary>
    public interface IExternalValue : ISmartToString
    {
        /// <summary>
        /// Kind of external value.
        /// </summary>
        ExternalValueKind Kind { get; }

        /// <summary>
        /// Key of the type.
        /// </summary>
        ulong TypeKey { get; }

        /// <summary>
        /// Gets the system value which represents on C#.
        /// </summary>
        object Value { get; }
    }
}
