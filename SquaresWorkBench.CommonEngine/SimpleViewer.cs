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

        private object mLockObj = new object();
        private ScrollViewer mViever = null;

        private Canvas mCanvas = null;

        public Canvas CurrCanvas
        {
            get
            {
                lock(mLockObj)
                {
                    return mCanvas;
                }           
            }
        }

        private RTree mRTree = null;

        public RTree CurrRTree
        {
            get
            {
                lock (mLockObj)
                {
                    return mRTree;
                }        
            }
        }

        public double Height
        {
            get
            {
                lock (mLockObj)
                {
                    return mCanvas.Height;
                }         
            }

            set
            {
                lock (mLockObj)
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
        }

        public double Width
        {
            get
            {
                lock (mLockObj)
                {
                    return mCanvas.Width;
                }              
            }

            set
            {
                lock (mLockObj)
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
