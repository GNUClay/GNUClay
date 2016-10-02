using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.InternalResolver
{
    public class InternalResultParamItem : IToStringData
    {
        public int ParamKey = 0;

        public int EntityKey = 0; 

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(ParamKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(ParamKey.ToString());

            tmpSb.Append(nameof(EntityKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(EntityKey.ToString());

            return tmpSb.ToString();
        }
    }

    public class InternalResultItem : IToStringData
    {
        public List<InternalResultParamItem> ParamsValues = new List<InternalResultParamItem>();

        public Dictionary<int, int> ParamsDict = new Dictionary<int, int>();

        public void End()
        {
            ParamsDict = ParamsValues.ToDictionary(p => p.ParamKey, p => p.EntityKey);
        }

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ListHelper._ToString(ParamsValues, nameof(ParamsValues)));

            tmpSb.AppendLine(_ListHelper._ToString(ParamsDict.ToList(), nameof(ParamsDict)));

            return tmpSb.ToString();
        }
    }

    public class InternalResult : IToStringData
    {
        public List<InternalResultItem> Items = new List<InternalResultItem>();

        public void Map(Dictionary<int, int> map)
        {
            foreach(var tmpItem in Items)
            {
                foreach(var tmpParam in tmpItem.ParamsValues)
                {
                    tmpParam.ParamKey = map[tmpParam.ParamKey];
                }

                tmpItem.End();
            }
        }

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ListHelper._ToString(Items, nameof(Items)));

            return tmpSb.ToString();
        }

        public static InternalResult MergeAsAnd(InternalResult leftResult, InternalResult rightResult)
        {
            var tmpLeftKeys = leftResult.Items.First().ParamsValues.Select(p => p.ParamKey).ToList();

            var tmpRightKeys = rightResult.Items.First().ParamsValues.Select(p => p.ParamKey).ToList();

            var tmpCommonKeys = _ListHelper.Comparare(tmpLeftKeys, tmpRightKeys).MustIgnoredItems;

            if (_ListHelper.IsEmpty(tmpCommonKeys))
            {
                throw new NotSupportedException();
            }

            InternalResult tmpMainResult = null;
            InternalResult tmpSecondResult = null;

            if (tmpLeftKeys.Count >= tmpRightKeys.Count)
            {
                tmpMainResult = leftResult;
                tmpSecondResult = rightResult;
            }
            else
            {
                tmpMainResult = rightResult;
                tmpSecondResult = leftResult;
            }

            var tmpTargetResult = new InternalResult();

            tmpTargetResult.Items = NMergeItemsAsAnd(tmpMainResult.Items, tmpSecondResult.Items, tmpCommonKeys);

            return tmpTargetResult;
        }

        private static List<InternalResultItem> NMergeItemsAsAnd(List<InternalResultItem> mainItems, List<InternalResultItem> secondItems, List<int> commonKeys)
        {
            var tmpResult = new List<InternalResultItem>();

            foreach(var tmpItem in mainItems)
            {
                foreach(var tmpSecondItem in secondItems)
                {
                    bool? tmpHasHit = null;

                    foreach(var tmpKey in commonKeys)
                    {
                        var tmpMainValue = tmpItem.ParamsDict[tmpKey];
                        var tmpSecondValue = tmpSecondItem.ParamsDict[tmpKey];

                        if(tmpMainValue == tmpSecondValue)
                        {
                            if(tmpHasHit == null)
                            {
                                tmpHasHit = true;
                            }
                        }
                        else
                        {
                            tmpHasHit = false;
                        }
                    }

                    if(tmpHasHit == true)
                    {
                        tmpResult.Add(tmpItem);

                        break;
                    }
                }
            }

            return tmpResult;
        }
    }
}
