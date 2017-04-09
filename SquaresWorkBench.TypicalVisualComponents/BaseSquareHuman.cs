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
    public abstract class BaseSquareHuman : ActiveEntity
    {
        protected BaseSquareHuman()
        {
            Class = "human";
            IsHard = true;
            Opacity = 1;
            IsLivingBeing = true;
        }

        protected override void OnCreateGeometry()
        {
            var tmpGeometryGroup = new GeometryGroup();

            var rect = new Rect(new Point(0, 0), new Size(15, 15));
            var tmpRectG = new RectangleGeometry(rect);

            tmpGeometryGroup.Children.Add(tmpRectG);

            var tmpLineGeometry = new LineGeometry(new Point(8, 2), new Point(13, 13));

            tmpGeometryGroup.Children.Add(tmpLineGeometry);

            tmpLineGeometry = new LineGeometry(new Point(8, 2), new Point(2, 13));

            tmpGeometryGroup.Children.Add(tmpLineGeometry);

            tmpLineGeometry = new LineGeometry(new Point(2, 13), new Point(13, 13));

            tmpGeometryGroup.Children.Add(tmpLineGeometry);

            CurrentGeometry = tmpGeometryGroup;
        }
    }
}
