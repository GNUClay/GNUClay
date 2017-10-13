using GnuClay.CommonClientTypes;
using GnuClay.CommonClientTypes.CommonData;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.CommonData
{
    /// <summary>
    /// Value which may go beyond GnuClayEngine.
    /// </summary>
    public class ExternalValue : IExternalValue
    {
        /// <summary>
        /// Kind of external value.
        /// </summary>
        public ExternalValueKind Kind { get; set; } = ExternalValueKind.Entity;

        /// <summary>
        /// Key of the type.
        /// </summary>
        public ulong TypeKey { get; set; }

        /// <summary>
        /// Gets or sets the system value which represents on C#.
        /// </summary>
        public object Value { get; set; }

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

            var tmpSb = new StringBuilder();
            tmpSb.AppendLine($"{spacesString}Begin ExternalValue");
            tmpSb.AppendLine($"{spacesString}{nameof(Kind)} = {Kind}");
            tmpSb.AppendLine($"{spacesString}{nameof(TypeKey)} = {TypeKey}");
            if(dataDictionary != null && TypeKey > 0)
            {
                tmpSb.AppendLine($"{spacesString}TypeName = {dataDictionary.GetValue(TypeKey)}");
            }
            tmpSb.AppendLine($"{spacesString}{nameof(Value)} = {Value}");
            tmpSb.AppendLine($"{spacesString}End ExternalValue");
            return tmpSb.ToString();
        }
    }
}
