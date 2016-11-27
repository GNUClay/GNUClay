using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.CommonData
{
    public class TryCallPropertyResult : ITryCallPropertyResult
    {
        public TryCallPropertyResult()
            : this(null, false, null)
        {
        }

        public TryCallPropertyResult(IValue result, bool success, IGnuClayAbstractProperty property)
        {
            mProperty = property;
            mSuccess = success;
            mResult = result;
        }

        private IGnuClayAbstractProperty mProperty = null;

        public IGnuClayAbstractProperty AbstractProperty
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private IValue mResult = null;

        public IValue Result
        {
            get
            {
                return mResult;
            }
        }

        private bool mSuccess = false;

        public bool Success
        {
            get
            {
                return mSuccess;
            }
        }
    }
}
