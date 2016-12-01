using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.ScriptExecutor.AST.Expressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    public enum Associativity
    {
        Undefined,
        Right,
        Left
    }

    public class InternalCodeExpressionNode : IToStringData
    {
        public InternalCodeExpressionNode Parent = null;
        public ExpressionKind Kind { get; set; } = ExpressionKind.Undefined;
        public int TypeKey = 0;
        public InternalCodeExpressionNode Left = null;
        public InternalCodeExpressionNode Right = null;
        public List<InternalCodeExpressionNode> Params = null;
        public InternalCodeExpressionNode CalledMember = null;
        public object Value = null;
        public int Priority = 0;
        public Associativity Associativity = Associativity.Undefined;

        /// <summary>
        /// Converts the value of this instance to its equivalent string representation. Overrides (Object.ToString)
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        /// <summary>
        /// Provides string data for method ToString.
        /// </summary>
        /// <returns>The string representation of this instance.</returns>
        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(Kind));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Kind.ToString());

            tmpSb.Append(nameof(TypeKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(TypeKey.ToString());

            tmpSb.AppendLine(_ObjectHelper._ToString(Left, nameof(Left)));
            tmpSb.AppendLine(_ObjectHelper._ToString(Right, nameof(Right)));
            tmpSb.AppendLine(_ObjectHelper._ToString(CalledMember, nameof(CalledMember)));
            tmpSb.AppendLine(_ListHelper._ToString(Params, nameof(Params)));

            tmpSb.Append(nameof(Value));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Value?.ToString());

            tmpSb.Append(nameof(Priority));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Priority.ToString());

            tmpSb.Append(nameof(Associativity));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Associativity.ToString());

            return tmpSb.ToString();
        }
    }
}
