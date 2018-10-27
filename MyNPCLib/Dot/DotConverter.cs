﻿using MyNPCLib.CG;
using System.IO;
using System.Text;

namespace MyNPCLib.Dot
{
    public class DotConverter
    {
        public static string ConvertToString(ICGNode node)
        {
            var tmpContext = new DotContext();

            var tmpMainLeaf = tmpContext.CreateRootLeaf(node);

            tmpMainLeaf.Run();

            return tmpMainLeaf.Text;
        }

        public static void DumpToFile(ICGNode node, string fileName)
        {
            var dotStr = ConvertToString(node);

            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }

            using (var fs = File.OpenWrite(fileName))
            {
                using (var writer = new StreamWriter(fs, Encoding.UTF8))
                {
                    writer.Write(dotStr);
                    fs.Flush();
                }
            }
        }
    }
}
