using GnuClay.CommonClientTypes;
using GnuClay.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuClay.CommonClientTypes.ResultTypes;

namespace GnuClay.LocalHost
{
    public class GnuClayEntityLocalHost: IGnuClayEntityConnection
    {
        public GnuClayEntityLocalHost(string entityName)
        {
            mEntityName = entityName;

            GnuClayEngine = new GnuClayEngine();
        }

        private string mEntityName = null;
        private GnuClayEngine GnuClayEngine = null;

        public SelectResult Query(string text)
        {
            NLog.LogManager.GetCurrentClassLogger().Info($"Query text = `{text}`");

            try
            {
                return GnuClayEngine.Query(text);
            }catch(Exception e)
            {
                var result = new SelectResult();
                result.HaveBeenFound = false;
                result.Success = false;
                result.ErrorText = e.ToString();
                return result;
            }
        }

        public string GetValue(int key)
        {
            return GnuClayEngine.DataDictionary.GetValue(key);
        }

        public int UniqueKeysCount()
        {
            return GnuClayEngine.DataDictionary.UniqueKeysCount();
        }
    }
}
