using GnuClay.CG;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters
{
    public interface IConverter
    {
        string ConvertToString(IConceptualNode node);
    }
}
