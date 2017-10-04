using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;

namespace GnuClay.Engine.CommonStorages
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
        private ConstTypeProvider mConstTypeProvider = null;

        private IValue mNullValue = null;

        private static string ParamVarName = "$x1";
        private ulong ParamVarKey = 0;

        private ulong mFactTypeKey = 0;
        private ulong mArrayTypeKey = 0;

        private ulong mSelfInstanceKey = 0;
        private IValue mSelfInstanceValue = null;

        private IValue mTrueValue = null;
        private IValue mFalseValue = null;

        public override void FirstInit()
        {
            mDataDictionary = Context.DataDictionary;
            mInheritanceEngine = Context.InheritanceEngine;
            mCommonKeysEngine = Context.CommonKeysEngine;
            mConstTypeProvider = Context.ConstTypeProvider;
        }

        public override void SecondInit()
        {
            mNullValue = new NullValue(mCommonKeysEngine.NullTypeKey);

            ParamVarKey = mDataDictionary.GetKey(ParamVarName);

            mFactTypeKey = mCommonKeysEngine.FactTypeKey;
            mArrayTypeKey = mCommonKeysEngine.ArrayTypeKey;

            mSelfInstanceKey = mCommonKeysEngine.SelfInstanceKey;
            mSelfInstanceValue = new EntityValue(mSelfInstanceKey);

            var booleanTypeKey = mCommonKeysEngine.BooleanKey;

            mTrueValue = mConstTypeProvider.CreateConstValue(booleanTypeKey, 1.0);
            mFalseValue = mConstTypeProvider.CreateConstValue(booleanTypeKey, 0.0);
        }

        public ulong CreateObject()
        {
            var tmpName = Guid.NewGuid().ToString("D");
            return mDataDictionary.GetKey(tmpName);
        }

        public IValue CreateDirectFactValue(ulong key)
        {
            return new FactValue(key, Context);
        }

        public IValue NullValue()
        {
            return mNullValue;
        }

        public IValue SelfInstanceValue()
        {
            return mSelfInstanceValue;
        }

        public IValue TrueValue()
        {
            return mTrueValue;
        }

        public IValue FalseValue()
        {
            return mFalseValue;
        }
    }
}
