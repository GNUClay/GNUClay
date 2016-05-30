using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SquaresWorkBench.CommonEngine
{
    public static class RTreeHelper
    {
        public static List<Rect> CreateChildRects(Rect baseRect)
        {
            var tmpDH = baseRect.Height / 2;
            var tmpDW = baseRect.Width / 2;

            var tmpRez = new List<Rect>();

            var tmpR = new Rect(baseRect.TopLeft, new Size(tmpDW, tmpDH));

            tmpRez.Add(tmpR);

            var tmpR_2 = new Rect(tmpR.TopRight, new Size(tmpDW, tmpDH));

            tmpRez.Add(tmpR_2);

            var tmpR_3 = new Rect(tmpR.BottomLeft, new Size(tmpDW, tmpDH));

            tmpRez.Add(tmpR_3);

            var tmpR_4 = new Rect(tmpR.BottomRight, new Size(tmpDW, tmpDH));

            tmpRez.Add(tmpR_4);

            return tmpRez;
        }

        public static List<BaseEntity> DistinctAndWithOut(List<BaseEntity> source, BaseEntity removedEntity)
        {
            var tmpRez = new List<BaseEntity>();

            foreach (var entity in source)
            {
                if (tmpRez.Contains(entity))
                {
                    continue;
                }

                if (entity == removedEntity)
                {
                    continue;
                }

                tmpRez.Add(entity);
            }

            return tmpRez;
        }
    }

    public abstract class RTreeNode
    {
        protected RTreeNode(Rect baseRect, Canvas canvas)
        {
            mCanvas = canvas;

            mBaseRect = baseRect;
        }

        private Canvas mCanvas = null;

        protected Canvas BaseCanvas
        {
            get
            {
                return mCanvas;
            }
        }

        private Rect mBaseRect = new Rect();

        public Rect BaseRect
        {
            get
            {
                return mBaseRect;
            }
        }

        public virtual List<RTreeNode> GetNodeByRect(Rect rect)
        {
            throw new NotImplementedException();
        }

        public virtual void AddEntity(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual void RemoveEntity(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual List<BaseEntity> Entities
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    public class RTreeNode_1 : RTreeNode
    {
        public RTreeNode_1(Rect baseRect, Canvas canvas)
            : base(baseRect, canvas)
        {
            Init();
        }

        private List<RTreeNode_2> Items = new List<RTreeNode_2>();

        private void Init()
        {
            var tmpChildRects = RTreeHelper.CreateChildRects(BaseRect);

            foreach (var rect in tmpChildRects)
            {
                var tmpRTreeNode = new RTreeNode_2(rect, BaseCanvas);

                Items.Add(tmpRTreeNode);
            }
        }

        public override List<RTreeNode> GetNodeByRect(Rect rect)
        {
            var tmpRez = new List<RTreeNode>();

            foreach (var item in Items)
            {
                var tmpR = Rect.Intersect(item.BaseRect, rect);

                if (tmpR == Rect.Empty)
                {
                    continue;
                }

                var tmpItems = item.GetNodeByRect(rect);

                tmpRez.AddRange(tmpItems);
            }

            return tmpRez;
        }

        public List<BaseEntity> GetEntitiesByRectAtPoint(Point point)
        {
            var tmpRez = new List<BaseEntity>();

            foreach (var item in Items)
            {
                if (item.BaseRect.Contains(point))
                {
                    tmpRez.AddRange(item.GetEntitiesByRectAtPoint(point));
                }
            }

            return tmpRez;
        }
    }

    public class RTreeNode_2 : RTreeNode
    {
        public RTreeNode_2(Rect baseRect, Canvas canvas)
            : base(baseRect, canvas)
        {
            Init();
        }

        private List<RTreeNode_3> Items = new List<RTreeNode_3>();

        private void Init()
        {
            var tmpChildRects = RTreeHelper.CreateChildRects(BaseRect);

            foreach (var rect in tmpChildRects)
            {
                var tmpRTreeNode = new RTreeNode_3(rect, BaseCanvas);

                Items.Add(tmpRTreeNode);
            }
        }

        public override List<RTreeNode> GetNodeByRect(Rect rect)
        {
            var tmpRez = new List<RTreeNode>();

            foreach (var item in Items)
            {
                var tmpR = Rect.Intersect(item.BaseRect, rect);

                if (tmpR == Rect.Empty)
                {
                    continue;
                }

                var tmpItems = item.GetNodeByRect(rect);

                tmpRez.AddRange(tmpItems);
            }

            return tmpRez;
        }

        public List<BaseEntity> GetEntitiesByRectAtPoint(Point point)
        {
            var tmpRez = new List<BaseEntity>();

            foreach (var item in Items)
            {
                if (item.BaseRect.Contains(point))
                {
                    tmpRez.AddRange(item.GetEntitiesByRectAtPoint(point));
                }
            }

            return tmpRez;
        }
    }

    public class RTreeNode_3 : RTreeNode
    {
        public RTreeNode_3(Rect baseRect, Canvas canvas)
            : base(baseRect, canvas)
        {
            Init();
        }

        private List<RTreeNode_4> Items = new List<RTreeNode_4>();

        private void Init()
        {
            var tmpChildRects = RTreeHelper.CreateChildRects(BaseRect);

            foreach (var rect in tmpChildRects)
            {
                var tmpRTreeNode = new RTreeNode_4(rect, BaseCanvas);

                Items.Add(tmpRTreeNode);
            }
        }

        public override List<RTreeNode> GetNodeByRect(Rect rect)
        {
            var tmpRez = new List<RTreeNode>();

            foreach (var item in Items)
            {
                var tmpR = Rect.Intersect(item.BaseRect, rect);

                if (tmpR == Rect.Empty)
                {
                    continue;
                }

                tmpRez.Add(item);
            }

            return tmpRez;
        }

        public List<BaseEntity> GetEntitiesByRectAtPoint(Point point)
        {
            var tmpRez = new List<BaseEntity>();

            foreach (var item in Items)
            {
                if (item.BaseRect.Contains(point))
                {
                    tmpRez.AddRange(item.Entities);
                }
            }

            return tmpRez;
        }
    }

    public class RTreeNode_4 : RTreeNode
    {
        public RTreeNode_4(Rect baseRect, Canvas canvas)
            : base(baseRect, canvas)
        {
            DERW();
        }

        private object mLocker = new object();

        private void DERW()
        {
            var tmpRectG = new System.Windows.Media.RectangleGeometry(BaseRect);

            var tmpPen = new Pen();

            tmpPen.Brush = Brushes.Black;
            tmpPen.DashStyle = DashStyles.Solid;
            tmpPen.Thickness = 1;

            var tmpGeometryDrawing = new GeometryDrawing(null, tmpPen, tmpRectG);

            var mDrawingVisual = new DrawingVisual();

            using (var drawingContext = mDrawingVisual.RenderOpen())
            {
                drawingContext.DrawDrawing(tmpGeometryDrawing);

                drawingContext.Close();
            }

            var mVisualHost = new CustomVisualHost(mDrawingVisual);

            BaseCanvas.Children.Add(mVisualHost);
        }

        private List<BaseEntity> mItems = new List<BaseEntity>();

        public override void AddEntity(BaseEntity entity)
        {
            lock (mLocker)
            {
                mItems.Add(entity);
            }
        }

        public override void RemoveEntity(BaseEntity entity)
        {
            lock (mLocker)
            {
                mItems.Remove(entity);
            }
        }

        public override List<BaseEntity> Entities
        {
            get
            {
                lock (mLocker)
                {
                    return mItems.ToList();
                }
            }
        }
    }

    public class RTree
    {
        public RTree(Canvas canvas)
        {
            mCanvas = canvas;
        }

        private Canvas mCanvas = null;

        private List<RTreeNode_1> Items = new List<RTreeNode_1>();

        public void Clear()
        {
            Items.Clear();
        }

        public void Create()
        {
            Clear();

            if (double.NaN.Equals(mCanvas.Height))
            {
                return;
            }

            if (double.NaN.Equals(mCanvas.Width))
            {
                return;
            }

            var tmpBaseRect = new Rect(0, 0, mCanvas.Width, mCanvas.Height);

            var tmpChildRects = RTreeHelper.CreateChildRects(tmpBaseRect);

            foreach (var rect in tmpChildRects)
            {
                var tmpRTreeNode = new RTreeNode_1(rect, mCanvas);

                Items.Add(tmpRTreeNode);
            }
        }

        public List<RTreeNode> GetNodeByRect(Rect rect)
        {
            var tmpRez = new List<RTreeNode>();

            foreach (var item in Items)
            {
                var tmpR = Rect.Intersect(item.BaseRect, rect);

                if (tmpR == Rect.Empty)
                {
                    continue;
                }

                var tmpItems = item.GetNodeByRect(rect);

                tmpRez.AddRange(tmpItems);
            }

            return tmpRez;
        }

        public List<BaseEntity> GetEntitiesByRectAtPoint(Point point)
        {
            var tmpRez = new List<BaseEntity>();

            foreach (var item in Items)
            {
                if (item.BaseRect.Contains(point))
                {
                    tmpRez.AddRange(item.GetEntitiesByRectAtPoint(point));
                }
            }

            return tmpRez;
        }
    }
}
