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
        /// Remove all elements from the stack.
        /// </summary>
        ClearStack,

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
        /// Push system variable to the stack.
        /// </summary>
        PushSystemVar,

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
