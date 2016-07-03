using GnuClay.Engine.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Interfaces
{
    public interface IECGResolver
    {
        IGnuClayEngineContext Context { get; }

        ICG.ConceptualNode ConvertECGToICG(ECG.ConceptualNode inputNode);
    }
}
