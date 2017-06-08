using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public class LogicalProcessFactoriesRegistry
    {
        public LogicalProcessFactoriesRegistry(IContextOfLogicalProcesses context)
        {
            Context = context;
        }

        private IContextOfLogicalProcesses Context = null;

        public void AddFactory<T>()
            where T : ILogicalProcess, new()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("AddFactory");

            NAddFactory(new LogicalProcessFactory<T>(Context));
        }

        public void AddFactory<T, C>(C instanceOfCommonClass) 
            where T: ILogicalProcessWithCommonClass<C>, new()
            where C: ICommonClassOfLogicalProcesses
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"AddFactory typeof(T).FullName = {typeof(T).FullName}");

            NAddFactory(new LogicalProcessFactoryWithCommonClassFactory<T, C>(Context, instanceOfCommonClass));           
        }

        private void NAddFactory(ILogicalProcessFactory factory)
        {
            factory.Register();
            mProsessFactoriesList.Add(factory);
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
