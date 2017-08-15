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
            NumberProvider = new NumberProvider(Context);
            mProvidersList.Add(NumberProvider);

            BooleanProvider = new BooleanProvider(Context);
            mProvidersList.Add(BooleanProvider);

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

        public NumberProvider NumberProvider { get; private set; }
        public BooleanProvider BooleanProvider { get; private set; }
    }
}
