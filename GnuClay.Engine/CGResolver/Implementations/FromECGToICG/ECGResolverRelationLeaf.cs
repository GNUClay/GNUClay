﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG
{
    public class ECGResolverRelationLeaf: ECGResolverBaseLeaf
    {
        public ECGResolverRelationLeaf(ECGResolverContext context, ECG.RelationNode inputNode)
             : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");

            mInputNode = inputNode;
        }

        private ECG.RelationNode mInputNode = null;

        public override void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            throw new NotImplementedException();
        }
    }
}
