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
    public class Tree : ResizedEntity
    {
        public Tree()
        {
            AddClass("tree");

            Threshold = 50;
            Durability = 100;
            IsPunch = true;
            Opacity = 1;

            CurrentBrush = Brushes.Lime;
        }

        protected override void OnCreateGeometry()
        {
            var tmpGeometryGroup = new GeometryGroup();

            var rect = new Rect(new Point(0, 0), new Size(Width, Width));
            var ellipse = new EllipseGeometry(rect);

            tmpGeometryGroup.Children.Add(ellipse);

            CurrentGeometry = tmpGeometryGroup;
        }
    }
}
