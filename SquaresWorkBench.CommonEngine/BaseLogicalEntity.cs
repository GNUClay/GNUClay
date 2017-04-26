﻿using GnuClay.CommonClientTypes;
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
        }

        protected CSharpTypesRegistry mCSharpTypesRegistry = null;

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
            lock(mVisibleItemsLockObj)
            {
                var result = new List<LogicalVisibleResultItem>();
                
                if (_ListHelper.IsEmpty(items))
                {
                    VisibleItems = result;
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
                }

                VisibleItems = result;
            }
        }

        private object mVisibleItemsLockObj = new object();
        private List<LogicalVisibleResultItem> mVisibleItems = new List<LogicalVisibleResultItem>();
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

        [Obsolete]
        protected ObjectsRegistry ObjectsRegistry = new ObjectsRegistry();

        private CommandsDispatcher mCommandsDispatcher = null;
        
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
