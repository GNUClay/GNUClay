using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class NullProvider : BaseGnuClayEngineComponent, IConcreteTypeProvider
    {
        public NullProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public ulong TypeKey { get; private set; }
        private CommonValuesFactory _CommonValuesFactory;

        public override void FirstInit()
        {
            _CommonValuesFactory = Context.CommonValuesFactory;
        }

        public override void SecondInit()
        {
            TypeKey = Context.CommonKeysEngine.NullTypeKey;
            Context.ConstTypeProvider.AddProvider(this);
        }

        public IValue CreateConstValue(ulong typeKey, object value)
        {
            return _CommonValuesFactory.NullValue();
        }
    }
}
