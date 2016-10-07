using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class InsertQueryItemStatistics : IToStringData
    {
        public RuleInstance Target = null;

        public bool Exists = false;

        public bool IsRule = false;

        public int VarsCount
        {
            get
            {
                return Vars.Count;
            }
        }

        public List<int> Entities = new List<int>();

        public List<int> Vars = new List<int>();

        public Dictionary<RulePart, List<int>> IndexedPartsDict = new Dictionary<RulePart, List<int>>();

        public Dictionary<int, ExpressionNode> LocalRelationsIndex = new Dictionary<int, ExpressionNode>();

        public void RegIndex(RulePart part, ExpressionNode node)
        {
            List<int> tmpList = null;

            if (IndexedPartsDict.ContainsKey(part))
            {
                tmpList = IndexedPartsDict[part];
            }
            else
            {
                tmpList = new List<int>();

                IndexedPartsDict.Add(part, tmpList);
            }

            if(tmpList.Contains(node.Key))
            {
                return;
            }

            tmpList.Add(node.Key);

            if(!LocalRelationsIndex.ContainsKey(node.Key))
            {
                LocalRelationsIndex[node.Key] = node;
            }
        }

        public void RegVar(int key)
        {
            if(Vars.Contains(key))
            {
                return;
            }

            Vars.Add(key);
        }

        public void RegEntity(int key)
        {
            if (Entities.Contains(key))
            {
                return;
            }

            Entities.Add(key);
        }

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(Exists));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Exists.ToString());

            tmpSb.Append(nameof(IsRule));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(IsRule.ToString());

            tmpSb.Append(nameof(VarsCount));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(VarsCount.ToString());

            tmpSb.AppendLine(_ListHelper._ToString(Entities, nameof(Entities)));

            tmpSb.AppendLine(_ListHelper._ToString(Vars, nameof(Vars)));

            tmpSb.AppendLine("Begin IndexedPartsDict");

            foreach (var tmpItem in IndexedPartsDict)
            {
                tmpSb.Append(tmpItem.Key.GetHashCode());
                tmpSb.AppendLine(":");

                foreach(var tmpKey in tmpItem.Value)
                {
                    tmpSb.AppendLine(tmpKey.ToString());
                }
            }

            tmpSb.AppendLine("End IndexedPartsDict");

            tmpSb.AppendLine(_ListHelper._ToString(LocalRelationsIndex.ToList(), nameof(LocalRelationsIndex)));

            return tmpSb.ToString();
        }
    }
}
