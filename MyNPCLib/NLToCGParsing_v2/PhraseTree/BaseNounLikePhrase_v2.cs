using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.PhraseTree
{
    public abstract class BaseNounLikePhrase_v2 : IObjectToString, IShortObjectToString, IRunTimeSessionKey
    {
        protected BaseNounLikePhrase_v2(bool getKey = true)
        {
            if (getKey)
            {
                RunTimeSessionKey = RunTimeSessionKeyHelper.GeyKey();
            }
        }

        public ulong RunTimeSessionKey { get; set; }
        public virtual bool IsNounPhrase => false;
        public virtual NounPhrase_v2 AsNounPhrase => null;
        public virtual bool IsPrepositionalPhrase => false;
        public virtual PrepositionalPhrase_v2 AsPrepositionalPhrase => null;

        public BaseNounLikePhrase_v2 Object { get; set; }

        public abstract BaseNounLikePhrase_v2 Fork();

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
