using SquaresWorkBench.CommonEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace SquaresWorkBench.TypicalVisualComponents
{
    public class Block : ResizedEntity
    {
        public Block()
        {
            AddClass("block");

            IsHard = true;
            Opacity = 1;
            Threshold = 5000;
            Durability = 5000;
            IsPunch = true;

            CurrentBrush = Brushes.Yellow;
        }

        protected override void OnCreateGeometry()
        {
            var rect = new Rect(new Point(0, 0), new Size(Width, Height));
            var tmpRectG = new RectangleGeometry(rect);

            CurrentGeometry = tmpRectG;
        }
    }
}
