using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClay.CommonHelpers.JsonSerializationHelpers
{
    // TODO: fix me!
    public class PlaneObjectsTree
    {
        public float Version { get; set; }
        public Dictionary<int, PlaneObject> ObjectsDict { get; set; }
    }
}
