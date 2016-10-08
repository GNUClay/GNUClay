using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.LogicalStorage.QueriesParsers.InternalParsers
{
    public enum TokenKind
    {
        Unknown,
        Word,
        Var,
        OpenFigureBracket,
        CloseFigureBracket,
        OpenRoundBracket,
        CloseRoundBracket,
        Comma,
        Colon,
        Dash,
        More,
        And,
        RULE_HEAD,
        RULE_BODY,
        SELECT,
        INSERT
    }

    public class Token : IToStringData
    {
        public TokenKind TokenKind = TokenKind.Unknown;
        public string Content = string.Empty;

        public override string ToString()
        {
            return _ObjectHelper.PrintDefaultToStringInformation(this);
        }

        public string ToStringData()
        {
            var tmpSb = new StringBuilder();

            tmpSb.Append(nameof(TokenKind));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(TokenKind.ToString());

            tmpSb.Append(nameof(Content));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Content);

            return tmpSb.ToString();
        }
    }
}
