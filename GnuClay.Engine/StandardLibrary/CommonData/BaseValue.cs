using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.CommonData
{
    public abstract class BaseValue: IValue
    {
        protected BaseValue(GCSClassInfo classInfo)
        {
            ClassInfo = classInfo;
        }

        protected GCSClassInfo ClassInfo = null;

        public ITryCallResult TryCall(int key, List<IValue> args)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TryCal key = `{key}` `{_ObjectHelper.PrintDefaultToStringInformation(args)}`");
            if (!ClassInfo.SystemMethods.ContainsKey(key))
            {
                return new TryCallResult();
            }

            var targetMethods = ClassInfo.SystemMethods[key];

            foreach (var method in targetMethods)
            {
                if(!method.Probing(args))
                {
                    continue;
                }

                return new TryCallResult(method.Invoke(this, args), true, method);
            }

            return new TryCallResult();
        }

        public ITryCallResult TrySetProperty(int key, IValue value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"TrySetProperty key = {key} value = {value}");
            throw new NotImplementedException();
        }
    }
}
