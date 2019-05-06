using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;
using System.Linq;

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

                //if (kindOfType == KindOfType.List)
                //{
                //    var val = property.GetValue(source);

                //    var i = val as System.Collections.IEnumerable;

                //    NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree (i != null) = {i != null}");

                //    foreach(var d in i)
                //    {
                //        NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree (d) = {d}");
                //    }
                //}
#endif

                var val = property.GetValue(source);
                var savedValue = DispatchObjectOnConvertingToPlaneTree(val, kindOfType, context);

                planeObjectAsDict[property.Name] = savedValue;
            }

            return key;
        }

        private object DispatchObjectOnConvertingToPlaneTree(object source, KindOfType kindOfType, ContextOfConvertToPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchObjectOnConvertingToPlaneTree source = {source}");
#endif

            if(source == null)
            {
                return null;
            }

            switch (kindOfType)
            {
                case KindOfType.Class:
                    return ProcessObjectOnConvertingToPlaneTree(source, context);

                case KindOfType.ValueType:
                    return source;

                case KindOfType.List:
                    return ProcessListOnConvertingToPlaneTree(source, context);

                case KindOfType.Dictionary:
                    return ProcessDictionaryOnConvertingToPlaneTree(source, context);

                default:
                    throw new ArgumentOutOfRangeException(nameof(kindOfType), kindOfType, null);
            }

            throw new NotSupportedException();
        }

        // TODO: fix me!
        private List<object> ProcessListOnConvertingToPlaneTree(object source, ContextOfConvertToPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingToPlaneTree source = {source}");
#endif

            var result = new List<object>();

            var sourceList = source as System.Collections.IEnumerable;

            if(sourceList == null)
            {
                throw new ArgumentNullException(nameof(sourceList));
            }

            foreach(var item in sourceList)
            {
                if(item == null)
                {
                    result.Add(null);
                    continue;
                }

                var type = item.GetType();
                var kindOfType = GetKindOfType(type);
                var savedValue = DispatchObjectOnConvertingToPlaneTree(item, kindOfType, context);
                result.Add(savedValue);
            }

            return result;
        }

        private Dictionary<object, object> ProcessDictionaryOnConvertingToPlaneTree(object source, ContextOfConvertToPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree source = {source}");
#endif

            var result = new Dictionary<object, object>();

            var sourceList = source as System.Collections.IEnumerable;

            if (sourceList == null)
            {
                throw new ArgumentNullException(nameof(sourceList));
            }

            foreach (var item in sourceList)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree item = {item}");
#endif

                var type = item.GetType();
                var propertiesList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var propertiesDict = propertiesList.ToDictionary(p => p.Name, p => p);
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree type.FullName = {type.FullName}");
                
                foreach (var property in propertiesList)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree property.Name = {property.Name}");
                    NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree property.PropertyType.FullName = {property.PropertyType.FullName}");
                }
#endif
                var keyProp = propertiesDict["Key"];
                var key = keyProp.GetValue(item);
                type = key.GetType();
                var kindOfType = GetKindOfType(type);
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree key = {key}");
#endif

                var savedKey = DispatchObjectOnConvertingToPlaneTree(item, kindOfType, context);

                var valProp = propertiesDict["Value"];
                var val = valProp.GetValue(item);
                type = val.GetType();
                kindOfType = GetKindOfType(type);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree val = {val}");
#endif

                var savedVal = DispatchObjectOnConvertingToPlaneTree(item, kindOfType, context);

                result[savedKey] = savedVal;
            }

            return result;
        }
    }
}
