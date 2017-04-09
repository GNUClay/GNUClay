using SquaresWorkBench.CommonEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

        public Canvas TSTDrawContext = null;

        public void Fire()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Fire");

            var speed = CurrPlatform.Speed;
            CurrPlatform.Speed = 0;

            TSTDrawContext = CurrViewer.CurrCanvas;
            var cornerPoint = new Point(TSTDrawContext.Width, TSTDrawContext.Height);

            var tmpStopwatch = new Stopwatch();
            tmpStopwatch.Start();

            var tmpRadius = 0;

            var tmpInitialPoint = GetCentralPos(7);
            var tmpRadianAngle = SimpleMath.DegreesToRadians(CurrPolarAngle);

            var tmpCosA = Math.Cos(tmpRadianAngle);
            var tmpSinA = Math.Sin(tmpRadianAngle);

            var tmpProcessedList = new List<object>();

            double tmpCurrentEnergy = 200;

            while (true)
            {
                tmpRadius++;

                var tmpDx = tmpRadius * tmpCosA;
                var tmpDY = tmpRadius * tmpSinA;

                var tmpTargetX = tmpInitialPoint.X + tmpDx;
                var tmpTargetY = tmpInitialPoint.Y + tmpDY;

                var tmpTargetPos = new Point(tmpTargetX, tmpTargetY);

                NLog.LogManager.GetCurrentClassLogger().Info($"Fire tmpTargetPos = {tmpTargetPos}");

                if(IsTerminatePos(tmpTargetPos, cornerPoint))
                {
                    NLog.LogManager.GetCurrentClassLogger().Info("Fire IsTerminatePos");

                    break;
                }

                var targetEntities = CurrViewer.CurrRTree.GetEntitiesByPoint(tmpTargetPos).Where(p => p.IsHard == true).ToList();

                DrawTSTLine(tmpInitialPoint, tmpTargetPos);

                if (targetEntities.Count == 0)
                {
                    continue;
                }

                foreach(var entity in targetEntities)
                {
                    if(tmpProcessedList.Contains(entity))
                    {
                        continue;
                    }

                    tmpProcessedList.Add(entity);

                    if(!ProcessHit(entity, ref tmpCurrentEnergy))
                    {
                        return;
                    }
                }             
            }

            CurrPlatform.Speed = speed;

            tmpStopwatch.Stop();
            NLog.LogManager.GetCurrentClassLogger().Info($"End Fire tmpStopwatch.Elapsed = {tmpStopwatch.Elapsed}");

            /*var tmpBullet = new Bullet();

            tmpBullet.CurrPos = mFrontPoint;
            tmpBullet.CurrAngle = CurrAngle;

            tmpBullet.CurrMainContext = CurrMainContext;

            tmpBullet.GoDirection = GoDirectionFlag.Go;

            NLog.LogManager.GetCurrentClassLogger().Info("tmpBullet.Damage = {0}", tmpBullet.Damage);*/
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

        private bool IsTerminatePos(Point point, Point cornerPoint)
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

            if(x > cornerPoint.X)
            {
                return true;
            }

            if(y > cornerPoint.Y)
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
