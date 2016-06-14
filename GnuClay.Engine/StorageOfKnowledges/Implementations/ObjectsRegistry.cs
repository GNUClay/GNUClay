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

        private ulong mCurrIndex = 0;

        private Dictionary<string, ulong> mIdByWordsDict = new Dictionary<string, ulong>();
        private Dictionary<ulong, List<string>> mWordsByIdDict = new Dictionary<ulong, List<string>>();

        public ulong AddWord(string word)
        {
            lock(mLockObj)
            {
                if (string.IsNullOrWhiteSpace(word))
                {
                    throw new ArgumentNullException(nameof(word));
                }

                if (mIdByWordsDict.ContainsKey(word))
                {
                    return mIdByWordsDict[word];
                }

                mCurrIndex++;

                mIdByWordsDict.Add(word, mCurrIndex);

                mWordsByIdDict.Add(mCurrIndex, new List<string>() { word });

                return mCurrIndex;
            }
        }
    }
}
