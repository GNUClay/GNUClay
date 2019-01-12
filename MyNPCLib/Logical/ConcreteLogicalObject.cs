using MyNPCLib.CGStorage;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.Logical
{
    public class ConcreteLogicalObject : OtherLogicalObject
    {
        public ConcreteLogicalObject(IEntityLogger entityLogger, ulong entityId, IEntityDictionary entityDictionary, ICGStorage source, SystemPropertiesDictionary systemPropertiesDictionary)
            : base(entityLogger, systemPropertiesDictionary)
        {
            mEntityId = entityId;
            mEntityDictionary = entityDictionary;
            mSource = source;
        }

        private ulong mEntityId;
        private IEntityDictionary mEntityDictionary;
        private ICGStorage mSource;

        public override bool IsConcrete => true;
        public override IList<ulong> CurrentEntitiesIdList => new List<ulong>() { mEntityId };
        public override ulong CurrentEntityId => mEntityId;

        public override object this[ulong propertyKey]
        {
            get
            {
#if DEBUG
                //Log($"propertyKey = {propertyKey}");
#endif

                return CommonGetProperty(propertyKey);
            }

            set
            {
#if DEBUG
                //Log($"propertyKey = {propertyKey} value = {value}");
#endif

                CommonSetProperty(propertyKey, value);
            }
        }

        public override object this[string propertyName]
        {
            get
            {
                var propertyKey = mEntityDictionary.GetKey(propertyName);

#if DEBUG
                //Log($"propertyName = {propertyName} propertyKey = {propertyKey}");
#endif

                return CommonGetProperty(propertyKey);
            }

            set
            {
                var propertyKey = mEntityDictionary.GetKey(propertyName);

#if DEBUG
                //Log($"propertyName = {propertyName} propertyKey = {propertyKey} value = {value}");
#endif

                CommonSetProperty(propertyKey, value);
            }
        }

        protected override void ConcreteSetProperty(ulong propertyKey, object value)
        {
            mSource.SetPropertyValueAsAsObject(mEntityId, propertyKey, value);
        }

        protected override object ConcreteGetPropertyFromStorage(ulong propertyKey)
        {
            return mSource.GetPropertyValueAsObject(mEntityId, propertyKey);
        }
    }
}
