using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.DOT
{
    public class DotConverter: IConverter
    {
        public string ConvertToString(IConceptualNode node)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("ConvertToString");

            throw new NotImplementedException();
        }
    }
}
