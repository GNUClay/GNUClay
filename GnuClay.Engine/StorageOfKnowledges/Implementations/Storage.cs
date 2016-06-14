using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StorageOfKnowledges.Implementations
{
    public class Storage: GnuClayEngineComponent, IStorage
    {
        public Storage(IGnuClayEngineContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

            mGraphsStorage = new GraphsStorage(context);
            mObjectsRegistry = new ObjectsRegistry(context);
        }

        private IGraphsStorage mGraphsStorage = null;
        private IObjectsRegistry mObjectsRegistry = null;
    }
}
