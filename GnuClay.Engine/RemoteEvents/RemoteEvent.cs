using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.RemoteEvents
{
    public class RemoteEvent
    {
        public int HolderKey { get; set; }
        public int MethodKey { get; set; }
        public Dictionary<int, object> Parameters = new Dictionary<int, object>();
    }
}
