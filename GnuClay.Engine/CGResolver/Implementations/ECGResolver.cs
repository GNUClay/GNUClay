﻿using GnuClay.Engine.CGResolver.Implementations.FromECGToICG;
using GnuClay.Engine.CGResolver.Interfaces;
using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations
{
    public class ECGResolver : IECGResolver
    {
        public ECGResolver(IGnuClayEngineContext context)
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

            var tmpConverter = new FromECGToICGConverter(mContext);

            return tmpConverter.ConvertECGToICG(inputNode);
        }
    }
}
