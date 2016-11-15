using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class GnuClayScriptExternalFunctor : IGnuClayScriptFunctor
    {
        public GnuClayScriptExternalFunctor(ExternalMethodInfo methodInfo)
        {
            mExternalMethodInfo = methodInfo;
        }

        private ExternalMethodInfo mExternalMethodInfo = null;

        public bool Probing(List<IValue> args)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Probing {mExternalMethodInfo.MethodKey}");

            var parameters = mExternalMethodInfo.Parameters;
            var methodParamsEnumerator = parameters.GetEnumerator();

            foreach (var arg in args)
            {
                if (!methodParamsEnumerator.MoveNext())
                {
                    return false;
                }

                var p = methodParamsEnumerator.Current;

                if (p.ParameterType != arg.TypeKey)
                {
                    return false;
                }
            }

            if (methodParamsEnumerator.MoveNext())
            {
                var p = methodParamsEnumerator.Current;

                if (!p.HasDefaultValue)
                {
                    return false;
                }
            }

            return true;
        }

        public IValue Invoke(object obj, List<IValue> args)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Invoke {mExternalMethodInfo.MethodKey}");

            throw new NotImplementedException();
        }
    }
}
