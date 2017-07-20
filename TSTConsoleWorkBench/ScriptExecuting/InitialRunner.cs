using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using GnuClay.Engine.ScriptExecutor.AST.Statements;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using GnuClay.Engine.StandardLibrary.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private NewAdditionalGnuClayEngineComponentContext additionalContext = null;

        private void RunMiddleScript()
        {
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

            var mainContext = GnuClayEngine.Context;

            additionalContext = new NewAdditionalGnuClayEngineComponentContext();

            var functionProvider = new NewFunctionsEngine(mainContext, additionalContext);
            additionalContext.NewFunctionEngine = functionProvider;

            var constTypeProvider = new NewConstTypeProvider();
            additionalContext.ConstTypeProvider = constTypeProvider;

            var numberProvider = new NewNumberProvider(mainContext, additionalContext);
            constTypeProvider.AddProvider(numberProvider);

            var errorsFactory = new NewErrorsFactory(mainContext, additionalContext);
            additionalContext.ErrorsFactory = errorsFactory;

            var userDefinedFunctionsStorage = new NewUserDefinedFunctionsStorage(mainContext, additionalContext);
            additionalContext.UserDefinedFunctionsStorage = userDefinedFunctionsStorage;

            var remoteFunctionsStorage = new NewRemoteFunctionsStorage(mainContext, additionalContext);
            additionalContext.RemoteFunctionsStorage = remoteFunctionsStorage;

            var filter = new CommandFilter();
            filter.Handler = FakeAddOperator;
            filter.HolderKey = selfKey;
            filter.FunctionKey = plusKey;
            filter.TargetKey = 0;

            filter.Params.Add(param_1_Key, new CommandFilterParam() {
                IsAnyType = false,
                TypeKey = numberKey
            });

            filter.Params.Add(param_2_Key, new CommandFilterParam() {
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

            filter.Params.Add(keyKey, new CommandFilterParam() {
            });

            var tmpUserDefinedFunctionModel = new NewUserDefinedFunctionModel();

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

            remoteFunctionsStorage.AddFilter(filter);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = remoteKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam()
            {
            });

            filter.Handler = FakeRemoteHandler_2;

            remoteFunctionsStorage.AddFilter(filter);

            filter = new CommandFilter();
            filter.HolderKey = selfKey;
            filter.FunctionKey = remoteKey;
            filter.TargetKey = doorKey;

            filter.Params.Add(keyKey, new CommandFilterParam()
            {
            });

            filter.Handler = FakeRemoteHandler_3;

            remoteFunctionsStorage.AddFilter(filter);

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
        }

        private void FakeOpen(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeOpen action = {action}");

            action.Result = new NewEntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeOpen action = {action}");
        }

        private void FakeAddOperator(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeAddOperator action = {action}");

            var actionCommand = action.Command;

            var tmpParam_1 = (NewNumberValue)actionCommand.PositionedParams[0].ParamValue;
            var tmpParam_2 = (NewNumberValue)actionCommand.PositionedParams[1].ParamValue;

            NLog.LogManager.GetCurrentClassLogger().Info($"FakeAddOperator tmpParam_1 = {tmpParam_1}");
            NLog.LogManager.GetCurrentClassLogger().Info($"FakeAddOperator tmpParam_2 = {tmpParam_2}");

            action.Result = additionalContext.ConstTypeProvider.CreateConstValue(tmpParam_1.TypeKey, tmpParam_1.OriginalValue + tmpParam_2.OriginalValue);

            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeAddOperator action = {action}");
        }

        private void FakeConsoleLog(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeConsoleLog action = {action}");

            action.Result = new NewEntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeConsoleLog action = {action}");
        }

        private void FakeRemoteHandler_1(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeRemoteHandler_1 action = {action}");

            action.Result = new NewEntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeRemoteHandler_1 action = {action}");
        }

        private void FakeRemoteHandler_2(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeRemoteHandler_2 action = {action}");

            action.Result = new NewEntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeRemoteHandler_2 action = {action}");
        }

        private void FakeRemoteHandler_3(EntityAction action)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Begin FakeRemoteHandler_3 action = {action}");

            action.Result = new NewEntityValue(15);
            action.State = EntityActionState.Completed;

            NLog.LogManager.GetCurrentClassLogger().Info($"End FakeRemoteHandler_3 action = {action}");
        }
    }
}
