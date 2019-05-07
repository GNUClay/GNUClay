using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    public class ObjectConvertor
    {
        #region public members
        public PlaneObjectsTree ConvertToPlaneTree(object source)
        {
            if(!source.GetType().IsClass)
            {
                throw new NotSupportedException();
            }

            var context = new ContextOfConvertToPlaneTree();

            var result = new PlaneObjectsTree();
            ProcessObjectOnConvertingToPlaneTree(source, context);

            result.ObjectsDict = context.ObjectsDict;
            return result;
        }

        // TODO: fix me!
        public T ConvertFromPlaneTree<T>(PlaneObjectsTree source, List<Type> knownTypes) where T: new()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ConvertFromPlaneTree source = {source}");
#endif

            var targetType = typeof(T);

            if (knownTypes == null)
            {
                knownTypes = new List<Type>() { targetType };
            }
            else
            {
                if(!knownTypes.Contains(targetType))
                {
                    knownTypes.Add(targetType);
                }
            }

            var context = CreateContext(source, knownTypes);

            var rootObject = source.ObjectsDict[0];

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ConvertFromPlaneTree rootObject = {rootObject}");
#endif

            //throw new NotImplementedException();

            var initObj = ProcessObjectOnConvertingFromPlaneTree(rootObject, context);

            return (T)initObj;
        }
        #endregion

        #region private
        private class ContextOfConvertToPlaneTree
        {
            public int CurrIndex { get; set; }
            public Dictionary<object, int> ProcessedObjectsDict { get; set; } = new Dictionary<object, int>();
            public Dictionary<int, PlaneObject> ObjectsDict { get; set; } = new Dictionary<int, PlaneObject>();
        }

        private class ContextOfConvertFromPlaneTree
        {
            public Dictionary<int, PlaneObject> ObjectsDict { get; set; }
            public Dictionary<int, object> ProcessedObjectsDict { get; set; } = new Dictionary<int, object>();
            public Dictionary<string, Type> TypesDictByFullNames { get; set; } = new Dictionary<string, Type>();
            public Dictionary<string, Dictionary<string, Type>> TypesDictByNamespacesAndNames { get; set; } = new Dictionary<string, Dictionary<string, Type>>();

            public Type GetType(PlaneObject source)
            {
                var fullTypeName = source.FullTypeName;

                if(TypesDictByFullNames.ContainsKey(fullTypeName))
                {
                    return TypesDictByFullNames[fullTypeName];
                }

                throw new NotImplementedException();
            }
        }

        // TODO: fix me!
        private ContextOfConvertFromPlaneTree CreateContext(PlaneObjectsTree source, List<Type> knownTypes)
        {
            knownTypes = knownTypes.Distinct().ToList();

            var context = new ContextOfConvertFromPlaneTree();
            context.ObjectsDict = source.ObjectsDict;

            foreach(var knownType in knownTypes)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ConvertFromPlaneTree knownType.FullName = {knownType.FullName}");
#endif

                context.TypesDictByFullNames[knownType.FullName] = knownType;

                //var dataContractAttribute = knownType.GetCustomAttribute<DataContractAttribute>();
            }

            return context;
        }

        // TODO: fix me!
        private object ProcessObjectOnConvertingFromPlaneTree(PlaneObject source, ContextOfConvertFromPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree source = {source}");
#endif

            if(context.ProcessedObjectsDict.ContainsKey(source.Key))
            {
                return context.ProcessedObjectsDict[source.Key];
            }

            var type = context.GetType(source);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree type.FullName = {type.FullName}");
#endif

            var result = Activator.CreateInstance(type);

            context.ProcessedObjectsDict[source.Key] = result;

            var propertiesList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propertiesDict = propertiesList.ToDictionary(p => p.Name, p => p);

            var sourcePropertiesList = source.PropertiesList;

            foreach (var sourcePropertyItem in sourcePropertiesList)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree sourcePropertyItem = {sourcePropertyItem}");
#endif

                var prop = propertiesDict[sourcePropertyItem.Name];

                var restoredValue = DispatchObjectOnConvertingFromPlaneTree(sourcePropertyItem, prop.PropertyType, context);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree restoredValue = {restoredValue}");
#endif

                prop.SetValue(result, restoredValue);
            }

            return result;
        }

        // TODO: fix me!
        private object DispatchObjectOnConvertingFromPlaneTree(PlaneObjectProp source, Type targetType, ContextOfConvertFromPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchObjectOnConvertingFromPlaneTree source = {source}");
#endif

            var kindOfType = source.Kind;

            switch(kindOfType)
            {
                case KindOfPlaneObjectPropType.Null:
                    return null;

                case KindOfPlaneObjectPropType.Class:
                    {
                        var key = source.Key;

#if DEBUG
                        NLog.LogManager.GetCurrentClassLogger().Info($"DispatchObjectOnConvertingFromPlaneTree key = {key}");
#endif
                        var planeObject = context.ObjectsDict[key];

#if DEBUG
                        NLog.LogManager.GetCurrentClassLogger().Info($"DispatchObjectOnConvertingFromPlaneTree planeObject = {planeObject}");
#endif

                        return ProcessObjectOnConvertingFromPlaneTree(planeObject, context);
                    }
                    

                case KindOfPlaneObjectPropType.ValueType:
                    return Convert.ChangeType(source.Value, targetType);

                case KindOfPlaneObjectPropType.List:
                    return ProcessListOnConvertingFromPlaneTree(source.List, context);

                case KindOfPlaneObjectPropType.Dictionary:
                    return ProcessDictionaryOnConvertingFromPlaneTree(source.Dict, context);

                default:
                    throw new ArgumentOutOfRangeException(nameof(kindOfType), kindOfType, null);
            }

            throw new NotImplementedException();
        }

        // TODO: fix me!
        private object ProcessListOnConvertingFromPlaneTree(PlaneObjectList source, ContextOfConvertFromPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree source = {source}");
#endif

            var type = Type.GetType(source.FullTypeName);

            var result = Activator.CreateInstance(type, source.List.Count);

            var resultAsList = result as System.Collections.IList;

            Type elementType = null;

            if(type.IsArray)
            {
                elementType = type.GetElementType();
            }
            else
            {
                elementType = type.GetGenericArguments()[0];
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree elementType = {elementType}");
#endif

            var i = -1;

            foreach (var item in source.List)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree item = {item}");
#endif

                var restoredValue = DispatchObjectOnConvertingFromPlaneTree(item, elementType, context);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree restoredValue = {restoredValue}");
#endif

                if(type.IsArray)
                {
                    i++;
                    resultAsList[i] = restoredValue;
                }
                else
                {
                    resultAsList.Add(restoredValue);
                }
            }

            return result;
        }

        // TODO: fix me!
        private object ProcessDictionaryOnConvertingFromPlaneTree(PlaneObjectDictionary source, ContextOfConvertFromPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingFromPlaneTree source = {source}");
#endif

            var type = Type.GetType(source.FullTypeName);

            var result = Activator.CreateInstance(type);

            var addMethod = type.GetMethod("Add");

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingFromPlaneTree addMethod.GetParameters().Length = {addMethod.GetParameters().Length}");
#endif

            return result;
        }

        private KindOfPlaneObjectPropType GetKindOfType(Type type)
        {
            if (type.IsValueType)
            {
                return KindOfPlaneObjectPropType.ValueType;
            }

            if(type.IsEnum)
            {
                return KindOfPlaneObjectPropType.ValueType;
            }

            if(type.IsArray)
            {
                return KindOfPlaneObjectPropType.List;
            }

            if(type.IsClass)
            {
                var fullName = type.FullName;

                if (fullName.StartsWith("System.String"))
                {
                    return KindOfPlaneObjectPropType.ValueType;
                }
                else
                {
                    if(fullName.StartsWith("System.Collections.Generic.List"))
                    {
                        return KindOfPlaneObjectPropType.List;
                    }
                    else
                    {
                        if(fullName.StartsWith("System.Collections.Generic.Dictionary"))
                        {
                            return KindOfPlaneObjectPropType.Dictionary;
                        }
                        else
                        {
                            return KindOfPlaneObjectPropType.Class;
                        }
                    }
                }
            }

            if(type.IsInterface)
            {
                var fullName = type.FullName;

                if (fullName.StartsWith("System.Collections.Generic.IDictionary"))
                {
                    return KindOfPlaneObjectPropType.Dictionary;
                }
                else
                {
                    if(fullName.StartsWith("System.Collections.Generic.IList"))
                    {
                        return KindOfPlaneObjectPropType.List;
                    }
                    else
                    {
                        return KindOfPlaneObjectPropType.Class;
                    }
                }
            }

            throw new NotSupportedException();
        }

        private PlaneObjectProp ProcessObjectOnConvertingToPlaneTree(object source, ContextOfConvertToPlaneTree context)
        {
            if(source == null)
            {
                return new PlaneObjectProp
                {
                    Kind = KindOfPlaneObjectPropType.Null,
                    Value = null
                };
            }

            if(context.ProcessedObjectsDict.ContainsKey(source))
            {
                return new PlaneObjectProp
                {
                    Kind = KindOfPlaneObjectPropType.Class,
                    Key = context.ProcessedObjectsDict[source]
                }; 
            }

            var key = context.CurrIndex;
            context.CurrIndex++;

            context.ProcessedObjectsDict[source] = key;

            var type = source.GetType();

            var planeObject = new PlaneObject
            {
                FullTypeName = type.FullName,
                Key = key
            };

            var result = new PlaneObjectProp
            {
                Kind = KindOfPlaneObjectPropType.Class,
                Key = key
            };

            context.ObjectsDict[key] = planeObject;

            var dataContractAttribute = type.GetCustomAttribute<DataContractAttribute>();

            if (dataContractAttribute == null)
            {
                planeObject.TypeName = type.Name;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(dataContractAttribute.Name))
                {
                    planeObject.TypeName = type.Name;
                }
                else
                {
                    planeObject.TypeName = dataContractAttribute.Name;
                }

                planeObject.Namespace = dataContractAttribute.Namespace;
            }

            var propertiesList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach(var property in propertiesList)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree property.Name = {property.Name}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree property.PropertyType.FullName = {property.PropertyType.FullName}");
#endif

                var savedPropItem = new PlaneObjectProp()
                {
                    Name = property.Name
                };

                planeObject.PropertiesList.Add(savedPropItem);

                var val = property.GetValue(source);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree val = {val}");
#endif

                if(val == null)
                {
                    savedPropItem.Kind = KindOfPlaneObjectPropType.Null;
                    savedPropItem.Value = null;
                    continue;
                }

                var kindOfType = GetKindOfType(property.PropertyType);
                
#if DEBUG     
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree val.GetType() = {val.GetType()}");
#endif

                var savedValue = DispatchObjectOnConvertingToPlaneTree(val, kindOfType, context);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree savedValue = {savedValue}");
#endif

                var kindOfSavedValue = savedValue.Kind;

                savedPropItem.Kind = kindOfSavedValue;

                switch (kindOfSavedValue)
                {
                    case KindOfPlaneObjectPropType.Null:
                        savedPropItem.Value = null;
                        break;

                    case KindOfPlaneObjectPropType.Class:
                        savedPropItem.Key = savedValue.Key;
                        break;

                    case KindOfPlaneObjectPropType.ValueType:
                        savedPropItem.Value = savedValue.Value;
                        savedPropItem.FullTypeName = savedValue.FullTypeName;
                        break;

                    case KindOfPlaneObjectPropType.List:
                        savedPropItem.List = savedValue.List;
                        break;

                    case KindOfPlaneObjectPropType.Dictionary:
                        savedPropItem.Dict = savedValue.Dict;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(kindOfSavedValue), kindOfSavedValue, null);
                }

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree result = {result}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree savedPropItem = {savedPropItem}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingToPlaneTree planeObject = {planeObject}");
#endif
            }

            return result;
        }

        private PlaneObjectProp DispatchObjectOnConvertingToPlaneTree(object source, KindOfPlaneObjectPropType kindOfType, ContextOfConvertToPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchObjectOnConvertingToPlaneTree source = {source}");
            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchObjectOnConvertingToPlaneTree kindOfType = {kindOfType}");
#endif

            if (source == null)
            {
                return new PlaneObjectProp
                {
                    Kind = KindOfPlaneObjectPropType.Null,
                    Value = null
                };
            }

            switch (kindOfType)
            {
                case KindOfPlaneObjectPropType.Class:
                    return ProcessObjectOnConvertingToPlaneTree(source, context);

                case KindOfPlaneObjectPropType.ValueType:
                    return new PlaneObjectProp
                    {
                        Kind = KindOfPlaneObjectPropType.ValueType,
                        FullTypeName = source.GetType().FullName,
                        Value = source
                    };

                case KindOfPlaneObjectPropType.List:
                    return ProcessListOnConvertingToPlaneTree(source, context);

                case KindOfPlaneObjectPropType.Dictionary:
                    return ProcessDictionaryOnConvertingToPlaneTree(source, context);

                default:
                    throw new ArgumentOutOfRangeException(nameof(kindOfType), kindOfType, null);
            }

            throw new NotSupportedException();
        }

        private PlaneObjectProp ProcessListOnConvertingToPlaneTree(object source, ContextOfConvertToPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingToPlaneTree source = {source}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingToPlaneTree source.GetType().FullName = {source.GetType().FullName}");
#endif

            var result = new PlaneObjectProp();
            var resultList = new PlaneObjectList();
            result.Kind = KindOfPlaneObjectPropType.List;
            result.List = resultList;
            resultList.FullTypeName = source.GetType().FullName;

            var sourceList = source as System.Collections.IEnumerable;

            if(sourceList == null)
            {
                throw new ArgumentNullException(nameof(sourceList));
            }

            foreach(var item in sourceList)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingToPlaneTree item = {item}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingToPlaneTree item?.GetType().FullName = {item?.GetType().FullName}");
#endif

                if(item == null)
                {
                    resultList.List.Add(new PlaneObjectProp {
                        Kind = KindOfPlaneObjectPropType.Null,
                        Value = null
                    });
                    continue;
                }

                var type = item.GetType();
                var kindOfType = GetKindOfType(type);
                var savedValue = DispatchObjectOnConvertingToPlaneTree(item, kindOfType, context);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingToPlaneTree savedValue = {savedValue}");
#endif
                resultList.List.Add(savedValue);
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingToPlaneTree result = {result}");
#endif

            return result;
        }

        private PlaneObjectProp ProcessDictionaryOnConvertingToPlaneTree(object source, ContextOfConvertToPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree source = {source}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree source.GetType().FullName = {source.GetType().FullName}");
#endif

            var result = new PlaneObjectProp();
            result.Kind = KindOfPlaneObjectPropType.Dictionary;
            var resultDict = new PlaneObjectDictionary();
            result.Dict = resultDict;
            resultDict.FullTypeName = source.GetType().FullName;

            var sourceList = source as System.Collections.IEnumerable;

            if (sourceList == null)
            {
                throw new ArgumentNullException(nameof(sourceList));
            }

            foreach (var item in sourceList)
            {
                var type = item.GetType();
                var propertiesList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
                var propertiesDict = propertiesList.ToDictionary(p => p.Name, p => p);

                var keyProp = propertiesDict["Key"];
                var key = keyProp.GetValue(item);
                type = key.GetType();

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree key = {key}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree type.FullName = {type.FullName}");
#endif

                var kindOfType = GetKindOfType(type);

                var savedKey = DispatchObjectOnConvertingToPlaneTree(key, kindOfType, context);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree savedKey = {savedKey}");
#endif

                var valProp = propertiesDict["Value"];
                var val = valProp.GetValue(item);
                type = val.GetType();

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree val = {val}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree type.FullName = {type.FullName}");
#endif

                kindOfType = GetKindOfType(type);

                var savedVal = DispatchObjectOnConvertingToPlaneTree(val, kindOfType, context);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingToPlaneTree savedVal = {savedVal}");
#endif

                resultDict.List.Add(new KeyValuePair<PlaneObjectProp, PlaneObjectProp>(savedKey, savedVal));
            }

            return result;
        }
        #endregion
    }
}
