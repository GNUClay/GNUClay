using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SquaresWorkBench.CommonEngine
{
    public static class SimpleMath
    {
        public static double DegreesToRadians(double value)
        {
            return value * (Math.PI / 180);
        }

        public static double RadiansToDegrees(double value)
        {
            return value * (180 / Math.PI);
        }

        public static Point PolarToDecart_D(double angle, double radius)
        {
            return PolarToDecart_R(DegreesToRadians(angle), radius);
        }

        public static Point PolarToDecart_R(double angle, double radius)
        {
            var tmpDx = radius * Math.Cos(angle);
            var tmpDY = radius * Math.Sin(angle);

            return new Point(tmpDx, tmpDY);
        }

        public static Point PolarToDecartByBasePos_D(double angle, double radius, Point _base)
        {
            return PolarToDecartByBasePos_R(DegreesToRadians(angle), radius, _base);
        }

        public static Point PolarToDecartByBasePos_R(double angle, double radius, Point _base)
        {
            var tmpDP = PolarToDecart_R(angle, radius);

            var tmpTargetX = _base.X + tmpDP.X;
            var tmpTargetY = _base.Y + tmpDP.Y;

            return new Point(tmpTargetX, tmpTargetY);
        }

        public static Point GetCentralPoint(Rect rect)
        {
            var tmpTargetX = Math.Abs((rect.Right - rect.Left) / 2);
            var tmpTargetY = Math.Abs((rect.Bottom - rect.Top) / 2);

            return new Point(tmpTargetX, tmpTargetY);
        }
    }
}
