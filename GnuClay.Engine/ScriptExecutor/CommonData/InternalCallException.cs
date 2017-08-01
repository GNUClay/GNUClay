using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    public class InternalCallException: Exception
    {
        public InternalCallException(IValue error)
        {
            InternalError = error;
        }

        public IValue InternalError { get; private set; }

        public ResultOfCalling ToResultOfCalling()
        {
            var result = new ResultOfCalling();
            result.Success = false;
            result.Error = InternalError;
            return result;
        }
    }
}
