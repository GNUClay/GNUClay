using GnuClay.CommonHelpers.DebugHelpers;
using GnuClay.CommonHelpers.JsonSerializationHelpers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GnuClay.CommonClasses.FileStorages
{
    public abstract class BaseJsonFileStorage<T>: IObjectToString, IShortObjectToString, IObjectToBriefString where T: class, new()
    {
        #region constructors
        protected BaseJsonFileStorage(string fullFileName)
        {
            FullFileName = fullFileName;
        }

        protected BaseJsonFileStorage(string fileName, string directoryName)
        {
            FileName = fileName;
            DirectoryName = directoryName;
        }

        protected BaseJsonFileStorage()
        {
        }
        #endregion

        #region public members
        public string FullFileName
        {
            get
            {
                return mFullFileName;
            }

            set
            {
                if (mFullFileName == value)
                {
                    return;
                }

                mFullFileName = value;

                if(string.IsNullOrWhiteSpace(mFullFileName))
                {
                    mFileName = string.Empty;
                    mDirectoryName = string.Empty;
                }

                var fileInfo = new FileInfo(mFullFileName);

                mFileName = fileInfo.Name;
                mDirectoryName = fileInfo.DirectoryName;
            }
        }

        public string FileName
        {
            get
            {
                return mFileName;
            }

            set
            {
                if (mFileName == value)
                {
                    return;
                }

                mFileName = value;

                CreateFullFileName();
            }
        }

        public string DirectoryName
        {
            get
            {
                return mDirectoryName;
            }

            set
            {
                if (mDirectoryName == value)
                {
                    return;
                }

                mDirectoryName = value;

                CreateFullFileName();
            }
        }

        public T Data { get; set; } = default(T);

        public virtual void Load()
        {
            CheckFullFileName();

            if (!File.Exists(mFullFileName))
            {
                throw new FileNotFoundException(null, mFullFileName);
            }

            ProcessLoading();
        }

        public virtual void LoadOrCreate()
        {
            CheckFullFileName();

            if (!File.Exists(mFullFileName))
            {
                Data = new T();
                return;
            }

            ProcessLoading();
        }

        public virtual void Save()
        {
            CheckFullFileName();

            if (Data == null)
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

            if (File.Exists(FullFileName))
            {
                File.Delete(FullFileName);
            }

            ProcessSaving();
        }

        /// <summary>
        /// Clears all data in the storage.
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <returns>A string that represents the current instance.</returns>
        public override string ToString()
        {
            return ToString(0u);
        }

        /// <summary>
        /// Returns a string that represents the current instance.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance.</returns>
        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        /// <summary>
        /// Internal method which returns a string that represents the current instance without additional information, only pair name of property - value.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance without additional information, only pair name of property - value.</returns>
        public string PropertiesToString(uint n)
        {
            var spaces = DisplayHelper.Spaces(n);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(FullFileName)} = {FullFileName}");
            sb.AppendLine($"{spaces}{nameof(FileName)} = {FileName}");
            sb.AppendLine($"{spaces}{nameof(DirectoryName)} = {DirectoryName}");
            return sb.ToString();
        }

        /// <summary>
        /// Returns a string that represents the current instance in short way.
        /// </summary>
        /// <returns>A string that represents the current instance in short way.</returns>
        public string ToShortString()
        {
            return ToShortString(0u);
        }

        /// <summary>
        /// Returns a string that represents the current instance in short way.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in short way.</returns>
        public string ToShortString(uint n)
        {
            return this.GetDefaultToShortStringInformation(n);
        }

        /// <summary>
        /// Internal method which returns a string that represents the current instance in short way without additional information, only pair name of property - value.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in short way without additional information, only pair name of property - value.</returns>
        public string PropertiesToShortString(uint n)
        {
            var spaces = DisplayHelper.Spaces(n);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(FullFileName)} = {FullFileName}");
            sb.AppendLine($"{spaces}{nameof(FileName)} = {FileName}");
            sb.AppendLine($"{spaces}{nameof(DirectoryName)} = {DirectoryName}");
            return sb.ToString();
        }

        /// <summary>
        /// Returns a string that represents the current instance in very short way.
        /// </summary>
        /// <returns>A string that represents the current instance in very short way.</returns>
        public string ToBriefString()
        {
            return ToBriefString(0u);
        }

        /// <summary>
        /// Returns a string that represents the current instance in very short way.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in very short way.</returns>
        public string ToBriefString(uint n)
        {
            return this.GetDefaultToBriefStringInformation(n);
        }

        /// <summary>
        /// Internal method which returns a string that represents the current instance in very short way without additional information, only pair name of property - value.
        /// </summary>
        /// <param name="n">Count of spaces in the string for more comfortable representation.</param>
        /// <returns>A string that represents the current instance in very short way without additional information, only pair name of property - value.</returns>
        public string PropertiesToBriefString(uint n)
        {
            var spaces = DisplayHelper.Spaces(n);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(FullFileName)} = {FullFileName}");
            sb.AppendLine($"{spaces}{nameof(FileName)} = {FileName}");
            sb.AppendLine($"{spaces}{nameof(DirectoryName)} = {DirectoryName}");
            return sb.ToString();
        }
        #endregion

        #region protected members
        protected void CheckFullFileName()
        {
            if (string.IsNullOrWhiteSpace(mFullFileName))
            {
                throw new NullReferenceException("File name can not be null or empty.");
            }
        }

        protected abstract void ProcessLoading();
        protected abstract void ProcessSaving();

        protected void SaveContentToStringFile(string content)
        {
            using (var fs = File.Create(mFullFileName))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(content);
                    fs.Flush();
                }
            }
        }

        protected string LoadContentFromStringFile()
        {
            using (var fs = File.OpenRead(FullFileName))
            {
                using (var sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
        #endregion

        #region private members
        private string mFullFileName = string.Empty;
        private string mFileName = string.Empty;

        private string mDirectoryName = string.Empty;

        private void CreateFullFileName()
        {
            if (string.IsNullOrWhiteSpace(mFileName))
            {
                mFullFileName = string.Empty;
            }
            else
            {
                if (string.IsNullOrWhiteSpace(mDirectoryName))
                {
                    mFullFileName = mFileName;
                }
                else
                {
                    mFullFileName = Path.Combine(mDirectoryName, mFileName);
                }
            }
        }
        #endregion
    }
}
