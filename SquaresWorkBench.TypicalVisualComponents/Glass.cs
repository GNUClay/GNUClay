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
    public class Glass : ResizedEntity
    {
        public Glass()
        {
            Class.Add("glass");

            IsHard = true;

            Opacity = 0;

            CurrentBrush = Brushes.WhiteSmoke;

            Width = 6;
        }

        protected override void OnCreateGeometry()
        {
            var tmpGeometryGroup = new GeometryGroup();

            var rect = new Rect(new Point(0, 0), new Size(Width, Height));
            var tmpRectG = new RectangleGeometry(rect);

            tmpGeometryGroup.Children.Add(tmpRectG);

            var tmpHH = Height / 2;

            var tmpLineGeometry = new LineGeometry(new Point(0, tmpHH), new Point(Width, tmpHH));

            tmpGeometryGroup.Children.Add(tmpLineGeometry);

            CurrentGeometry = tmpGeometryGroup;
        }

        protected override void CollideWith(BaseEntity entity)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("CollideWith => {0}", entity.Id);

            Hit(entity.Damage);

            NLog.LogManager.GetCurrentClassLogger().Info("Durability = {0}", Durability);
            NLog.LogManager.GetCurrentClassLogger().Info("Threshold = {0}", Threshold);
            NLog.LogManager.GetCurrentClassLogger().Info("IsBroken = {0}", IsBroken);

            if (IsBroken)
            {
                Destroy();
            }
        }
    }
}
