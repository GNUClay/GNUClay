using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Serialization
{
    [Serializable]
    public class SerializationPackage
    {
        public decimal Version;
        public byte[] Value;
    }
}
