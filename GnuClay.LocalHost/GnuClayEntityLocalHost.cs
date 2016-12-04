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
                result.Success = false;
                result.HasErrors = true;
                result.ErrorText = e.ToString();
                return result;
            }
        }
    }
}
