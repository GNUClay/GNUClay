﻿using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.ScriptExecutor.AST;
using GnuClay.Engine.ScriptExecutor.CommonData;
using GnuClay.Engine.ScriptExecutor.Compiler.InternalCompiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.Compiler
{
    public class GnuClayScriptCompiler: BaseGnuClayEngineComponent
    {
        public GnuClayScriptCompiler(GnuClayEngineComponentContext context)
            : base(context)
        {
        }

        public FunctionModel Compile(ASTCodeBlock ast)
        {
            //var context = new CompilerContext();
            //context.MainContext = Context;

            var codeBlock = new CodeBlockLeaf(Context);
            codeBlock.Run(ast);

            var tmpCommandsList = codeBlock.Result;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Compile pre tmpCommandsList = {_ListHelper._ToString(tmpCommandsList)}");
#endif

            var n = 0;

            ScriptCommand prevCommand = null;

            foreach(var cmd in tmpCommandsList)
            {
                n++;

                cmd.Position = n;

                if(prevCommand != null)
                {
                    prevCommand.Next = cmd;
                }

                prevCommand = cmd;
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Compile after tmpCommandsList = {_ListHelper._ToString(tmpCommandsList)}");
#endif

            return new FunctionModel(tmpCommandsList);
        }
    }
}
