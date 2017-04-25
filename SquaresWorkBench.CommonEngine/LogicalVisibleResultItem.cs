using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public class LogicalVisibleResultItem: IToStringData
    {
        public LogicalObjectInfo VisibleEntity = null;

        public List<VisiblePoint> VisiblePoints = new List<VisiblePoint>();

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

            tmpSb.AppendLine($"{nameof(VisibleEntity)} = {VisibleEntity}");
            tmpSb.AppendLine(_ListHelper._ToString(VisiblePoints, nameof(VisiblePoints)));

            return tmpSb.ToString();
        }
    }
}
