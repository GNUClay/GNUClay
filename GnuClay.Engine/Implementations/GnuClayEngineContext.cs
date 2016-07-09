using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.CodeExecutionSystem.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Interfaces;
using GnuClay.Engine.CGResolver.Interfaces;
using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.GC.Interfaces;
using GnuClay.Engine.TimeProvider.Interfaces;

namespace GnuClay.Engine.Implementations
{
    public class GnuClayEngineContext : IGnuClayEngineContext
    {
        public ICESystem CE { get; set; }

        public IStorage KS { get; set; }

        public IGCEngine GC { get; set; }

        public ITimeProviderEngine TimeProvider { get; set; }

        public ActiveContext ActiveContext { get; set; } = new ActiveContext();

        public ActiveContext SysActiveContext { get; set; } = new ActiveContext();

        private List<IGnuClayEngineComponent> mComponentsList = new List<IGnuClayEngineComponent>();

        public void RegComponent(IGnuClayEngineComponent component)
        {
            if(component == null)
            {
                throw new ArgumentNullException(nameof(component));
            }

            if(mComponentsList.Contains(component))
            {
                return;
            }

            mComponentsList.Add(component);
        }

        public void InitComponents()
        {
            foreach(var component in mComponentsList)
            {
                component.Init();
            }
        }
    }
}
