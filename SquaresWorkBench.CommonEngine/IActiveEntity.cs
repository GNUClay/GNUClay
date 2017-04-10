using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public interface IActiveEntity
    {
        EntityAction ExecuteCommand(Command command);
        void SetLogicalEntity(ILogicalEntity entity);
        void DumpCoords();
    }
}
