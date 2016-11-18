using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.RemoteEvents;
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
        public GnuClayScriptExternalFunctor(ExternalMethodInfo methodInfo, GnuClayEngineComponentContext context)
        {
            mExternalMethodInfo = methodInfo;
            mContext = context;
        }

        private ExternalMethodInfo mExternalMethodInfo = null;
        private GnuClayEngineComponentContext mContext = null;

        public bool Probing(List<IValue> args)
        {
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
            var e = new RemoteEvent();
            e.HolderKey = mExternalMethodInfo.HolderKey;
            e.MethodKey = mExternalMethodInfo.MethodKey;

            var parameters = mExternalMethodInfo.Parameters;
            var methodParamsEnumerator = parameters.GetEnumerator();

            foreach (var arg in args)
            {
                methodParamsEnumerator.MoveNext();
                e.Parameters.Add(methodParamsEnumerator.Current.NameKey, arg.ToExternal());
            }

            mContext.RemoteEventsEngine.Emit(e);
            return null;
        }
    }
}
