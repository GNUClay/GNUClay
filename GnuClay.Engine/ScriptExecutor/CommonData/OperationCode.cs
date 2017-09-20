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
        [Obsolete]
        OldBeginCall,

        /// <summary>
        /// Begin calling of the function or method.
        /// </summary>
        [Obsolete]
        OldBeginCallMethod,

        /// <summary>
        /// Begin calling of the method of the previous entity.
        /// </summary>
        [Obsolete]
        OldBeginCallMethodOfPrevEntity,

        /// <summary>
        /// Put current value from the stack to special register as target of function.
        /// </summary>
        [Obsolete]
        OldSetTarget,

        /// <summary>
        /// Put param name from the stack to special register.
        /// </summary>
        [Obsolete]
        OldSetParamName,

        /// <summary>
        /// Put param value from the stack to special register.
        /// </summary>
        [Obsolete]
        OldSetParamVal,
       
        /// <summary>
        /// Call unary operator.
        /// </summary>
        CallUnOp,

        /// <summary>
        /// Call binary operator.
        /// </summary>
        CallBinOp,

        /// <summary>
        /// Call variable with target by named parameters.
        /// </summary>
        CallWTargetN,

        /// <summary>
        /// Call variable with target by positional parameters.
        /// </summary>
        CallWTarget,

        /// <summary>
        /// Call variable without target by named parameters.
        /// </summary>
        CallN,

        /// <summary>
        /// Call variable without target by positional parameters.
        /// </summary>
        Call,

        /// <summary>
        /// Call async variable with target by named parameters.
        /// </summary>
        CallAsyncWTargetN,

        /// <summary>
        /// Call async variable with target by positional parameters.
        /// </summary>
        CallAsyncWTarget,

        /// <summary>
        /// Call async variable without target by named parameters.
        /// </summary>
        CallAsyncN,

        /// <summary>
        /// Call async variable without target by positional parameters.
        /// </summary>
        CallAsync,

        /// <summary>
        /// Call member with target by named parameters.
        /// </summary>
        CallMWTargetN,

        /// <summary>
        /// Call member with target by positional parameters.
        /// </summary>
        CallMWTarget,

        /// <summary>
        /// Call member without target by named parameters.
        /// </summary>
        CallMN,

        /// <summary>
        /// Call member without target by positional parameters.
        /// </summary>
        CallM,

        /// <summary>
        /// Call async member with target by named parameters.
        /// </summary>
        CallMAsyncWTargetN,

        /// <summary>
        /// Call async member with target by positional parameters.
        /// </summary>
        CallMAsyncWTarget,

        /// <summary>
        /// Call async member without target by named parameters.
        /// </summary>
        CallMAsyncN,

        /// <summary>
        /// Call async member without target by positional parameters.
        /// </summary>
        CallMAsync,

        /// <summary>
        /// Call synchronously function or method by named params.
        /// </summary>
        [Obsolete]
        OldCall,

        /// <summary>
        /// Call synchronously function or method by positioned params.
        /// </summary>
        [Obsolete]
        OldCallByPos,

        /// <summary>
        /// Call asynchronously function or method by named params.
        /// </summary>
        [Obsolete]
        OldCallAsync,

        /// <summary>
        /// Call asynchronously function or method by positioned params.
        /// </summary>
        [Obsolete]
        OldCallAsyncByPos,

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
