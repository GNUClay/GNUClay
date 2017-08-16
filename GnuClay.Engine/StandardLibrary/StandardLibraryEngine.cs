using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.OperatorsSupport;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System.Collections.Generic;

namespace GnuClay.Engine.StandardLibrary
{
    public class StandardLibraryEngine: BaseGnuClayEngineComponent
    {
        public StandardLibraryEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            CreateProviders();
            
        }

        private void CreateProviders()
        {
            CreateProvidersOfTypes();
            CreateProvidersOfOperators();
        }

        private void CreateProvidersOfTypes()
        {
            NumberProvider = new NumberProvider(Context);
            mProvidersList.Add(NumberProvider);

            BooleanProvider = new BooleanProvider(Context);
            mProvidersList.Add(BooleanProvider);
        }

        private void CreateProvidersOfOperators()
        {
            OperatorAssignProvider = new OperatorAssignProvider(Context);
            mProvidersList.Add(OperatorAssignProvider);
        }

        public override void FirstInit()
        {
            FirstInitProviders();
        }

        private void FirstInitProviders()
        {
            foreach (var component in mProvidersList)
            {
                component.FirstInit();
            }
        }

        public override void SecondInit()
        {
            SecondInitProviders();
        }

        private void SecondInitProviders()
        {
            foreach (var component in mProvidersList)
            {
                component.SecondInit();
            }
        }

        private List<BaseGnuClayEngineComponent> mProvidersList = new List<BaseGnuClayEngineComponent>();

        #region Providers of types
        public NumberProvider NumberProvider { get; private set; }
        public BooleanProvider BooleanProvider { get; private set; }
        #endregion

        #region Providers of operators
        private OperatorAssignProvider OperatorAssignProvider = null;
        #endregion
    }
}
