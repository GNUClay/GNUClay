using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
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

            ConsoleProvider = new ConsoleProvider(Context);
            mProvidersList.Add(ConsoleProvider);
        }

        private void CreateProvidersOfOperators()
        {
            AssignOperatorsProvider = new AssignOperatorsProvider(Context);
            mProvidersList.Add(AssignOperatorsProvider);

            ArithmeticOperatorsProvider = new ArithmeticOperatorsProvider(Context);
            mProvidersList.Add(ArithmeticOperatorsProvider);

            LogicalOperatorsProvider = new LogicalOperatorsProvider(Context);
            mProvidersList.Add(LogicalOperatorsProvider);
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
        public ConsoleProvider ConsoleProvider { get; private set; }
        #endregion

        #region Providers of operators
        private AssignOperatorsProvider AssignOperatorsProvider = null;
        private ArithmeticOperatorsProvider ArithmeticOperatorsProvider = null;
        private LogicalOperatorsProvider LogicalOperatorsProvider = null;
        #endregion

    }
}
