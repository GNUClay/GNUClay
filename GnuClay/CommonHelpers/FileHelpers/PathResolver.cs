using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GnuClay.CommonHelpers.FileHelpers
{
    public sealed class PathResolver
    {
        public string Resolve(string path)
        {
            return Resolve(path, string.Empty);
        }

        public string Resolve(string path, string basePath)
        {
            if(Path.IsPathRooted(path))
            {
                return path;
            }

            return Path.Combine(basePath, path);
        }
    }
}
