using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.RemoteEvents
{
    public class RemoteEvent: IToStringData
    {
        public ulong HolderKey { get; set; }
        public ulong MethodKey { get; set; }
        public Dictionary<ulong, object> Parameters = new Dictionary<ulong, object>();

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var sb = new StringBuilder();

            sb.Append(nameof(HolderKey));
            sb.Append(" = ");
            sb.AppendLine(HolderKey.ToString());

            sb.Append(nameof(MethodKey));
            sb.Append(" = ");
            sb.AppendLine(MethodKey.ToString());

            sb.AppendLine(_ListHelper._ToString(Parameters.ToList(), nameof(Parameters)));

            return sb.ToString();
        }
    }
}
