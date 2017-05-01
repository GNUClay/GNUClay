using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine.TemporaryLogical
{
    public class LogicalProcessFactory<T>: BaseLogicalProcessFactory where T: BaseLogicalProcess, new ()
    {
        public LogicalProcessFactory(BaseLogicalEntity logicalEntity)
            : base(logicalEntity)
        {
        }

        public override void Register()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(Register)}");

            var instance = new T();
            instance.LogicalEntity = LogicalEntity;

            NLog.LogManager.GetCurrentClassLogger().Info($"End {nameof(Register)}");
        }
    }
}
