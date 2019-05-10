using GnuClay;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem
{
    public class RuntimeSettingsStorage : BaseBusOfHostsLoggedComponent
    {
        #region constructors
        public RuntimeSettingsStorage(CommonContextOfBusOfHosts context, ILog logger)
            : base(context, logger)
        {
#if DEBUG
            logger.Log("Begin");
#endif

            mDataStorage = new RuntimeSettingsDataStorage();
            mDataStorage.DirectoryName = context.BaseDir;
            mDataStorage.FileName = "RuntimeSettingsDataStorage.json";

            mDataStorage.LoadOrCreate();
        }
        #endregion

        #region public members
        public string GetNameOfCurrentImage()
        {
            return mDataStorage.Data.NameOfCurrentImage;
        }

        public void SetNameOfCurrentImage(string name)
        {
            mDataStorage.Data.NameOfCurrentImage = name;
            mDataStorage.Save();
        }
        #endregion

        #region private members
        private RuntimeSettingsDataStorage mDataStorage;
        #endregion
    }
}
