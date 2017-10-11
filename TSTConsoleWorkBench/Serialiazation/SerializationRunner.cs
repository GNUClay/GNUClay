using GnuClay.Engine;
using GnuClay.Engine.LogicalStorage.DebugHelpers;
using GnuClay.LocalHost;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
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

                var result = tmpEngine.Save();

                using (var originalStream = new MemoryStream(result))
                {
                    using (var compressedStream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None))
                    {
                        using (var compressionStream = new GZipStream(compressedStream, CompressionMode.Compress))
                        {
                            originalStream.CopyTo(compressionStream);
                        }
                    }
                }

                /*using (var stream = new FileStream("MyFile.bin", FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    
                    NLog.LogManager.GetCurrentClassLogger().Info($"result.Count() = {result.Count()}");

                    stream.Write(result, 0, result.Count());
                    stream.Flush();
                }*/

                queryString = "SELECT{son(Piter,$X1)}";

                var tmpEngine_2 = new GnuClayEngine();

                var qr_1 = tmpEngine_2.Query(queryString);

                NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(qr_1, tmpEngine_2.DataDictionary));

                tmpEngine_2.Load(result);

                var qr_2 = tmpEngine_2.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(qr_2, tmpEngine_2.DataDictionary));

                tmpEngine_2.Clear();

                var qr_3 = tmpEngine_2.Query(queryString);
                NLog.LogManager.GetCurrentClassLogger().Info(SelectResultDebugHelper.ConvertToString(qr_3, tmpEngine_2.DataDictionary));

                var mEntityName = "#0813940A_EAC6_47E7_BF57_9B8C05E2168A";
                var mServerConnection = new GnuClayLocalServer();
                var mEntityConnection = mServerConnection.ConnectToNPC(mEntityName);

                mEntityConnection.Save($"{mEntityName}.gcd");

                mEntityConnection.Destroy();
            }
            catch (Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Info(e);
            }
        }
    }
}
