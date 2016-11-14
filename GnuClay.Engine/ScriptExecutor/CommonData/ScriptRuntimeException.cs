using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class ScriptRuntimeException: Exception
    {
        public ScriptRuntimeException()
        {
        }

        public ScriptRuntimeException(string message)
            : base(message)
        {
        }

        public ScriptRuntimeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
