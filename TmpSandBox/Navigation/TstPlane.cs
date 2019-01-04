﻿using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.Navigation
{
    public class TstPlane: IObjectToString
    {
        public string Name { get; set; } = string.Empty;
        public List<TstWayPoint> PointsList { get; set; } = new List<TstWayPoint>();

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

            if (PointsList == null)
            {
                sb.AppendLine($"{spaces}{nameof(PointsList)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(PointsList)}");
                foreach (var item in PointsList)
                {
                    sb.AppendLine($"{nextNSpaces}{item.Name}");
                }
                sb.AppendLine($"{spaces}End {nameof(PointsList)}");
            }

            return sb.ToString();
        }
    }
}
