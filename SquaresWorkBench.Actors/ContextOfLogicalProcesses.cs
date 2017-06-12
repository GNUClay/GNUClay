using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.Actors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.Actors
{
    public class ContextOfLogicalProcesses : IContextOfLogicalProcesses
    {
        public ContextOfLogicalProcesses(IGnuClayEntityConnection entityConnection)
        {
            mEntityConnection = entityConnection;

            mCSharpTypesRegistry = new CSharpTypesRegistry(mEntityConnection);
            mCommandsDispatcher = new CommandsDispatcher(this);
            mEntityActionNotificator = new EntityActionNotificator(this);
            mLogicalProcessFactoriesRegistry = new LogicalProcessFactoriesRegistry(this);
        }

        protected IGnuClayEntityConnection mEntityConnection = null;
        protected CSharpTypesRegistry mCSharpTypesRegistry = null;
        private CommandsDispatcher mCommandsDispatcher = null;
        private Blackboard mBlackboard = new Blackboard();
        private ExclusiveGroupProcessesManager mLogicalProcessesManager = new ExclusiveGroupProcessesManager();
        private CurrentEntityActionsManager mCurrentEntityActionsManager = new CurrentEntityActionsManager();
        protected EntityActionNotificator mEntityActionNotificator = null;
        protected LogicalProcessFactoriesRegistry mLogicalProcessFactoriesRegistry = null;

        public void AddFilter(CommandFilter filter)
        {
            mCommandsDispatcher.AddFilter(filter);
        }

        public ulong GetKey(string val)
        {
            return mEntityConnection.GetKey(val);
        }

        public ulong GetTypeKey(object value)
        {
            return mCSharpTypesRegistry.GetTypeKey(value);
        }

        public double GetTypeInheritanceRank(ulong subKey, ulong superKey)
        {
            return mEntityConnection.GetInheritanceRank(subKey, superKey);
        }

        public Blackboard Blackboard
        {
            get
            {
                return mBlackboard;
            }
        }

        public IEntityAction ExecuteCommand(ICommand command)
        {
            return ExecuteCommand(command, null);
        }

        public IEntityAction ExecuteCommand(ICommand command, IEntityAction initiator)
        {
            var result = new EntityAction(command);
            result.Name = Guid.NewGuid().ToString("D");
            result.NameKey = mEntityConnection.GetKey(result.Name);

            if (initiator != null)
            {
                result.Initiator = initiator;
            }

            NExecuteCommand(result);

            return result;
        }

        public IEntityAction ExecuteCommand(IEntityAction action)
        {
            NExecuteCommand(action);

            return action;
        }

        private async void NExecuteCommand(IEntityAction action)
        {
            await Task.Run(() => {
                try
                {
                    mEntityActionNotificator.AddEntityAction(action);

                    var dispatchedResult = mCommandsDispatcher.Dipatch(action);

                    NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteCommand dispatchedResult = {dispatchedResult}");

                    if (!dispatchedResult)
                    {
                        Task.Run(() => {
                            mOnFiledDispatchOfCommandHandler?.Invoke(action);
                        });
                    }
                }
                catch (Exception e)
                {
                    action.Exception = e;
                    action.Status = EntityActionStatus.Faulted;
                }
            });
        }

        public void SetExclusiveGroupProcess(IEntityAction action)
        {
            mLogicalProcessesManager.SetExclusiveGroupProcess(action);
        }

        public void RemoveExclusiveGroupProcess(IEntityAction action)
        {
            mLogicalProcessesManager.RemoveExclusiveGroupProcess(action);
        }

        public void SetProcessAsCurrent(IEntityAction action)
        {
            mCurrentEntityActionsManager.SetProcessAsCurrent(action);
        }

        public void RemoveProcessAsCurrent(IEntityAction action)
        {
            mCurrentEntityActionsManager.RemoveProcessAsCurrent(action);
        }

        private OnFiledDispatchOfCommand mOnFiledDispatchOfCommandHandler = null;

        public void SetFiledDispatchOfCommandHandler(OnFiledDispatchOfCommand handler)
        {
            mOnFiledDispatchOfCommandHandler = handler;
        }
    }
}
