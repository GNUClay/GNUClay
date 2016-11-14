using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.CommonData
{
    public class TryCallResult : ITryCallResult
    {
        public TryCallResult()
            : this(null, false, null)
        {
        }

        public TryCallResult(IValue result, bool success, IGnuClayScriptFunctor functor)
        {
            mResult = result;
            mSuccess = success;
            mFunctor = functor;
        }

        public IValue Result 
        {
            get
            {
                return mResult;
            }
        }

        public bool Success
        {
            get
            {
                return mSuccess;
            }
        }
        public IGnuClayScriptFunctor Functor
        {
            get
            {
                return mFunctor;
            }
        }

        private IValue mResult = null;
        private bool mSuccess = false;
        private IGnuClayScriptFunctor mFunctor = null;
    }
}
