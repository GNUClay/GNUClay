using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GnuClay.CommonUtils.Tasking
{
    public class ActiveObject
    {
        public ActiveObject()
        {
        }

        public bool IsShouldAutoActivateOnBeginning = true;

        private bool mIsBackground = true;

        public bool IsBackground
        {
            get
            {
                return mIsBackground;
            }

            set
            {
                lock (mLockObj)
                {
                    if (mIsBackground == value)
                    {
                        return;
                    }

                    mIsBackground = value;

                    if (mThread != null)
                    {
                        mThread.IsBackground = mIsBackground;
                    }
                }
            }
        }

        private ThreadPriority mPriority = ThreadPriority.Normal;

        public ThreadPriority Priority
        {
            get
            {
                return mPriority;
            }

            set
            {
                lock (mLockObj)
                {
                    if (mPriority == value)
                    {
                        return;
                    }

                    mPriority = value;

                    if (mThread != null)
                    {
                        mThread.Priority = mPriority;
                    }
                }
            }
        }

        private volatile ActiveContext mContext = null;

        private object mLockObj = new object();

        public ActiveContext Context
        {
            get
            {
                lock (mLockObj)
                {
                    return mContext;
                }
            }

            set
            {
                lock (mLockObj)
                {
                    if (mContext == value)
                    {
                        return;
                    }

                    var tmpOldContext = mContext;

                    mContext = value;

                    if (tmpOldContext != null)
                    {
                        tmpOldContext.RemoveChild(this);
                    }

                    if (mContext != null)
                    {
                        mContext.AddChild(this);
                    }
                }
            }
        }

        private Thread mThread = null;
        private volatile Func<bool> mBeforeStartAction = null;

        public Func<bool> BeforeStartAction
        {
            get
            {
                return mBeforeStartAction;
            }

            set
            {
                if (mBeforeStartAction == value)
                {
                    return;
                }

                mBeforeStartAction = value;
            }
        }

        private volatile ThreadStart mRunAction = null;

        public ThreadStart RunAction
        {
            get
            {
                return mRunAction;
            }

            set
            {
                if (mRunAction == value)
                {
                    return;
                }

                mRunAction = value;
            }
        }

        private volatile bool mIsShouldRun = false;

        public bool IsShouldRun
        {
            get
            {
                return mIsShouldRun;
            }
        }

        private volatile bool mIsSuspended = true;

        public bool IsSuspended
        {
            get
            {
                return mIsSuspended;
            }
        }

        public void RunAsync()
        {
            if (mIsShouldRun)
            {
                return;
            }

            mIsShouldRun = true;
            mIsSuspended = false;

            mThread = new Thread(NRunMethod);
            mThread.IsBackground = mIsBackground;
            mThread.Priority = mPriority;
            mThread.Start();
        }

        public void Run()
        {
            RunAsync();
            mThread.Join();
        }

        public void Stop()
        {
            //if (!mIsShouldRun)
            //{
            //    return;
            //}

            mIsShouldRun = false;

            mThread?.Abort();
            mThread = null;

            mIsSuspended = true;
        }

        private void NRunMethod()
        {
            mIsSuspended = false;

            if (mBeforeStartAction != null)
            {
                if (!mBeforeStartAction())
                {
                    return;
                }
            }

            while (mIsShouldRun)
            {
                if (Context != null)
                {
                    if (Context.IsNeedWait)
                    {
                        mIsSuspended = true;

                        Context.ResetEvent.WaitOne();

                        mIsSuspended = false;
                    }
                }

                mRunAction();
            }
        }
    }
}
