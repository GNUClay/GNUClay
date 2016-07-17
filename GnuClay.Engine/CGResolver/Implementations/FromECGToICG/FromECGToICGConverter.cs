using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public class FromECGToICGConverter
    {
        public FromECGToICGConverter(IGnuClayEngineContext context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

            mContext = context;
        }

        private IGnuClayEngineContext mContext = null;

        public IGnuClayEngineContext Context
        {
            get
            {
                return mContext;
            }
        }

        public ICG.ConceptualNode ConvertECGToICG(ECG.ConceptualNode inputNode)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ConvertECGToICG");

            var tmpContext = new ECGResolverContext(mContext);

            var tmpRootLeaf = new ECGResolverRootContainerLeaf(tmpContext, inputNode);

            tmpRootLeaf.Run();

            return tmpContext.Result;
        }
    }
}
