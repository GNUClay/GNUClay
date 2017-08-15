using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;

namespace GnuClay.Engine.ScriptExecutor
{
    public class ErrorsFactory : BaseGnuClayEngineComponent
    {
        public ErrorsFactory(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private CommonKeysEngine mCommonKeysEngine = null;
        private CommonValuesFactory mCommonValuesFactory = null;
        private InheritanceEngine mInheritanceEngine = null;

        private ulong mErrorTypeKey = 0;
        private ulong mUncaughtReferenceErrorTypeKey = 0;

        public override void FirstInit()
        {
            mCommonKeysEngine = Context.CommonKeysEngine;
            mCommonValuesFactory = Context.CommonValuesFactory;
            mInheritanceEngine = Context.InheritanceEngine;
        }

        public override void SecondInit()
        {
            mErrorTypeKey = mCommonKeysEngine.ErrorTypeKey;
            mUncaughtReferenceErrorTypeKey = mCommonKeysEngine.UncaughtReferenceErrorTypeKey;
        }

        public IValue CreateError()
        {
            var tmpKey = mCommonValuesFactory.CreateObject();
            mInheritanceEngine.SetInheritance(tmpKey, mErrorTypeKey, 1, InheritanceAspect.WithOutClause);
            return new ErrorValue(tmpKey);
        }

        public IValue CreateUncaughtReferenceError()
        {
            var tmpKey = mCommonValuesFactory.CreateObject();
            mInheritanceEngine.SetInheritance(tmpKey, mUncaughtReferenceErrorTypeKey, 1, InheritanceAspect.WithOutClause);
            return new ErrorValue(tmpKey);
        }
    }
}
