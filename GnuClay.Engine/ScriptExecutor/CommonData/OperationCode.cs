using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    /// <summary>
    /// Defines kind of operation in command.
    /// </summary>
    public enum OperationCode
    {
        /// <summary>
        /// No operation
        /// </summary>
        Nop,
        PushConst,
        /// <summary>
        /// Call binary operator
        /// </summary>
        CallBinOp
    }
}
