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
    public abstract class BaseRoundHuman : ActiveEntity
    {
        protected BaseRoundHuman()
        {
            Class.Add("round");
            Class.Add("human");

            IsHard = true;
            Opacity = 1;
            IsLivingBeing = true;
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
                CurrentBrush = Brushes.Black;
            }
        }
    }
}
