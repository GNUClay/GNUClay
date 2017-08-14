using GnuClay.CommonClientTypes.ResultTypes;
using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class CommonValuesFactory : BaseGnuClayEngineComponent
    {
        public CommonValuesFactory(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private InheritanceEngine mInheritanceEngine = null;
        private StorageDataDictionary mDataDictionary = null;
        private CommonKeysEngine mCommonKeysEngine = null;

        private IValue mUndefinedValue = null;
        private IValue mNullValue = null;

        private static string ParamVarName = "$x1";
        private ulong ParamVarKey = 0;

        private ulong mFactTypeKey = 0;
        private ulong mArrayTypeKey = 0;

        public override void FirstInit()
        {
            mDataDictionary = Context.DataDictionary;
            mInheritanceEngine = Context.InheritanceEngine;
            mCommonKeysEngine = Context.CommonKeysEngine;
        }

        public override void SecondInit()
        {
            mUndefinedValue = new UndefinedValue(mCommonKeysEngine.UndefinedTypeKey);
            mNullValue = new NullValue(mCommonKeysEngine.NullTypeKey);

            ParamVarKey = mDataDictionary.GetKey(ParamVarName);

            mFactTypeKey = mCommonKeysEngine.FactTypeKey;
            mArrayTypeKey = mCommonKeysEngine.ArrayTypeKey;
        }

        public IValue UndefinedValue()
        {
            return mUndefinedValue;
        }

        public IValue CreateDirectFactValue(ulong key)
        {
            return new DirectFactValue(key, Context);
        }

        public IValue NullValue()
        {
            return mNullValue;
        }
    }
}
