using System;
using System.Collections.Generic;
using System.Linq;
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
        public Camera(BaseEntity entity, RTree rTree)
        {
            mEntity = entity;
            mRTree = rTree;
        }

        private BaseEntity mEntity = null;

        private RTree mRTree = null;

        public void Scan()
        {
            mInitialPoint = mEntity.GetCentralPos(8); //mEntity.CurrPos;

            mInitialAngle = mEntity.CurrPolarAngle;

            mAngleA = mInitialAngle - 45;
            mAngleB = mInitialAngle - 15;
            mAngleC = mInitialAngle + 15;
            mAngleD = mInitialAngle + 45;
            
            //mAngleA = mInitialAngle;
            //mAngleB = mInitialAngle;
            //mAngleC = mInitialAngle;
            //mAngleD = mInitialAngle;

            mCurrAngle = mAngleA;

            var tmpRadianAngle = SimpleMath.DegreesToRadians(mCurrAngle);

            mCosA = Math.Cos(tmpRadianAngle);

            mSinA = Math.Sin(tmpRadianAngle);

            mCurrRadius = 1;

            mCurrAngleStep = 1;

            mDetectedEntitiesList = new List<BaseEntity>();

            mResult = new List<VisibleResultItem>();
            mResultDict = new Dictionary<BaseEntity, VisibleResultItem>();

            do
            {
                ScanTick(mCurrRadius, mCurrAngle, mCosA, mSinA);

                if (!NextPosition())
                {
                    return;
                }
            } while (true);
        }

        private Point mInitialPoint = new Point();

        private double mInitialAngle = 0;

        private double mAngleA = 0;
        private double mAngleB = 0;
        private double mAngleC = 0;
        private double mAngleD = 0;

        private double mCurrAngle = 0;

        private double mCosA = 0;
        private double mSinA = 0;

        private double mCurrRadius = 0;

        private double mCurrAngleStep = 1;

        private bool mResetRay = false;

        private double EndRadius = 400;

        private List<BaseEntity> mDetectedEntitiesList = null;

        private List<VisibleResultItem> mResult = new List<VisibleResultItem>();
        private Dictionary<BaseEntity, VisibleResultItem> mResultDict = new Dictionary<BaseEntity, VisibleResultItem>();

        public List<VisibleResultItem> Result
        {
            get
            {
                return mResult;
            }
        }

        private void ScanTick(double radius, double angle, double cosA, double sinA)
        {
            var tmpDx = radius * cosA;
            var tmpDY = radius * sinA;

            var tmpTargetX = mInitialPoint.X + tmpDx;

            var tmpTargetY = mInitialPoint.Y + tmpDY;

            var tmpTargetPos = new Point(tmpTargetX, tmpTargetY);

            DrawTSTLine(tmpTargetPos);

            //NLog.LogManager.GetCurrentClassLogger().Info("mEntitiesList.Count = {0}", mEntitiesList.Count);

            var tmpEntities = RTreeHelper.DistinctAndWithOut(mRTree.GetEntitiesByRectAtPoint(tmpTargetPos), mEntity);

            //NLog.LogManager.GetCurrentClassLogger().Info("tmpEntities.Count = {0}", tmpEntities.Count);

            foreach (var entity in tmpEntities)
            {
                //NLog.LogManager.GetCurrentClassLogger().Info(entity.Id);

                var tmpR = entity.Bound.Contains(tmpTargetPos);

                if (!tmpR)
                {
                    continue;
                }

                //NLog.LogManager.GetCurrentClassLogger().Info(entity.Id);

                try
                {
                    tmpR = entity.CurrentGeometry.Dispatcher.Invoke(() =>
                    {
                        return entity.CurrentGeometry.FillContains(tmpTargetPos);
                    }, DispatcherPriority.Send);
                }
                catch
                {
                    return;
                }

                if (!tmpR)
                {
                    continue;
                }

                if (mDetectedEntitiesList.Contains(entity))
                {
                    continue;
                }

                //NLog.LogManager.GetCurrentClassLogger().Info(tmpTargetPos);

                mDetectedEntitiesList.Add(entity);

                VisibleResultItem tmpCurrVisibleResultItem = null;

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

                var tmpVisiblePoint = new VisiblePoint();
                tmpVisiblePoint.TargetPoint = tmpTargetPos;
                tmpVisiblePoint.Radius = radius;
                tmpVisiblePoint.Angle = angle + 90;

                tmpCurrVisibleResultItem.VisiblePoints.Add(tmpVisiblePoint);

                if (entity.Opacity == 1)
                {
                    mResetRay = true;
                }
            }
        }

        private bool NextPosition()
        {
            mCurrRadius += 1;

            //NLog.LogManager.GetCurrentClassLogger().Info("mCurrRadius = {0}", mCurrRadius);

            if (mCurrRadius <= EndRadius)
            {
                if (!mResetRay)
                {
                    return true;
                }
            }

            mResetRay = false;

            mCurrRadius = 1;

            mDetectedEntitiesList = new List<BaseEntity>();

            mCurrAngle += mCurrAngleStep;

            var tmpRadianAngle = SimpleMath.DegreesToRadians(mCurrAngle);

            mCosA = Math.Cos(tmpRadianAngle);

            mSinA = Math.Sin(tmpRadianAngle);

            //NLog.LogManager.GetCurrentClassLogger().Info("mCurrAngle = {0}", mCurrAngle);

            if (mCurrAngle > mAngleA && mCurrAngle < mAngleB)
            {
                mCurrAngleStep = 2;

                return true;
            }

            if (mCurrAngle >= mAngleB && mCurrAngle <= mAngleC)
            {
                mCurrAngleStep = 1;

                return true;
            }

            if (mCurrAngle > mAngleC && mCurrAngle < mAngleD)
            {
                mCurrAngleStep = 2;

                return true;
            }

            return false;
        }

        public Canvas TSTDrawContext = null;

        private void DrawTSTLine(Point targetPos)
        {
            if (TSTDrawContext == null)
            {
                return;
            }

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
        }
    }
}
