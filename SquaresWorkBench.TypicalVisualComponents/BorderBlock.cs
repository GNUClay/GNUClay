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
    public abstract class BorderBlock : BaseEntity
    {
        protected BorderBlock(double lenght)
        {
            Length = lenght;

            Class = "border block";
            IsHard = true;
            Opacity = 1;
            Threshold = double.MaxValue;
            Durability = double.MaxValue;
            IsPunch = true;

            CurrentBrush = Brushes.Black;
        }

        protected double Length = 0;
    }

    public class VBorderBlock: BorderBlock
    {
        public VBorderBlock(double lenght = 100)
            : base(lenght)
        {
        }

        protected override void OnCreateGeometry()
        {
            var rect = new Rect(new Point(0, 0), new Size(2, Length));
            var tmpRectG = new RectangleGeometry(rect);

            CurrentGeometry = tmpRectG;
        }
    }

    public class HBorderBlock : BorderBlock
    {
        public HBorderBlock(double lenght = 100)
            : base(lenght)
        {
        }

        protected override void OnCreateGeometry()
        {
            var rect = new Rect(new Point(0, 0), new Size(Length, 2));
            var tmpRectG = new RectangleGeometry(rect);

            CurrentGeometry = tmpRectG;
        }
    }
}
