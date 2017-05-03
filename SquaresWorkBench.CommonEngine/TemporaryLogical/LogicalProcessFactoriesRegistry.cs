using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine.TemporaryLogical
{
    public class LogicalProcessFactoriesRegistry
    {
        public LogicalProcessFactoriesRegistry(BaseLogicalEntity logicalEntity)
        {
            LogicalEntity = logicalEntity;
        }

        protected BaseLogicalEntity LogicalEntity = null;

        public void AddProcessFactory<T>() where T : BaseLogicalProcess, new()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(AddProcessFactory)} T.FullName = {typeof(T).FullName}");

            var factoryInstance = new LogicalProcessFactory<T>(LogicalEntity);
            factoryInstance.Register();
            mProsessFactoriesList.Add(factoryInstance);
        }

        private List<BaseLogicalProcessFactory> mProsessFactoriesList = new List<BaseLogicalProcessFactory>();

        public void StartAutomaticallyProcesses()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(StartAutomaticallyProcesses)}");

            var targetProcesses = mProsessFactoriesList.Where(p => p.StartupMode == StartupMode.Automatically).ToList();

            if (_ListHelper.IsEmpty(targetProcesses))
            {
                return;
            }

            foreach(var process in targetProcesses)
            {
                process.StartAutomatically();
            }            

            NLog.LogManager.GetCurrentClassLogger().Info($"End {nameof(StartAutomaticallyProcesses)}");
        }
    }
}
