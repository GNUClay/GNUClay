using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.CommonData
{
    public class PropertyResultValue : BaseValue
    {
        public PropertyResultValue(GCSClassInfo classInfo, GnuClayEngineComponentContext context, List<IValue> value)
             : base(classInfo, context)
        {
            mValue = value;
        }

        private List<IValue> mValue = null;

        public override object ToExternal()
        {
            return mValue;
        }

        [GCSMember]
        public PropertyResultIteratorValue _GetIterator
        {
            get
            {
                NLog.LogManager.GetCurrentClassLogger().Info("_GetIterator");

                var nativeIterator = mValue.GetEnumerator();

                return Context.StandardLibrary.PropertyResultIteratorProvider.NCreate(nativeIterator);
            }
        }
    }
}
