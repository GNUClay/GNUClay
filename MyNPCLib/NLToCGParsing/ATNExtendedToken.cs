using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing
{
    public class ATNExtendedToken : IObjectToString, IRunTimeSessionKey
    {
        public ATNExtendedToken(bool getKey = true)
        {
            if(getKey)
            {
                RunTimeSessionKey = RunTimeSessionKeyHelper.GeyKey();
            }
        }

        public ulong RunTimeSessionKey { get; set; }
        public KindOfATNToken Kind { get; set; } = KindOfATNToken.Unknown;
        public string Content { get; set; } = string.Empty;
        public int Pos { get; set; }
        public int Line { get; set; }
        public GrammaticalPartOfSpeech PartOfSpeech { get; set; } = GrammaticalPartOfSpeech.Undefined;
        public bool IsName { get; set; }
        public bool IsShortForm { get; set; }
        public GrammaticalGender Gender { get; set; } = GrammaticalGender.Neuter;
        public GrammaticalNumberOfWord Number { get; set; } = GrammaticalNumberOfWord.Neuter;
        public bool IsCountable { get; set; }
        public bool IsGerund { get; set; }
        public bool IsPossessive { get; set; }
        public GrammaticalPerson Person { get; set; } = GrammaticalPerson.Neuter;
        public TypeOfPronoun TypeOfPronoun { get; set; } = TypeOfPronoun.Undefined;
        public CaseOfPersonalPronoun CaseOfPersonalPronoun { get; set; } = CaseOfPersonalPronoun.Undefined;
        public VerbType VerbType { get; set; } = VerbType.BaseForm;
        public GrammaticalTenses Tense { get; set; } = GrammaticalTenses.All;
        public bool IsModal { get; set; }
        public bool IsFormOfToBe { get; set; }
        public bool IsFormOfToHave { get; set; }
        public bool IsFormOfToDo { get; set; }
        public GrammaticalComparison Comparison { get; set; } = GrammaticalComparison.None;
        public bool IsQuestionWord { get; set; }
        public bool IsDeterminer { get; set; }
        public NumeralType NumeralType { get; set; } = NumeralType.Undefined;
        public IList<string> LogicalMeaning { get; set; }
        public IList<string> FullLogicalMeaning { get; set; }
        public string RootWord { get; set; }
        public KindOfItemOfSentence KindOfItem { get; set; } = KindOfItemOfSentence.Unknown;
        public float? RepresentedNumber { get; set; }
        public bool IsOf { get; set; }
        public bool IsSimple => Person == GrammaticalPerson.Neuter && (Tense == GrammaticalTenses.Present || Tense == GrammaticalTenses.All);

        public ATNExtendedToken Fork()
        {
            var item = new ATNExtendedToken(false);
            item.RunTimeSessionKey = RunTimeSessionKey;
            item.Kind = Kind;
            item.Content = Content;
            item.Pos = Pos;
            item.Line = Line;
            item.PartOfSpeech = PartOfSpeech;
            item.IsName = IsName;
            item.IsShortForm = IsShortForm;
            item.Gender = Gender;
            item.Number = Number;
            item.IsCountable = IsCountable;
            item.IsGerund = IsGerund;
            item.IsPossessive = IsPossessive;
            item.Person = Person;
            item.TypeOfPronoun = TypeOfPronoun;
            item.CaseOfPersonalPronoun = CaseOfPersonalPronoun;
            item.VerbType = VerbType;
            item.Tense = Tense;
            item.IsModal = IsModal;
            item.IsFormOfToBe = IsFormOfToBe;
            item.IsFormOfToHave = IsFormOfToHave;
            item.IsFormOfToDo = IsFormOfToDo;
            item.Comparison = Comparison;
            item.IsQuestionWord = IsQuestionWord;
            item.IsDeterminer = IsDeterminer;
            item.NumeralType = NumeralType;
            if(LogicalMeaning != null)
            {
                item.LogicalMeaning = LogicalMeaning.ToList();
            }
            
            if (FullLogicalMeaning != null)
            {
                item.FullLogicalMeaning = FullLogicalMeaning.ToList();
            }
    
            item.RootWord = RootWord;
            item.KindOfItem = KindOfItem;
            item.RepresentedNumber = RepresentedNumber;
            item.IsOf = IsOf;

            return item;
        }

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public string PropertiesToString(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var nextN = n + 4;
            var nextNSpaces = StringHelper.Spaces(nextN);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(RunTimeSessionKey)} = {RunTimeSessionKey}");
            sb.AppendLine($"{spaces}{nameof(Kind)} = {Kind}");
            sb.AppendLine($"{spaces}{nameof(Content)} = {Content}");
            sb.AppendLine($"{spaces}{nameof(Pos)} = {Pos}");
            sb.AppendLine($"{spaces}{nameof(Line)} = {Line}");
            sb.AppendLine($"{spaces}{nameof(PartOfSpeech)} = {PartOfSpeech}");
            sb.AppendLine($"{spaces}{nameof(IsName)} = {IsName}");
            sb.AppendLine($"{spaces}{nameof(IsShortForm)} = {IsShortForm}");
            sb.AppendLine($"{spaces}{nameof(Gender)} = {Gender}");
            sb.AppendLine($"{spaces}{nameof(Number)} = {Number}");
            sb.AppendLine($"{spaces}{nameof(IsCountable)} = {IsCountable}");
            sb.AppendLine($"{spaces}{nameof(IsGerund)} = {IsGerund}");
            sb.AppendLine($"{spaces}{nameof(IsPossessive)} = {IsPossessive}");
            sb.AppendLine($"{spaces}{nameof(Person)} = {Person}");
            sb.AppendLine($"{spaces}{nameof(TypeOfPronoun)} = {TypeOfPronoun}");
            sb.AppendLine($"{spaces}{nameof(CaseOfPersonalPronoun)} = {CaseOfPersonalPronoun}");
            sb.AppendLine($"{spaces}{nameof(VerbType)} = {VerbType}");
            sb.AppendLine($"{spaces}{nameof(Tense)} = {Tense}");
            sb.AppendLine($"{spaces}{nameof(IsModal)} = {IsModal}");
            sb.AppendLine($"{spaces}{nameof(IsFormOfToBe)} = {IsFormOfToBe}");
            sb.AppendLine($"{spaces}{nameof(IsFormOfToHave)} = {IsFormOfToHave}");
            sb.AppendLine($"{spaces}{nameof(IsFormOfToDo)} = {IsFormOfToDo}");
            sb.AppendLine($"{spaces}{nameof(Comparison)} = {Comparison}");
            sb.AppendLine($"{spaces}{nameof(IsQuestionWord)} = {IsQuestionWord}");
            sb.AppendLine($"{spaces}{nameof(IsDeterminer)} = {IsDeterminer}");
            sb.AppendLine($"{spaces}{nameof(NumeralType)} = {NumeralType}");
            if (LogicalMeaning == null)
            {
                sb.AppendLine($"{spaces}{nameof(LogicalMeaning)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(LogicalMeaning)}");
                foreach (var item in LogicalMeaning)
                {
                    sb.AppendLine($"{nextNSpaces}{item}");
                }
                sb.AppendLine($"{spaces}End {nameof(LogicalMeaning)}");
            }

            if (FullLogicalMeaning == null)
            {
                sb.AppendLine($"{spaces}{nameof(FullLogicalMeaning)} = null");
            }
            else
            {
                sb.AppendLine($"{spaces}Begin {nameof(FullLogicalMeaning)}");
                foreach (var item in FullLogicalMeaning)
                {
                    sb.AppendLine($"{nextNSpaces}{item}");
                }
                sb.AppendLine($"{spaces}End {nameof(FullLogicalMeaning)}");
            }
            sb.AppendLine($"{spaces}{nameof(RootWord)} = {RootWord}");
            sb.AppendLine($"{spaces}{nameof(KindOfItem)} = {KindOfItem}");
            sb.AppendLine($"{spaces}{nameof(RepresentedNumber)} = {RepresentedNumber}");
            sb.AppendLine($"{spaces}{nameof(IsOf)} = {IsOf}"); 
            return sb.ToString();
        }

        public override int GetHashCode()
        {
            var result = Kind.GetHashCode();

            if(!string.IsNullOrWhiteSpace(Content))
            {
                result ^= Content.GetHashCode();
            }

            result ^= PartOfSpeech.GetHashCode() ^ IsName.GetHashCode() ^ IsShortForm.GetHashCode() ^ Gender.GetHashCode() ^ Number.GetHashCode();
            result ^= IsCountable.GetHashCode() ^ IsGerund.GetHashCode() ^ IsPossessive.GetHashCode() ^ Person.GetHashCode();
            result ^= TypeOfPronoun.GetHashCode() ^ CaseOfPersonalPronoun.GetHashCode() ^ VerbType.GetHashCode() ^ Tense.GetHashCode();
            result ^= IsModal.GetHashCode() ^ IsFormOfToBe.GetHashCode() ^ IsFormOfToHave.GetHashCode() ^ IsFormOfToDo.GetHashCode();
            result ^= Comparison.GetHashCode() ^ IsQuestionWord.GetHashCode() ^ IsDeterminer.GetHashCode() ^ NumeralType.GetHashCode();
            if(!string.IsNullOrWhiteSpace(RootWord))
            {
                result ^= RootWord.GetHashCode();
            }

            result ^= KindOfItem.GetHashCode();

            if(RepresentedNumber.HasValue)
            {
                result ^= RepresentedNumber.GetHashCode();
            }

            result ^= IsOf.GetHashCode();
            return result;
        }

        public static bool NEquals(ATNExtendedToken left, ATNExtendedToken right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }
        }
    }

    public class ComparerOfATNExtendedToken : IEqualityComparer<ATNExtendedToken>
    {
        bool IEqualityComparer<ATNExtendedToken>.Equals(ATNExtendedToken left, ATNExtendedToken right)
        {
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
            {
                return false;
            }

            return ATNExtendedToken.NEquals(left, right);
        }

        int IEqualityComparer<ATNExtendedToken>.GetHashCode(ATNExtendedToken obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 0;
            }

            return obj.GetHashCode();
        }
    }
}
