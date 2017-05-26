using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public interface ILogicalProcessFactory
    {
        StartupMode StartupMode { get; }
        void StartAutomatically();
    }

    public class LogicalProcessFactory<T, C>: ILogicalProcessFactory 
        where T: ILogicalProcess<C>, new()
        where C: IContextOfLogicalProcesses
    {
        public LogicalProcessFactory(C context)
        {
            Context = context;
        }

        private C Context = default(C);

        private StartupMode mStartupMode = StartupMode.OnDemand;

        public StartupMode StartupMode
        {
            get
            {
                return mStartupMode;
            }
        }

        private string mName = string.Empty;

        public string Name
        {
            get
            {
                return mName;
            }
        }

        public void Register()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin Register");

            var instance = new T();
            instance.Context = Context;

            mStartupMode = instance.StartupMode;
            mName = instance.Name;

            var filters = instance.GetFilters();

            if (!_ListHelper.IsEmpty(filters))
            {
                foreach (var filter in filters)
                {
                    filter.Handler = Start;
                    filter.CommandName = mName;

                    Context.AddFilter(filter);
                }
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End Register");
        }

        public void StartAutomatically()
        {
            Task.Run(() => {
                NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(StartAutomatically)}");

                var command = new Command();
                command.Name = Name;

                var actionResult = new EntityAction(command);

                Start(actionResult);

                NLog.LogManager.GetCurrentClassLogger().Info($"End {nameof(StartAutomatically)}");
            });
        }

        private void Start(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(Start)} action.Status = {action.Status}");

            var instance = new T();
            instance.Context = Context;
            instance.Start(action);
        }
    }
}
