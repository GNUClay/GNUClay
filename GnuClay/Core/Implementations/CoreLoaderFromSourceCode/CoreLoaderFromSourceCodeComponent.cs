using GnuClay.CommonHelpers.FileHelpers;
using GnuClay.Core.CommonInterfaces.CoreCompiler;
using GnuClay.Core.Implementations.CoreCompiler;
using GnuClay.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GnuClay.Core.Implementations.CoreLoaderFromSourceCode
{
    public class CoreLoaderFromSourceCodeComponent : BaseCoreComponent, ICoreLoaderFromSourceCodeComponent
    {
        public CoreLoaderFromSourceCodeComponent(ICoreContext context)
            : base(context, KindOfCoreComponent.CoreLoaderFromSourceCode)
        {
        }

        private readonly List<string> mSuppotedExtensions = new List<string> { "gc.txt", "gcapp.txt" };

        public void LoadAppFromFile(string fileName)
        {
            var fileInfo = new FileInfo(fileName);
            var rootDir = fileInfo.Directory;

            ProcessDir(rootDir);
        }

        public void LoadFromFile(string fileName)
        {
#if DEBUG
            Debug($"fileName = {fileName}");
#endif

            var contents = FileHelper.ReadAllContent(fileName);

#if DEBUG
            Debug($"contents = {contents}");
#endif

            var compiledResult = CoreCompiler.Compile(contents);

#if DEBUG
            Debug($"compiledResult = {compiledResult}");
#endif

            CoreScopesRegistry.BaseScope.AddFromCompiledResult(compiledResult);
        }

        private void ProcessDir(DirectoryInfo directory)
        {
            foreach(var file in directory.GetFiles())
            {
                if (!HasTargetExtension(file.FullName))
                {
                    continue;
                }

                LoadFromFile(file.FullName);
            }

            foreach(var subDirectory in directory.GetDirectories())
            {
                ProcessDir(subDirectory);
            }
        }

        private bool HasTargetExtension(string fileName)
        {
            foreach (var ext in mSuppotedExtensions)
            {
                if(fileName.EndsWith(ext))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
