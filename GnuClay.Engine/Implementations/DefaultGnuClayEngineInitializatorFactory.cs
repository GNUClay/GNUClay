using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Implementations
{
    public class DefaultGnuClayEngineInitializatorFactory : IGnuClayEngineInitializatorFactory
    {
        public IGnuClayEngineInitializator Create(IGnuClayEngineContext context)
        {
            return new DefaultGnuClayEngineInitializator(context);
        }
    }
}
