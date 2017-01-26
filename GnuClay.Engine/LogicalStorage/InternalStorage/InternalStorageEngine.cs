using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalStorage
{
    public class InternalStorageEngine
    {
        public InternalStorageEngine()
        {
            Clear();
        }

        public Dictionary<ulong, List<RulePart>> mRelationIndex;
        public List<RuleInstance> mRulesAndFactsList;
        public Dictionary<ulong, List<RuleInstance>> mLongHasheCodeRulesAndFactsDict;
        public List<ulong> mEntitiesList;

        [Serializable]
        private class Data
        {
            public Dictionary<ulong, List<RulePart>> mRelationIndex;
            public List<RuleInstance> mRulesAndFactsList;
            public Dictionary<ulong, List<RuleInstance>> mLongHasheCodeRulesAndFactsDict;
            public List<ulong> mEntitiesList;
        }

        public void AddIndex(ulong key, RulePart rulePart)
        {
            List<RulePart> tmpList = null;

            if (mRelationIndex.ContainsKey(key))
            {
                tmpList = mRelationIndex[key];
            }
            else
            {
                tmpList = new List<RulePart>();

                mRelationIndex.Add(key, tmpList);
            }

            if(tmpList.Contains(rulePart))
            {
                return;
            }

            tmpList.Add(rulePart);
        }

        public List<RulePart> GetIndex(ulong key)
        {
            if (mRelationIndex.ContainsKey(key))
            {
                return mRelationIndex[key];
            }

            return new List<RulePart>();
        }

        public void AddEntity(ulong key)
        {
            if(mEntitiesList.Contains(key))
            {
                return;
            }

            mEntitiesList.Add(key);
        }

        public void RegExistsStatisticsHashCode(RuleInstance targetItem)
        {
            List<RuleInstance> tmpList = null;

            var hasheCode = targetItem.GetLongHashCode();

            if (mLongHasheCodeRulesAndFactsDict.ContainsKey(hasheCode))
            {
                tmpList = mLongHasheCodeRulesAndFactsDict[hasheCode];
            }
            else
            {
                tmpList = new List<RuleInstance>();

                mLongHasheCodeRulesAndFactsDict.Add(hasheCode, tmpList);
            }

            tmpList.Add(targetItem);
        }

        public bool RegEntity(ulong key)
        {
            if (mEntitiesList.Contains(key))
            {
                return false;
            }

            mEntitiesList.Add(key);

            return true;
        }

        public object Save()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Save");

            var tmpData = new Data();
            tmpData.mRelationIndex = mRelationIndex;
            tmpData.mRulesAndFactsList = mRulesAndFactsList;
            tmpData.mLongHasheCodeRulesAndFactsDict = mLongHasheCodeRulesAndFactsDict;
            tmpData.mEntitiesList = mEntitiesList;
            return tmpData;
        }

        public void Load(object value)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Load");

            var tmpData = (Data)value;
            mRelationIndex = tmpData.mRelationIndex;
            mRulesAndFactsList = tmpData.mRulesAndFactsList;
            mLongHasheCodeRulesAndFactsDict = tmpData.mLongHasheCodeRulesAndFactsDict;
            mEntitiesList = tmpData.mEntitiesList;
        }

        public void Clear()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clear");

            mRelationIndex = new Dictionary<ulong, List<RulePart>>();
            mRulesAndFactsList = new List<RuleInstance>();
            mLongHasheCodeRulesAndFactsDict = new Dictionary<ulong, List<RuleInstance>>();
            mEntitiesList = new List<ulong>();
        }
    }
}
