using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
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

        private string mPropertyActionTypeName = "__PropertyAction";
        private ulong mPropertyActionTypeKey = 0;

        private string mPropertyTypeName = "__property";
        private ulong mPropertyTypeKey = 0;

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

            mPropertyTypeKey = Context.DataDictionary.GetKey(mPropertyTypeName);
            Context.InheritanceEngine.SetInheritance(mPropertyTypeKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);
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

        public ResultOfCalling FindProperty(IValue holder, ulong propertyKey)
        {
            lock (mLockObj)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"Begin FindProperty holder = {holder} propertyKey = {propertyKey}");
#endif

                var command = CreateGetCommand(holder, propertyKey);
                var commandHashCode = command.GetLongHashCode();

                var result = new ResultOfCalling();

                if (mCommandErrorCacheDict.ContainsKey(commandHashCode))
                {
                    result.Success = false;
                    result.Error = mCommandErrorCacheDict[commandHashCode];
                    return result;
                }

                if (mCommandCacheDict.ContainsKey(commandHashCode))
                {
                    result.Success = true;
                    result.Result = mCommandCacheDict[commandHashCode];
                    return result;
                }

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"FindProperty NEXT holder = {holder} propertyKey = {propertyKey}");
#endif

                PropertyFilter targetExecutor = null;
                var isLogical = false;

                if (holder.Kind == KindOfValue.Logical)
                {
                    isLogical = true;
                }
                else
                {
                    var tmpList = mPropertiesFiltersStorage.FindExecutors(command);

                    if (tmpList.Count == 0)
                    {
                        if (holder.Kind == KindOfValue.Value)
                        {
                            isLogical = true;
                        }
                        else
                        {
                            var tmpError = Context.ErrorsFactory.CreateUncaughtReferenceError();
                            result.Error = tmpError;
                            result.Success = false;

                            mCommandErrorCacheDict[commandHashCode] = tmpError;

                            return result;
                        }
                    }
                    else
                    {
                        targetExecutor = tmpList.First();
                    }
                }

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"FindProperty NEXT NEXT holder = {holder} propertyKey = {propertyKey}");
#endif

                IValue tmpProperty = null;

                if(isLogical)
                {
                    tmpProperty = new LogicalPropertyValue(mPropertyTypeKey, holder, Context);
                }
                else
                {
                    tmpProperty = new SystemPropertyValue(mPropertyTypeKey, targetExecutor, holder, Context);
                }
                
                mCommandCacheDict[commandHashCode] = tmpProperty;

                result.Success = true;
                result.Result = tmpProperty;

                return result;
            }
        }

        public void CallSystemProperty(IValue holder, MethodInfo method, PropertyAction propertyAction)
        {
            var params_ = new object[1] { propertyAction };
            propertyAction.State = EntityActionState.Running;
            method.Invoke(holder, params_);

            if (propertyAction.State == EntityActionState.Running)
            {
                propertyAction.State = EntityActionState.Completed;
            }
        }

        public PropertyCommand CreateSetCommand(IValue holder, ulong propertyKey, IValue value)
        {
            var command = new PropertyCommand();
            command.IsGet = false;
            command.Holder = holder;
            command.PropertyKey = propertyKey;
            command.Value = value;
            return command;
        }

        public PropertyCommand CreateGetCommand(IValue holder, ulong propertyKey)
        {
            var command = new PropertyCommand();
            command.IsGet = true;
            command.Holder = holder;
            command.PropertyKey = propertyKey;
            return command;
        }

        public PropertyAction CreatePropertyAction(PropertyCommand command)
        {
            var name = Guid.NewGuid().ToString("D");
            var key = Context.DataDictionary.GetKey(name);
            var propertyAction = new PropertyAction(name, key, command, mPropertyActionTypeKey);
            return propertyAction;
        }

        private Dictionary<ulong, IValue> mCommandErrorCacheDict = new Dictionary<ulong, IValue>();
        private Dictionary<ulong, IValue> mCommandCacheDict = new Dictionary<ulong, IValue>();

        private void InvalidateCache()
        {
            mCommandErrorCacheDict.Clear();
            mCommandCacheDict.Clear();
        }
    }
}
