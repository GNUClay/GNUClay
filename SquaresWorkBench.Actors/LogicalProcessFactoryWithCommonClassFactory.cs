using GnuClay.CommonUtils.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.Actors
{
    public class LogicalProcessFactoryWithCommonClassFactory<T, C> : LogicalProcessFactory<T>
        where T : ILogicalProcessWithCommonClass<C>, new()
        where C : ICommonClassOfLogicalProcesses
    {
        public LogicalProcessFactoryWithCommonClassFactory(IContextOfLogicalProcesses context, C instanceOfCommonClass)
            : base(context)
        {
            mInstanceOfCommonClass = instanceOfCommonClass;
        }

        private C mInstanceOfCommonClass = default(C);

        protected override void Start(IEntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(Start)} action.Status = {action.Status}");

            var instance = new T();
            instance.InstanceOfCommonClass = mInstanceOfCommonClass;
            instance.Start(action);
        }
    }
}
