using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing.PhraseTree
{
    public abstract class BaseNounLikePhrase : IObjectToString, IShortObjectToString, IRunTimeSessionKey
    {
        protected BaseNounLikePhrase(bool getKey = true)
        {
            if (getKey)
            {
                RunTimeSessionKey = RunTimeSessionKeyHelper.GeyKey();
            }
        }

        public ulong RunTimeSessionKey { get; set; }
        public virtual bool IsNounPhrase => false;
        public virtual NounPhrase AsNounPhrase => null;
        public virtual bool IsPrepositionalPhrase => false;
        public virtual PrepositionalPhrase AsPrepositionalPhrase => null;
        public virtual bool IsAdjectivePhrase => false;
        public virtual AdjectivePhrase AsAdjectivePhrase => null;

        public BaseNounLikePhrase Object { get; set; }

        public abstract BaseNounLikePhrase Fork();

        public abstract T GetByRunTimeSessionKey<T>(IRunTimeSessionKey node) where T : class, IRunTimeSessionKey;
        public abstract T GetByRunTimeSessionKey<T>(ulong key) where T : class, IRunTimeSessionKey;

        public override string ToString()
        {
            return ToString(0u);
        }

        public string ToString(uint n)
        {
            return this.GetDefaultToStringInformation(n);
        }

        public abstract string PropertiesToSting(uint n);

        public string ToShortString()
        {
            return ToShortString(0u);
        }

        public string ToShortString(uint n)
        {
            return this.GetDefaultToShortStringInformation(n);
        }

        public abstract string PropertiesToShortSting(uint n);
    }
}
