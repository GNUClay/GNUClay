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
            GetKeysOfSystemVariables();
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

            SelfInstanceKey = DataDictionary.GetKey(StandartTypeNamesConstants.SelfInstanceName);
            InheritanceEngine.SetInheritance(SelfInstanceKey, SelfKey, 1, InheritanceAspect.WithOutClause);

            EntityActionTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.EntityActionTypeName);
            InheritanceEngine.SetInheritance(EntityActionTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            ErrorTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.ErrorTypeName);
            InheritanceEngine.SetInheritance(ErrorTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            UncaughtReferenceErrorTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.UncaughtReferenceErrorTypeName);
            InheritanceEngine.SetInheritance(UncaughtReferenceErrorTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);
        }

        private void GetKeysOfOperators()
        {
            GetKeysOfAssingOperators();
            GetKeysOfArithmeticOperators();
            GetKeysOfLogicalOperators();
            GetKeysOfCommonOperators();          
        }

        private void GetKeysOfAssingOperators()
        {
            AssignOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.AssignOperatorName);
            PlusAssingOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.PlusAssingOperatorName);
            MinusAssingOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.MinusAssingOperatorName);
            MulAssingOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.MulAssingOperatorName);
            DivAssingOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.DivAssingOperatorName);
            AssingFactOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.AssingFactOperatorName);
            PlusAssingFactOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.PlusAssingFactOperatorName);
        }

        private void GetKeysOfArithmeticOperators()
        {
            AddOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.AddOperatorName);
            SubOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.SubOperatorName);
            MulOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.MulOperatorName);
            DivOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.DivOperatorName);
        }

        private void GetKeysOfLogicalOperators()
        {
            EqualOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.EqualOperatorName);
            NotEqualOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.NotEqualOperatorName);
            MoreOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.MoreOperatorName);
            LessOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.LessOperatorName);
            AndOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.AndOperatorName);
            OrOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.OrOperatorName);
            MoreOrEqualOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.MoreOrEqualOperatorName);
            LessOrEqualOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.LessOrEqualOperatorName);
        }

        private void GetKeysOfCommonOperators()
        {
            PointOperatorKey = DataDictionary.GetKey(StandartTypeNamesConstants.PointOperatorName);
        }

        private void GetKeysOfSystemVariables()
        {
            SelfSystemVarKey = DataDictionary.GetKey(StandartTypeNamesConstants.SelfSystemVarName);
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
        public ulong SelfInstanceKey { get; private set; }
        public ulong EntityActionTypeKey { get; private set; }
        public ulong ErrorTypeKey { get; private set; }
        public ulong UncaughtReferenceErrorTypeKey { get; private set; }
        #endregion

        #region keys of assing operators
        public ulong AssignOperatorKey { get; private set; }
        public ulong PlusAssingOperatorKey { get; private set; }
        public ulong MinusAssingOperatorKey { get; private set; }
        public ulong MulAssingOperatorKey { get; private set; }
        public ulong DivAssingOperatorKey { get; private set; }
        public ulong AssingFactOperatorKey { get; private set; }
        public ulong PlusAssingFactOperatorKey { get; private set; }
        #endregion

        #region keys of arithmetic operators
        public ulong AddOperatorKey { get; private set; }
        public ulong SubOperatorKey { get; private set; }
        public ulong MulOperatorKey { get; private set; }
        public ulong DivOperatorKey { get; private set; }
        #endregion

        #region keys of logical operators
        public ulong EqualOperatorKey { get; private set; }
        public ulong NotEqualOperatorKey { get; private set; }
        public ulong MoreOperatorKey { get; private set; }
        public ulong LessOperatorKey { get; private set; }
        public ulong AndOperatorKey { get; private set; }
        public ulong OrOperatorKey { get; private set; }
        public ulong MoreOrEqualOperatorKey { get; private set; }
        public ulong LessOrEqualOperatorKey { get; private set; }
        #endregion

        #region keys of common operators
        public ulong PointOperatorKey { get; private set; }
        #endregion

        #region keys of system variables
        public ulong SelfSystemVarKey { get; private set; }
        #endregion

        #region keys of standard variables
        public ulong FirstParamKey { get; private set; }
        public ulong SecondParamKey { get; private set; }
        #endregion
    }
}
