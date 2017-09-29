using GnuClay.CommonClientTypes.CommonData;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor
{
    public delegate void CommandHandler(EntityAction action);

    public class CommandFilter: BaseCommandFilter
    {
        public CommandFilter()
        {
        }

        public CommandFilter(IExternalCommandFilter source)
            : base(source)
        {
        }

        public CommandHandler Handler { get; set; } = null;
        public bool IsUserDefined { get; set; }
        public FunctionModel FunctionModel { get; set; } = null;
    }
}
