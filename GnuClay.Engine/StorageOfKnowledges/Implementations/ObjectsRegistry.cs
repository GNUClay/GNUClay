using GnuClay.Engine.Implementations;
using GnuClay.Engine.Interfaces;
using GnuClay.Engine.StorageOfKnowledges.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.StorageOfKnowledges.Implementations
{
    public class ObjectsRegistry: GnuClayEngineComponent, IObjectsRegistry
    {
        public ObjectsRegistry(IGnuClayEngineContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        private object mLockObj = new object();

        private ulong mCurrIndex = PreDefinedConceptsCodes.MinAutoDefinedIndex;

        private Dictionary<string, ulong> mIdByWordsDict = new Dictionary<string, ulong>();
        private Dictionary<ulong, List<string>> mWordsByIdDict = new Dictionary<ulong, List<string>>();

        public ulong AddWord(string word)
        {
            lock(mLockObj)
            {
                CheckAddedWord(word);

                mCurrIndex++;

                return AddWord(word, mCurrIndex);
            }
        }

        public ulong AddWord(string word, ulong targetKey)
        {
            lock (mLockObj)
            {
                CheckAddedWord(word);

                mIdByWordsDict.Add(word, targetKey);

                mWordsByIdDict.Add(targetKey, new List<string>() { word });

                return mCurrIndex;
            }
        }

        private void CheckAddedWord(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
            {
                throw new ArgumentNullException(nameof(word));
            }

            if (mIdByWordsDict.ContainsKey(word))
            {
                throw new ArgumentOutOfRangeException(nameof(word), $"Word `{word}` already exists.");
            }
        }

        public bool ContainsKey(ulong key)
        {
            lock (mLockObj)
            {
                return mWordsByIdDict.ContainsKey(key);
            }
        }

        public bool ContainsWord(string word)
        {
            lock (mLockObj)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    throw new ArgumentNullException(nameof(word));
                }

                return mIdByWordsDict.ContainsKey(word);
            }
        }

        public ulong GetKey(string word)
        {
            lock (mLockObj)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    throw new ArgumentNullException(nameof(word));
                }

                if (mIdByWordsDict.ContainsKey(word))
                {
                    return mIdByWordsDict[word];
                }

                return 0;
            }
        }

        public void AddWordToExistsKey(string word, ulong key)
        {
            lock (mLockObj)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    throw new ArgumentNullException(nameof(word));
                }

                if(key == 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(key), "The param key can not be 0.");
                }

                if(!ContainsKey(key))
                {
                    throw new ArgumentOutOfRangeException(nameof(key), $"Key `{key}` not exists.");
                }

                if(ContainsWord(word))
                {
                    throw new ArgumentOutOfRangeException(nameof(word), $"This word `{word}` is already registered.");
                }

                mIdByWordsDict.Add(word, key);

                var tmpWordsList = mWordsByIdDict[key];

                tmpWordsList.Add(word);
            }       
        }
    }
}
