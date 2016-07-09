using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.CGResolver.Implementations.FromECGToICG.NodeNameLexer
{
    public enum NodeNameTokenKind
    {
        Undefined,
        String,

        /// <summary>
        /// ∃
        /// </summary>
        ExistentialQuantifier,

        /// <summary>
        /// ∀ or *
        /// </summary>
        UniversalQuantifier,

        /// <summary>
        /// ?
        /// </summary>
        Question,

        /// <summary>
        /// #
        /// </summary>
        Octothorpe,
        OpenRoundBracket,
        CloseRoundBracket,
        Colon,
        Space
    }

    public class NodeNameToken : IToStringData
    {
        public NodeNameTokenKind Kind = NodeNameTokenKind.Undefined;

        public string Content = string.Empty;

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(Kind));
            tmpSb.Append("=");
            tmpSb.AppendLine(Kind.ToString());

            tmpSb.Append(nameof(Content));
            tmpSb.Append("=");
            tmpSb.AppendLine(Content);

            return tmpSb.ToString();
        }
    }
}
