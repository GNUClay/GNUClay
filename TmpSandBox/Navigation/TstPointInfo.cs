using MyNPCLib;
using MyNPCLib.NavigationSupport;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace TmpSandBox.Navigation
{
    public class TstPointInfo: IPointInfo
    {
        public IRoute Route { get; set; }
        public IStepOfRoute StepOfRoute { get; set; }
        public bool IsInTheSamePlane { get; set; }
        public bool IsFinal { get; set; }
        public Vector3? Position { get; set; }
        public TstWayPoint WayPoint { get; set; }

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
            sb.AppendLine($"{spaces}{nameof(IsInTheSamePlane)} = {IsInTheSamePlane}");
            sb.AppendLine($"{spaces}{nameof(IsFinal)} = {IsFinal}");
            sb.AppendLine($"{spaces}{nameof(Position)} = {Position}");
            sb.AppendLine($"{spaces}{nameof(WayPoint)} = {WayPoint?.Name}");
            return sb.ToString();
        }

        public string ToShortString()
        {
            return ToShortString(0u);
        }

        public string ToShortString(uint n)
        {
            return this.GetDefaultToShortStringInformation(n);
        }

        public string PropertiesToShortString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(IsInTheSamePlane)} = {IsInTheSamePlane}");
            sb.AppendLine($"{spaces}{nameof(IsFinal)} = {IsFinal}");
            sb.AppendLine($"{spaces}{nameof(Position)} = {Position}");
            sb.AppendLine($"{spaces}{nameof(WayPoint)} = {WayPoint?.Name}");
            return sb.ToString();
        }

        public string ToBriefString()
        {
            return ToBriefString(0u);
        }

        public string ToBriefString(uint n)
        {
            return this.GetDefaultToBriefStringInformation(n);
        }

        public string PropertiesToBriefString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(IsInTheSamePlane)} = {IsInTheSamePlane}");
            sb.AppendLine($"{spaces}{nameof(IsFinal)} = {IsFinal}");
            sb.AppendLine($"{spaces}{nameof(Position)} = {Position}");
            sb.AppendLine($"{spaces}{nameof(WayPoint)} = {WayPoint?.Name}");
            return sb.ToString();
        }
    }
}
