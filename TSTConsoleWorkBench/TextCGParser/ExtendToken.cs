using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ExtendToken : IToStringData
    {
        /// <summary>
        /// What represents an instance of this class.
        /// </summary>
        public TokenKind TokenKind = TokenKind.Unknown;

        /// <summary>
        /// The content of this fragment, is not empty if field TokenKind equal TokenKind.Word or TokenKind.Var. Else is empty.
        /// </summary>
        public string Content = string.Empty;

        public ulong Key = 0;
        public ulong PartOfSpeech = 0;
        public ulong RootKey = 0;

        public List<ulong> Number = new List<ulong>();

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

            tmpSb.Append(nameof(Key));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(Key.ToString());

            tmpSb.Append(nameof(PartOfSpeech));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(PartOfSpeech.ToString());

            tmpSb.Append(nameof(RootKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(RootKey.ToString());

            tmpSb.AppendLine(_ListHelper._ToString(Number, nameof(Number)));

            return tmpSb.ToString();
        }
    }
}
