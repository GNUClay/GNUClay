using GnuClay.CommonUtils.Tasking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SquaresWorkBench.CommonEngine
{
    public class MainContext
    {
        public MainContext(ScrollViewer viewer)
        {
            mCurrActiveContext = new ActiveContext();
            mSimpleViewer = new SimpleViewer(viewer);
            mMovator = new Movator();
            mMovator.CurrActiveContext = mCurrActiveContext;
        }

        private ActiveContext mCurrActiveContext = null;

        public ActiveContext CurrActiveContext
        {
            get
            {
                return mCurrActiveContext;
            }
        }

        private SimpleViewer mSimpleViewer = null;

        public SimpleViewer CurrViewer
        {
            get
            {
                return mSimpleViewer;
            }
        }

        private Movator mMovator = null;

        public Movator CurrMovator
        {
            get
            {
                return mMovator;
            }
        }

        public void Start()
        {
            //mMovator.Start();
            mCurrActiveContext.ActivateAll();
        }
    }
}
