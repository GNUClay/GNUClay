using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.ConsoleTalk
{
    public class ConsoleTalkAppConfig
    {
        public bool EnabledAutoSave { get; set; } = false;
        public string AutoSavedDumpName { get; set; } = "DefaultData";
    }
}
