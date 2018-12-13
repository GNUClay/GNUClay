using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;

namespace MyNPCLib.Serialization
{
    public class SerializationEngine<T>
    {
        public SerializationEngine(string name, decimal version, bool needCompression)
        {
            mName = name;
            mVersion = version;
            mNeedCompression = needCompression;
            mFormatter = new BinaryFormatter();
            //mJsonSerializer = new DataContractJsonSerializer(typeof(T));
        }

        private string mName;
        private decimal mVersion;
        private bool mNeedCompression;
        private BinaryFormatter mFormatter;
        //private DataContractJsonSerializer mJsonSerializer;

        public SerializationPackage SaveToPackage(T item)
        {
            var result = new SerializationPackage();
            result.Version = mVersion;
            result.Name = mName;
            result.Value = SaveToBytes(item);

            if (mNeedCompression)
            {
                result.Value = Compress(result.Value);
            }

            return result;
        }

        public byte[] SaveToBytes(T item)
        {
            using (var packageStream = new MemoryStream())
            {
                mFormatter.Serialize(packageStream, item);
                //mJsonSerializer.WriteObject(packageStream, item);
                packageStream.Flush();
                return packageStream.ToArray();
            }
        }

        private byte[] Compress(byte[] bytes)
        {
            using (var destStream = new MemoryStream())
            {
                using (var sourceStream = new MemoryStream(bytes))
                {
                    using (var compressionStream = new GZipStream(destStream, CompressionMode.Compress))
                    {
                        sourceStream.CopyTo(compressionStream);
                        compressionStream.Flush();
                        return destStream.ToArray();
                    }
                }
            }
        }

        public void SaveToFile(T item, string fileName)
        {
            if(item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if(string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if(File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            var package = SaveToPackage(item);

            using (var fs = File.OpenWrite(fileName))
            {
                mFormatter.Serialize(fs, package);
                fs.Flush();
            }
        }

        public T LoadFromFile(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            using (var fs = File.OpenRead(fileName))
            {
                var package = (SerializationPackage)mFormatter.Deserialize(fs);

                if(mName != package.Name)
                {
                    throw new NotSupportedException($"Content with name `{package.Name}` is not supported. Content must have name `{mName}`.");
                }

                if (mVersion != package.Version)
                {
                    throw new NotSupportedException($"Version {package.Version} is not supported. Now verison {mVersion} is supported.");
                }

                return LoadFromPackage(package);
            }
        }

        public T LoadFromPackage(SerializationPackage package)
        {
            if(mNeedCompression)
            {
                package.Value = Decompress(package.Value);
            }

            return LoadFromBytes(package.Value);
        }

        private byte[] Decompress(byte[] bytes)
        {
            using (var originalStream = new MemoryStream(bytes))
            {
                using (var decompressionStream = new GZipStream(originalStream, CompressionMode.Decompress))
                {
                    using (var decompressedStream = new MemoryStream())
                    {
                        decompressionStream.Flush();
                        decompressionStream.CopyTo(decompressedStream);
                        return decompressedStream.ToArray();
                    }
                }        
            }
        }

        public T LoadFromBytes(byte[] bytes)
        {
            using (var packageStream = new MemoryStream(bytes))
            {
                return (T)mFormatter.Deserialize(packageStream);
            }
        }
    }
}
