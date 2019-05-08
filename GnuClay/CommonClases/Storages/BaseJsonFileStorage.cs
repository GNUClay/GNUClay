using GnuClay.CommonHelpers.JsonSerializationHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GnuClay.CommonClases.Storages
{
    public abstract class BaseJsonFileStorage<T> where T: class, new()
    {
        // TODO: fix me!
        protected BaseJsonFileStorage(string fullFileName, ITypeFactory typeFactory, float version)
            : this(typeFactory, version)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"BaseJsonFileStorage(1) fullFileName = {fullFileName}");
            NLog.LogManager.GetCurrentClassLogger().Info($"BaseJsonFileStorage(1) version = {version}");
#endif

            FullFileName = fullFileName;
        }

        // TODO: fix me!
        protected BaseJsonFileStorage(string fileName, string directoryName, ITypeFactory typeFactory, float version)
            : this(typeFactory, version)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"BaseJsonFileStorage(2) fileName = {fileName}");
            NLog.LogManager.GetCurrentClassLogger().Info($"BaseJsonFileStorage(2) directoryName = {directoryName}");
            NLog.LogManager.GetCurrentClassLogger().Info($"BaseJsonFileStorage(2) version = {version}");
#endif

            FileName = fileName;
            DirectoryName = directoryName;
        }

        protected BaseJsonFileStorage(ITypeFactory typeFactory, float version)
        {
            mTypeFactory = typeFactory;
            mVersion = version;
            mObjectConvertor = new ObjectConvertor();
        }

        private readonly ITypeFactory mTypeFactory;
        private readonly ObjectConvertor mObjectConvertor;
        private readonly float mVersion;

        private string mFullFileName = string.Empty;

        // TODO: fix me!
        public string FullFileName
        {
            get
            {
                return mFullFileName;
            }

            set
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"set FullFileName value = {value}");
#endif

                if(mFullFileName == value)
                {
                    return;
                }

                mFullFileName = value;

                throw new NotImplementedException();
            }
        }

        private string mFileName = string.Empty;

        public string FileName
        {
            get
            {
                return mFileName;
            }

            set
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"set FileName value = {value}");
#endif

                if(mFileName == value)
                {
                    return;
                }

                mFileName = value;

                CreateFullFileName();
            }
        }

        private void CreateFullFileName()
        {
            if(string.IsNullOrWhiteSpace(mFileName))
            {
                mFullFileName = string.Empty;
            }
            else
            {
                if(string.IsNullOrWhiteSpace(mDirectoryName))
                {
                    mFullFileName = mFileName;
                }
                else
                {
                    mFullFileName = Path.Combine(mDirectoryName, mFileName);
                }
            }

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"CreateFullFileName mFullFileName = {mFullFileName}");
#endif
        }

        private string mDirectoryName = string.Empty;

        public string DirectoryName
        {
            get
            {
                return mDirectoryName;
            }

            set
            {
#if DEBUG
                NLog.LogManager.GetCurrentClassLogger().Info($"set DirectoryName value = {value}");
#endif

                if(mDirectoryName == value)
                {
                    return;
                }

                mDirectoryName = value;

                CreateFullFileName();
            }
        }

        public T Instance { get; set; }

        // TODO: fix me!
        public virtual void Load()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("Load");
#endif

            throw new NotImplementedException();
        }

        // TODO: fix me!
        public virtual void LoadOrCreate()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info("LoadOrCreate");
#endif

            throw new NotImplementedException();
        }

        // TODO: fix me!
        public virtual void Save()
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Save mFullFileName = {mFullFileName}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Save mVersion = {mVersion}");
            NLog.LogManager.GetCurrentClassLogger().Info($"Save Instance = {Instance}");
#endif

            if (string.IsNullOrWhiteSpace(mFullFileName))
            {
                throw new NullReferenceException("File name can not be null or empty.");
            }

            if (Instance == null)
            {
                if (File.Exists(mFullFileName))
                {
                    File.Delete(mFullFileName);
                }

                using (var fs = File.Create(mFullFileName))
                {
                    using (var sw = new StreamWriter(fs))
                    {
                        sw.Write("null");
                        fs.Flush();
                    }
                }

                return;
            }

            var convertedItem = mObjectConvertor.ConvertToPlaneTree(Instance, mVersion);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Save convertedItem = {convertedItem}");
#endif

            var convertedItemJson = JsonConvert.SerializeObject(convertedItem);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"Save convertedItemJson = {convertedItemJson}");
#endif

            if (File.Exists(mFullFileName))
            {
                File.Delete(mFullFileName);
            }

            using (var fs = File.Create(mFullFileName))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(convertedItemJson);
                    fs.Flush();
                }
            }
        }

        public abstract void Clear();
    }
}
