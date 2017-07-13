using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewErrorsFactory
    {
        public NewErrorsFactory(GnuClayEngineComponentContext mainContext, NewAdditionalGnuClayEngineComponentContext additionalContext)
        {
            mMainContext = mainContext;
            mAdditionalContext = additionalContext;

            InitClassesOfError();
        }

        private GnuClayEngineComponentContext mMainContext = null;
        private NewAdditionalGnuClayEngineComponentContext mAdditionalContext = null;

        private string mErrorTypeName = "error";
        private ulong mErrorTypeKey = 0;

        private string mUncaughtReferenceErrorTypeName = "Uncaught Reference Error";
        private ulong mUncaughtReferenceErrorTypeKey = 0;

        private void InitClassesOfError()
        {
            var universalTypeKey = mMainContext.DataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            mErrorTypeKey = mMainContext.DataDictionary.GetKey(mErrorTypeName);

            mMainContext.InheritanceEngine.SetInheritance(mErrorTypeKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);

            mUncaughtReferenceErrorTypeKey = mMainContext.DataDictionary.GetKey(mUncaughtReferenceErrorTypeName);

            mMainContext.InheritanceEngine.SetInheritance(mUncaughtReferenceErrorTypeKey, mErrorTypeKey, 1, InheritanceAspect.WithOutClause);
        }

        private ulong CreateObject()
        {
            var tmpName = Guid.NewGuid().ToString("D");

            return mMainContext.DataDictionary.GetKey(tmpName);
        }

        public INewValue CreateError()
        {
            var tmpKey = CreateObject();

            NLog.LogManager.GetCurrentClassLogger().Info($"CreateError tmpKey = {tmpKey}");

            mMainContext.InheritanceEngine.SetInheritance(tmpKey, mErrorTypeKey, 1, InheritanceAspect.WithOutClause);

            return new NewErrorValue(tmpKey);
        }

        public INewValue CreateUncaughtReferenceError()
        {
            var tmpKey = CreateObject();

            NLog.LogManager.GetCurrentClassLogger().Info($"CreateUncaughtReferenceError tmpKey = {tmpKey}");

            mMainContext.InheritanceEngine.SetInheritance(tmpKey, mUncaughtReferenceErrorTypeKey, 1, InheritanceAspect.WithOutClause);

            return new NewErrorValue(tmpKey);
        }
    }
}
