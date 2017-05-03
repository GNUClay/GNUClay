using GnuClay.CommonUtils.TypeHelpers;
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

            mStartupMode = instance.StartupMode;
            mName = instance.Name;

            var filters = instance.GetFilters();

            if(!_ListHelper.IsEmpty(filters))
            {
                foreach(var filter in filters)
                {
                    throw new NotImplementedException();
                }
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End {nameof(Register)}");
        }
    }
}
