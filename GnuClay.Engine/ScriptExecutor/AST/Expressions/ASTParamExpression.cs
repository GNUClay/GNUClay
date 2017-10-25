using GnuClay.CommonClientTypes;
using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.ScriptExecutor.AST.Expressions
{
    public class ASTParamExpression: ASTExpression
    {
        public ASTParamExpression()
            : base(ExpressionKind.ParamExpression)
        {
        }

        public bool IsNamed { get; set; }
        public ASTExpression Name { get; set; }
        public ASTExpression Value { get; set; }

        /// <summary>
        /// Converts the value of this instance to its equivalent short string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The short string representation of this instance.</returns>
        public virtual string ToParentTitle(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            return $"{spacesString}ParamExpression";
        }

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="dataDictionary">An instance of the DataDictionary for human readable presentation.</param>
        /// <param name="indent">Indent for better formatting.</param>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString(IReadOnlyStorageDataDictionary dataDictionary, int indent)
        {
            var spacesString = _ObjectHelper.CreateSpaces(indent);
            var nextIndent = indent + 4;
            var sb = new StringBuilder();
            sb.AppendLine($"{spacesString}Begin ParamExpression");
            sb.AppendLine($"{spacesString}{nameof(IsNamed)} = {IsNamed}");
            if (Name == null)
            {
                sb.AppendLine($"{spacesString}{nameof(Name)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}{nameof(Name)} =");
                sb.AppendLine(Name.ToString(dataDictionary, nextIndent));
            }
            if (Value == null)
            {
                sb.AppendLine($"{spacesString}{nameof(Value)} = null");
            }
            else
            {
                sb.AppendLine($"{spacesString}{nameof(Value)} =");
                sb.AppendLine(Value.ToString(dataDictionary, nextIndent));
            }
            sb.AppendLine($"{spacesString}End ParamExpression");
            return sb.ToString();
        }
    }
}
