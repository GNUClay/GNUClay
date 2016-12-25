using GnuClay.Engine;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.Serialiazation
{
    public class SerializationRunner
    {
        public void Run()
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Run");

            try
            {
                var tmpEngine = new GnuClayEngine();

                //tmpEngine.Resume();
                //tmpEngine.Resume();
                //tmpEngine.Suspend();
                //tmpEngine.Suspend();
                //tmpEngine.Resume();
                //tmpEngine.Resume();

                var queryString = "INSERT{>: {parent($X1,$X2)} -> {child($X2,$X1)}},{>: {son($X1,$X2)} -> {child($X1,$X2) & male($X1)}},{>: {parent(Tom,Piter)}},{>: {parent(Tom,Mary)}},{>: {male(Piter)}},{>: {female(Mary)}},{>: {male(Bob)}}";

                tmpEngine.Query(queryString);

                byte[] result = null;

                using (var stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    result = tmpEngine.Save();
                    NLog.LogManager.GetCurrentClassLogger().Info($"result.Count() = {result.Count()}");

                    stream.Write(result, 0, result.Count());
                    stream.Flush();
                }

                queryString = "SELECT{son(Piter,$X1)}";

                var tmpEngine_2 = new GnuClayEngine();

                var qr_1 = tmpEngine_2.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(qr_1, tmpEngine_2.DataDictionary));

                tmpEngine_2.Load(result);

                var qr_2 = tmpEngine_2.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(qr_2, tmpEngine_2.DataDictionary));
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
