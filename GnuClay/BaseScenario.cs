using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay
{
    public abstract class BaseScenario: LoggedObject
    {
        protected BaseScenario(ILog logger)
            : base(logger)
        {     
        }

        public abstract void Execute();
    }
}
