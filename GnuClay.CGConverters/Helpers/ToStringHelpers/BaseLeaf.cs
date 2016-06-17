using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.Helpers.ToStringHelpers
{
    public abstract class BaseLeaf: IBaseLeaf
    {
        protected BaseLeaf(ILeafContext context)
        {
            mContext = context;
        }

        public virtual bool IsContainer
        {
            get
            {
                return false;
            }
        }

        public virtual IBaseLeaf SomeChildLeaf
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private ILeafContext mContext = null;

        protected ILeafContext Context
        {
            get
            {
                return mContext;
            }
        }

        private StringBuilder mSb = null;

        protected StringBuilder Sb
        {
            get
            {
                return mSb;
            }
        }

        public string Text
        {
            get
            {
                if (mSb == null)
                {
                    return string.Empty;
                }

                return mSb.ToString();
            }
        }

        private string mName = string.Empty;

        public string Name
        {
            protected set
            {
                mName = value;
            }

            get
            {
                return mName;
            }
        }

        public void Run()
        {
            mSb = new StringBuilder();

            OnRun();
        }

        protected virtual void OnRun()
        {
        }
    }
}
