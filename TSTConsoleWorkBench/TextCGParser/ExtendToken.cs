using GnuClay.CommonUtils.TypeHelpers;
using GnuClay.Engine.Parser.InternalParsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSTConsoleWorkBench.TextCGParser
{
    public class ExtendToken : IToStringData, IPhrase
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
        public List<GrammaticalPartOfSpeech> PartOfSpeech = new List<GrammaticalPartOfSpeech>();
        public ulong RootKey = 0;

        public List<GrammaticalNumberOfWord> Number = new List<GrammaticalNumberOfWord>();

        public bool IsModality = false;
        public bool IsNumberWord = false;

        public List<GrammaticalTenses> Tenses = new List<GrammaticalTenses>();
        public List<GrammaticalComparison> Comparison = new List<GrammaticalComparison>();
        public List<GrammaticalGender> Gender = new List<GrammaticalGender>();
        public List<CaseOfPersonalPronoun> CaseOfPersonalPronoun = new List<CaseOfPersonalPronoun>();
        public List<TypeOfPronoun> TypeOfPronoun = new List<TypeOfPronoun>();
        public List<GrammaticalPerson> Person = new List<GrammaticalPerson>();
        public List<VerbType> VerbType = new List<VerbType>();
        public List<NumeralType> NumeralType = new List<NumeralType>();

        public bool Is(GrammaticalPartOfSpeech value)
        {
            if(PartOfSpeech.Contains(value))
            {
                return true;
            }

            return false;
        }

        public bool Is(TypeOfPronoun value)
        {
            if(TypeOfPronoun.Contains(value))
            {
                return true;
            }

            return false;
        }

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

            tmpSb.AppendLine(_ListHelper._ToString(PartOfSpeech, nameof(PartOfSpeech)));

            tmpSb.Append(nameof(RootKey));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(RootKey.ToString());

            tmpSb.AppendLine(_ListHelper._ToString(Number, nameof(Number)));

            tmpSb.Append(nameof(IsModality));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(IsModality.ToString());

            tmpSb.Append(nameof(IsNumberWord));
            tmpSb.Append(" = ");
            tmpSb.AppendLine(IsNumberWord.ToString());

            tmpSb.AppendLine(_ListHelper._ToString(Tenses, nameof(Tenses)));

            tmpSb.AppendLine(_ListHelper._ToString(Comparison, nameof(Comparison)));

            tmpSb.AppendLine(_ListHelper._ToString(Gender, nameof(Gender)));

            tmpSb.AppendLine(_ListHelper._ToString(CaseOfPersonalPronoun, nameof(CaseOfPersonalPronoun)));

            tmpSb.AppendLine(_ListHelper._ToString(TypeOfPronoun, nameof(TypeOfPronoun)));

            tmpSb.AppendLine(_ListHelper._ToString(Person, nameof(Person)));

            tmpSb.AppendLine(_ListHelper._ToString(VerbType, nameof(VerbType)));

            tmpSb.AppendLine(_ListHelper._ToString(NumeralType, nameof(NumeralType)));

            return tmpSb.ToString();
        }
    }
}
