using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class PropertiesEngine : BaseGnuClayEngineComponent
    {
        public PropertiesEngine(GnuClayEngineComponentContext context)
            : base(context)
        {  
        }

        private CommonValuesFactory mCommonValuesFactory = null;

        private string mPropertyActionTypeName = "PropertyAction";
        private ulong mPropertyActionTypeKey = 0;

        public override void FirstInit()
        {
            Context.InternalBusEngine.OnInvalidateCache += () =>
            {
                Task.Run(() => {
                    InvalidateCache();
                });
            };

            mCommonValuesFactory = Context.CommonValuesFactory;

            mPropertiesFiltersStorage = new PropertiesFiltersStorage(Context);

            var universalTypeKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            mPropertyActionTypeKey = Context.DataDictionary.GetKey(mPropertyActionTypeName);
            Context.InheritanceEngine.SetInheritance(mPropertyActionTypeKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);

        }

        private object mLockObj = new object();

        private PropertiesFiltersStorage mPropertiesFiltersStorage = null;
       
        public ulong AddFilter(PropertyFilter filter)
        {
            lock(mLockObj)
            {
                var descriptor = mPropertiesFiltersStorage.AddFilter(filter);
                InvalidateCache();
                return descriptor;
            }
        }

        public void RemoveFilter(ulong descriptor)
        {
            lock (mLockObj)
            {
                mPropertiesFiltersStorage.RemoveFilter(descriptor);
                InvalidateCache();
            }
        }

        public ResultOfCalling CallSetProperty(IValue holder, ulong propertyKey, IValue value)
        {
            lock(mLockObj)
            {
                var command = CreateSetCommand(holder, propertyKey, value);
                var propertyAction = CreatePropertyAction(command);

                if(TryCallByCache(propertyAction, command))
                {
                    return CreateSetResultOfCalling(propertyAction);
                }

                if (holder.Kind == KindOfValue.Logical)
                {
                    return CallSetLogicalHolder(propertyAction);
                }

                var tmpList = mPropertiesFiltersStorage.FindExecutors(command);

                if(tmpList.Count == 0)
                {
                    if(holder.Kind == KindOfValue.Value)
                    {
                        return CallSetLogicalHolder(propertyAction);
                    }

                    return ReturnUncaughtReferenceError(propertyAction);
                }

                var targetExecutor = tmpList.First();
                return CallSystemProperty(holder, targetExecutor.SetMethod, propertyAction);
            }
        }

        private ResultOfCalling CallSetLogicalHolder(PropertyAction action)
        {
            action.State = EntityActionState.Running;
            action.Command.Holder.ExecuteSetLogicalProperty(action);

            if (action.State == EntityActionState.Running)
            {
                action.State = EntityActionState.Completed;
            }

            return CreateSetResultOfCalling(action);
        }

        public ResultOfCalling CallGetProperty(IValue holder, ulong propertyKey)
        {
            lock (mLockObj)
            {
                var command = CreateGetCommand(holder, propertyKey);
                var propertyAction = CreatePropertyAction(command);

                if (TryCallByCache(propertyAction, command))
                {
                    return CreateGetResultOfCalling(propertyAction);
                }

                if (holder.Kind == KindOfValue.Logical)
                {
                    return CallGetLogicalHolder(propertyAction);
                }

                var tmpList = mPropertiesFiltersStorage.FindExecutors(command);

                if (tmpList.Count == 0)
                {
                    if(holder.Kind == KindOfValue.Value)
                    {
                        return CallGetLogicalHolder(propertyAction);
                    }

                    return ReturnUncaughtReferenceError(propertyAction);
                }

                var targetExecutor = tmpList.First();
                return CallSystemProperty(holder, targetExecutor.GetMethod, propertyAction);
            }
        }

        private ResultOfCalling CallGetLogicalHolder(PropertyAction action)
        {
            action.State = EntityActionState.Running;
            action.Command.Holder.ExecuteGetLogicalProperty(action);

            if (action.State == EntityActionState.Running)
            {
                action.State = EntityActionState.Completed;
            }

            return CreateGetResultOfCalling(action);
        }

        private ResultOfCalling CallSystemProperty(IValue holder, MethodInfo method, PropertyAction propertyAction)
        {
            var params_ = new object[1] { propertyAction };
            propertyAction.State = EntityActionState.Running;
            method.Invoke(holder, params_);

            if (propertyAction.State == EntityActionState.Running)
            {
                propertyAction.State = EntityActionState.Completed;
            }

            if (propertyAction.Command.IsGet)
            {
                return CreateGetResultOfCalling(propertyAction);
            }

            return CreateSetResultOfCalling(propertyAction);
        }

        private PropertyCommand CreateSetCommand(IValue holder, ulong propertyKey, IValue value)
        {
            var command = new PropertyCommand();
            command.IsGet = false;
            command.Holder = holder;
            command.PropertyKey = propertyKey;
            command.Value = value;
            return command;
        }

        private PropertyCommand CreateGetCommand(IValue holder, ulong propertyKey)
        {
            var command = new PropertyCommand();
            command.IsGet = true;
            command.Holder = holder;
            command.PropertyKey = propertyKey;
            return command;
        }

        private PropertyAction CreatePropertyAction(PropertyCommand command)
        {
            var name = Guid.NewGuid().ToString("D");
            var key = Context.DataDictionary.GetKey(name);
            var propertyAction = new PropertyAction(name, key, command, mPropertyActionTypeKey);
            return propertyAction;
        }

        private ResultOfCalling CreateSetResultOfCalling(PropertyAction propertyAction)
        {
            var result = new ResultOfCalling();

            if (propertyAction.State == EntityActionState.Completed)
            {
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Error = propertyAction.Error;
            }

            return result;
        }

        private ResultOfCalling CreateGetResultOfCalling(PropertyAction propertyAction)
        {
            var result = new ResultOfCalling();

            if (propertyAction.State == EntityActionState.Completed)
            {
                result.Success = true;

                if (propertyAction.Result == null)
                {
                    propertyAction.Result = mCommonValuesFactory.UndefinedValue();
                }

                result.Result = propertyAction.Result;
            }
            else
            {
                result.Success = false;
                result.Error = propertyAction.Error;
            }

            return result;
        }

        private ResultOfCalling ReturnUncaughtReferenceError(PropertyAction propertyAction)
        {
            propertyAction.State = EntityActionState.Faulted;
            propertyAction.Error = Context.ErrorsFactory.CreateUncaughtReferenceError();

            if(propertyAction.Command.IsGet)
            {
                return CreateGetResultOfCalling(propertyAction);
            }

            return CreateSetResultOfCalling(propertyAction);
        }

        private bool TryCallByCache(PropertyAction propertyAction, PropertyCommand command)
        {
            var commnadHashCode = command.

            if (mCommandIsLogicalCacheDict.ContainsKey())
            {

            }
        }

        private Dictionary<ulong, PropertyFilter> mCommandFiltersCacheDict = new Dictionary<ulong, PropertyFilter>();
        private Dictionary<ulong, bool> mCommandIsLogicalCacheDict = new Dictionary<ulong, bool>();

        private void InvalidateCache()
        {
            mCommandFiltersCacheDict.Clear();
            mCommandIsLogicalCacheDict.Clear();
        }
    }
}
