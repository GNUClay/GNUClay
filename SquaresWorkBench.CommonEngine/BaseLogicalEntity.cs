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

            mCSharpTypesRegistry = new CSharpTypesRegistry(mEntityConnection);
            mCommandsDispatcher = new CommandsDispatcher(mEntityConnection, mCSharpTypesRegistry);
            mEntityActionNotificator = new EntityActionNotificator(mEntityConnection, mCSharpTypesRegistry);
            mLogicalProcessFactoriesRegistry = new LogicalProcessFactoriesRegistry(this);
        }

        protected CSharpTypesRegistry mCSharpTypesRegistry = null;

        private IGnuClayServerConnection mServerConnection = null;
        protected IGnuClayEntityConnection mEntityConnection = null;

        public IGnuClayEntityConnection EntityConnection
        {
            get
            {
                return mEntityConnection;
            }
        }

        public ulong GetKey(string val)
        {
            return mEntityConnection.GetKey(val);
        }

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
            lock(mVisibleItemsLockObj)
            {
                var result = new List<LogicalVisibleResultItem>();
                var resultDict = new Dictionary<string, LogicalVisibleResultItem>();

                if (_ListHelper.IsEmpty(items))
                {
                    VisibleItems = result;
                    VisibleItemsDict = resultDict;
                    return;
                }

                foreach (var scanItem in items)
                {
                    var entity = scanItem.VisibleEntity;
                    var entityId = entity.Id;
                    var entityKey = mEntityConnection.GetKey(entityId);

                    foreach (var entityClassValue in entity.Class)
                    {
                        var classKey = mEntityConnection.GetKey(entityClassValue);
                        var range = mEntityConnection.GetInheritanceRank(entityKey, classKey);

                        if(range == 0)
                        {
                            mEntityConnection.SetInheritance(entityKey, classKey, 1);
                        }
                    }

                    var item = new LogicalVisibleResultItem();
                    var logicalEntityInfo = new LogicalObjectInfo();
                    logicalEntityInfo.Key = entityKey;
                    logicalEntityInfo.Name = entityId;

                    item.VisibleEntity = logicalEntityInfo;
                    item.VisiblePoints = scanItem.VisiblePoints;

                    result.Add(item);
                    resultDict[entityId] = item;
                }

                VisibleItems = result;
                VisibleItemsDict = resultDict;
            }
        }

        private object mVisibleItemsLockObj = new object();
        private List<LogicalVisibleResultItem> mVisibleItems = new List<LogicalVisibleResultItem>();
        private Dictionary<string, LogicalVisibleResultItem> mVisibleItemsDict = new Dictionary<string, LogicalVisibleResultItem>();

        protected List<LogicalVisibleResultItem> VisibleItems
        {
            get
            {
                lock (mVisibleItemsLockObj)
                {
                    return mVisibleItems;
                }
            }

            set
            {
                lock (mVisibleItemsLockObj)
                {
                    mVisibleItems = value;
                }
            }
        }

        protected Dictionary<string, LogicalVisibleResultItem> VisibleItemsDict
        {
            get
            {
                lock (mVisibleItemsLockObj)
                {
                    return mVisibleItemsDict;
                }                
            }

            set
            {
                lock (mVisibleItemsLockObj)
                {
                    mVisibleItemsDict = value;
                }
            }
        }

        public LogicalVisibleResultItem GetVisibleResultItem(string id)
        {
            var visibleDict = VisibleItemsDict;

            if (visibleDict.ContainsKey(id))
            {
                return visibleDict[id];
            }

            return null;
        }

        public bool IsVisible(string id)
        {
            var visibleDict = VisibleItemsDict;

            if (visibleDict.ContainsKey(id))
            {
                return true;
            }

            return false;
        }

        [Obsolete]
        protected ObjectsRegistry ObjectsRegistry = new ObjectsRegistry();

        private CommandsDispatcher mCommandsDispatcher = null;
        
        public void AddFilter(ActionCommandFilter filter)
        {
            mCommandsDispatcher.AddFilter(filter);
        }

        protected EntityActionNotificator mEntityActionNotificator = null;

        public EntityAction ExecuteCommand(Command command)
        {
            var result = new EntityAction(command);

            NExecuteCommand(result, command);

            return result;
        }

        public EntityAction ExecuteCommand(EntityAction actionResult, Command command)
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

        protected LogicalProcessFactoriesRegistry mLogicalProcessFactoriesRegistry = null;

        protected void AddProcessFactory<T>() where T : BaseLogicalProcess, new()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(AddProcessFactory)} T.FullName = {typeof(T).FullName}");

            mLogicalProcessFactoriesRegistry.AddProcessFactory<T>();
        }
    }
}
