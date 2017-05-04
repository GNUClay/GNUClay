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
                    filter.Handler = Start;
                    filter.CommandName = mName;

                    LogicalEntity.AddFilter(filter);
                }
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End {nameof(Register)}");
        }

        public override void StartAutomatically()
        {
            Task.Run(() => {
                NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(StartAutomatically)}");

                var command = new Command();
                command.Name = Name;

                var actionResult = new EntityAction(command);

                Start(actionResult, command);

                NLog.LogManager.GetCurrentClassLogger().Info($"End {nameof(StartAutomatically)}");
            });
        }

        private void Start(EntityAction actionResult, Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(Start)} actionResult.Status = {actionResult.Status}  command = {command}");

            /*while(true)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(Start)} actionResult.Status = {actionResult.Status}  command = {command} !!!!!!!!!!!!!");
            }*/
        }
    }
}
