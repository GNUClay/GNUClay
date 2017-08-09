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

        public Dictionary<ulong, List<RulePart>> mRelationPartsIndex;
        public Dictionary<ulong, RuleInstance> mRulesAndFactsDict;
        public Dictionary<ulong, List<RuleInstance>> mLongHasheCodeRulesAndFactsDict;
        public List<ulong> mEntitiesList;

        [Serializable]
        private class Data
        {
            public Dictionary<ulong, List<RulePart>> mRelationPartsIndex;
            public Dictionary<ulong, RuleInstance> mRulesAndFactsDict;
            public Dictionary<ulong, List<RuleInstance>> mLongHasheCodeRulesAndFactsDict;
            public List<ulong> mEntitiesList;
        }

        public void AddPartIndex(ulong key, RulePart rulePart)
        {
            List<RulePart> tmpList = null;

            if (mRelationPartsIndex.ContainsKey(key))
            {
                tmpList = mRelationPartsIndex[key];
            }
            else
            {
                tmpList = new List<RulePart>();

                mRelationPartsIndex.Add(key, tmpList);
            }

            if(tmpList.Contains(rulePart))
            {
                return;
            }

            tmpList.Add(rulePart);
        }

        public List<RulePart> GetIndex(ulong key)
        {
            if (mRelationPartsIndex.ContainsKey(key))
            {
                return mRelationPartsIndex[key];
            }

            return new List<RulePart>();
        }

        private void RemovePartIndex(RulePart rulePart)
        {
            throw new NotImplementedException();
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

        private void RemoveExistsStatisticsHashCode(RuleInstance targetItem)
        {
            var hasheCode = targetItem.GetLongHashCode();
            var tmpList = mLongHasheCodeRulesAndFactsDict[hasheCode];
            tmpList.Remove(targetItem);
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

        public void RemoveFactOrRuleByKey(ulong key)
        {
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveFactOrRuleByKey key = {key}");
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveFactOrRuleByKey pre mRulesAndFactsDict.Count = {mRulesAndFactsDict.Count}");
#endif

            var targetItem = mRulesAndFactsDict[key];
            mRulesAndFactsDict.Remove(key);
#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveFactOrRuleByKey after mRulesAndFactsDict.Count = {mRulesAndFactsDict.Count}");
            NLog.LogManager.GetCurrentClassLogger().Info($"RemoveFactOrRuleByKey targetItem = {targetItem}");
#endif

            RemoveExistsStatisticsHashCode(targetItem);

            RemovePartIndex(targetItem.Part_1);

            var part_2 = targetItem.Part_2;

            if (part_2 != null)
            {
                RemovePartIndex(part_2);
            }

            throw new NotImplementedException();
        }

        public object Save()
        {
            var tmpData = new Data();
            tmpData.mRelationPartsIndex = mRelationPartsIndex;
            tmpData.mRulesAndFactsDict = mRulesAndFactsDict;
            tmpData.mLongHasheCodeRulesAndFactsDict = mLongHasheCodeRulesAndFactsDict;
            tmpData.mEntitiesList = mEntitiesList;
            return tmpData;
        }

        public void Load(object value)
        {
            var tmpData = (Data)value;
            mRelationPartsIndex = tmpData.mRelationPartsIndex;
            mRulesAndFactsDict = tmpData.mRulesAndFactsDict;
            mLongHasheCodeRulesAndFactsDict = tmpData.mLongHasheCodeRulesAndFactsDict;
            mEntitiesList = tmpData.mEntitiesList;
        }

        public void Clear()
        {
            mRelationPartsIndex = new Dictionary<ulong, List<RulePart>>();
            mRulesAndFactsDict = new Dictionary<ulong, RuleInstance>();
            mLongHasheCodeRulesAndFactsDict = new Dictionary<ulong, List<RuleInstance>>();
            mEntitiesList = new List<ulong>();
        }
    }
}
