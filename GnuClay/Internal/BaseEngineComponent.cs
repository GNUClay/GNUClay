using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Internal
{
    /// <summary>
    /// Represents a base component of the engine. 
    /// </summary>
    public abstract class BaseEngineComponent
    {
        /// <summary>
        /// Construct an instance of the class.
        /// </summary>
        /// <param name="context">Context of the engine.</param>
        protected BaseEngineComponent(CommonContext context)
        {
            Context = context;
            context.AddComponent(this);
        }

        protected readonly CommonContext Context;
    }
}
