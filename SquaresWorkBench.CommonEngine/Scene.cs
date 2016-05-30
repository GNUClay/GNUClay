using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SquaresWorkBench.CommonEngine
{
    public class Scene : IDisposable, ISceneForSoftCreator
    {
        public Scene(ScrollViewer viewer)
        {
            mViever = viewer;
        }

        private ScrollViewer mViever = null;

        private MainContext mMainContext = null;

        public void Close()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Close");

            if (mMainContext == null)
            {
                return;
            }

            NLog.LogManager.GetCurrentClassLogger().Info("Close Next");

            mMainContext.CurrActiveContext.StopAll();

            mViever.Content = null;

            mMainContext = null;
        }

        private void NCreateMainContext()
        {
            mMainContext = new MainContext(mViever);

            mMainContext.CurrViewer.Height = 2000;
            mMainContext.CurrViewer.Width = 2000;
        }

        public void New()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("New");

            Close();

            NLog.LogManager.GetCurrentClassLogger().Info("New Next");

            NCreateMainContext();
        }

        public void Dispose()
        {
            Close();
        }

        public void BeginAddEntities()
        {
            if (mMainContext == null)
            {
                return;
            }

            mMainContext.CurrActiveContext.StopAll();
        }

        public void EndAddEntities()
        {
            if (mMainContext == null)
            {
                return;
            }

            mMainContext.CurrActiveContext.ActivateAll();
        }

        public MainContext CurrContext
        {
            get
            {
                return mMainContext;
            }
        }
    }
}
