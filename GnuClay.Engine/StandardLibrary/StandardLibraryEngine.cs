using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GnuClay.Engine.StandardLibrary
{
    public class StandardLibraryEngine: BaseGnuClayEngineComponent
    {
        public StandardLibraryEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("StandardLibraryEngine");
        }

        public void CreateProviders()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("CreateProviders");
            mNumberProvider = new NumberProvider(Context);
            RegProvider(mNumberProvider);
        }

        private NumberProvider mNumberProvider = null;

        private void RegProvider(BaseTypeProvider provider)
        {
            mProvidersList.Add(provider);
        }

        private List<BaseTypeProvider> mProvidersList = new List<BaseTypeProvider>();

        public void InitFromZero()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("InitFromZero");
            mProvidersList.ForEach(p => p.InitFromZero());
        }
    }
}
