using GnuClay.CommonUtils.Actors;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.Actors
{
    public interface ILogicalProcessFactory
    {
        StartupMode StartupMode { get; }
        void StartAutomatically();
        void Register();
    }

    public class LogicalProcessFactory<T> : ILogicalProcessFactory
        where T : ILogicalProcess, new()
    {
        public LogicalProcessFactory(IContextOfLogicalProcesses context)
        {
            Context = context;
        }

        private IContextOfLogicalProcesses Context = null;

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

        protected virtual void Start(IEntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(Start)} action.Status = {action.Status}");

            var instance = new T();
            instance.Context = Context;
            instance.Start(action);
        }
    }
}
