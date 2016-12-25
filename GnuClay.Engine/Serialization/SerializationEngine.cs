using GnuClay.Engine.InternalCommonData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Serialization
{
    public class SerializationEngine : BaseGnuClayEngineComponent
    {
        private static decimal CurrentVersion = 0.2M;

        public SerializationEngine(GnuClayEngineComponentContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"SerializationEngine CurrentVersion = {CurrentVersion}");
        }

        public byte[] Save()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Save");

            var serializationInfo = new SerializationInfo();

            serializationInfo.StorageDataDictionaryInfo = Context.DataDictionary.Save();
            serializationInfo.LogicalStorageInfo = Context.LogicalStorage.Save();

            var formatter = new BinaryFormatter();

            using (var packageStream = new MemoryStream())
            {
                var package = new SerializationPackage();
                package.Version = CurrentVersion;

                using (var infoStream = new MemoryStream())
                {
                    formatter.Serialize(infoStream, serializationInfo);
                    package.Value = infoStream.ToArray();
                }

                formatter.Serialize(packageStream, package);

                return packageStream.ToArray();
            }
        }

        public void Load(byte[] value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Load");

            var formatter = new BinaryFormatter();

            SerializationInfo serializationInfo = null;

            using (var packageStream = new MemoryStream(value))
            {
                var package = (SerializationPackage)formatter.Deserialize(packageStream);

                NLog.LogManager.GetCurrentClassLogger().Info($"Load package.Version = {package.Version}");

                if(CurrentVersion > package.Version)
                {
                    throw new NotSupportedException($"Version {package.Version} is not supported. Now verison {CurrentVersion} is supported.");
                }

                using (var infoStream = new MemoryStream(package.Value))
                {
                    serializationInfo = (SerializationInfo)formatter.Deserialize(infoStream);
                }
            }

            Context.DataDictionary.Load(serializationInfo.StorageDataDictionaryInfo);
            Context.LogicalStorage.Load(serializationInfo.LogicalStorageInfo);
        }
    }
}
