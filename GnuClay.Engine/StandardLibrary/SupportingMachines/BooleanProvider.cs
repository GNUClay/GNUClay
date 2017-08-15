using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class BooleanProvider : BaseGnuClayEngineComponent, IConcreteTypeProvider
    {
        public BooleanProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public ulong TypeKey { get; private set; }

        public override void FirstInit()
        {
            TypeKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.Boolean);

            Context.ConstTypeProvider.AddProvider(this);
        }

        public IValue CreateConstValue(ulong typeKey, object value)
        {
            return new BooleanValue(typeKey, value);
        }
    }
}
