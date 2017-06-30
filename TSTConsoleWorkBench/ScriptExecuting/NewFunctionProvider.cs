using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class NewFunctionProvider
    {
        public NewFunctionProvider(GnuClayEngineComponentContext context)
        {
            mContext = context;
        }

        private GnuClayEngineComponentContext mContext = null;

        public INewCallAction CallByNamedParameters()
        {

        }

        public INewCallAction CallByPositionedParameters()
        {

        }
    }
}
