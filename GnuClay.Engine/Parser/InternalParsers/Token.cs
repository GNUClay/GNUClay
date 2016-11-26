using GnuClay.CommonUtils.TypeHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GnuClay.Engine.Parser.InternalParsers
{
    /// <summary>
    /// What represents an instance of Token.
    /// </summary>
    public enum TokenKind
    {
        /// <summary>
        /// Default value. Represents nothing.
        /// </summary>
        Unknown,

        /// <summary>
        /// Represents some word. Next may transforms to Var, SELECT, INSERT.
        /// </summary>
        Word,

        /// <summary>
        /// Represents a variable.
        /// </summary>
        Var,

        /// <summary>
        /// Represents symbol `{`.
        /// </summary>
        OpenFigureBracket,

        /// <summary>
        /// Represents symbol `}`.
        /// </summary>
        CloseFigureBracket,

        /// <summary>
        /// Represents symbol `(`.
        /// </summary>
        OpenRoundBracket,

        /// <summary>
        /// Represents symbol `)`.
        /// </summary>
        CloseRoundBracket,

        /// <summary>
        /// Represents symbol `,`.
        /// </summary>
        Comma,

        /// <summary>
        /// Represents symbol `:`.
        /// </summary>
        Colon,

        /// <summary>
        /// Represents symbol `-`.
        /// </summary>
        Dash,

        /// <summary>
        /// Represents symbol `>`.
        /// </summary>
        More,

        /// <summary>
        /// Represents symbol Ampersand.
        /// </summary>
        And,

        /// <summary>
        /// Represents symbol `+`.
        /// </summary>
        Plus,

        /// <summary>
        /// Represents symbol `;`.
        /// </summary>
        Semicolon,

        /// <summary>
        /// Represents combination of symbols `>:`.
        /// </summary>
        RULE_HEAD,

        /// <summary>
        /// Represents combination of symbols `->`.
        /// </summary>
        RULE_BODY,

        /// <summary>
        /// Represents keyword `SELECT`.
        /// </summary>
        SELECT,

        /// <summary>
        /// Represents keyword `INSERT`.
        /// </summary>
        INSERT
    }

    /// <summary>
    /// Represents some fragment from code string.
    /// </summary>
    public class Token : IToStringData
    {
        /// <summary>
        /// What represents an instance of this class.
        /// </summary>
        public TokenKind TokenKind = TokenKind.Unknown;

        /// <summary>
        /// The content of this fragment, is not empty if field TokenKind equal TokenKind.Word or TokenKind.Var. Else is empty.
        /// </summary>
        public string Content = string.Empty;

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
