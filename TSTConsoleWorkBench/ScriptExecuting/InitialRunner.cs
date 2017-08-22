using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.Engine.StandardLibrary.CommonData;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public class InitialRunner: BaseRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");
            try
            {
                RunMiddleScript();
                //RunScriptsCommands();
                //RunAST();
                //TstWorkWithProperties();
                //TSTRunCodeWithProperties();
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }

        //private void RunAST()
        //{
        //    var addOperatorKey = GnuClayEngine.DataDictionary.GetKey("Add");
        //    var numberKey = GnuClayEngine.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);

        //    var codeBlock = new ASTCodeBlock();

        //    var statement = new ASTExpressionStatement();
        //    codeBlock.Statements.Add(statement);

        //    var addOperator = new ASTBinaryOperator();
        //    statement.Expression = addOperator;

        //    addOperator.OperatorKey = addOperatorKey;

        //    var leftExpr = new ASTConstExpression();
        //    addOperator.Left = leftExpr;

        //    leftExpr.TypeKey = numberKey;
        //    leftExpr.Value = 1.0;

        //    var rightExpr = new ASTConstExpression();
        //    addOperator.Right = rightExpr;

        //    rightExpr.TypeKey = numberKey;
        //    rightExpr.Value = 2.0;

        //    var tmpCodeFrame = GnuClayEngine.ExecutorEngine.Compiler.Compile(codeBlock);
        //    NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);

        //    var context = new GnuClayThreadExecutionContext();
        //    context.MainContext = GnuClayEngine.Context;
        //    var tmpInternalThreadExecutor = new InternalThreadExecutor(tmpCodeFrame, context);

        //    tmpInternalThreadExecutor.Run();
        //}

        //private void RunScriptsCommands()
        //{
        //    var tmpTSTProvider = new TSTValueProvider(GnuClayEngine.Context);
        //    tmpTSTProvider.InitFromZero();
        //    var tmpVal = tmpTSTProvider.Create(15);
        //    var targetKey = GnuClayEngine.DataDictionary.GetKey("SecondMethod");
        //    NLog.LogManager.GetCurrentClassLogger().Info($"SecondMethod targetKey = `{targetKey}`");

        //    var rez = tmpVal.TryCall(targetKey, new List<IValue>());

        //    NLog.LogManager.GetCurrentClassLogger().Info($"SecondMethod rez.Result = `{rez.Result}`");

        //    targetKey = GnuClayEngine.DataDictionary.GetKey("SomeMethod");
        //    NLog.LogManager.GetCurrentClassLogger().Info($"SomeMethod targetKey = `{targetKey}`");

        //    rez = tmpVal.TryCall(targetKey, new List<IValue>());

        //    NLog.LogManager.GetCurrentClassLogger().Info($"SomeMethod rez.Result = `{rez.Result}`");

        //    var numberKey = GnuClayEngine.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);

        //    NLog.LogManager.GetCurrentClassLogger().Info($"numberKey = `{numberKey}`");

        //    var numberValue = GnuClayEngine.Context.TypeProcessingContext.CreateValue(numberKey, 12.0);

        //    NLog.LogManager.GetCurrentClassLogger().Info($"numberValue = `{numberValue}`");

        //    var tmpParamNameKey = GnuClayEngine.DataDictionary.GetKey("a");

        //    var externalMethodInfoKey = GnuClayEngine.DataDictionary.GetKey("Move");
        //    var externalMethodInfo = new ExternalMethodInfo();
        //    externalMethodInfo.MethodKey = externalMethodInfoKey;
        //    externalMethodInfo.HolderKey = numberKey;
        //    externalMethodInfo.Parameters.Add(new ExternalParameterInfo()
        //    {
        //        NameKey = tmpParamNameKey,
        //        ParameterType = numberKey
        //    });

        //    GnuClayEngine.Context.TypeProcessingContext.RegExternalMethod(externalMethodInfo);

        //    rez = numberValue.TryCall(externalMethodInfoKey, new List<IValue>() { numberValue });

        //    NLog.LogManager.GetCurrentClassLogger().Info($"externalMethodInfo rez.Result = `{rez.Result}`");

        //    var somePropertyKey = GnuClayEngine.DataDictionary.GetKey("SomeProperty");
        //    NLog.LogManager.GetCurrentClassLogger().Info($"somePropertyKey = `{somePropertyKey}`");

        //    rez = tmpVal.TrySetProperty(somePropertyKey, numberValue);
        //    NLog.LogManager.GetCurrentClassLogger().Info($"SomeProperty rez = `{rez.Result}`");

        //    var initList = new List<IValue>() { GnuClayEngine.Context.TypeProcessingContext.CreateValue(numberKey, 12.0),
        //            GnuClayEngine.Context.TypeProcessingContext.CreateValue(numberKey, 2.0),
        //            GnuClayEngine.Context.TypeProcessingContext.CreateValue(numberKey, 3.0)};

        //    var arrayKey = GnuClayEngine.DataDictionary.GetKey(StandartTypeNamesConstants.ArrayName);
        //    NLog.LogManager.GetCurrentClassLogger().Info($"arrayKey = `{arrayKey}`");

        //    var arrayVal = GnuClayEngine.Context.TypeProcessingContext.CreateValue(arrayKey, initList);

        //    var getIteratorKey = GnuClayEngine.DataDictionary.GetKey("GetIterator");
        //    NLog.LogManager.GetCurrentClassLogger().Info($"getIteratorKey = `{getIteratorKey}`");

        //    var iterator = arrayVal.TryGetProperty(getIteratorKey).Result;

        //    var moveNextKey = GnuClayEngine.DataDictionary.GetKey("MoveNext");

        //    iterator.TryCall(moveNextKey, new List<IValue>());

        //    var currentValueKey = GnuClayEngine.DataDictionary.GetKey("CurrentValue");

        //    var currentValue = iterator.TryGetProperty(currentValueKey).Result;
        //    NLog.LogManager.GetCurrentClassLogger().Info($"currentValue = `{currentValue}`");

        //    iterator.TryCall(moveNextKey, new List<IValue>());
        //    currentValue = iterator.TryGetProperty(currentValueKey).Result;
        //    NLog.LogManager.GetCurrentClassLogger().Info($"currentValue = `{currentValue}`");

        //    iterator.TryCall(moveNextKey, new List<IValue>());
        //    currentValue = iterator.TryGetProperty(currentValueKey).Result;
        //    NLog.LogManager.GetCurrentClassLogger().Info($"currentValue = `{currentValue}`");

        //    var tmpCodeFrame = new FunctionModel();
        //    tmpCodeFrame.AddCommand(new ScriptCommand()
        //    {
        //        OperationCode = OperationCode.Nop
        //    });

        //    tmpCodeFrame.AddCommand(new ScriptCommand()
        //    {
        //        OperationCode = OperationCode.PushConst,
        //        Key = numberKey,
        //        Value = 1.0
        //    });

        //    tmpCodeFrame.AddCommand(new ScriptCommand()
        //    {
        //        OperationCode = OperationCode.PushConst,
        //        Key = numberKey,
        //        Value = 2.0
        //    });

        //    var addOperatorKey = GnuClayEngine.DataDictionary.GetKey("Add");

        //    tmpCodeFrame.AddCommand(new ScriptCommand()
        //    {
        //        OperationCode = OperationCode.CallBinOp,
        //        Key = addOperatorKey
        //    });

        //    /*tmpCodeFrame.AddCommand(new ScriptCommand()
        //    {
        //        OperationCode = OperationCode.CallBinOp,
        //        Key = addOperatorKey
        //    });*/

        //    NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);
        //    var context = new GnuClayThreadExecutionContext();
        //    context.MainContext = GnuClayEngine.Context;
        //    var tmpInternalThreadExecutor = new InternalThreadExecutor(tmpCodeFrame, context);

        //    tmpInternalThreadExecutor.Run();
        //}

        private GnuClayEngineComponentContext mainContext = null;

        private void RunMiddleScript()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin RunMiddleScript");

            mainContext = GnuClayEngine.Context;
            var CommonKeysEngine = mainContext.CommonKeysEngine;

            var openKey = GnuClayEngine.DataDictionary.GetKey("open");
            var doorKey = GnuClayEngine.DataDictionary.GetKey("door");
            var keyKey = GnuClayEngine.DataDictionary.GetKey("$key");
            var numberKey = CommonKeysEngine.NumberKey;
            var resultVarKey = GnuClayEngine.DataDictionary.GetKey("$result");
            var plusKey = CommonKeysEngine.AddOperatorKey;
            var result_2_VarKey = GnuClayEngine.DataDictionary.GetKey("$result2");
            var consoleKey = GnuClayEngine.DataDictionary.GetKey("console");
            var logKey = GnuClayEngine.DataDictionary.GetKey("log");

            var param_1_Key = CommonKeysEngine.FirstParamKey;
            var param_2_Key = CommonKeysEngine.SecondParamKey;

            var messageParamKey = GnuClayEngine.DataDictionary.GetKey("$message");

            var selfKey = CommonKeysEngine.SelfKey;

            var remoteKey = GnuClayEngine.DataDictionary.GetKey("some remote");

            var assignKey = CommonKeysEngine.AssignOperatorKey;

            

            var functionProvider = mainContext.FunctionsEngine;

            var userDefinedFunctionsStorage = mainContext.UserDefinedFunctionsStorage;

            var remoteFunctionsStorage = mainContext.RemoteFunctionsEngine;

            var filter = new CommandFilter();
            filter.Handler = FakeConsoleLog;
            filter.HolderKey = consoleKey;
            filter.FunctionKey = logKey;

            filter.Params.Add(messageParamKey, new CommandFilterParam()
            {
            });

            var descriptor = functionProvider.AddFilter(filter);

            NLog.LogManager.GetCurrentClassLogger().Info($"RunMiddleScript descriptor = {descriptor}");

            //functionProvider.RemoveFilter(descriptor);

            //functionProvider.AddFilter(filter);
            functionProvider.AddFilter(filter);

            var namedParams = new List<NamedParamInfo>();

            var namedParam = new NamedParamInfo();
            namedParams.Add(namedParam);
            namedParam.ParamName = new EntityValue(messageParamKey);
            namedParam.ParamValue = new EntityValue(doorKey);

            var tmpHolder = mainContext.CommonValuesFactory.SelfValue();

            ulong tmpTarget = 0;

            var resultOfCallByDescription = functionProvider.CallForDecsriptorByNamedParameters(null, null, tmpHolder, descriptor, tmpTarget, namedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"RunMiddleScript resultOfCallByDescription = {resultOfCallByDescription}");

            resultOfCallByDescription = functionProvider.CallAsyncForDecsriptorByNamedParameters(null, null, tmpHolder, descriptor, tmpTarget, namedParams);

            NLog.LogManager.GetCurrentClassLogger().Info($"RunMiddleScript resultOfCallByDescription = {resultOfCallByDescription}");

            var positionedParameters = new List<PositionParamInfo>();

            var positionedParam = new PositionParamInfo();
            positionedParameters.Add(positionedParam);
            positionedParam.ParamValue = new EntityValue(doorKey);
            positionedParam.Position = 0;

            resultOfCallByDescription = functionProvider.CallForDecsriptorByPositionedParameters(null, null, tmpHolder, descriptor, tmpTarget, positionedParameters);

            NLog.LogManager.GetCurrentClassLogger().Info($"RunMiddleScript resultOfCallByDescription = {resultOfCallByDescription}");

            resultOfCallByDescription = functionProvider.CallAsyncForDecsriptorByPositionedParameters(null, null, tmpHolder, descriptor, tmpTarget, positionedParameters);

            NLog.LogManager.GetCurrentClassLogger().Info($"RunMiddleScript resultOfCallByDescription = {resultOfCallByDescription}");

            var tmpUserDefinedCodeFrame = new FunctionModel();
            var tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushVar;
            tmpCommand.Key = keyKey;
            tmpUserDefinedCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.ReturnValue;
            tmpUserDefinedCodeFrame.AddCommand(tmpCommand);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = openKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam() {
            });

            var tmpUserDefinedFunctionModel = new UserDefinedFunctionModel();

            tmpUserDefinedFunctionModel.Filter = filter;
            tmpUserDefinedFunctionModel.FunctionModel = tmpUserDefinedCodeFrame;

            userDefinedFunctionsStorage.AddFunction(tmpUserDefinedFunctionModel);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = remoteKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam()
            {
            });

            filter.Handler = FakeRemoteHandler_1;

            GnuClayEngine.AddRemoteFunction(filter);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = remoteKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam()
            {
            });

            filter.Handler = FakeRemoteHandler_2;

            GnuClayEngine.AddRemoteFunction(filter);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = remoteKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam()
            {
            });

            filter.Handler = FakeRemoteHandler_3;

            GnuClayEngine.AddRemoteFunction(filter);

            var tmpCodeFrame = new FunctionModel();

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushVar;
            tmpCommand.Key = resultVarKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.BeginCallMethod;
            tmpCommand.Key = openKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = doorKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetTarget;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = keyKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetParamName;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushConst;
            tmpCommand.Key = numberKey;
            tmpCommand.Value = 1.0;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetParamVal;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.Call;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.CallBinOp;
            tmpCommand.Key = assignKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand.OperationCode = OperationCode.PushVar;
            tmpCommand.Key = result_2_VarKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushConst;
            tmpCommand.Key = numberKey;
            tmpCommand.Value = 1.0;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushConst;
            tmpCommand.Key = numberKey;
            tmpCommand.Value = 1.0;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.CallBinOp;
            tmpCommand.Key = plusKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.CallBinOp;
            tmpCommand.Key = assignKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = consoleKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.BeginCallMethodOfPrevEntity;
            tmpCommand.Key = logKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushVar;
            tmpCommand.Key = result_2_VarKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetParamVal;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.CallAsyncByPos;
            tmpCodeFrame.AddCommand(tmpCommand);

            //tmpCommand = new ScriptCommand();
            //tmpCommand.OperationCode = OperationCode.BeginCallMethod;
            //tmpCommand.Key = remoteKey;
            //tmpCodeFrame.AddCommand(tmpCommand);

            //tmpCommand = new ScriptCommand();
            //tmpCommand.OperationCode = OperationCode.PushEntity;
            //tmpCommand.Key = doorKey;
            //tmpCodeFrame.AddCommand(tmpCommand);

            //tmpCommand = new ScriptCommand();
            //tmpCommand.OperationCode = OperationCode.SetTarget;
            //tmpCodeFrame.AddCommand(tmpCommand);

            //tmpCommand = new ScriptCommand();
            //tmpCommand.OperationCode = OperationCode.PushEntity;
            //tmpCommand.Key = keyKey;
            //tmpCodeFrame.AddCommand(tmpCommand);

            //tmpCommand = new ScriptCommand();
            //tmpCommand.OperationCode = OperationCode.SetParamName;
            //tmpCodeFrame.AddCommand(tmpCommand);

            //tmpCommand = new ScriptCommand();
            //tmpCommand.OperationCode = OperationCode.PushConst;
            //tmpCommand.Key = numberKey;
            //tmpCommand.Value = 1.0;
            //tmpCodeFrame.AddCommand(tmpCommand);

            //tmpCommand = new ScriptCommand();
            //tmpCommand.OperationCode = OperationCode.SetParamVal;
            //tmpCodeFrame.AddCommand(tmpCommand);

            //tmpCommand = new ScriptCommand();
            //tmpCommand.OperationCode = OperationCode.Call;
            //tmpCodeFrame.AddCommand(tmpCommand);

            NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);

            var resultOfCalling = functionProvider.CallCodeFrame(tmpCodeFrame);

            NLog.LogManager.GetCurrentClassLogger().Info($"End RunMiddleScript resultOfCalling = {resultOfCalling}");

            Thread.Sleep(1000);
        }

        private void FakeOpen(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeOpen action = {action}");

            action.Result = new EntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeOpen action = {action}");
        }

        private void FakeConsoleLog(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeConsoleLog action = {action}");

            action.Result = new EntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeConsoleLog action = {action}");
        }

        private void FakeRemoteHandler_1(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeRemoteHandler_1 action = {action}");

            action.Result = new EntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeRemoteHandler_1 action = {action}");
        }

        private void FakeRemoteHandler_2(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeRemoteHandler_2 action = {action}");

            action.Result = new EntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeRemoteHandler_2 action = {action}");
        }

        private void FakeRemoteHandler_3(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeRemoteHandler_3 action = {action}");

            action.Result = new EntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeRemoteHandler_3 action = {action}");
        }

        private void TstWorkWithProperties()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin TstWorkWithProperties");

            var iteratorKey = GnuClayEngine.DataDictionary.GetKey("tstiterator");
            var propertyKey = GnuClayEngine.DataDictionary.GetKey("CurrentValue");
            var colorKey = GnuClayEngine.DataDictionary.GetKey("color");
            var valueTypeKey = GnuClayEngine.DataDictionary.GetKey("TstValueType");
            var dogKey = GnuClayEngine.DataDictionary.GetKey("dog");
            var blackKey = GnuClayEngine.DataDictionary.GetKey("black");

            //var fiter = new PropertyFilter();
            //fiter.HolderKey = iteratorKey;
            //fiter.PropertyKey = propertyKey;

            //var targetType = typeof(TstIterator);
            //fiter.GetMethod = targetType.GetMethod("GetCurrentValue");
            //fiter.SetMethod = targetType.GetMethod("SetCurrentValue");

            //var descriptor = GnuClayEngine.Context.PropertiesEngine.AddFilter(fiter);

            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties descriptor = {descriptor}");

            var tmpValue = new EntityValue(blackKey);

            //var tmpHolder = new TstIterator(iteratorKey);

            //var prop = GnuClayEngine.Context.PropertiesEngine.FindProperty(tmpHolder, propertyKey);

            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties prop = {prop}");

            //var propInstance = prop.Result;

            //propInstance.ValueFromContainer = tmpValue;

            //var result = propInstance.ValueFromContainer;

            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties result = {result}");

            //fiter = new PropertyFilter();
            //fiter.HolderKey = valueTypeKey;
            //fiter.PropertyKey = propertyKey;

            //targetType = typeof(TstValueType);
            //fiter.GetMethod = targetType.GetMethod("GetCurrentValue");
            //fiter.SetMethod = targetType.GetMethod("SetCurrentValue");

            //var descriptor_2 = GnuClayEngine.Context.PropertiesEngine.AddFilter(fiter);

            //var tmpValueTypeHolder = new TstValueType(valueTypeKey, 2.9);

            //prop = GnuClayEngine.Context.PropertiesEngine.FindProperty(tmpValueTypeHolder, propertyKey);

            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties prop = {prop}");

            //propInstance = prop.Result;
            //propInstance.ValueFromContainer = tmpValue;

            //result = propInstance.ValueFromContainer;

            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties result (4)= {result}");

            //prop = GnuClayEngine.Context.PropertiesEngine.FindProperty(tmpValueTypeHolder, colorKey);
            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties prop = {prop}");
            //propInstance = prop.Result;

            //var result_1 = propInstance.ExecuteSetLogicalProperty(tmpValue, KindOfLogicalOperator.INSERT_FACT_RETURN_VALUE);

            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties (5) result = {result_1}");

            //result = propInstance.ValueFromContainer;

            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties result (6)= {result}");

            var tmpEntityHolder = new EntityValue(dogKey);

            var prop = GnuClayEngine.Context.PropertiesEngine.FindProperty(tmpEntityHolder, colorKey);
            NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties prop = {prop}");
            var propInstance = prop.Result;

            var result_1 = propInstance.ExecuteSetLogicalProperty(tmpValue, KindOfLogicalOperator.WriteFactReturnValue);
            NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties (7) result = {result_1}");

            var result = propInstance.ValueFromContainer;
            NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties result (8) = {result}");

            //prop = GnuClayEngine.Context.PropertiesEngine.FindProperty(tmpHolder, colorKey);
            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties prop = {prop}");
            //propInstance = prop.Result;

            //NLog.LogManager.GetCurrentClassLogger().Info($"TstWorkWithProperties propInstance==null = {propInstance == null}");

            //GnuClayEngine.Context.PropertiesEngine.RemoveFilter(descriptor);
            //GnuClayEngine.Context.PropertiesEngine.RemoveFilter(descriptor_2);

            NLog.LogManager.GetCurrentClassLogger().Info("End TstWorkWithProperties");
        }

        //$var_1 = dog.Color = red;
        private void TSTRunCodeWithProperties()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Begin TSTRunCodeWithProperties");

            mainContext = GnuClayEngine.Context;
            var CommonKeysEngine = mainContext.CommonKeysEngine;

            var doorKey = GnuClayEngine.DataDictionary.GetKey("door");
            var colorKey = GnuClayEngine.DataDictionary.GetKey("color");
            var redKey = GnuClayEngine.DataDictionary.GetKey("red");
            var var_1_Key = GnuClayEngine.DataDictionary.GetKey("$var_1");
            var assignKey = CommonKeysEngine.AssignOperatorKey;
            var param_1_Key = CommonKeysEngine.FirstParamKey;
            var param_2_Key = CommonKeysEngine.SecondParamKey;
            var selfKey = CommonKeysEngine.SelfKey;
          
            var functionProvider = mainContext.FunctionsEngine;

            var tmpCodeFrame = new FunctionModel();

            var tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = doorKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushProp;
            tmpCommand.Key = colorKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = colorKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.CallBinOp;
            tmpCommand.Key = assignKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);

            var resultOfCalling = functionProvider.CallCodeFrame(tmpCodeFrame);

            NLog.LogManager.GetCurrentClassLogger().Info($"End TSTRunCodeWithProperties resultOfCalling = {resultOfCalling}");
        }
    }
}

/*
             NLog.LogManager.GetCurrentClassLogger().Info("Begin RunMiddleScript");

            var openKey = GnuClayEngine.DataDictionary.GetKey("open");
            var doorKey = GnuClayEngine.DataDictionary.GetKey("door");
            var keyKey = GnuClayEngine.DataDictionary.GetKey("$key");
            var numberKey = GnuClayEngine.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);
            var resultVarKey = GnuClayEngine.DataDictionary.GetKey("$result");
            var plusKey = GnuClayEngine.DataDictionary.GetKey("+");
            var result_2_VarKey = GnuClayEngine.DataDictionary.GetKey("$result2");
            var consoleKey = GnuClayEngine.DataDictionary.GetKey("console");
            var logKey = GnuClayEngine.DataDictionary.GetKey("log");

            var param_1_Key = GnuClayEngine.DataDictionary.GetKey("$param1");
            var param_2_Key = GnuClayEngine.DataDictionary.GetKey("$param2");

            var messageParamKey = GnuClayEngine.DataDictionary.GetKey("$message");

            var selfKey = GnuClayEngine.DataDictionary.GetKey("self");

            var remoteKey = GnuClayEngine.DataDictionary.GetKey("some remote");

            mainContext = GnuClayEngine.Context;

            var functionProvider = mainContext.FunctionsEngine;

            var userDefinedFunctionsStorage = mainContext.UserDefinedFunctionsStorage;

            var remoteFunctionsStorage = mainContext.RemoteFunctionsEngine;

            var filter = new CommandFilter();
            filter.Handler = FakeAddOperator;
            filter.HolderKey = selfKey;
            filter.FunctionKey = plusKey;
            filter.TargetKey = 0;

            filter.Params.Add(param_1_Key, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = numberKey
            });

            filter.Params.Add(param_2_Key, new CommandFilterParam()
            {
                IsAnyType = false,
                TypeKey = numberKey
            });

            functionProvider.AddFilter(filter);

            filter = new CommandFilter();
            filter.Handler = FakeConsoleLog;
            filter.HolderKey = consoleKey;
            filter.FunctionKey = logKey;

            filter.Params.Add(messageParamKey, new CommandFilterParam()
            {
            });

            var descriptor = functionProvider.AddFilter(filter);

            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAsyncCall descriptor = {descriptor}");

            functionProvider.RemoveFilter(descriptor);

            functionProvider.AddFilter(filter);
            functionProvider.AddFilter(filter);


            var tmpUserDefinedCodeFrame = new FunctionModel();
            var tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushValFromVar;
            tmpCommand.Key = keyKey;
            tmpUserDefinedCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.ReturnValue;
            tmpUserDefinedCodeFrame.AddCommand(tmpCommand);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = openKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam()
            {
            });

            var tmpUserDefinedFunctionModel = new UserDefinedFunctionModel();

            tmpUserDefinedFunctionModel.Filter = filter;
            tmpUserDefinedFunctionModel.FunctionModel = tmpUserDefinedCodeFrame;

            userDefinedFunctionsStorage.AddFunction(tmpUserDefinedFunctionModel);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = remoteKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam()
            {
            });

            filter.Handler = FakeRemoteHandler_1;

            GnuClayEngine.AddRemoteFunction(filter);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = remoteKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam()
            {
            });

            filter.Handler = FakeRemoteHandler_2;

            GnuClayEngine.AddRemoteFunction(filter);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = remoteKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam()
            {
            });

            filter.Handler = FakeRemoteHandler_3;

            GnuClayEngine.AddRemoteFunction(filter);

            var tmpCodeFrame = new FunctionModel();

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.BeginCallMethod;
            tmpCommand.Key = openKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = doorKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetTarget;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = keyKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetParamName;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushConst;
            tmpCommand.Key = numberKey;
            tmpCommand.Value = 1.0;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetParamVal;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.Call;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetValToVar;
            tmpCommand.Key = resultVarKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushConst;
            tmpCommand.Key = numberKey;
            tmpCommand.Value = 1.0;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushConst;
            tmpCommand.Key = numberKey;
            tmpCommand.Value = 1.0;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.CallBinOp;
            tmpCommand.Key = plusKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetValToVar;
            tmpCommand.Key = result_2_VarKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = consoleKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.BeginCallMethodOfPrevEntity;
            tmpCommand.Key = logKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushValFromVar;
            tmpCommand.Key = result_2_VarKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetParamVal;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.CallAsyncByPos;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.BeginCallMethod;
            tmpCommand.Key = remoteKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = doorKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetTarget;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushEntity;
            tmpCommand.Key = keyKey;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetParamName;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushConst;
            tmpCommand.Key = numberKey;
            tmpCommand.Value = 1.0;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.SetParamVal;
            tmpCodeFrame.AddCommand(tmpCommand);

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.Call;
            tmpCodeFrame.AddCommand(tmpCommand);

            NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);

            var resultOfCalling = functionProvider.CallCodeFrame(tmpCodeFrame);

            NLog.LogManager.GetCurrentClassLogger().Info($"End RunMiddleScript resultOfCalling = {resultOfCalling}");
*/
