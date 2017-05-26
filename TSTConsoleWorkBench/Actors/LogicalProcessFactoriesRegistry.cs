using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class LogicalProcessFactoriesRegistry<C>
        where C : IContextOfLogicalProcesses
    {
        public LogicalProcessFactoriesRegistry(C context)
        {
            Context = context;
        }

        private C Context = default(C);

        public void AddFactory<T>() 
            where T: ILogicalProcess<C>, new ()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFactory typeof(T).FullName = {typeof(T).FullName}");

            var factoryInstance = new LogicalProcessFactory<T, C>(Context);
            factoryInstance.Register();
            mProsessFactoriesList.Add(factoryInstance);
        }

        private List<ILogicalProcessFactory> mProsessFactoriesList = new List<ILogicalProcessFactory>();

        public void StartAutomaticallyProcesses()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(StartAutomaticallyProcesses)}");

            var targetProcesses = mProsessFactoriesList.Where(p => p.StartupMode == StartupMode.Automatically).ToList();

            if (_ListHelper.IsEmpty(targetProcesses))
            {
                return;
            }

            foreach (var process in targetProcesses)
            {
                process.StartAutomatically();
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End {nameof(StartAutomaticallyProcesses)}");
        }
    }
}
