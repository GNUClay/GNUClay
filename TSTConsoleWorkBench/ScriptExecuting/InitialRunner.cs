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

        private void RunAST()
        {
            var addOperatorKey = GnuClayEngine.DataDictionary.GetKey("Add");
            var numberKey = GnuClayEngine.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);

            var codeBlock = new ASTCodeBlock();

            var statement = new ASTExpressionStatement();
            codeBlock.Statements.Add(statement);

            var addOperator = new ASTBinaryOperator();
            statement.Expression = addOperator;

            addOperator.OperatorKey = addOperatorKey;

            var leftExpr = new ASTConstExpression();
            addOperator.Left = leftExpr;

            leftExpr.TypeKey = numberKey;
            leftExpr.Value = 1.0;

            var rightExpr = new ASTConstExpression();
            addOperator.Right = rightExpr;

            rightExpr.TypeKey = numberKey;
            rightExpr.Value = 2.0;

            var tmpCodeFrame = GnuClayEngine.ExecutorEngine.Compiler.Compile(codeBlock);
            NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);

            var context = new GnuClayThreadExecutionContext();
            context.MainContext = GnuClayEngine.Context;
            var tmpInternalThreadExecutor = new InternalThreadExecutor(tmpCodeFrame, context);

            tmpInternalThreadExecutor.Run();
        }

        private void RunScriptsCommands()
        {
            var tmpTSTProvider = new TSTValueProvider(GnuClayEngine.Context);
            tmpTSTProvider.InitFromZero();
            var tmpVal = tmpTSTProvider.Create(15);
            var targetKey = GnuClayEngine.DataDictionary.GetKey("SecondMethod");
            NLog.LogManager.GetCurrentClassLogger().Info($"SecondMethod targetKey = `{targetKey}`");

            var rez = tmpVal.TryCall(targetKey, new List<IValue>());

            NLog.LogManager.GetCurrentClassLogger().Info($"SecondMethod rez.Result = `{rez.Result}`");

            targetKey = GnuClayEngine.DataDictionary.GetKey("SomeMethod");
            NLog.LogManager.GetCurrentClassLogger().Info($"SomeMethod targetKey = `{targetKey}`");

            rez = tmpVal.TryCall(targetKey, new List<IValue>());

            NLog.LogManager.GetCurrentClassLogger().Info($"SomeMethod rez.Result = `{rez.Result}`");

            var numberKey = GnuClayEngine.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);

            NLog.LogManager.GetCurrentClassLogger().Info($"numberKey = `{numberKey}`");

            var numberValue = GnuClayEngine.Context.TypeProcessingContext.CreateValue(numberKey, 12.0);

            NLog.LogManager.GetCurrentClassLogger().Info($"numberValue = `{numberValue}`");

            var tmpParamNameKey = GnuClayEngine.DataDictionary.GetKey("a");

            var externalMethodInfoKey = GnuClayEngine.DataDictionary.GetKey("Move");
            var externalMethodInfo = new ExternalMethodInfo();
            externalMethodInfo.MethodKey = externalMethodInfoKey;
            externalMethodInfo.HolderKey = numberKey;
            externalMethodInfo.Parameters.Add(new ExternalParameterInfo()
            {
                NameKey = tmpParamNameKey,
                ParameterType = numberKey
            });

            GnuClayEngine.Context.TypeProcessingContext.RegExternalMethod(externalMethodInfo);

            rez = numberValue.TryCall(externalMethodInfoKey, new List<IValue>() { numberValue });

            NLog.LogManager.GetCurrentClassLogger().Info($"externalMethodInfo rez.Result = `{rez.Result}`");

            var somePropertyKey = GnuClayEngine.DataDictionary.GetKey("SomeProperty");
            NLog.LogManager.GetCurrentClassLogger().Info($"somePropertyKey = `{somePropertyKey}`");

            rez = tmpVal.TrySetProperty(somePropertyKey, numberValue);
            NLog.LogManager.GetCurrentClassLogger().Info($"SomeProperty rez = `{rez.Result}`");

            var initList = new List<IValue>() { GnuClayEngine.Context.TypeProcessingContext.CreateValue(numberKey, 12.0),
                    GnuClayEngine.Context.TypeProcessingContext.CreateValue(numberKey, 2.0),
                    GnuClayEngine.Context.TypeProcessingContext.CreateValue(numberKey, 3.0)};

            var arrayKey = GnuClayEngine.DataDictionary.GetKey(StandartTypeNamesConstants.ArrayName);
            NLog.LogManager.GetCurrentClassLogger().Info($"arrayKey = `{arrayKey}`");

            var arrayVal = GnuClayEngine.Context.TypeProcessingContext.CreateValue(arrayKey, initList);

            var getIteratorKey = GnuClayEngine.DataDictionary.GetKey("GetIterator");
            NLog.LogManager.GetCurrentClassLogger().Info($"getIteratorKey = `{getIteratorKey}`");

            var iterator = arrayVal.TryGetProperty(getIteratorKey).Result;

            var moveNextKey = GnuClayEngine.DataDictionary.GetKey("MoveNext");

            iterator.TryCall(moveNextKey, new List<IValue>());

            var currentValueKey = GnuClayEngine.DataDictionary.GetKey("CurrentValue");

            var currentValue = iterator.TryGetProperty(currentValueKey).Result;
            NLog.LogManager.GetCurrentClassLogger().Info($"currentValue = `{currentValue}`");

            iterator.TryCall(moveNextKey, new List<IValue>());
            currentValue = iterator.TryGetProperty(currentValueKey).Result;
            NLog.LogManager.GetCurrentClassLogger().Info($"currentValue = `{currentValue}`");

            iterator.TryCall(moveNextKey, new List<IValue>());
            currentValue = iterator.TryGetProperty(currentValueKey).Result;
            NLog.LogManager.GetCurrentClassLogger().Info($"currentValue = `{currentValue}`");

            var tmpCodeFrame = new FunctionModel();
            tmpCodeFrame.AddCommand(new ScriptCommand()
            {
                OperationCode = OperationCode.Nop
            });

            tmpCodeFrame.AddCommand(new ScriptCommand()
            {
                OperationCode = OperationCode.PushConst,
                Key = numberKey,
                Value = 1.0
            });

            tmpCodeFrame.AddCommand(new ScriptCommand()
            {
                OperationCode = OperationCode.PushConst,
                Key = numberKey,
                Value = 2.0
            });

            var addOperatorKey = GnuClayEngine.DataDictionary.GetKey("Add");

            tmpCodeFrame.AddCommand(new ScriptCommand()
            {
                OperationCode = OperationCode.CallBinOp,
                Key = addOperatorKey
            });

            /*tmpCodeFrame.AddCommand(new ScriptCommand()
            {
                OperationCode = OperationCode.CallBinOp,
                Key = addOperatorKey
            });*/

            NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);
            var context = new GnuClayThreadExecutionContext();
            context.MainContext = GnuClayEngine.Context;
            var tmpInternalThreadExecutor = new InternalThreadExecutor(tmpCodeFrame, context);

            tmpInternalThreadExecutor.Run();
        }

        private void RunMiddleScript()
        {
            var openKey = GnuClayEngine.DataDictionary.GetKey("open");
            var doorKey = GnuClayEngine.DataDictionary.GetKey("door");
            var keyKey = GnuClayEngine.DataDictionary.GetKey("key");
            var numberKey = GnuClayEngine.DataDictionary.GetKey(StandartTypeNamesConstants.NumberName);
            var resultVarKey = GnuClayEngine.DataDictionary.GetKey("$result");
            var plusKey = GnuClayEngine.DataDictionary.GetKey("+");
            var result_2_VarKey = GnuClayEngine.DataDictionary.GetKey("$result2");
            var consoleKey = GnuClayEngine.DataDictionary.GetKey("console");
            var logKey = GnuClayEngine.DataDictionary.GetKey("log");

            var tmpCodeFrame = new FunctionModel();

            var tmpCommand = new ScriptCommand();
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

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.PushValFromVal;
            tmpCommand.Key = result_2_VarKey;

            tmpCommand = new ScriptCommand();
            tmpCommand.OperationCode = OperationCode.CallByPos;
            tmpCodeFrame.AddCommand(tmpCommand);

            NLog.LogManager.GetCurrentClassLogger().Info(tmpCodeFrame);

            var mainContext = GnuClayEngine.Context;

            var functionProvider = new NewFunctionsEngine(GnuClayEngine.Context);

            var context = new NewGnuClayThreadExecutionContext();
            context.NewFunctionEngine = functionProvider;

            var tmpNewInternalThreadExecutor = new NewInternalFunctionExecutionModel(tmpCodeFrame, context, context);
            tmpNewInternalThreadExecutor.Run();
        }
    }
}
