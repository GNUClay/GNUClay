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
        /// Represents some number.
        /// </summary>
        Number,

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
        /// Represents symbol `.`.
        /// </summary>
        Point,

        /// <summary>
        /// Represents symbol `-`.
        /// </summary>
        Dash,

        /// <summary>
        /// Represents symbol `/`.
        /// </summary>
        Div,

        /// <summary>
        /// Represents symbol `&gt;`.
        /// </summary>
        More,

        /// <summary>
        /// Represents symbol `&lt;`.
        /// </summary>
        Less,

        /// <summary>
        /// Represents symbol `&amp;`.
        /// </summary>
        And,

        /// <summary>
        /// Represents symbol `|`.
        /// </summary>
        Or,

        /// <summary>
        /// Represents symbol `+`.
        /// </summary>
        Plus,

        /// <summary>
        /// Represents symbol `*`.
        /// </summary>
        Mul,

        /// <summary>
        /// Represents symbol `;`.
        /// </summary>
        Semicolon,

        /// <summary>
        /// Represents symbol `!`.
        /// </summary>
        Not,

        /// <summary>
        /// Represents symbol `==`.
        /// </summary>
        Equal,

        /// <summary>
        /// Represents symbol `!=`.
        /// </summary>
        NotEqual,

        /// <summary>
        /// Represents symbol `&gt;=`.
        /// </summary>
        MoreOrEqual,

        /// <summary>
        /// Represents symbol `&lt;=`.
        /// </summary>
        LessOrEqual,

        /// <summary>
        /// Represents symbol `=`.
        /// </summary>
        Assing,

        /// <summary>
        /// Represents symbol `+=`.
        /// </summary>
        PlusAssing,

        /// <summary>
        /// Represents symbol `-=`.
        /// </summary>
        MinusAssing,

        /// <summary>
        /// Represents symbol `*=`.
        /// </summary>
        MulAssing,

        /// <summary>
        /// Represents symbol `/=`.
        /// </summary>
        DivAssing,

        /// <summary>
        /// Represents symbol `&lt;&lt;`.
        /// </summary>
        AssingFact,

        /// <summary>
        /// Represents symbol `+&lt;&lt;`.
        /// </summary>
        PlusAssingFact,

        /// <summary>
        /// Represents symbol `~`.
        /// </summary>
        Tilde,

        /// <summary>
        /// Represents combination of symbols `>:`.
        /// </summary>
        RULE_HEAD,

        /// <summary>
        /// Represents combination of symbols `->`.
        /// </summary>
        RULE_BODY,

        /// <summary>
        /// Represents combination of symbols `&lt;!`.
        /// </summary>
        BEGIN_TARGET,

        /// <summary>
        /// Represents combination of symbols `!>`.
        /// </summary>
        END_TERGET,
        /// <summary>
        /// Represents keyword `READ`.
        /// </summary>
        READ,

        /// <summary>
        /// Represents keyword `WRITE`.
        /// </summary>
        WRITE,

        /// <summary>
        /// Represents keyword `REWRITE`.
        /// </summary>
        REWRITE,

        /// <summary>
        /// Represents keyword `DELETE`.
        /// </summary>
        DELETE,

        /// <summary>
        /// Represents keyword `CALL`.
        /// </summary>
        CALL,

        /// <summary>
        /// Represents keyword `DEFINE`.
        /// </summary>
        DEFINE,

        /// <summary>
        /// Represents keyword `fun`.
        /// </summary>
        FUN,

        /// <summary>
        /// Represents keyword `if`.
        /// </summary>
        IF,

        /// <summary>
        /// Represents keyword `else`.
        /// </summary>
        ELSE,

        /// <summary>
        /// Represents keyword `while`.
        /// </summary>
        WHILE,
    }

    /// <summary>
    /// Represents some fragment from code string.
    /// </summary>
    public class Token : IToStringData
    {
        /// <summary>
        /// What represents by the instance of this class.
        /// </summary>
        public TokenKind TokenKind = TokenKind.Unknown;

        /// <summary>
        /// Which key word is represent by the instance of this class.
        /// </summary>
        public TokenKind KeyWordTokenKind = TokenKind.Unknown;

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

            tmpSb.AppendLine($"{nameof(TokenKind)} = {TokenKind}");
            tmpSb.AppendLine($"{nameof(KeyWordTokenKind)} = {KeyWordTokenKind}");
            tmpSb.AppendLine($"{nameof(Content)} = {Content}");

            return tmpSb.ToString();
        }

        public string ToDebugString()
        {
            var tmpSb = new StringBuilder($"`{TokenKind}`");

            if(!string.IsNullOrWhiteSpace(Content))
            {
                tmpSb.Append($": `{Content}`");
            }

            return tmpSb.ToString();
        }
    }
}
