using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StandardLibrary.SupportingMachines
{
    public class TypeProcessingContext: BaseGnuClayEngineComponent, ITypeProcessingContext
    {
        private static Type TargetAttribute = typeof(GCSMemberAttribute);
        private static Type VoidType = typeof(void);
        private static Type IValueType = typeof(IValue);
        //private static Type NullValueType = typeof(NullValue);

        public TypeProcessingContext(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        private Dictionary<Type, GCSClassInfo> mGCSClassInfoDict = new Dictionary<Type, GCSClassInfo>();
        private Dictionary<int, GCSClassInfo> mGCSClassInfoDictByKey = new Dictionary<int, GCSClassInfo>();
        private Dictionary<int, ITypeProvider> mProvidersDict = new Dictionary<int, ITypeProvider>();

        public GCSClassInfo RegType<T>(ITypeProvider provider)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RegType");
            var type = typeof(T);

            if (mGCSClassInfoDict.ContainsKey(type))
            {
                return mGCSClassInfoDict[type];
            }

            NLog.LogManager.GetCurrentClassLogger().Info($"RegType `{type.FullName}`");

            var result = CreateClassInfo(type);
            result.TypeKey = provider.TypeKey;
            mGCSClassInfoDict.Add(type, result);
            mGCSClassInfoDictByKey.Add(provider.TypeKey, result);
            mProvidersDict[provider.TypeKey] = provider;
            return result;
        }

        private GCSClassInfo CreateClassInfo(Type type)
        {
            var result = new GCSClassInfo();
            FillSystemMethods(result, type);
            return result;
        }

        private void FillSystemMethods(GCSClassInfo result, Type type)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"CreateClassInfo `{type.FullName}`");
            var methodsList = type.GetMethods().Where(p => p.CustomAttributes.Any(x => x.AttributeType == TargetAttribute));

            var targetsMethods = new List<MethodInfo>();

            foreach (var method in methodsList)
            {
                if (method.ReturnType != VoidType && method.ReturnType != IValueType)
                {
                    throw new NotSupportedException($"Registered method must have void or IValue as return type. Instead of this, `{method.Name}` of `{type.FullName}` is `{method.ReturnType.FullName}`.");
                }

                foreach (var param in method.GetParameters())
                {
                    if (!param.ParameterType.GetInterfaces().Any(p => p == IValueType))
                    {
                        throw new NotSupportedException($"A parameter of registered method must have IValue as self type. Instead of this, parameter `{param.Name}` of `{method.Name}` of `{type.FullName}` is `{param.ParameterType.FullName}`.");
                    }

                    /*if (param.ParameterType == NullValueType)
                    {
                        throw new NotSupportedException($"A parameter of registered method must not have `{NullValueType.FullName}` as self type. Instead of this, parameter `{param.Name}` of `{method.Name}` of `{type.FullName}` is `{param.ParameterType.FullName}`.");
                    }*/
                }

                targetsMethods.Add(method);
            }

            var tmpMethodsDict = targetsMethods.GroupBy(p => p.Name).ToDictionary(p => p.Key, p => p.ToList());

            foreach(var item in tmpMethodsDict)
            {
                var key = Context.DataDictionary.GetKey(item.Key);
                NLog.LogManager.GetCurrentClassLogger().Info($"CreateClassInfo `{key}` `{item.Key}`");

                var functorsList = new List<IGnuClayScriptFunctor>();

                foreach(var method in item.Value)
                {
                    functorsList.Add(new GnuClayScriptSystemFunctor(method));
                }

                result.SystemMethods.Add(key, functorsList);
            }
        }

        public IValue CreateValue(int typeKey, object value)
        {
            return mProvidersDict[typeKey].Create(value);
        }

        public void RegExternalMethod(ExternalMethodInfo methodInfo)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("RegExternalMethod");

            var targetClassInfo = mGCSClassInfoDictByKey[methodInfo.HolderKey];

            List<IGnuClayScriptFunctor> tmpFunctorsList = null;

            if(targetClassInfo.ExternalMethods.ContainsKey(methodInfo.MethodKey))
            {
                tmpFunctorsList = targetClassInfo.ExternalMethods[methodInfo.MethodKey];
            }
            else
            {
                tmpFunctorsList = new List<IGnuClayScriptFunctor>();
                targetClassInfo.ExternalMethods.Add(methodInfo.MethodKey, tmpFunctorsList);
            }

            tmpFunctorsList.Add(new GnuClayScriptExternalFunctor(methodInfo, Context));
        }
    }
}
