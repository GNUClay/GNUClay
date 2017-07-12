using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewExceptionValue: INewValue
    {
        public NewExceptionValue(ulong typeKey)
        {
            mTypeKey = typeKey;
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

        public override string ToString()
        {
            return $"ExceptionValue {nameof(TypeKey)} = {TypeKey}";
        }
    }
}
