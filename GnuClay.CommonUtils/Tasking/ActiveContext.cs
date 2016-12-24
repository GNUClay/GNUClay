using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.Tasking
{
    public class ActiveContext
    {
        public ActiveContext()
        {
            mResetEvent = new ManualResetEvent(true);
        }

        private List<ActiveObject> mChildren = new List<ActiveObject>();

        private object mLockObj = new object();

        public void AddChild(ActiveObject child)
        {
            lock (mLockObj)
            {
                if (mChildren.Contains(child))
                {
                    return;
                }

                mChildren.Add(child);

                if (child.Context != this)
                {
                    child.Context = this;
                }
            }
        }

        public void RemoveChild(ActiveObject child)
        {
            lock (mLockObj)
            {
                if (!mChildren.Contains(child))
                {
                    return;
                }

                mChildren.Remove(child);

                if (child.Context == this)
                {
                    child.Context = null;
                }
            }
        }

        private volatile ManualResetEvent mResetEvent = null;

        public ManualResetEvent ResetEvent
        {
            get
            {
                return mResetEvent;
            }
        }

        private volatile bool mIsNeedWait = false;

        public bool IsNeedWait
        {
            get
            {
                return mIsNeedWait;
            }
        }

        private bool mIsRunning = false;

        public bool IsRunning
        {
            get
            {
                lock (mLockObj)
                {
                    return mIsRunning;
                }
            }
        }

        public void ActivateAll()
        {
            lock (mLockObj)
            {
                Suspend();

                var tmpTargetList = mChildren.Where(p => p.IsShouldAutoActivateOnBeginning).ToList();

                foreach (var child in tmpTargetList)
                {
                    child.Run();
                }

                while (tmpTargetList.Count(p => p.IsSuspended) < tmpTargetList.Count)
                {
                }

                Resume();
            }
        }

        public void StopAll()
        {
            lock (mLockObj)
            {
                foreach (var child in mChildren)
                {
                    child.Stop();
                }
            }
        }

        public void Suspend()
        {
            lock (mLockObj)
            {
                mResetEvent.Reset();
                mIsNeedWait = true;
                mIsRunning = false;

                while (mChildren.Count(p => p.IsSuspended) < mChildren.Count)
                {
                }
            }
        }

        public void Resume()
        {
            lock (mLockObj)
            {
                mIsNeedWait = false;
                mIsRunning = true;
                mResetEvent.Set();
            }
        }
    }
}
