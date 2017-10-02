using GnuClay.CommonClientTypes.CommonData;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.ExternalData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.RemoteFunctions
{
    public class RemoteFunctionsHandler
    {
        public RemoteFunctionsHandler(IExternalCommandFilter filter, GnuClayEngineComponentContext mainContext, RemoteFunctionsEngine parent)
        {
            mMainContext = mainContext;

            mFilter = new CommandFilter(filter);
            mFilter.Handler = Handler;

            mParent = parent;
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private CommandFilter mFilter = null;
        private RemoteFunctionsEngine mParent = null;
        private ulong mDescriptor = 0;

        private void Handler(EntityAction action)
        {
            var tmpTaskList = new List<Task>();

            foreach (var item in mDict)
            {
                tmpTaskList.Add(Task.Run(() => {
                    var externalAction = CreateExternalEntityAction(action);

                    item.Value.Handler(externalAction);
                }));
            }

            Task.WaitAll(tmpTaskList.ToArray());

            action.State = EntityActionState.Completed;
        }

        private IExternalEntityAction CreateExternalEntityAction(EntityAction action)
        {
            var initCommand = action.Command;

            var result = new ExternalEntityAction();
            result.Key = action.Key;
            result.Initiator = action.Initiator;

            var command = new ExternalCommand();
            result.Command = command;
            command.Function = initCommand.Function.ToExternalValue();
            command.DescriptorOfFunction = mDescriptor;
            command.Holder = initCommand.Holder.ToExternalValue();
            command.TargetKey = initCommand.TargetKey;

            var _params = new List<IExternalParamInfo>();

            command.Params = _params;

            foreach (var initParam in initCommand.NamedParams)
            {
                var paramItem = new ExternalParamInfo();
                paramItem.ParamName = initParam.ParamName.ToExternalValue();
                paramItem.ParamValue = initParam.ParamValue.ToExternalValue();
                _params.Add(paramItem);
            }

            command.NamedParamsDict = _params.ToDictionary(p => p.ParamName.TypeKey, p => p.ParamValue);
            return result;
        }

        public ulong AddFilter(IExternalCommandFilter filter)
        {
            if (mDict.Count == 0)
            {
                mDescriptor = mMainContext.FunctionsEngine.AddFilter(mFilter);
            }

            var descriptorName = Guid.NewGuid().ToString("D");
            var descriptorKey = mMainContext.DataDictionary.GetKey(descriptorName);

            mDict[descriptorKey] = filter;

            mParent.OnAddFilter(descriptorKey, this);

            return descriptorKey;
        }

        public void RemoveFilter(ulong descriptor)
        {
            if (mDict.ContainsKey(descriptor))
            {
                mDict.Remove(descriptor);

                if (mDict.Count == 0)
                {
                    mMainContext.FunctionsEngine.RemoveFilter(mDescriptor);
                }
            }
        }

        public Dictionary<ulong, IExternalCommandFilter> mDict = new Dictionary<ulong, IExternalCommandFilter>();
    }

    public class RemoteFunctionsEngine : BaseGnuClayEngineComponent
    {
        public RemoteFunctionsEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private object mLockObj = new object();

        public ulong AddFilter(IExternalCommandFilter filter)
        {
            lock (mLockObj)
            {
                var filterHashCode = filter.GetLongHashCode();

                RemoteFunctionsHandler targetStorage = null;

                if (mDict.ContainsKey(filterHashCode))
                {
                    targetStorage = mDict[filterHashCode];
                }
                else
                {
                    targetStorage = new RemoteFunctionsHandler(filter, Context, this);
                    mDict[filterHashCode] = targetStorage;
                }

                return targetStorage.AddFilter(filter);
            }
        }

        public void OnAddFilter(ulong descriptor, RemoteFunctionsHandler handler)
        {
            mDescriptorsDict[descriptor] = handler;
        }

        public void RemoveFilter(ulong descriptor)
        {
            lock (mLockObj)
            {
                if (mDescriptorsDict.ContainsKey(descriptor))
                {
                    var handler = mDescriptorsDict[descriptor];
                    handler.RemoveFilter(descriptor);
                    mDescriptorsDict.Remove(descriptor);
                }
            }
        }

        private Dictionary<ulong, RemoteFunctionsHandler> mDict = new Dictionary<ulong, RemoteFunctionsHandler>();
        private Dictionary<ulong, RemoteFunctionsHandler> mDescriptorsDict = new Dictionary<ulong, RemoteFunctionsHandler>();
    }
}
