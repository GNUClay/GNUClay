using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public interface ILogicalEntity
    {
        void SetEntity(IActiveEntity entity);
        void OnSeen(List<VisibleResultItem> items);
    }
}
