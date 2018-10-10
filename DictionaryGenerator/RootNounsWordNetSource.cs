using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DictionaryGenerator
{
    public class RootNounsWordNetSource
    {
        public RootNounsWordNetSource()
        {
            var rootPath = AppDomain.CurrentDomain.BaseDirectory;

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"RootNounsWordNetSource rootPath = {rootPath}");
#endif

            var localPath = @"Resources\WordNet\dict\data.noun";

            mPath = Path.Combine(rootPath, localPath);

#if DEBUG
            NLog.LogManager.GetCurrentClassLogger().Info($"RootNounsWordNetSource mPath = {mPath}");
#endif
        }

        private string mPath;
        private int mSkipFirstLines = 30;

        public List<string> ReadAll()
        {
            var resultList = new List<string>();

            using (var fs = File.OpenRead(mPath))
            {
                using (var sr = new StreamReader(fs))
                {
                    var currentLine = string.Empty;

                    var n = 0;

                    while((currentLine = sr.ReadLine()) != null)
                    {
                        n++;

                        if(n < mSkipFirstLines)
                        {
                            continue;
                        }

#if DEBUG
                        NLog.LogManager.GetCurrentClassLogger().Info($"RootNounsWordNetSource currentLine = {currentLine}");
#endif

                        var sb = new StringBuilder();

                        foreach(var ch in currentLine)
                        {
#if DEBUG
                            NLog.LogManager.GetCurrentClassLogger().Info($"RootNounsWordNetSource ch = {ch} (int)ch = {(int)ch}");
#endif
                        }

#if DEBUG
                        if (n > 200)
                        {
                            break;
                        }
#endif
                    }
                }
            }

            return resultList;
        }
    }
}
