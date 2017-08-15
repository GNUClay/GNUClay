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
            DataDictionary = Context.DataDictionary;
            InheritanceEngine = Context.InheritanceEngine;

            UniversalTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.UniversalTypeName);

            UndefinedTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.UndefinedTypeMame);
            InheritanceEngine.SetInheritance(UndefinedTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            NullTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.NullTypeName);
            InheritanceEngine.SetInheritance(NullTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

            FactTypeKey = DataDictionary.GetKey(StandartTypeNamesConstants.FactName);
            InheritanceEngine.SetInheritance(FactTypeKey, UniversalTypeKey, 1, InheritanceAspect.WithOutClause);

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
        }

        public ulong UniversalTypeKey { get; private set; }
        public ulong NullTypeKey { get; private set; }
        public ulong UndefinedTypeKey { get; private set; }
        public ulong FactTypeKey { get; private set; }
        public ulong ArrayTypeKey { get; private set; }
        public ulong PropertyKey { get; private set; }
        public ulong LogicalPropertyKey { get; private set; }
        public ulong PropertyActionTypeKey { get; private set; }
    }
}
