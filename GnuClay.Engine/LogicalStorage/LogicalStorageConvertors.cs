using GnuClay.CommonClientTypes.CommonData;
using GnuClay.Engine.LogicalStorage.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage
{
    public static class LogicalStorageConvertors
    {
        public static ISelectResult Convert(SelectResult source)
        {
            var result = new ExternalSelectResult();
            result.ErrorText = source.ErrorText;
            result.Success = source.Success;
            result.HaveBeenFound = source.HaveBeenFound;

            var resultItems = result.Items;

            foreach (var initItem in source.Items)
            {
                resultItems.Add(Convert(initItem));
            }

            return result;
        }

        public static ISelectResultItem Convert(SelectResultItem source)
        {
            var result = new ExternalSelectResultItem();
            result.Key = source.Key;

            var resultParams = result.Params;

            foreach(var initParam in source.Params)
            {
                var resultParam = new ExternalVarResultItem();
                resultParam.ParamKey = initParam.ParamKey;
                resultParam.EntityKey = initParam.EntityKey;
                resultParam.Kind = initParam.Kind;
                resultParam.Value = initParam.Value;

                resultParams.Add(resultParam);
            }

            return result;
        }
    }
}
