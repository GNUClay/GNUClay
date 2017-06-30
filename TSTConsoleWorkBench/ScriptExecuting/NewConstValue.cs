using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewConstValue : INewValue
    {
        public NewConstValue(ulong typeKey, object value)
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

        public override string ToString()
        {
            return $"ConstValue {nameof(TypeKey)} = {TypeKey}; {nameof(mValue)} = {mValue}";
        }
    }
}
