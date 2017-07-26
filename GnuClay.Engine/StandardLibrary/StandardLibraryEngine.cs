using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System.Collections.Generic;

namespace GnuClay.Engine.StandardLibrary
{
    public class StandardLibraryEngine: BaseGnuClayEngineComponent
    {
        public StandardLibraryEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public override void FirstInit()
        {
            mNumberProvider = new NumberProvider(Context);
            mProvidersList.Add(mNumberProvider);
            
            FirstInitProviders();
        }

        private void FirstInitProviders()
        {
            foreach (var component in mProvidersList)
            {
                component.FirstInit();
            }
        }

        private List<BaseGnuClayEngineComponent> mProvidersList = new List<BaseGnuClayEngineComponent>();

        private NumberProvider mNumberProvider = null;

        public NumberProvider NumberProvider
        {
            get
            {
                return mNumberProvider;
            }
        }
    }
}
