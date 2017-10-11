using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SquaresWorkBench.CommonEngine
{
    public class Scene : IDisposable, IScene
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

        private double mWidth = 1000;

        public double Width
        {
            get
            {
                return mWidth;
            }
        }

        private double mHeight = 1000;

        public double Height
        {
            get
            {
                return mHeight;
            }
        }

        private void NCreateMainContext()
        {
            mMainContext = new MainContext(mViever);

            mMainContext.CurrViewer.Height = mHeight;
            mMainContext.CurrViewer.Width = mWidth;
        }

        public void New()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("New");

            Close();

            NLog.LogManager.GetCurrentClassLogger().Info("New Next");

            NCreateMainContext();
        }

        /// <summary>
        /// Stop and free all of internal resources.
        /// </summary>
        public void Dispose()
        {
            Close();
        }

        public void BeginAddEntities()
        {
            Stop();
        }

        public void EndAddEntities()
        {
        }

        public void Start()
        {
            if (mMainContext == null)
            {
                return;
            }

            mMainContext.CurrActiveContext.ActivateAll();
        }

        public void Stop()
        {
            if (mMainContext == null)
            {
                return;
            }

            mMainContext.CurrActiveContext.StopAll();
        }

        public MainContext CurrContext
        {
            get
            {
                return mMainContext;
            }
        }

        public object CurrentActiveEntityController { get; set; }

        public List<KeyValuePair<string, string>> ExistingObjectsList { get; set; } = new List<KeyValuePair<string, string>>();
        public List<string> ExistingClassesList = new List<string>();

        public void AddExistingEntity(BaseEntity entity)
        {
            var id = entity.Id;
            var classStr = entity.ClassString;

            ExistingObjectsList.Add(new KeyValuePair<string, string>(id, $"{classStr} {id}"));

            if(ExistingClassesList.Contains(classStr))
            {
                ExistingClassesList.Add(classStr);
            }
        }
    }
}
