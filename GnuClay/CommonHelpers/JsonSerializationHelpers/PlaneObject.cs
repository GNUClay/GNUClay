using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    // TODO: fix me!
    public class PlaneObject
    {
        public string ___TypeName { get; set; }
        public Dictionary<string, object> Values { get; set; } = new Dictionary<string, object>();
    }
}
