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
    public class PropertyResultIteratorValue : BaseValue
    {
        public PropertyResultIteratorValue(GCSClassInfo classInfo, GnuClayEngineComponentContext context, List<IValue>.Enumerator value)
            : base(classInfo, context)
        {
            mValue = value;
        }

        private List<IValue>.Enumerator mValue;

        public override object ToExternal()
        {
            throw new NotImplementedException();
        }

        [GCSMember]
        public void _MoveNext()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("_MoveNext");

            mValue.MoveNext();
        }

        [GCSMember]
        public IValue _CurrentValue
        {
            get
            {
                NLog.LogManager.GetCurrentClassLogger().Info("_CurrentValue");

                return mValue.Current;
            }
        }
    }
}
