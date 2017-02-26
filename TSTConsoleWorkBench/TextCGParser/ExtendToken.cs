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

        public bool IsNumberWord = false;

        public bool IsDoVerb = false;
        public bool IsHaveVerb = false;
        public bool IsBeVerb = false;
        public bool IsWillVerb = false;
        public bool IsCanVerb = false;
        public bool IsCouldVerb = false;    
        public bool IsMustVerb = false;
        public bool IsMayVerb = false;
        public bool IsMightVerb = false;

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

            tmpSb.AppendLine($"{nameof(TokenKind)} = {TokenKind}");
            tmpSb.AppendLine($"{nameof(Content)} = {Content}");
            tmpSb.AppendLine($"{nameof(Key)} = {Key}");
            tmpSb.AppendLine(_ListHelper._ToString(PartOfSpeech, nameof(PartOfSpeech)));
            tmpSb.AppendLine($"{nameof(RootKey)} = {RootKey}");
            tmpSb.AppendLine(_ListHelper._ToString(Number, nameof(Number)));
            tmpSb.AppendLine($"{nameof(IsNumberWord)} = {IsNumberWord}");
            tmpSb.AppendLine($"{nameof(IsDoVerb)} = {IsDoVerb}");
            tmpSb.AppendLine($"{nameof(IsHaveVerb)} = {IsHaveVerb}");
            tmpSb.AppendLine($"{nameof(IsBeVerb)} = {IsBeVerb}");
            tmpSb.AppendLine($"{nameof(IsWillVerb)} = {IsWillVerb}");
            tmpSb.AppendLine($"{nameof(IsCanVerb)} = {IsCanVerb}");
            tmpSb.AppendLine($"{nameof(IsCouldVerb)} = {IsCouldVerb}");
            tmpSb.AppendLine($"{nameof(IsMustVerb)} = {IsMustVerb}");
            tmpSb.AppendLine($"{nameof(IsMayVerb)} = {IsMayVerb}");
            tmpSb.AppendLine($"{nameof(IsMightVerb)} = {IsMightVerb}");
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

        public IPhrase Clone(Dictionary<object, object> ptrList)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Clone");

            return this;
        }

        public string ToDbgString()
        {
            return Content;
        }
    }
}
