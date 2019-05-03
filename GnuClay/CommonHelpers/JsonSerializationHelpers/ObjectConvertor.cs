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

        public PlaneObjectsTree ConvertToPlaneTree(object source)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"ConvertToPlaneTree source = {source}");
#endif

            var context = new ContextOfConvertToPlaneTree();

            var result = new PlaneObjectsTree();

            ProcessObjectOnConvertingToPlaneTree(source, context);

            result.ObjectsDict = context.ObjectsDict;
            return result;
        }

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

            var planeObject = new PlaneObject();
            context.ObjectsDict[key] = planeObject;
            var planeObjectAsDict = planeObject.Values;

            var propertiesList = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

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
#endif

                planeObjectAsDict[property.Name] = 12;
            }

            return key;
        }
    }
}
