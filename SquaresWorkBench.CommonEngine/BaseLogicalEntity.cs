using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.LocalHost;
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
        public BaseLogicalEntity()
        {
            mServerConnection = new GnuClayLocalServer();
            mEntityConnection = mServerConnection.CreateEntity();
        }

        private IGnuClayServerConnection mServerConnection = null;
        protected IGnuClayEntityConnection mEntityConnection = null;

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

            //RegObjects(items);

            lock(mVisibleItemsLockObj)
            {
                mVisibleItems = new List<LogicalVisibleResultItem>();

                if (_ListHelper.IsEmpty(items))
                {
                    return;
                }

                NLog.LogManager.GetCurrentClassLogger().Info("End OnSeen. Not Implemented Yet!!");
            }
        }

        private object mVisibleItemsLockObj = new object();
        private List<LogicalVisibleResultItem> mVisibleItems = new List<LogicalVisibleResultItem>();

        protected List<LogicalVisibleResultItem> GetVisibleItems()
        {
            lock (mVisibleItemsLockObj)
            {
                return mVisibleItems;
            }
        }

        protected ObjectsRegistry ObjectsRegistry = new ObjectsRegistry();

        /*protected void RegObjects(List<VisibleResultItem> items)
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
        }*/

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
