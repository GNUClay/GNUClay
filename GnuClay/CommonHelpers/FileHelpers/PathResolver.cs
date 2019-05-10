using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GnuClay.CommonHelpers.FileHelpers
{
    /// <summary>
    /// It helps to convert a path to canonical view.
    /// </summary>
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

        private string ResolveEnvVar(string path)
        {
            path = path.Substring(1);
            var pos = path.IndexOf("%");
            var varName = path.Substring(0, pos);
            path = path.Substring(pos + 1).Trim();

            if(path.StartsWith("/"))
            {
                path = path.Substring(1).Trim();
            }
            else
            {
                if(path.StartsWith(@"\"))
                {
                    path = path.Substring(1).Trim();
                }
            }

            var varPath = MapVarName(varName);
            return Path.Combine(varPath, path);
        }

        private bool HasPathAlias(string path)
        {
            return path.StartsWith("$");
        }

        private string ResolvePathAlias(string path)
        {
            path = path.Substring(2);
            var pos = path.IndexOf(")");
            var varName = path.Substring(0, pos);
            path = path.Substring(pos + 1);

            if (path.StartsWith("/"))
            {
                path = path.Substring(1).Trim();
            }
            else
            {
                if (path.StartsWith(@"\"))
                {
                    path = path.Substring(1).Trim();
                }
            }

            var varPath = MapVarName(varName);
            return Path.Combine(varPath, path);
        }

        private string MapVarName(string varName)
        {
            if(Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                throw new NotSupportedException();
            }

            switch(varName)
            {
                case "PWD":
                    return Environment.CurrentDirectory;

                case "SystemRoot":
                    return Environment.GetEnvironmentVariable("SystemRoot");

                case "ProgramData":
                    return Environment.GetEnvironmentVariable("ProgramData");

                case "TEMP":
                case "TMP":
                    return Environment.GetEnvironmentVariable("TEMP");

                case "DriverData":
                    return Environment.GetEnvironmentVariable("DriverData");

                case "HOMEDRIVE":
                    return Environment.GetEnvironmentVariable("HOMEDRIVE");

                case "APPDATA":
                case "AppData":
                    return Environment.GetEnvironmentVariable("APPDATA");

                case "VSAPPIDDIR":
                    return Environment.GetEnvironmentVariable("VSAPPIDDIR");

                case "ProgramFiles(x86)":
                    return Environment.GetEnvironmentVariable("ProgramFiles(x86)");

                case "VisualStudioDir":
                    return Environment.GetEnvironmentVariable("VisualStudioDir");

                case "GTK_BASEPATH":
                    return Environment.GetEnvironmentVariable("GTK_BASEPATH");

                case "OneDrive":
                    return Environment.GetEnvironmentVariable("OneDrive");

                case "CommonProgramW6432":
                    return Environment.GetEnvironmentVariable("CommonProgramW6432");

                case "ALLUSERSPROFILE":
                    return Environment.GetEnvironmentVariable("ALLUSERSPROFILE");

                case "ProgramW6432":
                    return Environment.GetEnvironmentVariable("ProgramW6432");

                case "LOCALAPPDATA":
                    return Environment.GetEnvironmentVariable("LOCALAPPDATA");

                case "CommonProgramFiles(x86)":
                    return Environment.GetEnvironmentVariable("CommonProgramFiles(x86)");

                case "windir":
                    return Environment.GetEnvironmentVariable("windir");

                case "CommonProgramFiles":
                    return Environment.GetEnvironmentVariable("CommonProgramFiles");

                case "USERPROFILE":
                    return Environment.GetEnvironmentVariable("USERPROFILE");

                case "SystemDrive":
                    return Environment.GetEnvironmentVariable("SystemDrive");

                case "ProgramFiles":
                    return Environment.GetEnvironmentVariable("ProgramFiles");

                case "PUBLIC":
                    return Environment.GetEnvironmentVariable("PUBLIC");

                default:
                    throw new ArgumentOutOfRangeException(nameof(varName), varName, null);
            }
        }
    }
}
