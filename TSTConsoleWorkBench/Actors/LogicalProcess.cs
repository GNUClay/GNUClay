using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Actors
{
    public interface ILogicalProcess<T>
    {
        T Context { get; set; }
        StartupMode StartupMode { get; }
        string Name { get; }
        List<CommandFilter> GetFilters();
        void Start(EntityAction action);
    }

    public class LogicalProcess<T>: ILogicalProcess<T>
    {
        public LogicalProcess(StartupMode startupMode, string name)
        {
            StartupMode = startupMode;
            Name = name;
        }

        public T Context { get; set; }

        public StartupMode StartupMode { get; set;}
        public string Name { get; set; }

        private List<CommandFilter> mFiltersList = null;

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

        protected EntityAction CurrentEntityAction = null;
        protected Command CurrentCommand = null;

        public void Start(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(Start)} action.Status = {action.Status}");

            CurrentCommand = action.Command;
            CurrentEntityAction = action;

            OnStart();
            Main();
            OnStop();

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
