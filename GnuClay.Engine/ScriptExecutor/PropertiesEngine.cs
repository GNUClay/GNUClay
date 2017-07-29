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

                var commandHashCode = command.GetLongHashCode();

                if(mCommandErrorSetCacheDict.ContainsKey(commandHashCode))
                {
                    propertyAction.State = EntityActionState.Faulted;
                    propertyAction.Error = mCommandErrorSetCacheDict[commandHashCode];

                    return CreateSetResultOfCalling(propertyAction);
                }

                PropertyFilter targetExecutor = null;

                if (mCommandIsLogicalSetCacheDict.ContainsKey(commandHashCode))
                {
                    if (mCommandIsLogicalSetCacheDict[commandHashCode])
                    {
                        CallSetLogicalHolder(propertyAction);
                        return CreateSetResultOfCalling(propertyAction);
                    }

                    targetExecutor = mCommandFiltersSetCacheDict[commandHashCode];
                    CallSystemProperty(holder, targetExecutor.SetMethod, propertyAction);
                    return CreateSetResultOfCalling(propertyAction);
                }

                var isLogical = true;

                if (holder.Kind == KindOfValue.Logical)
                {
                    CallSetLogicalHolder(propertyAction);
                    isLogical = true;
                }
                else
                {
                    var tmpList = mPropertiesFiltersStorage.FindExecutors(command);

                    if (tmpList.Count == 0)
                    {
                        if (holder.Kind == KindOfValue.Value)
                        {
                            CallSetLogicalHolder(propertyAction);
                            isLogical = true;
                        }
                        else
                        {
                            ReturnUncaughtReferenceError(propertyAction);
                        }
                    }
                    else
                    {
                        targetExecutor = tmpList.First();
                        CallSystemProperty(holder, targetExecutor.SetMethod, propertyAction);
                    }
                }

                if(propertyAction.State == EntityActionState.Faulted)
                {
                    mCommandErrorSetCacheDict[commandHashCode] = propertyAction.Error;
                    return CreateSetResultOfCalling(propertyAction);
                }

                if(isLogical)
                {
                    mCommandIsLogicalSetCacheDict[commandHashCode] = true;
                    return CreateSetResultOfCalling(propertyAction);
                }

                if(targetExecutor.WithOutClause)
                {
                    mCommandIsLogicalSetCacheDict[commandHashCode] = false;
                    mCommandFiltersSetCacheDict[commandHashCode] = targetExecutor;
                }

                return CreateSetResultOfCalling(propertyAction);
            }
        }

        private void CallSetLogicalHolder(PropertyAction action)
        {
            throw new NotImplementedException();

            //action.State = EntityActionState.Running;
            //action.Command.Holder.ExecuteSetLogicalProperty(action);

            //if (action.State == EntityActionState.Running)
            //{
            //    action.State = EntityActionState.Completed;
            //}
        }

        public ResultOfCalling CallGetProperty(IValue holder, ulong propertyKey)
        {
            lock (mLockObj)
            {
                var command = CreateGetCommand(holder, propertyKey);
                var propertyAction = CreatePropertyAction(command);

                var commandHashCode = command.GetLongHashCode();

                if (mCommandErrorGetCacheDict.ContainsKey(commandHashCode))
                {
                    propertyAction.State = EntityActionState.Faulted;
                    propertyAction.Error = mCommandErrorGetCacheDict[commandHashCode];
                    return CreateGetResultOfCalling(propertyAction);
                }

                PropertyFilter targetExecutor = null;

                if (mCommandIsLogicalGetCacheDict.ContainsKey(commandHashCode))
                {
                    if (mCommandIsLogicalGetCacheDict[commandHashCode])
                    {
                        CallGetLogicalHolder(propertyAction);
                        return CreateGetResultOfCalling(propertyAction);
                    }

                    targetExecutor = mCommandFiltersGetCacheDict[commandHashCode];
                    CallSystemProperty(holder, targetExecutor.GetMethod, propertyAction);
                    return CreateGetResultOfCalling(propertyAction);
                }

                var isLogical = false;

                if (holder.Kind == KindOfValue.Logical)
                {
                    CallGetLogicalHolder(propertyAction);
                    isLogical = true;
                }
                else
                {
                    var tmpList = mPropertiesFiltersStorage.FindExecutors(command);

                    if (tmpList.Count == 0)
                    {
                        if (holder.Kind == KindOfValue.Value)
                        {
                            CallGetLogicalHolder(propertyAction);
                            isLogical = true;
                        }
                        else
                        {
                            ReturnUncaughtReferenceError(propertyAction);
                        }
                    }
                    else
                    {
                        targetExecutor = tmpList.First();
                        CallSystemProperty(holder, targetExecutor.GetMethod, propertyAction);
                    }
                }

                if (propertyAction.State == EntityActionState.Faulted)
                {
                    mCommandErrorGetCacheDict[commandHashCode] = propertyAction.Error;
                    return CreateGetResultOfCalling(propertyAction);
                }

                if (isLogical)
                {
                    mCommandIsLogicalGetCacheDict[commandHashCode] = true;
                    return CreateGetResultOfCalling(propertyAction);
                }

                if(targetExecutor.WithOutClause)
                {
                    mCommandIsLogicalGetCacheDict[commandHashCode] = false;
                    mCommandFiltersGetCacheDict[commandHashCode] = targetExecutor;
                }

                return CreateGetResultOfCalling(propertyAction);
            }
        }

        private void CallGetLogicalHolder(PropertyAction action)
        {
            action.State = EntityActionState.Running;
            action.Command.Holder.ExecuteGetLogicalProperty(action);

            if (action.State == EntityActionState.Running)
            {
                action.State = EntityActionState.Completed;
            }
        }

        private void CallSystemProperty(IValue holder, MethodInfo method, PropertyAction propertyAction)
        {
            var params_ = new object[1] { propertyAction };
            propertyAction.State = EntityActionState.Running;
            method.Invoke(holder, params_);

            if (propertyAction.State == EntityActionState.Running)
            {
                propertyAction.State = EntityActionState.Completed;
            }
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

        private void ReturnUncaughtReferenceError(PropertyAction propertyAction)
        {
            propertyAction.State = EntityActionState.Faulted;
            propertyAction.Error = Context.ErrorsFactory.CreateUncaughtReferenceError();
        }

        private Dictionary<ulong, PropertyFilter> mCommandFiltersGetCacheDict = new Dictionary<ulong, PropertyFilter>();
        private Dictionary<ulong, bool> mCommandIsLogicalGetCacheDict = new Dictionary<ulong, bool>();
        private Dictionary<ulong, IValue> mCommandErrorGetCacheDict = new Dictionary<ulong, IValue>();
        private Dictionary<ulong, PropertyFilter> mCommandFiltersSetCacheDict = new Dictionary<ulong, PropertyFilter>();
        private Dictionary<ulong, bool> mCommandIsLogicalSetCacheDict = new Dictionary<ulong, bool>();
        private Dictionary<ulong, IValue> mCommandErrorSetCacheDict = new Dictionary<ulong, IValue>();

        private void InvalidateCache()
        {
            mCommandFiltersGetCacheDict.Clear();
            mCommandIsLogicalGetCacheDict.Clear();
            mCommandErrorGetCacheDict.Clear();
            mCommandFiltersSetCacheDict.Clear();
            mCommandIsLogicalSetCacheDict.Clear();
            mCommandErrorSetCacheDict.Clear();
        }
    }
}
