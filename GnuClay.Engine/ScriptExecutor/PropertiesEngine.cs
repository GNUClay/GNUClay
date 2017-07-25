using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class PropertiesEngine : BaseGnuClayEngineComponent
    {
        public PropertiesEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");       
        }

        private string mPropertyActionTypeName = "PropertyAction";
        private ulong mPropertyActionTypeKey = 0;

        private ulong mUndefinedTypeKey = 0;

        public override void FirstInit()
        {
            mPropertiesFiltersStorage = new PropertiesFiltersStorage(Context);

            var universalTypeKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            mPropertyActionTypeKey = Context.DataDictionary.GetKey(mPropertyActionTypeName);

            Context.InheritanceEngine.SetInheritance(mPropertyActionTypeKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);

            mUndefinedTypeKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.UndefinedTypeMame);
        }

        private object mLockObj = new object();

        private PropertiesFiltersStorage mPropertiesFiltersStorage = null;

        public ulong AddFilter(PropertyFilter filter)
        {
            lock(mLockObj)
            {
                return mPropertiesFiltersStorage.AddFilter(filter);
            }
        }

        public ResultOfCalling CallSetProperty(IValue holder, ulong propertyKey, IValue value)
        {
            lock(mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"CallSetProperty holder = {holder} propertyKey = {propertyKey} value = {value}");

                var command = CreateSetCommand(holder, propertyKey, value);

                var propertyAction = CreatePropertyAction(command);

                if (holder.Kind == KindOfValue.Logical)
                {
                    return CallSetLogicalHolder(propertyAction);
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"CallSetProperty NEXT command  = {command}");

                var tmpList = mPropertiesFiltersStorage.FindExecutors(command);

                NLog.LogManager.GetCurrentClassLogger().Info($"CallSetProperty tmpList.Count = {tmpList.Count}");

                if(tmpList.Count == 0)
                {
                    throw new NotImplementedException();
                }

                var targetExecutor = tmpList.First();

                var params_ = new object[1] { propertyAction };

                propertyAction.State = EntityActionState.Running;

                targetExecutor.SetMethod.Invoke(holder, params_);

                if (propertyAction.State == EntityActionState.Running)
                {
                    propertyAction.State = EntityActionState.Completed;
                }

                return CreateSetResultOfCalling(propertyAction);
            }
        }

        private ResultOfCalling CallSetLogicalHolder(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallSetLogicalHolder command = {action}");

            throw new NotImplementedException();
        }

        public ResultOfCalling CallGetProperty(IValue holder, ulong propertyKey)
        {
            lock (mLockObj)
            {
                NLog.LogManager.GetCurrentClassLogger().Info($"CallGetProperty holder = {holder} propertyKey = {propertyKey}");

                var command = CreateGetCommand(holder, propertyKey);

                var propertyAction = CreatePropertyAction(command);

                if (holder.Kind == KindOfValue.Logical)
                {
                    return CallGetLogicalHolder(propertyAction);
                }

                NLog.LogManager.GetCurrentClassLogger().Info($"CallGetProperty NEXT command  = {command}");

                var tmpList = mPropertiesFiltersStorage.FindExecutors(command);

                NLog.LogManager.GetCurrentClassLogger().Info($"CallGetProperty tmpList.Count = {tmpList.Count}");

                if (tmpList.Count == 0)
                {
                    throw new NotImplementedException();
                }

                var targetExecutor = tmpList.First();

                var params_ = new object[1] { propertyAction };

                propertyAction.State = EntityActionState.Running;

                targetExecutor.GetMethod.Invoke(holder, params_);

                if (propertyAction.State == EntityActionState.Running)
                {
                    propertyAction.State = EntityActionState.Completed;
                }

                return CreateGetResultOfCalling(propertyAction);
            }
        }

        private ResultOfCalling CallGetLogicalHolder(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CallGetLogicalHolder command = {action}");

            throw new NotImplementedException();
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
            NLog.LogManager.GetCurrentClassLogger().Info($"CreateSetResultOfCalling propertyAction = {propertyAction}");

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

            NLog.LogManager.GetCurrentClassLogger().Info($"End CreateSetResultOfCalling result = {result}");

            return result;
        }

        private ResultOfCalling CreateGetResultOfCalling(PropertyAction propertyAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CreateGetResultOfCalling propertyAction = {propertyAction}");

            var result = new ResultOfCalling();

            if (propertyAction.State == EntityActionState.Completed)
            {
                result.Success = true;

                if (propertyAction.Result == null)
                {
                    propertyAction.Result = new EntityValue(mUndefinedTypeKey);
                }

                result.Result = propertyAction.Result;
            }
            else
            {
                result.Success = false;
                result.Error = propertyAction.Error;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End CreateGetResultOfCalling result = {result}");

            return result;
        }

        /*private ResultOfCalling CreateSyncResultOfCalling(EntityAction entityAction)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CreateSyncResultOfCalling entityAction = {entityAction}");

            var result = new ResultOfCalling();

            if (entityAction.State == EntityActionState.Completed)
            {
                result.Success = true;

                if (entityAction.Result == null)
                {
                    entityAction.Result = new EntityValue(mUndefinedTypeKey);
                }

                result.Result = entityAction.Result;
            }
            else
            {
                result.Success = false;
                result.Error = entityAction.Error;
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"End CreateSyncResultOfCalling result = {result}");

            return result;
        }*/
    }
}
