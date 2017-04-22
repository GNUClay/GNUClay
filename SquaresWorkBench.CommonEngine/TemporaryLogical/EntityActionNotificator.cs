using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine.TemporaryLogical
{
    public class EntityActionNotificator
    {


        public void AddEntityAction(EntityAction entityAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("AddEntityAction");
        }
    }
}
