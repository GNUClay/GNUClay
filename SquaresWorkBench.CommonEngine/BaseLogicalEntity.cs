using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class BaseLogicalEntity: ILogicalEntity
    {
        protected IActiveEntity ActiveEntity = null;

        public void SetEntity(IActiveEntity entity)
        {
            if(ActiveEntity == entity)
            {
                return;
            }

            ActiveEntity = entity;

            ActiveEntity.SetLogicalEntity(this);
        }

        public virtual void OnSeen(List<VisibleResultItem> items)
        {
        }

        private CommandsDispatcher mCommandsDispatcher = new CommandsDispatcher();

        protected void AddFilter(ActionCommandFilter filter)
        {
            mCommandsDispatcher.AddFilter(filter);
        }

        protected EntityAction ExecuteCommand(Command command)
        {
            var result = new EntityAction(command);

            NExecuteCommand(result, command);

            return result;
        }

        protected EntityAction ExecuteCommand(EntityAction actionResult, Command command)
        {
            NExecuteCommand(actionResult, command);

            return actionResult;
        }

        private void NExecuteCommand(EntityAction actionResult, Command command)
        {
            var task = new Task(() => {
                var dispatchedResult = mCommandsDispatcher.Dipatch(actionResult);

                NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteCommand dispatchedResult = {dispatchedResult}");

                if (!dispatchedResult)
                {
                    ActiveEntity.ExecuteCommand(actionResult, command);
                }
            });

            task.Start();
        }
    }
}
