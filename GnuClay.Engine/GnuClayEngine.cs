using GnuClay.Engine.CommonStorages;
using GnuClay.Engine.InternalCommonData;
using GnuClay.Engine.LogicalStorage;
using GnuClay.Engine.ScriptExecutor;
using GnuClay.Engine.StandardLibrary;
using GnuClay.Engine.StandardLibrary.SupportingMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine
{
    public class GnuClayEngine
    {
        public GnuClayEngine()
        {
            CreateContext();
            InitFromZero();
        }

        public StorageDataDictionary DataDictionary
        {
            get
            {
                return mContext.DataDictionary;
            }
        }

        public LogicalStorageEngine LogicalStorage
        {
            get
            {
                return mContext.LogicalStorage;
            }
        }

        public ScriptExecutorEngine ExecutorEngine
        {
            get
            {
                return mContext.ScriptExecutor;
            }
        }

        private GnuClayEngineComponentContext mContext = null;

        public GnuClayEngineComponentContext Context
        {
            get
            {
                return mContext;
            }
        }

        private void CreateContext()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("CreateContext");

            mContext = new GnuClayEngineComponentContext();

            mContext.DataDictionary = new StorageDataDictionary(mContext);
            mContext.LogicalStorage = new LogicalStorageEngine(mContext);
            mContext.TypeProcessingContext = new TypeProcessingContext(mContext);
            mContext.StandardLibrary = new StandardLibraryEngine(mContext);
            mContext.ScriptExecutor = new ScriptExecutorEngine(mContext);

            mContext.StandardLibrary.CreateProviders();
        }

        private void InitFromZero()
        {
            mContext.StandardLibrary.InitFromZero();
        }
    }
}
