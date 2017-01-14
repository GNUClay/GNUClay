using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.OOP
{
    public class GnuClayLocalServerInheritanceSelectQueryRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            try
            {
                var tmpEngine = new GnuClayEngine();

                var queryString = "INSERT {>: {`count of feet`(biped, 2)}}";
                var qr_1 = tmpEngine.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"qr_1 = {SelectResultDebugHelper.ConvertToString(qr_1, tmpEngine.DataDictionary)}");

                queryString = "INSERT {>: {biped(Robot)}}";
                var qr_1_1 = tmpEngine.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"qr_1_1 = {SelectResultDebugHelper.ConvertToString(qr_1_1, tmpEngine.DataDictionary)}");

                queryString = "INSERT {>: {is(human, biped)}}";
                var qr_2 = tmpEngine.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"qr_2 = {SelectResultDebugHelper.ConvertToString(qr_2, tmpEngine.DataDictionary)}");

                var tmpInstanceName = "#957B6203_D200_47E0_B51E_0E8DEF869B3D";

                queryString = "INSERT {>: {is(#957B6203_D200_47E0_B51E_0E8DEF869B3D,human)}}";
                var qr_3 = tmpEngine.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"qr_3 = {SelectResultDebugHelper.ConvertToString(qr_3, tmpEngine.DataDictionary)}");

                queryString = "SELECT {`count of feet`(#957B6203_D200_47E0_B51E_0E8DEF869B3D,$X)}";
                var qr_4 = tmpEngine.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info($"qr_4 = {SelectResultDebugHelper.ConvertToString(qr_4, tmpEngine.DataDictionary)}");

                NLog.LogManager.GetCurrentClassLogger().Info("Run Finish");
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
