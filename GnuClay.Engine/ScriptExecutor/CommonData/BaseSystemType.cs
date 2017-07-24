using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public abstract class BaseSystemType : IValue
    {
        protected BaseSystemType(ulong typeKey)
        {
            mTypeKey = typeKey;
        }

        public KindOfValue Kind
        {
            get
            {
                return KindOfValue.System;
            }
        }

        private ulong mTypeKey = 0;

        public ulong TypeKey
        {
            get
            {
                return mTypeKey;
            }
        }

        public abstract ulong GetLongHashCode();

        public void ExecuteSetLogicalProperty(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteSetLogicalProperty action = {action}");

            throw new NotImplementedException();
        }

        public void ExecuteGetLogicalProperty(PropertyAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteGetLogicalProperty action = {action}");

            throw new NotImplementedException();
        }
    }
}
