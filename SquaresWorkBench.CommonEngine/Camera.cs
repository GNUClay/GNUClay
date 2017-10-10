using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace SquaresWorkBench.CommonEngine
{
    public class Camera
    {
        public Camera(ActiveEntity entity, RTree rTree)
        {
            mEntity = entity;
            mRTree = rTree;
        }

        private ActiveEntity mEntity = null;

        private RTree mRTree = null;

        //private int mCurrIndex = 0;

        public void Scan()
        {
            var tmpStopWatch = new Stopwatch();

            if (mEntity.EnableLoging)
            {
                tmpStopWatch.Start();
            }

            mResult = new List<VisibleResultItem>();
            mResultDict = new Dictionary<BaseEntity, VisibleResultItem>();

            var targetAngles = GetTargetAngles();

            targetAngles.AsParallel().WithExecutionMode(ParallelExecutionMode.ForceParallelism).ForAll(angle => {
                ProcessAngle(angle);
            });

            if (mEntity.EnableLoging)
            {
                tmpStopWatch.Stop();
                NLog.LogManager.GetCurrentClassLogger().Info($"Scan {tmpStopWatch.Elapsed}");
            }
        }

        private void ProcessAngle(double angle)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ProcessAngle angle = {angle}");

            var tmpRadianAngle = SimpleMath.DegreesToRadians(angle);

            var tmpCosA = Math.Cos(tmpRadianAngle);

            var tmpSinA = Math.Sin(tmpRadianAngle);

            var tmpCurrRadius = 1;

            var tmpDetectedEntitiesList = new List<BaseEntity>();

            var tmpResetRay = false;

            while (true)
            {
                ScanTick(tmpCurrRadius, angle, tmpCosA, tmpSinA, tmpDetectedEntitiesList, ref tmpResetRay);

                tmpCurrRadius++;

                if(tmpCurrRadius > EndRadius)
                {
                    return;
                }

                if(tmpResetRay)
                {
                    return;
                }
            }
        }

        private object mLockObj = new object();

        private void ScanTick(double radius, double angle, double cosA, double sinA, List<BaseEntity> detectedEntitiesList, ref bool resetRay)
        {
            //NLog.LogManager.GetCurrentClassLogger().Info($"ScanTick radius = {radius} angle = {angle} cosA = {cosA} sinA = {sinA}");

            var tmpDx = radius * cosA;
            var tmpDY = radius * sinA;

            var tmpTargetX = mInitialPoint.X + tmpDx;

            var tmpTargetY = mInitialPoint.Y + tmpDY;

            var tmpTargetPos = new Point(tmpTargetX, tmpTargetY);

            var tmpEntities = RTreeHelper.DistinctAndWithOut(mRTree.GetEntitiesByRectAtPoint(tmpTargetPos), mEntity);

            //NLog.LogManager.GetCurrentClassLogger().Info("tmpEntities.Count = {0}", tmpEntities.Count);

            foreach (var entity in tmpEntities)
            {
                if (detectedEntitiesList.Contains(entity))
                {
                    continue;
                }

                var tmpR = entity.Bound.Contains(tmpTargetPos);

                if (!tmpR)
                {
                    continue;
                }

                //NLog.LogManager.GetCurrentClassLogger().Info(tmpTargetPos);

                detectedEntitiesList.Add(entity);

                VisibleResultItem tmpCurrVisibleResultItem = null;

                lock(mLockObj)
                {
                    if (mResultDict.ContainsKey(entity))
                    {
                        tmpCurrVisibleResultItem = mResultDict[entity];
                    }
                    else
                    {
                        tmpCurrVisibleResultItem = new VisibleResultItem();

                        mResult.Add(tmpCurrVisibleResultItem);

                        mResultDict.Add(entity, tmpCurrVisibleResultItem);

                        tmpCurrVisibleResultItem.VisibleEntity = entity;
                    }
                }

                var tmpVisiblePoint = new VisiblePoint();
                tmpVisiblePoint.TargetPoint = tmpTargetPos;
                tmpVisiblePoint.Radius = radius;
                tmpVisiblePoint.Angle = angle + 90;

                //NLog.LogManager.GetCurrentClassLogger().Info($"radius = {radius} distance = {GetDecartDistance(tmpTargetPos)} angle = {angle + 90} Id = {entity.Id} Class = {entity.ClassString}");

                lock(mLockObj)
                {
                    tmpCurrVisibleResultItem.VisiblePoints.Add(tmpVisiblePoint);
                }
                
                if (entity.Opacity == 1)
                {
                    resetRay = true;
                }
            }
        }

        private List<double> GetTargetAngles()
        {
            mInitialPoint = mEntity.GetCentralPos(8);

            mInitialAngle = mEntity.CurrPolarAngle;

            mAngleA = mInitialAngle - 45;
            mAngleB = mInitialAngle - 15;
            mAngleC = mInitialAngle + 15;
            mAngleD = mInitialAngle + 45;

            var result = new List<double>();

            var tmpCurrAngle = mAngleA;

            var tmpCurrAngleStep = 1D;

            while (true)
            {
                result.Add(tmpCurrAngle);

                tmpCurrAngle += tmpCurrAngleStep;

                //NLog.LogManager.GetCurrentClassLogger().Info("mCurrAngle = {0}", mCurrAngle);

                if (tmpCurrAngle > mAngleA && tmpCurrAngle < mAngleB)
                {
                    tmpCurrAngleStep = 1;

                    continue;
                }

                if (tmpCurrAngle >= mAngleB && tmpCurrAngle <= mAngleC)
                {
                    tmpCurrAngleStep = 0.5;

                    continue;
                }

                if (tmpCurrAngle > mAngleC && tmpCurrAngle < mAngleD)
                {
                    tmpCurrAngleStep = 1;

                    continue;
                }

                return result;
            }          
        }

        private Point mInitialPoint = new Point();

        private double mInitialAngle = 0;

        private double mAngleA = 0;
        private double mAngleB = 0;
        private double mAngleC = 0;
        private double mAngleD = 0;

        //private double mCurrAngle = 0;

        //private double mCosA = 0;
        //private double mSinA = 0;

        //private double mCurrRadius = 0;

        //private double mCurrAngleStep = 1;

        //private bool mResetRay = false;

        private double EndRadius = 400;

        //private List<BaseEntity> mDetectedEntitiesList = null;

        private List<VisibleResultItem> mResult = new List<VisibleResultItem>();
        private Dictionary<BaseEntity, VisibleResultItem> mResultDict = new Dictionary<BaseEntity, VisibleResultItem>();

        public List<VisibleResultItem> Result
        {
            get
            {
                return mResult;
            }
        }

        private double GetDecartDistance(Point p)
        {
            return Math.Sqrt(Math.Pow(mInitialPoint.X - p.X, 2) + Math.Pow(mInitialPoint.Y - p.Y, 2));
        }

        public Canvas TSTDrawContext = null;

        private void DrawTSTLine(Point targetPos)
        {
            if (TSTDrawContext == null)
            {
                return;
            }

            /*TSTDrawContext.Dispatcher.Invoke(() => {
                var tmpLineGeometry = new LineGeometry(mInitialPoint, targetPos);

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
            });*/
        }
    }
}
