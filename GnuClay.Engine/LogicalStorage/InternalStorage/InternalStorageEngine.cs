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
        public Dictionary<int, List<RulePart>> mRelationIndex = new Dictionary<int, List<RulePart>>();

        public List<RuleInstance> mRulesAndFactsList = new List<RuleInstance>();

        public List<int> mEntitiesList = new List<int>();

        public void AddIndex(int key, RulePart rulePart)
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

        public List<RulePart> GetIndex(int key)
        {
            if (mRelationIndex.ContainsKey(key))
            {
                return mRelationIndex[key];
            }

            return new List<RulePart>();
        }

        public void AddEntity(int key)
        {
            if(mEntitiesList.Contains(key))
            {
                return;
            }

            mEntitiesList.Add(key);
        }
    }
}
