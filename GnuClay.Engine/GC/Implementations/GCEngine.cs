﻿using GnuClay.CommonUtils.Tasking;
using GnuClay.Engine.GC.Interfaces;
using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.GC.Implementations
{
    public class GCEngine: GnuClayEngineComponent, IGCEngine
    {
        public GCEngine(IGnuClayEngineContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        private ActiveObject mActiveObject = null;

        public override void Init()
        {
            mActiveObject = new ActiveObject();

            mActiveObject.Context = Context.SysActiveContext;

            mActiveObject.RunAction = NRun;
        }

        private void NRun()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("NRun");
        }
    }
}
