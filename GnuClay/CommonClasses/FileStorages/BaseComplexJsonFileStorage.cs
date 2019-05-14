using GnuClay.CommonHelpers.JsonSerializationHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GnuClay.CommonClasses.FileStorages
{
    public abstract class BaseComplexJsonFileStorage<T>: BaseJsonFileStorage<T> where T : class, new()
    {
        protected BaseComplexJsonFileStorage(string fullFileName, ITypeFactory typeFactory, float version)
            : this(typeFactory, version)
        {
            FullFileName = fullFileName;
        }

        protected BaseComplexJsonFileStorage(string fileName, string directoryName, ITypeFactory typeFactory, float version)
            : this(typeFactory, version)
        {
            FileName = fileName;
            DirectoryName = directoryName;
        }

        protected BaseComplexJsonFileStorage(ITypeFactory typeFactory, float version)
        {
            mTypeFactory = typeFactory;
            mVersion = version;
            mObjectConvertor = new ObjectConvertor();
        }

        #region public members
        public float? ReadVersionFromFile()
        {
            CheckFullFileName();

            if (!File.Exists(FullFileName))
            {
                throw new FileNotFoundException(null, FullFileName);
            }

            var deserializedPlaneObjectsTree = LoadPlaneObjectsTree();

            return deserializedPlaneObjectsTree?.Version;
        }
        #endregion

        #region protected members
        protected override void ProcessSaving()
        {
            var convertedItem = mObjectConvertor.ConvertToPlaneTree(Data, mVersion);

            var convertedItemJson = JsonConvert.SerializeObject(convertedItem);

            SaveContentToStringFile(convertedItemJson);
        }

        protected override void ProcessLoading()
        {
            var deserializedPlaneObjectsTree = LoadPlaneObjectsTree();

            if (deserializedPlaneObjectsTree == null)
            {
                Data = null;
                return;
            }

            if (mVersion > deserializedPlaneObjectsTree.Version)
            {
                throw new NotSupportedException($"Version {deserializedPlaneObjectsTree.Version} of content in file '{FullFileName}' doesn't support.");
            }

            Data = mObjectConvertor.ConvertFromPlaneTree<T>(deserializedPlaneObjectsTree, mTypeFactory);
        }
        #endregion

        #region private members
        private readonly ITypeFactory mTypeFactory;
        private readonly ObjectConvertor mObjectConvertor;
        private readonly float mVersion;

        private PlaneObjectsTree LoadPlaneObjectsTree()
        {
            var content = LoadContentFromStringFile();

            if (string.IsNullOrWhiteSpace(content) || content == "null")
            {
                return null;
            }

            return JsonConvert.DeserializeObject<PlaneObjectsTree>(content);
        }
        #endregion
    }
}
