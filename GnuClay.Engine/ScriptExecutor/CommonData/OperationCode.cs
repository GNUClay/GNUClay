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
        /// No operation.
        /// </summary>
        Nop,

        /// <summary>
        /// Push constant (number, boolean or other) to the stack.
        /// </summary>
        PushConst,

        /// <summary>
        /// Push entity to the stack.
        /// </summary>
        PushEntity,

        /// <summary>
        /// Push property to the stack.
        /// </summary>
        PushProp,

        /// <summary>
        /// Push variable to the stack.
        /// </summary>
        PushVar,

        /// <summary>
        /// Begin calling of the function.
        /// </summary>
        BeginCall,

        /// <summary>
        /// Put current value from stack to special register as target of function.
        /// </summary>
        SetTarget,

        /// <summary>
        /// Put values from stack to current named parameter. 
        /// А current value of the stack will a value of the named parameter.
        /// A previous value of the stack will a name of the named parameter.
        /// </summary>
        SetParam,

        /// <summary>
        /// Call unary operator.
        /// </summary>
        CallUnOp,

        /// <summary>
        /// Call binary operator.
        /// </summary>
        CallBinOp,

        /// <summary>
        /// Call function or method by named params.
        /// </summary>
        Call,

        /// <summary>
        /// Call function or method by positioned params.
        /// </summary>
        CallByPos
    }
}
