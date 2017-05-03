using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine.TemporaryLogical
{
    public abstract class BaseLogicalProcessFactory
    {
        protected BaseLogicalProcessFactory(BaseLogicalEntity logicalEntity)
        {
            LogicalEntity = logicalEntity;
        }

        protected BaseLogicalEntity LogicalEntity = null;

        public abstract void Register();

        protected StartupMode mStartupMode = StartupMode.OnDemand;

        public StartupMode StartupMode
        {
            get
            {
                return mStartupMode;
            }
        }

        protected string mName = string.Empty;

        public string Name
        {
            get
            {
                return mName;
            }
        }

        public abstract void StartAutomatically();
    }
}
