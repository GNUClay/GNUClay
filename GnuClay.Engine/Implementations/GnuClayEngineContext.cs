﻿using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.Engine.CodeExecutionSystem.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Interfaces;
using GnuClay.Engine.CGResolver.Interfaces;

namespace GnuClay.Engine.Implementations
{
    public class GnuClayEngineContext : IGnuClayEngineContext
    {
        public ICESystem CE { get; set; }

        public IStorage KS { get; set; }

        public IECGResolver ECGResolver { get; set; }

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
