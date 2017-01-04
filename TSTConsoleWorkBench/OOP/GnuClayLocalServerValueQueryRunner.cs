using GnuClay.Engine;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.LocalHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.OOP
{
    public class GnuClayLocalServerValueQueryRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            try
            {
                var GnuClayEngine = new GnuClayEngine();

                var queryString = "INSERT {>: {age(Tom,25.4)}}";

                var qr_1 = GnuClayEngine.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"qr_1 = {SelectResultDebugHelper.ConvertToString(qr_1, GnuClayEngine.DataDictionary)}");

                queryString = "SELECT {age(Tom, $X1)}";

                var qr_2 = GnuClayEngine.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"qr_2 = {SelectResultDebugHelper.ConvertToString(qr_2, GnuClayEngine.DataDictionary)}");
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
