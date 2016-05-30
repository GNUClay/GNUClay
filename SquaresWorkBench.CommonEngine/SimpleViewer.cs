using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SquaresWorkBench.CommonEngine
{
    public class SimpleViewer
    {
        public SimpleViewer(ScrollViewer viewer)
        {
            mViever = viewer;

            mCanvas = new Canvas();

            mViever.Content = mCanvas;

            mRTree = new RTree(mCanvas);
        }

        private ScrollViewer mViever = null;

        private Canvas mCanvas = null;

        public Canvas CurrCanvas
        {
            get
            {
                return mCanvas;
            }
        }

        private RTree mRTree = null;

        public RTree CurrRTree
        {
            get
            {
                return mRTree;
            }
        }

        public double Height
        {
            get
            {
                return mCanvas.Height;
            }

            set
            {
                if (mCanvas.Height == value)
                {
                    return;
                }

                mCanvas.Height = value;

                mRTree.Create();

                UpdateBound();
            }
        }

        public double Width
        {
            get
            {
                return mCanvas.Width;
            }

            set
            {
                if (mCanvas.Width == value)
                {
                    return;
                }

                mCanvas.Width = value;

                mRTree.Create();

                UpdateBound();
            }
        }

        private Rect mBound = Rect.Empty;

        private void UpdateBound()
        {
            mBound = new Rect(new Size(mCanvas.Width, mCanvas.Height));
        }

        private List<BaseEntity> mEntitiesList = new List<BaseEntity>();

        public void AddEntity(BaseEntity entity)
        {
            if (mEntitiesList.Contains(entity))
            {
                return;
            }

            mEntitiesList.Add(entity);

            if (entity.CurrViewer != this)
            {
                entity.CurrViewer = this;
            }

            entity.UpdateView();

            mCanvas.Children.Add(entity.VisualHost);
        }

        public bool Contains(BaseEntity entity)
        {
            return mBound.Contains(entity.CurrPos);
        }

        public void RemoveEntity(BaseEntity entity)
        {
            if (!mEntitiesList.Contains(entity))
            {
                return;
            }

            mEntitiesList.Remove(entity);

            if (entity.CurrViewer == this)
            {
                entity.CurrViewer = null;
            }

            try
            {
                mCanvas.Dispatcher.Invoke(() =>
                {
                    mCanvas.Children.Remove(entity.VisualHost);
                });
            }
            catch
            {
            }
        }

        public ViewerInfo CreateInfo()
        {
            var tmpInfo = new ViewerInfo();

            tmpInfo.Height = Height;
            tmpInfo.Width = Width;

            return tmpInfo;
        }

        public void Assign(ViewerInfo source)
        {
            Height = source.Height;
            Width = source.Width;
        }
    }
}
