using MyNPCLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TmpSandBox.VarOfSentences
{
    public class ATNNodeGenerator
    {
        public ATNNodeGenerator(string path)
        {
            mPath = path;

            LogInstance.Log($"mPath = {mPath}");
        }

        private string mPath;

        public void CreateAndSaveToFile(string stateName)
        {
            LogInstance.Log($"stateName = {stateName}");

            var atnNodeClassName = GetATNNodeClassName(stateName);

            var totalFileName = Path.Combine(mPath, $"{atnNodeClassName}.cs");

            if(File.Exists(totalFileName))
            {
                File.Delete(totalFileName);
            }

            var atnNodeFactoryClassName = GetATNNodeFactoryClassName(stateName);

            var n = 4u;
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var nextNSpaces = StringHelper.Spaces(nextN);
            var sb = new StringBuilder();
            sb.AppendLine("namespace MyNPCLib.NLToCGParsing_v2");
            sb.AppendLine("{");
            sb.AppendLine($"{spaces}public class {atnNodeFactoryClassName}: BaseATNNodeFactory_v2");
            sb.AppendLine($"{spaces}{{");
            sb.AppendLine($"{nextNSpaces}public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)");
            sb.AppendLine($"{nextNSpaces}{{");
            sb.AppendLine($"{nextNSpaces}}}");
            sb.AppendLine($"{spaces}}}");
            sb.AppendLine();
            sb.AppendLine($"{spaces}public class {atnNodeClassName}: BaseATNNode_v2");
            sb.AppendLine($"{spaces}{{");
            sb.AppendLine($"{spaces}}}");

            sb.AppendLine("}");
            sb.AppendLine();
            //sb.AppendLine($"{nextNSpaces}");
            //sb.AppendLine($"{spaces}");
            using (var fs = File.OpenWrite(totalFileName))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.Write(sb.ToString());
                    fs.Flush();
                }
            }

            LogInstance.Log("End");
        }

        private string GetATNNodeClassName(string stateName)
        {
            return $"ATN{stateName.Replace("_", string.Empty)}Node_v2";
        }

        private string GetATNNodeFactoryClassName(string stateName)
        {
            return $"ATN{stateName.Replace("_", string.Empty)}NodeFactory_v2";
        }
    }
}
