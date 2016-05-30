using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    public abstract class ResizedEntity : UnaliveEntity
    {
        protected ResizedEntity()
        {
        }

        private double mHeight = 5;

        [PersistentKVPProperty]
        public double Height
        {
            get
            {
                return mHeight;
            }

            set
            {
                if (mHeight == value)
                {
                    return;
                }

                mHeight = value;

                UpdateView();
            }
        }

        private double mWidth = 5;

        [PersistentKVPProperty]
        public double Width
        {
            get
            {
                return mWidth;
            }

            set
            {
                if (mWidth == value)
                {
                    return;
                }

                mWidth = value;

                UpdateView();
            }
        }
    }
}
