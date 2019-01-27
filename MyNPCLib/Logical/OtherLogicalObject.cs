using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.Logical
{
    public abstract class OtherLogicalObject : BaseAbstractLogicalObject
    {
        protected OtherLogicalObject(IEntityLogger entityLogger, SystemPropertiesDictionary systemPropertiesDictionary)
            : base(entityLogger, systemPropertiesDictionary)
        {
        }

        protected VisionObjectImpl CurrentVisionObjectImpl { get; set; }
        protected virtual void OnDemandUpdateCurrentVisionObjectImpl()
        {
        }

        protected object CommonGetProperty(ulong propertyKey)
        {
#if DEBUG
            //Log($"propertyKey = {propertyKey}");
#endif

            var kindOfSystemProperty = GetKindOfSystemProperty(propertyKey);

#if DEBUG
            //Log($"kindOfSystemProperty = {kindOfSystemProperty}");
#endif

            switch (kindOfSystemProperty)
            {
                case KindOfSystemProperties.Undefined:
                    return ConcreteGetPropertyFromStorage(propertyKey);

                case KindOfSystemProperties.GlobalPosition:
                    return GetGlobalPosition(propertyKey);

                default:
                    throw new ArgumentOutOfRangeException(nameof(kindOfSystemProperty), kindOfSystemProperty, null);
            }
        }

        protected virtual object ConcreteGetPropertyFromStorage(ulong propertyKey)
        {
            return null;
        }

        protected void CommonSetProperty(ulong propertyKey, object value)
        {
            ConcreteSetProperty(propertyKey, value);
        }

        protected virtual void ConcreteSetProperty(ulong propertyKey, object value)
        {
        }

        private object GetGlobalPosition(ulong propertyKey)
        {
#if DEBUG
            //Log($"propertyKey = {propertyKey} (CurrentVisionObjectImpl == null) = {CurrentVisionObjectImpl == null}");
#endif

            if(CurrentVisionObjectImpl == null)
            {
                OnDemandUpdateCurrentVisionObjectImpl();

#if DEBUG
                //Log($"NEXT propertyKey = {propertyKey} (CurrentVisionObjectImpl == null) = {CurrentVisionObjectImpl == null}");
#endif

                return ConcreteGetPropertyFromStorage(propertyKey);
            }

            var globalPos = CurrentVisionObjectImpl.GetGlobalPosition();

#if DEBUG
            //Log($"globalPos = {globalPos}");
#endif

            if (globalPos == null)
            {
                return ConcreteGetPropertyFromStorage(propertyKey);
            }

            return globalPos;
        }
    }
}
