using GnuClay.CommonUtils.TypeHelpers;
using SquaresWorkBench.CommonEngine.TemporaryLogical;
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

        public void OnSeen(List<VisibleResultItem> items)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("OnSeen");

            RegObjects(items);

            lock(mVisibleItemsLockObj)
            {
                mVisibleItems = items;
            }
        }

        private object mVisibleItemsLockObj = new object();
        private List<VisibleResultItem> mVisibleItems = new List<VisibleResultItem>();

        protected List<VisibleResultItem> GetVisibleItems()
        {
            lock (mVisibleItemsLockObj)
            {
                return mVisibleItems;
            }
        }

        protected ObjectsRegistry ObjectsRegistry = new ObjectsRegistry();

        protected void RegObjects(List<VisibleResultItem> items)
        {
            if (_ListHelper.IsEmpty(items))
            {
                return;
            }

            foreach (var scanItem in items)
            {
                var entity = scanItem.VisibleEntity;

                ObjectsRegistry.RegObject(entity.Id, entity.Class);
            }
        }

        private CommandsDispatcher mCommandsDispatcher = new CommandsDispatcher();
        
        protected void AddFilter(ActionCommandFilter filter)
        {
            mCommandsDispatcher.AddFilter(filter);
        }

        private EntityActionNotificator mEntityActionNotificator = new EntityActionNotificator();

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

        private async void NExecuteCommand(EntityAction actionResult, Command command)
        {
            await Task.Run(() => {
                mEntityActionNotificator.AddEntityAction(actionResult);

                var dispatchedResult = mCommandsDispatcher.Dipatch(actionResult);

                NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteCommand dispatchedResult = {dispatchedResult}");

                if (!dispatchedResult)
                {
                    ActiveEntity.ExecuteCommand(actionResult, command);
                }
            });
        }
    }
}
