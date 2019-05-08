using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;
using GnuClay.CommonHelpers.ReflectionHelpers;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    public class ObjectConvertor
    {
        #region public members
        public PlaneObjectsTree ConvertToPlaneTree(object source, float version)
        {
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

        public T ConvertFromPlaneTree<T>(PlaneObjectsTree source, ITypeFactory typeFactory) where T: new()
        {
            var context = CreateContext(source, typeFactory);

            var rootObject = source.ObjectsDict[0];

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
            public ITypeFactory TypeFactory { get; set; }

            public Type GetType(string name)
            {
                return TypeFactory.GetTypeByName(name);
            }
        }

        // TODO: fix me!
        private ContextOfConvertFromPlaneTree CreateContext(PlaneObjectsTree source, ITypeFactory typeFactory)
        {
            var context = new ContextOfConvertFromPlaneTree
            {
                ObjectsDict = source.ObjectsDict,
                TypeFactory = typeFactory
            };

            return context;
        }

        private object ProcessObjectOnConvertingFromPlaneTree(PlaneObject source, ContextOfConvertFromPlaneTree context)
        {
            if(context.ProcessedObjectsDict.ContainsKey(source.Key))
            {
                return context.ProcessedObjectsDict[source.Key];
            }

            var type = context.GetType(source.TypeName);

            var result = Activator.CreateInstance(type);

            context.ProcessedObjectsDict[source.Key] = result;

            var propertiesList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propertiesDict = propertiesList.ToDictionary(p => p.Name, p => p);

            var sourcePropertiesList = source.PropertiesList;

            foreach (var sourcePropertyItem in sourcePropertiesList)
            {
                var prop = propertiesDict[sourcePropertyItem.Name];

                var restoredValue = DispatchObjectOnConvertingFromPlaneTree(sourcePropertyItem, prop.PropertyType, context);

                prop.SetValue(result, restoredValue);
            }

            return result;
        }

        private object DispatchObjectOnConvertingFromPlaneTree(PlaneObjectProp source, Type targetType, ContextOfConvertFromPlaneTree context)
        {
            var kindOfType = source.Kind;

            switch(kindOfType)
            {
                case KindOfPlaneObjectPropType.Null:
                    return null;

                case KindOfPlaneObjectPropType.Class:
                    var key = source.Key;
                    var planeObject = context.ObjectsDict[key];
                    return ProcessObjectOnConvertingFromPlaneTree(planeObject, context);

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

        private object ProcessListOnConvertingFromPlaneTree(PlaneObjectList source, ContextOfConvertFromPlaneTree context)
        {
            var type = context.GetType(source.TypeName);

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

            var i = -1;

            foreach (var item in source.List)
            {
                var restoredValue = DispatchObjectOnConvertingFromPlaneTree(item, elementType, context);

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

        private object ProcessDictionaryOnConvertingFromPlaneTree(PlaneObjectDictionary source, ContextOfConvertFromPlaneTree context)
        {
            var type = context.GetType(source.TypeName);

            var result = Activator.CreateInstance(type);

            var addMethod = type.GetMethod("Add");

            var genericArgumentsList = type.GetGenericArguments();
            var keyType = genericArgumentsList[0];
            var valType = genericArgumentsList[1];

            foreach(var kvpItem in source.List)
            {
                var keyItem = kvpItem.Key;
                var valItem = kvpItem.Value;

                var restoredKeyItem = DispatchObjectOnConvertingFromPlaneTree(keyItem, keyType, context);
                var restoredValueItem = DispatchObjectOnConvertingFromPlaneTree(valItem, valType, context);

                addMethod.Invoke(result, new object[] { restoredKeyItem, restoredValueItem });
            }

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
                TypeName = TypeHelper.RemoveLibInfoFromFullName(type.FullName),
                Key = key
            };

            var result = new PlaneObjectProp
            {
                Kind = KindOfPlaneObjectPropType.Class,
                Key = key
            };

            context.ObjectsDict[key] = planeObject;

            var propertiesList = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach(var property in propertiesList)
            {
                var savedPropItem = new PlaneObjectProp()
                {
                    Name = property.Name
                };

                planeObject.PropertiesList.Add(savedPropItem);

                var val = property.GetValue(source);

                if(val == null)
                {
                    savedPropItem.Kind = KindOfPlaneObjectPropType.Null;
                    savedPropItem.Value = null;
                    continue;
                }

                var kindOfType = GetKindOfType(property.PropertyType);
                
                var savedValue = DispatchObjectOnConvertingToPlaneTree(val, kindOfType, context);

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
                        savedPropItem.TypeName = savedValue.TypeName;
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
            }

            return result;
        }

        private PlaneObjectProp DispatchObjectOnConvertingToPlaneTree(object source, KindOfPlaneObjectPropType kindOfType, ContextOfConvertToPlaneTree context)
        {
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
                        TypeName = TypeHelper.RemoveLibInfoFromFullName(source.GetType().FullName),
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
            var result = new PlaneObjectProp();
            var resultList = new PlaneObjectList();
            result.Kind = KindOfPlaneObjectPropType.List;
            result.List = resultList;
            resultList.TypeName = TypeHelper.RemoveLibInfoFromFullName(source.GetType().FullName);

            var sourceList = source as System.Collections.IEnumerable;

            if(sourceList == null)
            {
                throw new ArgumentNullException(nameof(sourceList));
            }

            foreach(var item in sourceList)
            {
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
                resultList.List.Add(savedValue);
            }

            return result;
        }

        private PlaneObjectProp ProcessDictionaryOnConvertingToPlaneTree(object source, ContextOfConvertToPlaneTree context)
        {
            var result = new PlaneObjectProp();
            result.Kind = KindOfPlaneObjectPropType.Dictionary;
            var resultDict = new PlaneObjectDictionary();
            result.Dict = resultDict;
            resultDict.TypeName = TypeHelper.RemoveLibInfoFromFullName(source.GetType().FullName);

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

                var kindOfType = GetKindOfType(type);

                var savedKey = DispatchObjectOnConvertingToPlaneTree(key, kindOfType, context);

                var valProp = propertiesDict["Value"];
                var val = valProp.GetValue(item);
                type = val.GetType();

                kindOfType = GetKindOfType(type);

                var savedVal = DispatchObjectOnConvertingToPlaneTree(val, kindOfType, context);

                resultDict.List.Add(new KeyValuePair<PlaneObjectProp, PlaneObjectProp>(savedKey, savedVal));
            }

            return result;
        }
        #endregion
    }
}
