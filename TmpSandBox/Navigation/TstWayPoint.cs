using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.Navigation
{
    public class TstWayPoint: IObjectToString
    {
        public string Name { get; set; } = string.Empty;
        public List<TstPlane> PlanesList { get; set; } = new List<TstPlane>();

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
            sb.AppendLine($"{spaces}{nameof(Name)} = {Name}");

            if (PlanesList == null)
            {
                sb.AppendLine($"{spaces}{nameof(PlanesList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(PlanesList)}");
                foreach (var item in PlanesList)
                {
                    sb.AppendLine($"{nextNSpaces}{item.Name}");
                }
                sb.AppendLine($"{spaces}End {nameof(PlanesList)}");
            }

            return sb.ToString();
        }
    }
}
