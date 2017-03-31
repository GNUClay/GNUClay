using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class BaseLogicalEntity: ILogicalEntity
    {
        protected IActiveEntity ActiveEntity = null;

        public void SetEntity(IActiveEntity entity)
        {
            if(ActiveEntity == entity)
            {
                return;
            }

            ActiveEntity = entity;

            ActiveEntity.SetLogicalEntity(this);
        }

        public virtual void OnSeen(List<VisibleResultItem> items)
        {
        }
    }
}
