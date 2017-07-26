using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class ConstTypeProvider : BaseGnuClayEngineComponent
    {
        public ConstTypeProvider(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public void AddProvider(IConcreteTypeProvider concreteTypeProvider)
        {
            mDict[concreteTypeProvider.TypeKey] = concreteTypeProvider;
        }

        private Dictionary<ulong, IConcreteTypeProvider> mDict = new Dictionary<ulong, IConcreteTypeProvider>();

        public IValue CreateConstValue(ulong typeKey, object value)
        {
            return mDict[typeKey].CreateConstValue(typeKey, value);
        }
    }
}
