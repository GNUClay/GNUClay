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

            var type = context.GetType(source);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree type.FullName = {type.FullName}");
#endif

            var result = Activator.CreateInstance(type);

            context.ProcessedObjectsDict[source.Key] = result;

            var sourcePropertiesList = source.PropertiesList;

            foreach (var sourcePropertyItem in sourcePropertiesList)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree sourcePropertyItem = {sourcePropertyItem}");
#endif
            }

            //var propertiesList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            //foreach (var property in propertiesList)
            //{
            //#if DEBUG
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree property.Name = {property.Name}");
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree property.PropertyType = {property.PropertyType}");
            //#endif

            //                if (!source.Values.ContainsKey(property.Name))
            //                {
            //                    continue;
            //                }

            //                var kindOfType = GetKindOfType(property.PropertyType);
            //                var val = source.Values[property.Name];

            //#if DEBUG
            //                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree kindOfType = {kindOfType}");
            //                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree val = {val}");
            //                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree val?.GetType().FullName = {val?.GetType().FullName}");
            //#endif

            //                var restoredVal = DispatchObjectOnConvertingFromPlaneTree(val, kindOfType, property.PropertyType, context);

            //#if DEBUG
            //                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessObjectOnConvertingFromPlaneTree restoredVal = {restoredVal}");
            //#endif

            //                property.SetValue(result, restoredVal);
            //}

            return result;
        }

        // TODO: fix me!
        private object DispatchObjectOnConvertingFromPlaneTree(object source, KindOfPlaneObjectPropType kindOfType, Type type, ContextOfConvertFromPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchObjectOnConvertingFromPlaneTree source = {source}");
#endif

            if (source == null)
            {
                return null;
            }

            switch (kindOfType)
            {
                case KindOfPlaneObjectPropType.ValueType:
                    return Convert.ChangeType(source, type);

                case KindOfPlaneObjectPropType.List:
                    return ProcessListOnConvertingFromPlaneTree(source, type, context);

                case KindOfPlaneObjectPropType.Dictionary:
                    return ProcessDictionaryOnConvertingFromPlaneTree(source, type, context);

                default:
                    throw new ArgumentOutOfRangeException(nameof(kindOfType), kindOfType, null);
            }

            throw new NotImplementedException();
        }

        // TODO: fix me!
        private object ProcessListOnConvertingFromPlaneTree(object source, Type type, ContextOfConvertFromPlaneTree context)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree type.IsArray = {type.IsArray}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree type.IsGenericType = {type.IsGenericType}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree type.GenericTypeArguments.Length = {type.GenericTypeArguments.Length}");
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree type.GetElementType() = {type.GetElementType()}");
#endif

            var sourceList = source as System.Collections.ICollection;

            if (sourceList == null)
            {
                throw new ArgumentNullException(nameof(sourceList));
            }

            object result = null;

            if (type.IsInterface)
            {
                var fullName = type.FullName;

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree fullName = {fullName}");
#endif

                var genericPos = fullName.IndexOf("`");

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree genericPos = {genericPos}");
#endif

                var genericPart = fullName.Substring(genericPos);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree genericPart = {genericPart}");
#endif

                fullName = $"System.Collections.Generic.List{genericPart}";

                type = Type.GetType(fullName);
            }
            else
            {
                if(type.IsArray)
                {
#if DEBUG
                    NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree sourceList.Count = {sourceList.Count}");
#endif

                    result = Activator.CreateInstance(type, sourceList.Count);
                }
                else
                {
                    result = Activator.CreateInstance(type);
                }
            }

            foreach(var item in sourceList)
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree item = {item}");
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessListOnConvertingFromPlaneTree item.GetType().FullName = {item.GetType().FullName}");
#endif
            }

            return result;
        }

        // TODO: fix me!
        private object ProcessDictionaryOnConvertingFromPlaneTree(object source, Type type, ContextOfConvertFromPlaneTree context)
        {
            if(type.IsInterface)
            {
                var fullName = type.FullName;

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingFromPlaneTree fullName = {fullName}");
#endif

                var genericPos = fullName.IndexOf("`");

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingFromPlaneTree genericPos = {genericPos}");
#endif

                var genericPart = fullName.Substring(genericPos);

#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"ProcessDictionaryOnConvertingFromPlaneTree genericPart = {genericPart}");
#endif

                fullName = $"System.Collections.Generic.Dictionary{genericPart}";

                type = Type.GetType(fullName);
            }

            var result = Activator.CreateInstance(type);

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
