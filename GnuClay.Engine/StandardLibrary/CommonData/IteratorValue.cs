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
    public class IteratorValue : BaseValue
    {
        public IteratorValue(GCSClassInfo classInfo, GnuClayEngineComponentContext context, List<IValue>.Enumerator value)
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
        public void MoveNext()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("MoveNext");

            mValue.MoveNext();
        }

        [GCSMember]
        public IValue CurrentValue
        {
            get
            {
                NLog.LogManager.GetCurrentClassLogger().Info("CurrentValue");

                return mValue.Current;
            }
        }
    }
}
