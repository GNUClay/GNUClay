﻿using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresWorkBench.CommonEngine
{
    public class VisiblePoint : IToStringData
    {
        public Point TargetPoint = new Point();

        public double Radius = 0;
        public double Angle = 0;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public virtual string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine($"{nameof(TargetPoint)} = {TargetPoint}");
            tmpSb.AppendLine($"{nameof(Radius)} = {Radius}");
            tmpSb.AppendLine($"{nameof(Angle)} = {Angle}");

            return tmpSb.ToString();
        }
    }

    public class VisibleResultItem
    {
        public BaseEntity VisibleEntity = null;

        public List<VisiblePoint> VisiblePoints = new List<VisiblePoint>();
    }
}
