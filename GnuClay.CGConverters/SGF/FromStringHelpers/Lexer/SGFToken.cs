using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.CGConverters.SGF.FromStringHelpers.Lexer
{
    public enum SGFTokenKind
    {
        Undefined,
        OpenSquareBracket,
        CloseSquareBracket,
        OpenFiguredBracket,
        CloseFiguredBracket,
        OpenRoundBracket,
        CloseRoundBracket,
        String,
        Identifier,
        Colon,
        Semicolon,
        LeftArrow,
        RightArrow
    }

    public class SGFToken : IToStringData
    {
        public SGFTokenKind Kind = SGFTokenKind.Undefined;

        public string Content = string.Empty;

        public int Pos = 1;

        public int Line = 1;

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

            tmpSb.Append(nameof(Pos));
            tmpSb.Append("=");
            tmpSb.AppendLine(Pos.ToString());

            tmpSb.Append(nameof(Line));
            tmpSb.Append("=");
            tmpSb.AppendLine(Line.ToString());

            return tmpSb.ToString();
        }
    }
}
