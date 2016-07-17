using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ICG
{
    /// <summary>
    /// Represents quantification in name
    /// </summary>
    public enum QuantificationInfo
    {
        /// <summary>
        /// None quantification.
        /// </summary>
        None,

        /// <summary>
        /// Existential quantification (∃).
        /// </summary>
        Existential,

        /// <summary>
        /// Universal quantification (∀).
        /// </summary>
        Universal
    }
}
