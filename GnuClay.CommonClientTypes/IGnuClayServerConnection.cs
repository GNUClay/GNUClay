using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CommonClientTypes
{
    public interface IGnuClayServerConnection
    {
        IGnuClayEntityConnection ConnectToEntity(string entityName);
    }
}
