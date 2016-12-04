using GnuClay.CommonClientTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.LocalHost
{
    public class GnuClayLocalServer : IGnuClayServerConnection
    {
        public IGnuClayEntityConnection ConnectToEntity(string entityName)
        {
            if(mEntityConnectionDict.ContainsKey(entityName))
            {
                return mEntityConnectionDict[entityName];
            }

            var tmpInstance = new GnuClayEntityLocalHost(entityName);
            mEntityConnectionDict[entityName] = tmpInstance;

            return tmpInstance;
        }

        private Dictionary<string, IGnuClayEntityConnection> mEntityConnectionDict = new Dictionary<string, IGnuClayEntityConnection>();
    }
}
