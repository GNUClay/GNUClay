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
            if(IsAbsolutePath(path))
            {
                return path;
            }

            return Path.Combine(basePath, path);
        }

        private bool IsAbsolutePath(string path)
        {
            if(path.StartsWith("/"))
            {
                return true;
            }

            if(path.Contains(@":\"))
            {
                return true;
            }

            if (path.Contains(":/"))
            {
                return true;
            }

            return false;
        }
    }
}
