using SquaresWorkBench.CommonEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SquaresWorkBench.TypicalVisualComponents
{
    public class SimplePlatform : UnaliveEntity
    {
        public SimplePlatform()
        {
        }

        protected override void OnCreateGeometry()
        {
            var tmpGeometryGroup = new GeometryGroup();

            var rect = new Rect(new Point(0, 0), new Size(100, 200));
            var tmpRectG = new RectangleGeometry(rect);

            tmpGeometryGroup.Children.Add(tmpRectG);

            CurrentGeometry = tmpGeometryGroup;
        }
    }
}
