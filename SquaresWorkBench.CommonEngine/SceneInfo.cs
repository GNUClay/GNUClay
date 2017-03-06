using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquaresWorkBench.CommonEngine
{
    [Serializable]
    public class SceneInfo : IToStringData
    {
        public ViewerInfo CurrentViewer = null;
        public List<EntityInfo> EntitiesList = new List<EntityInfo>();

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.AppendLine(_ObjectHelper._ToString(CurrentViewer, "CurrentViewer"));

            tmpSb.AppendLine(_ListHelper._ToString(EntitiesList, "EntitiesList"));

            return tmpSb.ToString();
        }
    }
}
