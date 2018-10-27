using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MyNPCLib.Serialization
{
    public class SerializationEngine<T>
    {
        public SerializationEngine(string name, decimal version)
        {
            mName = name;
            mVersion = version;
            mFormatter = new BinaryFormatter();
        }

        private string mName;
        private decimal mVersion;
        private BinaryFormatter mFormatter;

        public SerializationPackage SaveToPackage(T item)
        {
            var result = new SerializationPackage();
            result.Version = mVersion;
            result.Name = mName;
            result.Value = SaveToBytes(item);
            return result;
        }

        public byte[] SaveToBytes(T item)
        {
            using (var packageStream = new MemoryStream())
            {
                mFormatter.Serialize(packageStream, item);
                packageStream.Flush();
                return packageStream.ToArray();
            }
        }

        /*
                    using (var originalStream = new MemoryStream(result))
            {
                using (var compressedStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (var compressionStream = new GZipStream(compressedStream, CompressionMode.Compress))
                    {
                        originalStream.CopyTo(compressionStream);
                    }
                }
            }
         */

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
            return LoadFromBytes(package.Value);
        }

        /*
        
                using (var originalStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    using (var decompressionStream = new GZipStream(originalStream, CompressionMode.Decompress))
                    {
                        using (var decompressedStream = new MemoryStream())
                        {
                            decompressionStream.CopyTo(decompressedStream);

                            GnuClayEngine.Load(decompressedStream.ToArray());
                        }
                    }                     
                }  
        */

        public T LoadFromBytes(byte[] bytes)
        {
            using (var packageStream = new MemoryStream(bytes))
            {
                return (T)mFormatter.Deserialize(packageStream);
            }
        }
    }
}
