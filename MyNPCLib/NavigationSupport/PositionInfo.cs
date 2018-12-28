using MyNPCLib.Logical;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MyNPCLib.NavigationSupport
{
    public class PositionInfo: IPositionInfo
    {
        public KindOfPoint KindOfPoint { get; set; }
        public KindOfLocation KindOfLocation { get; set; }
        public Vector3? Point { get; set; }
        public IList<BaseAbstractLogicalObject> PlanesOfThePoint { get; set; }

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
            sb.Append($"{spaces}{nameof(KindOfPoint)} = {KindOfPoint}");
            sb.Append($"{spaces}{nameof(KindOfLocation)} = {KindOfLocation}");
            sb.Append($"{spaces}{nameof(Point)} = {Point}");
            if (PlanesOfThePoint == null)
            {
                sb.AppendLine($"{spaces}{nameof(PlanesOfThePoint)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(PlanesOfThePoint)}");
                foreach(var item in PlanesOfThePoint)
                {
                    sb.Append(item.ToString(nextN));
                }            
                sb.AppendLine($"{spaces}End {nameof(PlanesOfThePoint)}");
            }
            return sb.ToString();
        }
    }
}
