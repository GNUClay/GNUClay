using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine.TemporaryLogical
{
    public enum StartupMode
    {
        Automatically,
        OnDemand
    }

    public abstract class BaseLogicalProcess
    {
        protected BaseLogicalProcess(StartupMode startupMode, string name)
        {
            mStartupMode = startupMode;
            mName = name;

            NLog.LogManager.GetCurrentClassLogger().Info($"constructor() {nameof(mStartupMode)} = {mStartupMode} mName = {mName}");
        }

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

        public BaseLogicalEntity LogicalEntity { get; set; }

        protected bool EnableLoging
        {
            get
            {
                if(LogicalEntity == null)
                {
                    return false;
                }

                return LogicalEntity.EnableLoging;
            }
        }

        private List<ActionCommandFilter> mFiltersList = null;

        public List<ActionCommandFilter> GetFilters()
        {
            mFiltersList = new List<ActionCommandFilter>();

            OnRegFilter();

            return mFiltersList;
        }

        protected virtual void OnRegFilter()
        {
        }

        protected void AddFilter(ActionCommandFilter filter)
        {
            mFiltersList.Add(filter);
        }

        protected EntityAction CurrentEntityAction = null;
        protected Command CurrentCommand = null;

        public void Start(EntityAction actionResult, Command command)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(Start)} actionResult.Status = {actionResult.Status}  command = {command}");

            CurrentCommand = command;
            CurrentEntityAction = actionResult;

            OnStart();
            Main();
            OnStop();

            NLog.LogManager.GetCurrentClassLogger().Info($"End {nameof(Start)} actionResult.Status = {actionResult.Status}  command = {command}");
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
