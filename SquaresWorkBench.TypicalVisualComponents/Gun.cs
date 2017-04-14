using SquaresWorkBench.CommonEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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

        private Point mCornerPoint = new Point();

        protected override void OnSetViewer()
        {
            var w = CurrViewer.Width;
            var h = CurrViewer.Height;

            mCornerPoint = new Point(w, h);
        }

        public Canvas TSTDrawContext = null;

        private volatile bool mIsFiring = false;
        private object mFiringLockObj = new object();

        public void Fire()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Fire");

            lock(mFiringLockObj)
            {
                if(mIsFiring)
                {
                    NLog.LogManager.GetCurrentClassLogger().Info("Fire mIsFiring return;");
                    return;
                }

                mIsFiring = true;
            }

            NLog.LogManager.GetCurrentClassLogger().Info("Fire Next");

            //var state = CurrPlatform.GoDirection;

            //CurrPlatform.GoDirection = GoDirectionFlag.Stop;
 
            var tmpInitialPoint = GetCentralPos(7);
            var tmpRadianAngle = SimpleMath.DegreesToRadians(CurrPolarAngle);

            var tmpRadius = 0;

            var tmpCosA = Math.Cos(tmpRadianAngle);
            var tmpSinA = Math.Sin(tmpRadianAngle);

            var tmpProcessedList = new List<object>();

            double tmpCurrentEnergy = 200;

            var rTree = CurrViewer.CurrRTree;

            while (true)
            {
                tmpRadius += 2;

                var tmpDx = tmpRadius * tmpCosA;
                var tmpDY = tmpRadius * tmpSinA;

                var tmpTargetX = tmpInitialPoint.X + tmpDx;
                var tmpTargetY = tmpInitialPoint.Y + tmpDY;

                var tmpTargetPos = new Point(tmpTargetX, tmpTargetY);

                if (IsTerminatePos(tmpTargetPos))
                {
                    break;
                }

                var targetEntity = rTree.GetEntitiesByPoint(tmpTargetPos).Where(p => p.IsHard == true).FirstOrDefault();

                if (targetEntity == null)
                {
                    //NLog.LogManager.GetCurrentClassLogger().Info($"Fire targetEntity == nulltmpRadius = {tmpRadius}");
                    continue;
                }

                //NLog.LogManager.GetCurrentClassLogger().Info($"Fire tmpProcessedList.Contains(targetEntity) tmpRadius = {tmpRadius} targetEntity.Id = {targetEntity.Id} targetEntity.Class = {targetEntity.Class}");

                if (tmpProcessedList.Contains(targetEntity))
                {
                    //NLog.LogManager.GetCurrentClassLogger().Info($"Fire tmpProcessedList.Contains(targetEntity) tmpRadius = {tmpRadius}");
                    continue;
                }

                tmpProcessedList.Add(targetEntity);

                if (!ProcessHit(targetEntity, ref tmpCurrentEnergy))
                {
                    //NLog.LogManager.GetCurrentClassLogger().Info($"Fire !ProcessHit(targetEntity, ref tmpCurrentEnergy) tmpRadius = {tmpRadius}");
                    break;
                }
            }

            lock (mFiringLockObj)
            {
                mIsFiring = false;
            }

            NLog.LogManager.GetCurrentClassLogger().Info("End Fire");
        }

        private bool ProcessHit(BaseEntity targetEntity, ref double energy)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"ProcessHit tmpTargetPos targetEntity.Id = {targetEntity.Id} Threshold = {targetEntity.Threshold} Durability = {targetEntity.Durability} energy = {energy} entity.Class = {targetEntity.Class}");

            if(energy < targetEntity.Threshold)
            {
                energy = 0;

                return false;
            }

            var durability = targetEntity.Durability;

            if (energy < durability)
            {
                energy = 0;

                return false;
            }

            if(!targetEntity.IsPunch)
            {
                if(targetEntity.IsLivingBeing)
                {
                    targetEntity.Alive = false;
                }
                else
                {
                    targetEntity.Destroy();
                }           
            }
            
            energy -= durability;

            if(energy <= 0)
            {
                return false;
            }

            return true;
        }

        private bool IsTerminatePos(Point point)
        {
            var x = point.X;
            var y = point.Y;

            if(x < 0)
            {
                return true;
            }

            if(y < 0)
            {
                return true;
            }

            if(x > mCornerPoint.X)
            {
                return true;
            }

            if(y > mCornerPoint.Y)
            {
                return true;
            }

            return false;
        }

        private void DrawTSTLine(Point initialPoint, Point targetPos)
        {
            if (TSTDrawContext == null)
            {
                return;
            }

            var tmpLineGeometry = new LineGeometry(initialPoint, targetPos);

            var tmpPen = new Pen();
            tmpPen.Brush = Brushes.Black;
            tmpPen.DashStyle = DashStyles.Solid;
            tmpPen.Thickness = 1;

            var tmpGeometryDrawing = new GeometryDrawing(Brushes.Beige, tmpPen, tmpLineGeometry);

            var drawingVisual = new DrawingVisual();

            // Retrieve the DrawingContext in order to create new drawing content.
            var drawingContext = drawingVisual.RenderOpen();

            drawingContext.DrawDrawing(tmpGeometryDrawing);

            // Persist the drawing content.
            drawingContext.Close();

            var tmpMyVisualHost = new CustomVisualHost(drawingVisual);

            TSTDrawContext.Children.Add(tmpMyVisualHost);
        }

        public override bool CanTaken()
        {
            return true;
        }

        public override void DispatchExternalAction(EntityAction actionResult, Command command)
        {
            var actionName = command.Name;

            NLog.LogManager.GetCurrentClassLogger().Info($"DispatchExternalAction actionName = {actionName}");

            if(actionName == "fire")
            {
                Fire();
                actionResult.Status = EntityActionStatus.Completed;
                return;
            }

            actionResult.Status = EntityActionStatus.Faulted;
        }
    }
}
