using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public abstract class BasePhrase_v2 : IObjectToString, IShortObjectToString, IRunTimeSessionKey
    {
        protected BasePhrase_v2(bool getKey)
        {
            if (getKey)
            {
                RunTimeSessionKey = RunTimeSessionKeyHelper.GeyKey();
            }
        }

        public ulong RunTimeSessionKey { get; set; }

        public virtual bool IsSentence => false;
        public virtual Sentence_v2 AsSentence => null;
        public virtual bool IsBaseWordPhrase => false;
        public virtual BaseWordPhrase_v2 AsBaseWordPhrase => null;
        public virtual bool IsNounPhrase => false;
        public virtual NounPhrase_v2 AsNounPhrase => null;
        public virtual bool IsAdjectivePhrase => false;
        public virtual AdjectivePhrase_v2 AsAdjectivePhrase => null;
        public virtual bool IsPrepositionalPhrase => false;
        public virtual PrepositionalPhrase_v2 AsPrepositionalPhrase => null;

        public virtual T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node) where T : class, IRunTimeSessionKey
        {
            return GetByRunTimeSessionKey<T>(node.RunTimeSessionKey);
        }

        public abstract T GetByRunTimeSessionKey<T>(ulong key) where T : class, IRunTimeSessionKey;

        public abstract BasePhrase_v2 ForkAsBasePhrase();

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public virtual string PropertiesToSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(RunTimeSessionKey)} = {RunTimeSessionKey}");
            return sb.ToString();
        }

        public string ToShortString()
        {
            return ToShortString(0u);
        }

        public string ToShortString(uint n)
        {
            return this.GetDefaultToShortStringInformation(n);
        }

        public virtual string PropertiesToShortSting(uint n)
        {
            var spaces = StringHelper.Spaces(n);
            var sb = new StringBuilder();
            sb.AppendLine($"{spaces}{nameof(RunTimeSessionKey)} = {RunTimeSessionKey}");
            return sb.ToString();
        }
    }
}
