using GnuClay.CommonHelpers.JsonSerializationHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GnuClay.CommonClasses.Storages
{
    public abstract class BaseSimpleJsonFileStorage<T> : BaseJsonFileStorage<T> where T : class, new()
    {
        protected BaseSimpleJsonFileStorage(string fullFileName)
            : base(fullFileName)
        {
        }

        protected BaseSimpleJsonFileStorage(string fileName, string directoryName)
            : base(fileName, directoryName)
        {
        }

        protected BaseSimpleJsonFileStorage()
        {
        }

        protected override void ProcessSaving()
        {
            var convertedItemJson = JsonConvert.SerializeObject(Data);
            SaveContentToStringFile(convertedItemJson);
        }

        protected override void ProcessLoading()
        {
            var content = LoadContentFromStringFile();

            if (string.IsNullOrWhiteSpace(content) || content == "null")
            {
                Data = null;
                return;
            }

            Data = JsonConvert.DeserializeObject<T>(content);
        }
    }
}
