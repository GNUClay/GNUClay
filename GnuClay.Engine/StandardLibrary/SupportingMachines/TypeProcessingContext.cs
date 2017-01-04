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
        private Dictionary<ulong, GCSClassInfo> mGCSClassInfoDictByKey = new Dictionary<ulong, GCSClassInfo>();
        private Dictionary<ulong, ITypeProvider> mProvidersDict = new Dictionary<ulong, ITypeProvider>();

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
            mGCSClassInfoDict.Add(type, result);
            result.TypeKey = provider.TypeKey;
            mGCSClassInfoDictByKey.Add(provider.TypeKey, result);
            mProvidersDict[provider.TypeKey] = provider;

            return result;
        }

        private GCSClassInfo CreateClassInfo(Type type)
        {
            var result = new GCSClassInfo();
            FillSystemMethods(result, type);
            FillSystemProperties(result, type);
            return result;
        }

        private void FillSystemMethods(GCSClassInfo result, Type type)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FillSystemMethods `{type.FullName}`");
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
                NLog.LogManager.GetCurrentClassLogger().Info($"FillSystemMethods `{key}` `{item.Key}`");

                var functorsList = new List<IGnuClayScriptFunctor>();

                foreach(var method in item.Value)
                {
                    functorsList.Add(new GnuClayScriptSystemFunctor(method));
                }

                result.SystemMethods.Add(key, functorsList);
            }
        }

        private void FillSystemProperties(GCSClassInfo result, Type type)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"FillSystemProperties `{type.FullName}`");

            var propertiesList = type.GetProperties().Where(p => p.CustomAttributes.Any(x => x.AttributeType == TargetAttribute));

            var targetProperties = new List<PropertyInfo>();

            foreach (var property in propertiesList)
            {
                if (!property.PropertyType.GetInterfaces().Any(p => p == IValueType) && !(property.PropertyType == IValueType))
                {
                    throw new NotSupportedException($"Registered property must have IValue as self type. Instead of this, `{property.Name}` of `{type.FullName}` is `{property.PropertyType.FullName}`.");
                }

                targetProperties.Add(property);
            }

            var propertiesDict = targetProperties.GroupBy(p => p.Name).ToDictionary(p => p.Key, p => p.ToList());

            foreach (var item in propertiesDict)
            {
                var key = Context.DataDictionary.GetKey(item.Key);
                NLog.LogManager.GetCurrentClassLogger().Info($"FillSystemProperties `{key}` `{item.Key}`");

                var abstractPropertiesList = new List<IGnuClayAbstractProperty>();

                foreach (var property in item.Value)
                {
                    abstractPropertiesList.Add(new GnuClayScriptSystemProperty(property));
                }

                result.SystemProperties.Add(key, abstractPropertiesList);
            }
        }

        public IValue CreateValue(ulong typeKey, object value)
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

        private Dictionary<ulong, Dictionary<ulong, BinaryOperatorHandler>> mOperatorsDict = new Dictionary<ulong, Dictionary<ulong, BinaryOperatorHandler>>();

        public void RegBinaryOperator(BinaryOperatorRule rule)
        {
            Dictionary<ulong, BinaryOperatorHandler> tmpDict = null;

            if (mOperatorsDict.ContainsKey(rule.FirstOperandType))
            {
                tmpDict = mOperatorsDict[rule.FirstOperandType];
            }
            else
            {
                tmpDict = new Dictionary<ulong, BinaryOperatorHandler>();

                mOperatorsDict.Add(rule.FirstOperandType, tmpDict);
            }

            tmpDict[rule.SecondOperandType] = rule.OperatorHandler;
        }

        public IValue CallBinaryOperator(ulong operatorKey, IValue firstOperand, IValue secondOperand)
        {
            var tmpHandler = mOperatorsDict[firstOperand.TypeKey][secondOperand.TypeKey];
            return tmpHandler(firstOperand, secondOperand);
        }
    }
}
