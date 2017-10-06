using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.CommonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.InternalScriptExecutor
{
    public class ResultOfCalling: ISmartToString
    {
        public bool IsUserDefined { get; set; }
        public FunctionModel ExecutableCode { get; set; }
        public EntityAction EntityAction { get; set; }
        public bool Success { get; set; }
        public IValue Result { get; set; }
        public IValue Error { get; set; }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return ToString(null, 0);
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var nextIndent = indent + 4;

            var sb = new StringBuilder();
            sb.AppendLine($"{spacesString}Begin ResultOfCalling");
            sb.AppendLine($"{spacesString}{nameof(IsUserDefined)} = {IsUserDefined}");
            sb.AppendLine($"{spacesString}{nameof(ExecutableCode)} = {ExecutableCode?.ToString(dataDictionary, nextIndent)}");
            sb.AppendLine($"{spacesString}{nameof(EntityAction)} = {EntityAction?.ToString(dataDictionary, nextIndent)}");
            sb.AppendLine($"{spacesString}{nameof(Success)} = {Success}");
            sb.AppendLine($"{spacesString}{nameof(Result)} = {Result?.ToString(dataDictionary, nextIndent)}");
            sb.AppendLine($"{spacesString}{nameof(Error)} = {Error?.ToString(dataDictionary, nextIndent)}");
            sb.AppendLine($"{spacesString}{spacesString}End ResultOfCalling");
            return sb.ToString();
        }
    }
}
