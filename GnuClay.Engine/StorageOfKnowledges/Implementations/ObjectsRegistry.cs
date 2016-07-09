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
        public const byte MinGenerationsCount = 0;
        public const byte MaxGenerationsCount = 2;

        public ObjectsRegistry(IGnuClayEngineContext context)
            : base(context)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("constructor");
        }

        private object mLockObj = new object();

        private ulong mCurrIndex = PreDefinedConceptsCodes.MinAutoDefinedIndex;

        private Dictionary<string, ulong> mIdByWordsDict = new Dictionary<string, ulong>();
        private Dictionary<ulong, List<string>> mWordsByIdDict = new Dictionary<ulong, List<string>>();

        //private List<ulong> mRemovedKeys = new List<ulong>();

        //private Dictionary<ulong, ulong> mCeneration_0 = new Dictionary<ulong, ulong>();
        //private Dictionary<ulong, ulong> mCeneration_1 = new Dictionary<ulong, ulong>();
        //private Dictionary<ulong, ulong> mCeneration_2 = new Dictionary<ulong, ulong>();

        //private Dictionary<ulong, byte> mGenerationsOfKeys = new Dictionary<ulong, byte>();

        //private Dictionary<ulong, ulong> mTimeOfLife = new Dictionary<ulong, ulong>();

        public ulong AddWord(string word)
        {
            lock(mLockObj)
            {
                CheckAddedWord(word);

                mCurrIndex++;

                return AddWord(word, mCurrIndex, MinGenerationsCount);
            }
        }

        private ulong NCreateCurrIndex()
        {
            /*if(mRemovedKeys.Count == 0)
            {*/
                mCurrIndex++;

                return mCurrIndex;
            /*}

            var tmpIndex = mRemovedKeys.First();

            mRemovedKeys.Remove(tmpIndex);

            return tmpIndex;*/
        }

        public ulong AddWord(string word, ulong targetKey, byte targetGeneration = MaxGenerationsCount)
        {
            lock (mLockObj)
            {
                CheckAddedWord(word);

                mIdByWordsDict.Add(word, targetKey);

                mWordsByIdDict.Add(targetKey, new List<string>() { word });

                //var tmpCurrLifeTime = Context.TimeProvider.Now;

                //SetGenerationForNewKey(targetKey, targetGeneration, tmpCurrLifeTime);

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

        /*private void SetGenerationForNewKey(ulong key, byte targetGeneration, ulong timeOfLife)
        {
            mGenerationsOfKeys.Add(key, targetGeneration);
            mTimeOfLife.Add(key, timeOfLife);

            var tmpGenerationDict = GetDictionaryForTargetGeneration(targetGeneration);

            tmpGenerationDict.Add(key, timeOfLife);
        }*/

        /*private Dictionary<ulong, ulong> GetDictionaryForTargetGeneration(byte targetGeneration)
        {
            switch(targetGeneration)
            {
                case 0:
                    return mCeneration_0;

                case 1:
                    return mCeneration_1;

                case 2:
                    return mCeneration_2;
            }

            var tmpSb = new StringBuilder();

            tmpSb.Append("Generation maybe from 0 to 2 inclusively, but current value is ");
            tmpSb.Append(targetGeneration);

            throw new ArgumentOutOfRangeException(nameof(targetGeneration), tmpSb.ToString());
        }*/
    }
}
