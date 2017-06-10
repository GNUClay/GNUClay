using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public interface ILogicalProcess 
    {
        IContextOfLogicalProcesses Context { get; set; }
        StartupMode StartupMode { get; }
        string Name { get; }
        List<CommandFilter> GetFilters();
        void Start(IEntityAction action);
    }

    public class LogicalProcess: ILogicalProcess
    {
        public LogicalProcess(LogicalProcessOptions options)
        {
            StartupMode = options.StartupMode;
            Name = options.Name;
            IsAutoCanceled = options.IsAutoCanceled;
            ExclusiveGroup = options.ExclusiveGroup;

            if(!string.IsNullOrWhiteSpace(ExclusiveGroup))
            {
                HasExclusiveGroup = true;
            }
        }

        public IContextOfLogicalProcesses Context { get; set; }
        public StartupMode StartupMode { get; private set;}
        public string Name { get; private set; }

        public bool IsAutoCanceled { get; private set; }

        private List<CommandFilter> mFiltersList = null;

        public bool HasExclusiveGroup { get; private set; }
        public string ExclusiveGroup { get; private set; } = string.Empty;

        public List<CommandFilter> GetFilters()
        {
            mFiltersList = new List<CommandFilter>();

            OnRegFilter();

            return mFiltersList;
        }

        protected virtual void OnRegFilter()
        {
        }

        protected void AddFilter(CommandFilter filter)
        {
            mFiltersList.Add(filter);
        }

        protected IEntityAction CurrentEntityAction = null;
        protected ICommand CurrentCommand = null;

        public void Start(IEntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(Start)} action.Status = {action.Status}");

            action.IsAutoCanceled = IsAutoCanceled;

            if(HasExclusiveGroup)
            {
                action.ExclusiveGroupKey = Context.GetKey(ExclusiveGroup);

                Context.SetExclusiveGroupProcess(action);
            }
            
            CurrentCommand = action.Command;
            CurrentEntityAction = action;

            Context.SetProcessAsCurrent(CurrentEntityAction);

            OnStart();
            Main();
            OnStop();

            if(CurrentEntityAction.Status == EntityActionStatus.Running)
            {
                CurrentEntityAction.Status = EntityActionStatus.Completed;
            }

            if(HasExclusiveGroup)
            {
                Context.RemoveExclusiveGroupProcess(action);
            }

            Context.RemoveProcessAsCurrent(CurrentEntityAction);

            NLog.LogManager.GetCurrentClassLogger().Info($"End {nameof(Start)} action.Status = {action.Status}");
        }

        protected virtual void OnStart()
        {
        }

        protected virtual void Main()
        {
        }

        protected virtual void OnStop()
        {
        }
    }
}
