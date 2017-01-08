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

        public bool IsNot = false;

        public InsertQueryItemStatisticsKind Kind = InsertQueryItemStatisticsKind.Unknown;

        //public bool IsRule = false;

        public ulong VarsCount
        {
            get
            {
                return (ulong)Vars.Count;
            }
        }

        public List<ulong> Entities = new List<ulong>();

        public List<ulong> Vars = new List<ulong>();

        public Dictionary<RulePart, List<ulong>> IndexedPartsDict = new Dictionary<RulePart, List<ulong>>();

        public Dictionary<ulong, ExpressionNode> LocalRelationsIndex = new Dictionary<ulong, ExpressionNode>();

        public void RegIndex(RulePart part, ExpressionNode node)
        {
            List<ulong> tmpList = null;

            if (IndexedPartsDict.ContainsKey(part))
            {
                tmpList = IndexedPartsDict[part];
            }
            else
            {
                tmpList = new List<ulong>();

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

        public void RegVar(ulong key)
        {
            if(Vars.Contains(key))
            {
                return;
            }

            Vars.Add(key);
        }

        public void RegEntity(ulong key)
        {
            if (Entities.Contains(key))
            {
                return;
            }

            Entities.Add(key);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(Exists));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Exists.ToString());

            tmpSb.Append(nameof(IsNot));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(IsNot.ToString());
            
            tmpSb.Append(nameof(Kind));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Kind.ToString());

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
