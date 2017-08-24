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
        /// Begin calling current value of the stack as a function.
        /// </summary>
        BeginCall,

        /// <summary>
        /// Begin calling of the function or method.
        /// </summary>
        BeginCallMethod,

        /// <summary>
        /// Begin calling of the method of the previous entity.
        /// </summary>
        BeginCallMethodOfPrevEntity,

        /// <summary>
        /// Put current value from the stack to special register as target of function.
        /// </summary>
        SetTarget,

        /// <summary>
        /// Put param name from the stack to special register.
        /// </summary>
        SetParamName,

        /// <summary>
        /// Put param value from the stack to special register.
        /// </summary>
        SetParamVal,
       
        /// <summary>
        /// Call unary operator.
        /// </summary>
        CallUnOp,

        /// <summary>
        /// Call binary operator.
        /// </summary>
        CallBinOp,

        /// <summary>
        /// Call synchronously function or method by named params.
        /// </summary>
        Call,

        /// <summary>
        /// Call synchronously function or method by positioned params.
        /// </summary>
        CallByPos,

        /// <summary>
        /// Call asynchronously function or method by named params.
        /// </summary>
        CallAsync,

        /// <summary>
        /// Call asynchronously function or method by positioned params.
        /// </summary>
        CallAsyncByPos,

        /// <summary>
        /// Jump to line of code if current value of the stack is true.
        /// </summary>
        JumpIfTrue,

        /// <summary>
        /// Jump to line of code if current value of the stack is false.
        /// </summary>
        JumpIfFalse,

        /// <summary>
        /// Jump to line of code.
        /// </summary>
        Jump,

        /// <summary>
        /// Return from the function.
        /// </summary>
        Return,

        /// <summary>
        /// Return a value from the function.
        /// </summary>
        ReturnValue
    }
}
