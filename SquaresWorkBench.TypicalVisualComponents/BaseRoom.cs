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
    public class BaseRoom: ResizedEntity
    {
        public BaseRoom()
        {
            Width = 50;
            Height = 50;

            Class.Add("room");
        }

        protected override void OnCreateGeometry()
        {
            var rect = new Rect(new Point(0, 0), new Size(Width, Height));
            var tmpRectG = new RectangleGeometry(rect);

            CurrentGeometry = tmpRectG;
        }
    }
}
