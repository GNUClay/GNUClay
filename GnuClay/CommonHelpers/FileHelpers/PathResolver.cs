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
            if (HasEnvVar(path))
            {
                return ResolveEnvVar(path);
            }

            if (HasPathAlias(path))
            {
                return ResolvePathAlias(path);
            }

            if (IsAbsolutePath(path))
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

        private bool HasEnvVar(string path)
        {
            return path.StartsWith("%");
        }

        // https://en.wikipedia.org/wiki/Environment_variable
        // TODO: fix me!
        private string ResolveEnvVar(string path)
        {
            throw new NotImplementedException();
        }

        private bool HasPathAlias(string path)
        {
            return path.StartsWith("$");
        }

        // Like https://docs.microsoft.com/en-us/visualstudio/msbuild/standard-and-custom-toolset-configurations?view=vs-2019
        // TODO: fix me!
        private string ResolvePathAlias(string path)
        {
            throw new NotImplementedException();
        }
    }
}
