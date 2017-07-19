using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.ScriptExecuting
{
    public delegate void NewCommandHandler(NewEntityAction action);

    public class NewCommandFilter: NewBaseCommandFilter
    {
        public NewCommandFilter()
        {
        }

        public NewCommandFilter(NewBaseCommandFilter source)
            : base(source)
        {
        }

        public NewCommandHandler Handler { get; set; } = null;
    }
}
