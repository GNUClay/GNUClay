using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    public class ObjectConvertor
    {
        private class ContextOfConvertToPlaneTree
        {
            public int CurrIndex { get; set; }
            public Dictionary<object, int> ProcessedObjectsDict { get; set; } = new Dictionary<object, int>();
            public Dictionary<int, PlaneObject> ObjectsDict { get; set; } = new Dictionary<int, PlaneObject>();
        }

        private enum KindOfType
        {
            Class,
            ValueType,
            List,
            Dictionary
        }

        public PlaneObjectsTree ConvertToPlaneTree(object source, float version)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ConvertToPlaneTree source = {source} version = {version}");
#endif

            if(!source.GetType().IsClass)
            {
                throw new NotSupportedException();
            }

            var context = new ContextOfConvertToPlaneTree();

            var result = new PlaneObjectsTree();
            result.Version = version;
            ProcessObjectOnConvertingToPlaneTree(source, context);

            result.ObjectsDict = context.ObjectsDict;
            return result;
        }

        private KindOfType GetKindOfType(Type type)
        {
            if (type.IsValueType)
            {
                return KindOfType.ValueType;
            }

            if(type.IsEnum)
            {
                return KindOfType.ValueType;
            }

            if(type.IsArray)
            {
                return KindOfType.List;
            }

            if(type.IsClass)
            {
                var fullName = type.FullName;

                if (fullName.StartsWith("System.String"))
                {
                    return KindOfType.ValueType;
                }
                else
                {
                    if(fullName.StartsWith("System.Collections.Generic.List"))
                    {
                        return KindOfType.List;
                    }
                    else
                    {
                        if(fullName.StartsWith("System.Collections.Generic.Dictionary"))
                        {
                            return KindOfType.Dictionary;
                        }
                        else
                        {
                            return KindOfType.Class;
                        }
                    }
                }
            }

            if(type.IsInterface)
            {
                var fullName = type.FullName;

                if (fullName.StartsWith("System.Collections.Generic.IDictionary"))
                {
                    return KindOfType.Dictionary;
                }
                else
                {
                    if(fullName.StartsWith("System.Collections.Generic.IList"))
                    {
                        return KindOfType.List;
                    }
                    else
                    {
                        return KindOfType.Class;
                    }
                }
            }

            throw new NotSupportedException();
        }

        // TODO: fix me!
        private int ProcessObjectOnConvertingToPlaneTree(object source, ContextOfConvertToPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree source = {source}");
#endif

            if(context.ProcessedObjectsDict.ContainsKey(source))
            {
                return context.ProcessedObjectsDict[source];
            }

            var key = context.CurrIndex;
            context.CurrIndex++;

            context.ProcessedObjectsDict[source] = key;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree key = {key}");
#endif

            var type = source.GetType();

            var planeObject = new PlaneObject();
            planeObject.___TypeName = type.FullName;
            context.ObjectsDict[key] = planeObject;
            var planeObjectAsDict = planeObject.Values;

            var propertiesList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree propertiesList.Length = {propertiesList.Length}");
#endif

            foreach(var property in propertiesList)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree property.Name = {property.Name}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree property.PropertyType.FullName = {property.PropertyType.FullName}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree property.PropertyType.IsClass = {property.PropertyType.IsClass}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree property.PropertyType.IsArray = {property.PropertyType.IsArray}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree property.PropertyType.IsEnum = {property.PropertyType.IsEnum}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree property.PropertyType.IsValueType = {property.PropertyType.IsValueType}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree property.PropertyType.IsGenericType = {property.PropertyType.IsGenericType}");
                //planeObjectAsDict[property.Name] = 12;
#endif

                var kindOfType = GetKindOfType(property.PropertyType);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree kindOfType = {kindOfType}");

                if (kindOfType == KindOfType.List)
                {
                    var val = property.GetValue(source);

                    var i = val as System.Collections.IEnumerable;

                    NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree (i != null) = {i != null}");

                    foreach(var d in i)
                    {
                        NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree (d) = {d}");
                    }
                }
#endif

                switch(kindOfType)
                {
                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfType), kindOfType, null);
                }
            }

            return key;
        }
    }
}
