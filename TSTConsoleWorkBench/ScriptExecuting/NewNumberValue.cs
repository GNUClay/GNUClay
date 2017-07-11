using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewNumberValue: INewValue
    {
        public NewNumberValue(ulong typeKey, object value)
        {
            mTypeKey = typeKey;
            mValue = value;
        }

        private ulong mTypeKey = 0;

        public ulong TypeKey
        {
            get
            {
                return mTypeKey;
            }
        }

        private object mValue = null;

        public ulong GetLongHashCode()
        {
            var result = mTypeKey;

            if (mValue != null)
            {
                result ^= (ulong)mValue.GetHashCode();
            }

            return result;
        }

        public override string ToString()
        {
            return $"NumberValue {nameof(TypeKey)} = {TypeKey}; {nameof(mValue)} = {mValue}";
        }
    }
}
