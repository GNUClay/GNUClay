﻿using GnuClay.CommonClientTypes;
using GnuClay.LocalHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSTConsoleWorkBench.Actors;

namespace TSTConsoleWorkBench.Actors
{
    public class TstContext: IContextOfLogicalProcesses
    {
        public TstContext()
        {
            mServerConnection = new GnuClayLocalServer();
            mEntityConnection = mServerConnection.CreateEntity();

            mCSharpTypesRegistry = new CSharpTypesRegistry(mEntityConnection);
            mCommandsDispatcher = new CommandsDispatcher<TstContext>(this);
            mEntityActionNotificator = new EntityActionNotificator<TstContext>(this);
            mLogicalProcessFactoriesRegistry = new LogicalProcessFactoriesRegistry<TstContext>(this);
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

        public ulong GetTypeKey(object value)
        {
            return mCSharpTypesRegistry.GetTypeKey(value);
        }

        public double GetTypeInheritanceRank(ulong subKey, ulong superKey)
        {
            return mEntityConnection.GetInheritanceRank(subKey, superKey);
        }

        private CommandsDispatcher<TstContext> mCommandsDispatcher = null;

        public void AddFilter(CommandFilter filter)
        {
            mCommandsDispatcher.AddFilter(filter);
        }

        protected EntityActionNotificator<TstContext> mEntityActionNotificator = null;

        public EntityAction ExecuteCommand(Command command)
        {
            var result = new EntityAction(command);

            NExecuteCommand(result);

            return result;
        }

        public EntityAction ExecuteCommand(EntityAction action)
        {
            NExecuteCommand(action);

            return action;
        }

        private async void NExecuteCommand(EntityAction action)
        {
            await Task.Run(() => {
                mEntityActionNotificator.AddEntityAction(action);

                var dispatchedResult = mCommandsDispatcher.Dipatch(action);

                NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteCommand dispatchedResult = {dispatchedResult}");

                if (!dispatchedResult)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info("ExecuteCommand !dispatchedResult No Dispatch");
                    //ActiveEntity.ExecuteCommand(actionResult);
                }
            });
        }

        protected LogicalProcessFactoriesRegistry<TstContext> mLogicalProcessFactoriesRegistry = null;

        protected void AddProcessFactory<T>()
            where T : ILogicalProcess<TstContext>, new()
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"{nameof(AddProcessFactory)} T.FullName = {typeof(T).FullName}");

            mLogicalProcessFactoriesRegistry.AddFactory<T>();
        }

        public void GoToMarket()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("GoToMarket");
        }
    }
}
