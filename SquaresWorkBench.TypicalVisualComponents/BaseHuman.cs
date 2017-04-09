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
    public class BaseHuman : ActiveEntity
    {
        public BaseHuman()
        {
            Class = "human";

            IsHard = true;
            Opacity = 1;
            IsLivingBeing = true;

            CurrentBrush = Brushes.Lime;
        }

        protected double Width { get; set; } = 15;

        protected override void OnCreateGeometry()
        {
            var tmpGeometryGroup = new GeometryGroup();

            var rect = new Rect(new Point(0, 0), new Size(Width, Width));
            var ellipse = new EllipseGeometry(rect);

            tmpGeometryGroup.Children.Add(ellipse);

            var line = new LineGeometry(new Point(Width/2, 0), ellipse.Center);
            tmpGeometryGroup.Children.Add(line);
            CurrentGeometry = tmpGeometryGroup;
        }

        protected override void OnSetAlive()
        {
            if (!Alive)
            {
                CurrentBrush = System.Windows.Media.Brushes.Black;
            }
        }
    }
}
