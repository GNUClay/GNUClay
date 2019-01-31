using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.Internal
{
    public class CommonContext
    {
        public void AddComponent(BaseEngineComponent component)
        {
            mComponentList.Add(component);
        }

        private readonly List<BaseEngineComponent> mComponentList = new List<BaseEngineComponent>();
    }
}
