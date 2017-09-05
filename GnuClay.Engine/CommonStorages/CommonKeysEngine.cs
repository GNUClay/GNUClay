using GnuClay.Engine.Inheritance;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.StandardLibrary.CommonData;

namespace GnuClay.Engine.CommonStorages
{
    public class CommonKeysEngine : BaseGnuClayEngineComponent
    {
        public CommonKeysEngine(GnuClayEngineComponentContext context)
            :base(context)
        {
        }

        private StorageDataDictionary DataDictionary = null;
        private InheritanceEngine InheritanceEngine = null;

        public override void FirstInit()
        {
            GetKeysOfTypes();
            GetKeysOfOperators();
            GetKeysOfStandardVariables();
        }

        private void GetKeysOfTypes()
        {
            DataDictionary = Context.DataDictionary;
            InheritanceEngine = Context.InheritanceEngine;

            UniversalTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            UndefinedTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.UndefinedTypeMame);
            InheritanceEngine.SetInheritance(UndefinedTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            NullTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.NullTypeName);
            InheritanceEngine.SetInheritance(NullTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            NumberKey = DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);
            InheritanceEngine.SetInheritance(NumberKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            BooleanKey = Context.DataDictionary.GetKey(StandartTypeNamesConstants.Boolean);
            InheritanceEngine.SetInheritance(NumberKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            FactTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.FactName);
            InheritanceEngine.SetInheritance(BooleanKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            ArrayTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.ArrayName);
            InheritanceEngine.SetInheritance(ArrayTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            PropertyKey = DataDictionary.GetKey(StandartTypeNamesConstants.PropertyActionName);
            InheritanceEngine.SetInheritance(PropertyKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            LogicalPropertyKey = DataDictionary.GetKey(StandartTypeNamesConstants.LogicalPropertyName);
            InheritanceEngine.SetInheritance(LogicalPropertyKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);
            InheritanceEngine.SetInheritance(LogicalPropertyKey, PropertyKey, 1, InheritanceAspect.WithOutClause);
            InheritanceEngine.SetInheritance(LogicalPropertyKey, ArrayTypeKey, 1, InheritanceAspect.WithOutClause);

            PropertyActionTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.PropertyActionName);
            InheritanceEngine.SetInheritance(PropertyActionTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            SelfKey = DataDictionary.GetKey(StandartTypeNamesConstants.SelfName);
            InheritanceEngine.SetInheritance(SelfKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            EntityActionTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.EntityActionTypeName);
            InheritanceEngine.SetInheritance(EntityActionTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            ErrorTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.ErrorTypeName);
            InheritanceEngine.SetInheritance(ErrorTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            UncaughtReferenceErrorTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.UncaughtReferenceErrorTypeName);
            InheritanceEngine.SetInheritance(UncaughtReferenceErrorTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);
        }

        private void GetKeysOfOperators()
        {
            AssignOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.AssignOperatorName);
            AddOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.AddOperatorName);
            SubOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.SubOperatorName);
            MulOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.MulOperatorName);
            DivOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.DivOperatorName);
        }

        private void GetKeysOfStandardVariables()
        {
            FirstParamKey = DataDictionary.GetKey(StandartTypeNamesConstants.FirstParamName);
            SecondParamKey = DataDictionary.GetKey(StandartTypeNamesConstants.SecondParamName);
        }

        #region keys of types
        public ulong UniversalTypeKey { get; private set; }
        public ulong NullTypeKey { get; private set; }
        public ulong UndefinedTypeKey { get; private set; }
        public ulong NumberKey { get; private set; }
        public ulong BooleanKey { get; private set; }
        public ulong FactTypeKey { get; private set; }
        public ulong ArrayTypeKey { get; private set; }
        public ulong PropertyKey { get; private set; }
        public ulong LogicalPropertyKey { get; private set; }
        public ulong PropertyActionTypeKey { get; private set; }
        public ulong SelfKey { get; private set; }
        public ulong EntityActionTypeKey { get; private set; }
        public ulong ErrorTypeKey { get; private set; }
        public ulong UncaughtReferenceErrorTypeKey { get; private set; }
        #endregion

        #region keys of operators
        public ulong AssignOperatorKey { get; private set; }
        public ulong AddOperatorKey { get; private set; }
        public ulong SubOperatorKey { get; private set; }
        public ulong MulOperatorKey { get; private set; }
        public ulong DivOperatorKey { get; private set; }
        #endregion

        #region keys of standard variables
        public ulong FirstParamKey { get; private set; }
        public ulong SecondParamKey { get; private set; }
        #endregion
    }
}
