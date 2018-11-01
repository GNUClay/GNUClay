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

        public string CreateAndSaveToFile(string stateName, string parentStateName, List<string> nameOfChildList)
        {
            LogInstance.Log($"stateName = {stateName}");

            var atnNodeClassName = GetATNNodeClassName(stateName);

            var parentATNNodeClassName = GetATNNodeClassName(parentStateName);

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
            var nextNextN = nextN + 4;
            var nextNextNSpaces = StringHelper.Spaces(nextNextN);
            var nextNextNextN = nextNextN + 4;
            var nextNextNextNSpaces = StringHelper.Spaces(nextNextNextN);
            var nextNextNextNextN = nextNextNextN + 4;
            var nextNextNextNextNSpaces = StringHelper.Spaces(nextNextNextNextN);

            var nameOfInitDelegate = $"Init{atnNodeClassName.Replace("_v2", string.Empty)}Action";

            var sb = new StringBuilder();
            sb.AppendLine("using MyNPCLib.NLToCGParsing;");
            sb.AppendLine("using System;");
            sb.AppendLine("using System.Collections.Generic;");
            sb.AppendLine("using System.Text;");
            sb.AppendLine();
            sb.AppendLine("namespace MyNPCLib.NLToCGParsing_v2.ATNNodes");
            sb.AppendLine("{");
            sb.AppendLine($"{spaces}public delegate void {nameOfInitDelegate}({atnNodeClassName} item);");
            sb.AppendLine();
            sb.AppendLine($"{spaces}public class {atnNodeFactoryClassName}: BaseATNNodeFactory_v2");
            sb.AppendLine($"{spaces}{{");
            sb.AppendLine($"{nextNSpaces}public {atnNodeFactoryClassName}({parentATNNodeClassName} parentNode, ATNExtendedToken token)");
            sb.AppendLine($"{nextNSpaces}{{");
            sb.AppendLine($"{nextNextNSpaces}mNumberOfConstructor = 1;");
            sb.AppendLine($"{nextNextNSpaces}mParentNode = parentNode;");
            sb.AppendLine($"{nextNextNSpaces}mToken = token;");
            sb.AppendLine($"{nextNSpaces}}}");
            sb.AppendLine();
            sb.AppendLine($"{nextNSpaces}public {atnNodeFactoryClassName}({atnNodeClassName} sameNode, ATNExtendedToken token, {nameOfInitDelegate} initAction)");
            sb.AppendLine($"{nextNSpaces}{{");
            sb.AppendLine($"{nextNextNSpaces}mNumberOfConstructor = 2;");
            sb.AppendLine($"{nextNextNSpaces}mSameNode = sameNode;");
            sb.AppendLine($"{nextNextNSpaces}mToken = token;");
            sb.AppendLine($"{nextNextNSpaces}mInitAction = initAction;");
            sb.AppendLine($"{nextNSpaces}}}");
            sb.AppendLine();
            sb.AppendLine($"{nextNSpaces}private int mNumberOfConstructor;");
            sb.AppendLine($"{nextNSpaces}private {parentATNNodeClassName} mParentNode;");
            sb.AppendLine($"{nextNSpaces}private {atnNodeClassName} mSameNode;");
            sb.AppendLine($"{nextNSpaces}private ATNExtendedToken mToken;");
            sb.AppendLine($"{nextNSpaces}private {nameOfInitDelegate} mInitAction;");
            sb.AppendLine();
            sb.AppendLine($"{nextNSpaces}public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)");
            sb.AppendLine($"{nextNSpaces}{{");
            sb.AppendLine($"{nextNextNSpaces}switch(mNumberOfConstructor)");
            sb.AppendLine($"{nextNextNSpaces}{{");
            sb.AppendLine($"{nextNextNextNSpaces}case 1:");
            sb.AppendLine($"{nextNextNextNextNSpaces}return new {atnNodeClassName}(context, mParentNode, mToken);");
            sb.AppendLine();
            sb.AppendLine($"{nextNextNextNSpaces}case 2:");
            sb.AppendLine($"{nextNextNextNextNSpaces}return new {atnNodeClassName}(context, mSameNode, mInitAction, mToken);");
            sb.AppendLine();
            sb.AppendLine($"{nextNextNextNSpaces}default:");
            sb.AppendLine($"{nextNextNextNextNSpaces}throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);");
            sb.AppendLine($"{nextNextNSpaces}}}");
            sb.AppendLine($"{nextNSpaces}}}");
            sb.AppendLine($"{spaces}}}");
            sb.AppendLine();

            if(!nameOfChildList.IsEmpty())
            {
                sb.AppendLine("/*Sub states:");

                foreach (var nameOfChild in nameOfChildList)
                {
                    sb.AppendLine($"{spaces}{nameOfChild}");
                }
                sb.AppendLine("*/");
                sb.AppendLine();
            }
            
            sb.AppendLine($"{spaces}public class {atnNodeClassName}: BaseATNNode_v2");
            sb.AppendLine($"{spaces}{{");
            sb.AppendLine($"{nextNSpaces}public {atnNodeClassName}(ContextOfATNParsing_v2 context, {parentATNNodeClassName} parentNode, ATNExtendedToken token)");
            sb.AppendLine($"{nextNextNSpaces}: base(context, token)");
            sb.AppendLine($"{nextNSpaces}{{");
            sb.AppendLine($"{nextNextNSpaces}ParentNode = parentNode;");
            sb.AppendLine($"{nextNSpaces}}}");
            sb.AppendLine();
            sb.AppendLine($"{nextNSpaces}public {atnNodeClassName}(ContextOfATNParsing_v2 context, {atnNodeClassName} sameNode, {nameOfInitDelegate} initAction, ATNExtendedToken token)");
            sb.AppendLine($"{nextNextNSpaces}: base(context, token)");
            sb.AppendLine($"{nextNSpaces}{{");
            sb.AppendLine($"{nextNextNSpaces}mSameNode = sameNode;");
            sb.AppendLine($"{nextNextNSpaces}mInitAction = initAction;");
            sb.AppendLine($"{nextNextNSpaces}ParentNode = mSameNode.ParentNode;");
            sb.AppendLine($"{nextNextNSpaces}mInitAction?.Invoke(this);");
            sb.AppendLine($"{nextNSpaces}}}");
            sb.AppendLine();
            sb.AppendLine($"{nextNSpaces}public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.{stateName};");
            sb.AppendLine();
            sb.AppendLine($"{nextNSpaces}public {parentATNNodeClassName} ParentNode {{ get; private set; }}");
            sb.AppendLine($"{nextNSpaces}private {atnNodeClassName} mSameNode;");
            sb.AppendLine($"{nextNSpaces}private {nameOfInitDelegate} mInitAction;");
            sb.AppendLine();
            sb.AppendLine($"{nextNSpaces}protected override void ImplementGoalToken()");
            sb.AppendLine($"{nextNSpaces}{{");
            sb.AppendLine($"{nextNextNSpaces}throw new NotImplementedException();");
            sb.AppendLine($"{nextNSpaces}}}");
            sb.AppendLine();
            sb.AppendLine($"{nextNSpaces}protected override void ProcessNextToken()");
            sb.AppendLine($"{nextNSpaces}{{");
            sb.AppendLine($"{nextNextNSpaces}throw new NotImplementedException();");
            sb.AppendLine($"{nextNSpaces}}}");
            sb.AppendLine($"{spaces}}}");
            sb.AppendLine("}");
            sb.AppendLine();

            //sb.AppendLine($"{nextNextNextNextNSpaces}");
            //sb.AppendLine($"{nextNextNextNSpaces}");
            //sb.AppendLine($"{nextNextNSpaces}");
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

            return totalFileName;
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
