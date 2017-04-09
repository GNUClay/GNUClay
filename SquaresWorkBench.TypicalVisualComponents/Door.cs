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
    public class Door : ResizedEntity
    {
        public Door()
        {
            Class = "door";

            NSetClosed();

            Threshold = 50;
            Durability = 100;
            IsPunch = true; 
        }

        private Brush mClosedBrush = Brushes.Brown;
        private Brush mOpenedBrush = null;

        protected override void OnCreateGeometry()
        {
            var tmpGeometryGroup = new GeometryGroup();

            var rect = new Rect(new Point(0, 0), new Size(Width, Height));
            var tmpRectG = new RectangleGeometry(rect);

            tmpGeometryGroup.Children.Add(tmpRectG);

            CurrentGeometry = tmpGeometryGroup;
        }

        private bool mIsOpened = false;

        [PersistentKVPProperty]
        public bool IsOpened
        {
            get
            {
                return mIsOpened;
            }

            set
            {
                if (mIsOpened == value)
                {
                    return;
                }

                if (value)
                {
                    Open();

                    return;
                }

                Close();
            }
        }

        public void Open()
        {
            if (mIsOpened)
            {
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info("Open");

            NSetOpened();
        }

        private void NSetOpened()
        {
            mIsOpened = true;

            IsHard = false;

            Opacity = 0;

            CurrentBrush = mOpenedBrush;
        }

        public void Close()
        {
            if (!mIsOpened)
            {
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info("Close");

            NSetClosed();
        }

        private void NSetClosed()
        {
            mIsOpened = false;

            IsHard = true;

            Opacity = 1;

            CurrentBrush = mClosedBrush;
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

        public override EntityAction DispatchExternalAction(Command command)
        {
            var actionName = command.Name;

            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchExternalAction actionName = {actionName}");

            if(actionName == "open")
            {
                Open();
                return EntityAction.CreateSuccess(command);
            }

            if(actionName == "close")
            {
                Close();
                return EntityAction.CreateSuccess(command);
            }

            return EntityAction.CreateError(command);
        }
    }
}
