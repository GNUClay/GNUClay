using GnuClay.Engine.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Implementations
{
    public class DefaultGnuClayEngineInitializator: BaseGnuClayEngineInitializator
    {
        public DefaultGnuClayEngineInitializator(IGnuClayEngineContext context)
            : base (context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("DefaultGnuClayEngineInitializator");
        }

        public override void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            Context.KS.ObjectsRegistry.AddWord("Iself", PreDefinedConceptsCodes.ISELF, ObjectsRegistry.MaxGenerationsCount);

            Context.KS.ObjectsRegistry.AddWord("is", PreDefinedConceptsCodes.IS, ObjectsRegistry.MaxGenerationsCount);

            Context.KS.ObjectsRegistry.AddWord("proposition", PreDefinedConceptsCodes.PROPOSITION, ObjectsRegistry.MaxGenerationsCount);
        }
    }
}
