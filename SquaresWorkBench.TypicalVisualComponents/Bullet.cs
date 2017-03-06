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
    public class Bullet : UnaliveEntity
    {
        public Bullet()
        {
            IsHard = true;

            Opacity = 0;

            CurrentBrush = Brushes.Black;

            Speed = 100;
        }

        protected override void OnCreateGeometry()
        {
            var tmpGeometryGroup = new GeometryGroup();

            var tmpLineGeometry = new LineGeometry(new Point(0, 0), new Point(1, 1));

            tmpGeometryGroup.Children.Add(tmpLineGeometry);

            CurrentGeometry = tmpGeometryGroup;
        }

        protected override void CollideWith(BaseEntity entity)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("CollideWith {0} => {1}", Id, entity.Id);

            Hit();
        }

        protected override void OnImplementLocationAsync()
        {
            if (CurrViewer == null)
            {
                return;
            }

            try
            {
                if (!CurrViewer.Contains(this))
                {
                    Hit();
                }
            }
            catch
            {
            }
        }

        private void Hit()
        {
            GoDirection = GoDirectionFlag.Stop;

            Destroy();
        }
    }
}
