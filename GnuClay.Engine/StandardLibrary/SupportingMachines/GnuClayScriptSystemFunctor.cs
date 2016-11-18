using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class GnuClayScriptSystemFunctor: IGnuClayScriptFunctor
    {
        public GnuClayScriptSystemFunctor(MethodInfo methodInfo)
        {
            mMethodInfo = methodInfo;
        }

        private MethodInfo mMethodInfo = null;

        public bool Probing(List<IValue> args)
        {
            var parameters = mMethodInfo.GetParameters();
            var methodParamsEnumerator = parameters.GetEnumerator();
            
            foreach (var arg in args)
            {
                if(!methodParamsEnumerator.MoveNext())
                {
                    return false;
                }

                var p = (ParameterInfo)methodParamsEnumerator.Current;
                
                if (p.ParameterType != arg.GetType())
                {
                    return false;
                }
            }

            if (methodParamsEnumerator.MoveNext())
            {
                var p = (ParameterInfo)methodParamsEnumerator.Current;

                if (!p.HasDefaultValue)
                {
                    return false;
                }
            }

            return true;
        }

        public IValue Invoke(object obj, List<IValue> args)
        {
            var parameters = mMethodInfo.GetParameters();
            var argsAsObjectList = new List<object>();
            var methodParamsEnumerator = parameters.GetEnumerator();

            foreach (var arg in args)
            {
                methodParamsEnumerator.MoveNext();
                argsAsObjectList.Add(arg);
            }

            while (methodParamsEnumerator.MoveNext())
            {
                var p = (ParameterInfo)methodParamsEnumerator.Current;

                if (p.DefaultValue == null)
                {
                    argsAsObjectList.Add(null);
                }
                else
                {
                    argsAsObjectList.Add(p.DefaultValue);
                }
            }

            var callResult = mMethodInfo.Invoke(obj, argsAsObjectList.ToArray());
            return (IValue)callResult;
        }
    }
}
