using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.Navigation
{
    public class TstPlanesConnectionInfo: IObjectToString
    {
        public bool IsDirect { get; set; }
        public TstWayPoint WayPoint { get; set; }
        public List<TstLinkOfPoints> LinksList { get; set; }

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
            var nextNSpaces = StringHelper.Spaces(nextN);

            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(IsDirect)} = {IsDirect}");
            sb.AppendLine($"{spaces}{nameof(WayPoint)} = {WayPoint?.Name}");

            if (LinksList == null)
            {
                sb.AppendLine($"{spaces}{nameof(LinksList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(LinksList)}");
                foreach (var item in LinksList)
                {
                    sb.AppendLine($"{nextNSpaces}{item.Name}");
                }
                sb.AppendLine($"{spaces}End {nameof(LinksList)}");
            }
            return sb.ToString();
        }
    }
}
