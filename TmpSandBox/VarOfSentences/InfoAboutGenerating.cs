using MyNPCLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace TmpSandBox.VarOfSentences
{
    public class FileInfoAboutGenerating: IObjectToString
    {
        public string FileName { get; set; }
        public long Size { get; set; }

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(FileName)} = {FileName}");
            sb.AppendLine($"{spaces}{nameof(Size)} = {Size}");
            return sb.ToString();
        }
    }

    public class InfoAboutGenerating : IObjectToString
    {
        public DateTime CreationTime { get; set; }
        public List<FileInfoAboutGenerating> Items { get; set; } = new List<FileInfoAboutGenerating>();

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(CreationTime)} = {CreationTime}");
            if (Items == null)
            {
                sb.AppendLine($"{spaces}{nameof(Items)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(Items)}");
                foreach (var item in Items)
                {
                    sb.Append(item.ToString(nextN));
                }
                sb.AppendLine($"{spaces}End {nameof(Items)}");
            }
            return sb.ToString();
        }
    }
}
