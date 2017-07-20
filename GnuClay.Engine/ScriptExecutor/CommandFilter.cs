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

        public CommandFilter(BaseCommandFilter source)
            : base(source)
        {
        }

        public CommandHandler Handler { get; set; } = null;
    }
}
