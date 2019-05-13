using GnuClay;
using GnuClay.CommonClasses.CommonExceptions;
using GnuClayUnity3DHost.BusSystem.Internal.RuntimeSettingsSystem;
using System;
using System.Collections.Generic;
using System.IO;
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

        public void InitFromOptions()
        {
            if(string.IsNullOrWhiteSpace(Context.Options.CurrentImage))
            {
                Context.CurrentImageName = Context.RunTimeSettingsStorageComponent.GetNameOfCurrentImage();
            }
            else
            {
                Context.CurrentImageName = Context.Options.CurrentImage;
                Context.RunTimeSettingsStorageComponent.SetNameOfCurrentImage(Context.CurrentImageName);
            }

            var imageDirectoryName = GetCurrentImageDirectory();

#if DEBUG
            Debug($"imageDirectoryName = {imageDirectoryName}");
#endif

            if(string.IsNullOrWhiteSpace(imageDirectoryName))
            {
                return;
            }

            if (!Directory.Exists(imageDirectoryName))
            {
                throw new GnuClayImageNotFoundException(Context.CurrentImageName);
            }
        }

        /// <summary>
        /// Returns current image name.
        /// </summary>
        public string GetCurrentImageName()
        {
            return Context.RunTimeSettingsStorageComponent.GetNameOfCurrentImage();
        }

        public void CreateNewImageAndSetAsCurrent()
        {
            var imageName = Guid.NewGuid().ToString("D");

#if DEBUG
            Debug($"imageName = {imageName}");
#endif

            Context.CurrentImageName = imageName;

            Context.RunTimeSettingsStorageComponent.SetNameOfCurrentImage(imageName);

            InitDirectoriesOfImages();
        }

        public void InitDirectoriesOfImages()
        {
#if DEBUG
            Debug($"Context.CurrentImageName = {Context.CurrentImageName}");
#endif

            var imageDirectoryName = GetCurrentImageDirectory();

#if DEBUG
            Debug($"imageDirectoryName = {imageDirectoryName}");
#endif

            if(!Directory.Exists(imageDirectoryName))
            {
                Directory.CreateDirectory(imageDirectoryName);
            }
            
            Context.CurrentImageDir = imageDirectoryName;

            var imageBusDirectoryName = Path.Combine(imageDirectoryName, "bus");

            if(!Directory.Exists(imageBusDirectoryName))
            {
                Directory.CreateDirectory(imageBusDirectoryName);
            }

            Context.CurrentImageBusDir = imageBusDirectoryName;

            var imageBusParsedFilesDirectoryName = Path.Combine(imageBusDirectoryName, "ParsedFiles");

            if (!Directory.Exists(imageBusParsedFilesDirectoryName))
            {
                Directory.CreateDirectory(imageBusParsedFilesDirectoryName);
            }

            Context.CurrentImageBusParsedFilesDir = imageBusParsedFilesDirectoryName;

            var imageBusIndexFilesDirectoryName = Path.Combine(imageBusDirectoryName, "IndexFiles");

            if (!Directory.Exists(imageBusIndexFilesDirectoryName))
            {
                Directory.CreateDirectory(imageBusIndexFilesDirectoryName);
            }

            Context.CurrentImageBusIndexFilesDir = imageBusIndexFilesDirectoryName;
        }

        /// <summary>
        /// Returns current image.
        /// </summary>
        // TODO: fix me!
        public Image CurentImage
        {
            get
            {
                if(string.IsNullOrWhiteSpace(Context.CurrentImageName))
                {
                    return null;
                }

                var result = new Image
                {
                    Name = Context.CurrentImageName,
                    IsCurrent = true
                };

                return result;
            }
        }

        /// <summary>
        /// Returns all available images on the base directory.
        /// </summary>
        /// <returns>List of all available images on the base directory.</returns>
        public IList<Image> GetAllImages()
        {
            var directoriesList = Directory.EnumerateDirectories(Context.ImagesDir);

            var result = new List<Image>();

            foreach(var dir in directoriesList)
            {
                var item = new Image();

                var directoryInfo = new DirectoryInfo(dir);

                item.Name = directoryInfo.Name;

                if(directoryInfo.Name == Context.CurrentImageName)
                {
                    item.IsCurrent = true;
                }

                result.Add(item);
            }

            return result;
        }
        #endregion

        #region private members
        private RuntimeSettingsStorage mRuntimeSettingsStorage;

        private string GetCurrentImageDirectory()
        {
            if(string.IsNullOrWhiteSpace(Context.CurrentImageName))
            {
                return string.Empty;
            }

            return Path.Combine(Context.ImagesDir, Context.CurrentImageName);
        }
        #endregion
    }
}
