using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace MyNPCLib.NavigationSupport
{
    public class Route : IRoute
    {
        public StatusOfRoute Status { get; set; } = StatusOfRoute.Unknown;
        public Vector3 TargetPosition { get; set; }
        public IList<IStepOfRoute> NextSteps { get; set; }
        public IList<IPointInfo> NextPoints { get; set; }

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
            if (NextSteps == null)
            {
                sb.AppendLine($"{spaces}{nameof(NextSteps)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NextSteps)}");
                foreach (var item in NextSteps)
                {
                    sb.Append($"{item.ToString(nextN)}");
                }
                sb.AppendLine($"{spaces}End {nameof(NextSteps)}");
            }

            if (NextPoints == null)
            {
                sb.AppendLine($"{spaces}{nameof(NextPoints)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NextPoints)}");
                foreach (var item in NextPoints)
                {
                    sb.Append($"{item.ToString(nextN)}");
                }
                sb.AppendLine($"{spaces}End {nameof(NextPoints)}");
            }
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

            if (NextSteps == null)
            {
                sb.AppendLine($"{spaces}{nameof(NextSteps)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NextSteps)}");
                foreach (var item in NextSteps)
                {
                    sb.Append($"{item.ToShortString(nextN)}");
                }
                sb.AppendLine($"{spaces}End {nameof(NextSteps)}");
            }

            if (NextPoints == null)
            {
                sb.AppendLine($"{spaces}{nameof(NextPoints)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NextPoints)}");
                foreach (var item in NextPoints)
                {
                    sb.Append($"{item.ToShortString(nextN)}");
                }
                sb.AppendLine($"{spaces}End {nameof(NextPoints)}");
            }

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

            if (NextSteps == null)
            {
                sb.AppendLine($"{spaces}{nameof(NextSteps)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NextSteps)}");
                foreach (var item in NextSteps)
                {
                    sb.Append($"{item.ToBriefString(nextN)}");
                }
                sb.AppendLine($"{spaces}End {nameof(NextSteps)}");
            }

            if (NextPoints == null)
            {
                sb.AppendLine($"{spaces}{nameof(NextPoints)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(NextPoints)}");
                foreach (var item in NextPoints)
                {
                    sb.Append($"{item.ToBriefString(nextN)}");
                }
                sb.AppendLine($"{spaces}End {nameof(NextPoints)}");
            }

            return sb.ToString();
        }
    }
}
