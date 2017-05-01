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
    }
}
