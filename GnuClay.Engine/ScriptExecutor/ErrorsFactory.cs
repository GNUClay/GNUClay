using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class ErrorsFactory : BaseGnuClayEngineComponent
    {
        public ErrorsFactory(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private string mErrorTypeName = "error";
        private ulong mErrorTypeKey = 0;

        private string mUncaughtReferenceErrorTypeName = "Uncaught Reference Error";
        private ulong mUncaughtReferenceErrorTypeKey = 0;

        public override void FirstInit()
        {
            var universalTypeKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            mErrorTypeKey = Context.DataDictionary.GetKey(mErrorTypeName);

            Context.InheritanceEngine.SetInheritance(mErrorTypeKey, universalTypeKey, 1, InheritanceAspect.WithOutClause);

            mUncaughtReferenceErrorTypeKey = Context.DataDictionary.GetKey(mUncaughtReferenceErrorTypeName);

            Context.InheritanceEngine.SetInheritance(mUncaughtReferenceErrorTypeKey, mErrorTypeKey, 1, InheritanceAspect.WithOutClause);
        }

        private ulong CreateObject()
        {
            var tmpName = Guid.NewGuid().ToString("D");

            return Context.DataDictionary.GetKey(tmpName);
        }

        public IValue CreateError()
        {
            var tmpKey = CreateObject();

            Context.InheritanceEngine.SetInheritance(tmpKey, mErrorTypeKey, 1, InheritanceAspect.WithOutClause);

            return new ErrorValue(tmpKey);
        }

        public IValue CreateUncaughtReferenceError()
        {
            var tmpKey = CreateObject();

            Context.InheritanceEngine.SetInheritance(tmpKey, mUncaughtReferenceErrorTypeKey, 1, InheritanceAspect.WithOutClause);

            return new ErrorValue(tmpKey);
        }
    }
}
