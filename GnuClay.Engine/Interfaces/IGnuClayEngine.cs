using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Interfaces
{
    /// <summary>
    /// This is the interface of the simple AI engine.
    /// </summary>
    public interface IGnuClayEngine
    {
        IGnuClayEngineInitializatorFactory InitializatorFactory { get; set; }

        ECG.ConceptualNode Query(ECG.ConceptualNode inputNode); 
    }
}
