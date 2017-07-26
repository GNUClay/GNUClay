using GnuClay.Engine.ScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class EntityValue : IValue
    {
        public EntityValue(ulong typeKey)
        {
            mTypeKey = typeKey;
        }

        public KindOfValue Kind
        {
            get
            {
                return KindOfValue.Logical;
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

        public ulong GetLongHashCode()
        {
            return mTypeKey;
        }

        public void ExecuteSetLogicalProperty(PropertyAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteSetLogicalProperty action = {action}");
#endif
            //throw new NotImplementedException();
        }

        public void ExecuteGetLogicalProperty(PropertyAction action)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ExecuteGetLogicalProperty action = {action}");
#endif
            //throw new NotImplementedException();
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return $"EntityValue {nameof(TypeKey)} = {TypeKey}";
        }
    }
}
