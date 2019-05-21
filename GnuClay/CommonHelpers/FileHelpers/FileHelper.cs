using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GnuClay.CommonHelpers.FileHelpers
{
    public static class FileHelper
    {
        public static string ReadAllContent(string fileName)
        {
            using (var fs = File.OpenRead(fileName))
            {
                using (var sr = new StreamReader(fs))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
