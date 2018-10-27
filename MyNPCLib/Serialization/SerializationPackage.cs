using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.Serialization
{
    [Serializable]
    public class SerializationPackage
    {
        public string Name;
        public decimal Version;
        public byte[] Value;
    }
}
