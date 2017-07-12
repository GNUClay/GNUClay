using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewNumberProvider : INewConcreteTypeProvider
    {
        public NewNumberProvider(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContext)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContext;

            TypeKey = mMainContext.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        public ulong TypeKey { get; private set; }

        public INewValue CreateConstValue(ulong typeKey, object value)
        {
            return new NewNumberValue(typeKey, value);
        }
    }
}
