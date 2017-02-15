using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.CommonData
{
    /// <summary>
    /// Represents instance of rule (or fact) in the storage.
    /// </summary>
    [Serializable]
    public class RuleInstance : IToStringData
    {
        /// <summary>
        /// Head of rule (or fact).
        /// </summary>
        public RulePart Part_1 = null;

        /// <summary>
        /// Body of rule (or fact).
        /// </summary>
        public RulePart Part_2 = null;

        /// <summary>
        /// Count variables in the rule.
        /// </summary>
        public ulong VarsCount = 0;

        /// <summary>
        /// Links key and relation which this key represents in the rule (or fact).
        /// </summary>
        public Dictionary<ulong, ExpressionNode> LocalRelationsIndex = new Dictionary<ulong, ExpressionNode>();

        private ulong mHasheCode = 0;

        /// <summary>
        /// Calculating long hashcode (which may get by GetLongHashCode()).
        /// </summary>
        public void CalculateHashCode()
        {
            //NLog.LogManager.GetCurrentClassLogger().Info("CalculateHashCode");

            mHasheCode = Part_1.GetLongHashCode();

            if (Part_2 == null)
            {
                mHasheCode *= 1000;
            }
            else { 
                mHasheCode += Part_2.GetLongHashCode();
                mHasheCode *= 10000;
            }
        }

        /// <summary>
        /// Returns the hash code for this instance. The hashcode has type long and do not override standard GetHashCode().
        /// </summary>
        /// <returns>The hash code for this instance</returns>
        public ulong GetLongHashCode()
        {
            return mHasheCode;
        }

        /// <summary>
        /// Add some expression node to LocalRelationsIndex.
        /// </summary>
        /// <param name="node">Added expression node.</param>
        public void IndexRelationNode(ExpressionNode node)
        {
            LocalRelationsIndex[node.Key] = node;
        }

        /// <summary>
        /// Get some expression node from LocalRelationsIndex by its key.
        /// </summary>
        /// <param name="key">The key of target expression node.</param>
        /// <returns></returns>
        public ExpressionNode GetRealationNodeByKey(ulong key)
        {
            return LocalRelationsIndex[key];
        }

        public bool IsEquals(RuleInstance item)
        {
            if(item == null)
            {
                return false;
            }

            if(Part_1 == null && item.Part_1 != null)
            {
                return false;
            }

            if(Part_2 == null && item.Part_2 != null)
            {
                return false;
            }

            if(Part_1 != null)
            {
                if(!Part_1.IsEquals(item.Part_1))
                {
                    return false;
                }
            }

            if(Part_2 != null)
            {
                if(!Part_2.IsEquals(item.Part_2))
                {
                    return false;
                }
            }

            return true;
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

            tmpSb.Append(nameof(VarsCount));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(VarsCount.ToString());

            tmpSb.AppendLine(_ObjectHelper._ToString(Part_1, nameof(Part_1)));
            tmpSb.AppendLine(_ObjectHelper._ToString(Part_2, nameof(Part_2)));

            return tmpSb.ToString();
        }
    }
}
