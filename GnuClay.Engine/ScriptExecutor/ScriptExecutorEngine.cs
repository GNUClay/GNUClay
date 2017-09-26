using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.Parser.CommonData;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.Compiler;
using GnuClay.Engine.ScriptExecutor.InternalScriptExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public class ScriptExecutorEngine: BaseGnuClayEngineComponent
    {
        public ScriptExecutorEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            mContextOfSystemVariables = new ContextOfSystemVariables();
        }

        public override void FirstInit()
        {
            mCompiler = Context.ScriptCompiler;
            mFunctionsEngine = Context.FunctionsEngine;
        }

        private GnuClayScriptCompiler mCompiler = null;
        private FunctionsEngine mFunctionsEngine = null;

        private ContextOfSystemVariables mContextOfSystemVariables;

        public ContextOfSystemVariables ContextOfSystemVariables
        {
            get
            {
                return mContextOfSystemVariables;
            }
        }

        public void Execute(ASTCodeBlock codeBlock)
        {
            var tmpCodeFrame = mCompiler.Compile(codeBlock);
            mFunctionsEngine.CallCodeFrame(tmpCodeFrame);
        }

        public void DefineFunction(UserDefinedFunction userDefinedFunction)
        {
            var tmpCodeFrame = mCompiler.Compile(userDefinedFunction.Body);

            var filter = new CommandFilter();
            filter.HolderKey = userDefinedFunction.HolderKey;
            filter.FunctionKey = userDefinedFunction.FunctionKey;
            filter.TargetKey = userDefinedFunction.TargetKey;

            foreach(var parameter in userDefinedFunction.Params)
            {
                var item = new CommandFilterParam();
                
                var typeKey = parameter.TypeKey;

                item.TypeKey = typeKey;

                if(typeKey == 0)
                {
                    item.IsAnyType = true;
                }
                else
                {
                    item.IsAnyType = false;
                }
                
                filter.Params.Add(parameter.NameKey, item);
            }

            var tmpUserDefinedFunctionModel = new UserDefinedFunctionModel();
            tmpUserDefinedFunctionModel.Filter = filter;
            tmpUserDefinedFunctionModel.FunctionModel = tmpCodeFrame;

            Context.UserDefinedFunctionsStorage.AddFunction(tmpUserDefinedFunctionModel);
        }
    }
}
