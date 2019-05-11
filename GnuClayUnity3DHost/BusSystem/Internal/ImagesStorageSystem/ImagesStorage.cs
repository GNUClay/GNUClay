using GnuClay;
using GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem;
using System;
using System.Collections.Generic;
using System.Text;

namespace GnuClayUnity3DHost.BusSystem.Internal.ImagesStorageSystem
{
    public class ImagesStorage: BaseBusOfHostsLoggedComponent
    {
        public ImagesStorage(CommonContextOfBusOfHosts context, ILog logger)
            : base(context, logger)
        {
        }

        #region public members
        public override void InitStep1()
        {
            base.InitStep1();
            mRuntimeSettingsStorage = Context.RunTimeSettingsStorageComponent;
        }

        /// <summary>
        /// Returns current image name.
        /// </summary>
        // TODO: fix me!
        public string GetCurrentImageName()
        {
            throw new NotImplementedException();
        }

        // TODO: fix me!
        public void CreateNewImageAndSetAsCurrent()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns current image.
        /// </summary>
        // TODO: fix me!
        public Image CurentImage
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// Returns all available images on the base directory.
        /// </summary>
        /// <returns>List of all available images on the base directory.</returns>
        // TODO: fix me!
        public IList<Image> GetAllImages()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region private members
        private RuntimeSettingsStorage mRuntimeSettingsStorage;
        #endregion
    }
}
