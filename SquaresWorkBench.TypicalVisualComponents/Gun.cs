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
    public class Gun : UnaliveEntity
    {
        public Gun()
        {
            IsHard = false;
            Opacity = 1;

            //CurrentBrush = System.Windows.Media.Brushes.Black;
        }

        private Point mFrontPoint = new Point();

        protected override void OnCreateGeometry()
        {
            var tmpGeometryGroup = new GeometryGroup();

            var rect = new Rect(new Point(0, 0), new Size(2, 10));
            var tmpRectG = new RectangleGeometry(rect);

            tmpGeometryGroup.Children.Add(tmpRectG);

            CurrentGeometry = tmpGeometryGroup;
        }

        protected override void OnImplementLocation()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("OnImplementLocation");

            mFrontPoint = SimpleMath.PolarToDecartByBasePos_D(CurrPolarAngle, DY + 4, CurrPos);
        }

        public void Fire()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Fire");

            var tmpBullet = new Bullet();

            tmpBullet.CurrPos = mFrontPoint;
            tmpBullet.CurrAngle = CurrAngle;

            tmpBullet.CurrMainContext = CurrMainContext;

            tmpBullet.GoDirection = GoDirectionFlag.Go;

            NLog.LogManager.GetCurrentClassLogger().Info("tmpBullet.Damage = {0}", tmpBullet.Damage);
        }

        public override bool CanTaken()
        {
            return true;
        }

        public override EntityAction DispatchExternalAction(Command command)
        {
            var actionName = command.Name;

            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchExternalAction actionName = {actionName}");

            if(actionName == "fire")
            {
                Fire();

                return EntityAction.CreateSuccess(command);
            }

            return EntityAction.CreateError(command);
        }
    }
}
