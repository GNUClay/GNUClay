using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresWorkBench.CommonEngine
{
    public class VisiblePoint
    {
        public Point TargetPoint = new Point();

        public double Radius = 0;
        public double Angle = 0;
    }

    public class VisibleResultItem
    {
        public BaseEntity VisibleEntity = null;

        public List<VisiblePoint> VisiblePoints = new List<VisiblePoint>();
    }
}
