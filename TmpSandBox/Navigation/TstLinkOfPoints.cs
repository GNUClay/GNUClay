using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.Navigation
{
    public class TstLinkOfPoints : IObjectToString
    {
        public string Name { get; set; } = string.Empty;
        public TstWayPoint Point1 { get; set; }
        public TstWayPoint Point2 { get; set; }

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(Name)} = {Name}");
            sb.AppendLine($"{spaces}{nameof(Point1)} = {Point1?.Name}");
            sb.AppendLine($"{spaces}{nameof(Point2)} = {Point2?.Name}");
            return sb.ToString();
        }
    }
}
