using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ATNSlaveNAPNounStateNode: ATNSlaveNAPBaseStateNode
    {
        public ATNSlaveNAPNounStateNode(ContextOfATNParsing_v2 context, ITargetOfATNSlaveNAPNode target, ContextOfATNSlaveNAPStateNode contextOfState)
            : base(context, target, contextOfState)
        {
        }

        public ATNSlaveNAPNounStateNode(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
             : base(context, contextOfState)
        {
        }

        public StateOfATNSlaveNAPNode State { get; set; } = StateOfATNSlaveNAPNode.Init;

        private NounPhrase_v2 mNounPhrase;
        private List<ATNExtendedToken> mDeterminers = new List<ATNExtendedToken>();
        private float? mNumberValue;
        private List<BaseWordPhrase_v2> mPossesiveNounPhrases = new List<BaseWordPhrase_v2>();
        private AdjectivePhrase_v2 mAdjectivePhrase;

        public override ATNSlaveNAPBaseStateNode Fork(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
        {
            var result = new ATNSlaveNAPNounStateNode(context, contextOfState);
            result.State = State;
            result.Target = Target;

            if(mAdjectivePhrase != null)
            {
                result.mAdjectivePhrase = context.GetByRunTimeSessionKey<AdjectivePhrase_v2>(mAdjectivePhrase);
            }

            if (mNounPhrase == null)
            {
                result.mDeterminers = mDeterminers.Select(p => p.Fork()).ToList();
                result.mPossesiveNounPhrases = mPossesiveNounPhrases.Select(p => p.ForkAsBaseWordPhrase()).ToList();
            }
            else
            {
                result.mNounPhrase = context.GetByRunTimeSessionKey<NounPhrase_v2>(mNounPhrase);
                foreach (var determiner in mDeterminers)
                {
                    result.mDeterminers.Add(context.GetByRunTimeSessionKey<ATNExtendedToken>(determiner));
                }
                foreach (var possesivePhrase in mPossesiveNounPhrases)
                {
                    result.mPossesiveNounPhrases.Add(context.GetByRunTimeSessionKey<NounPhrase_v2>(possesivePhrase));
                }
            }

            result.mNumberValue = mNumberValue;

            return result;
        }

        public override bool Run(ATNExtendedToken token)
        {
#if DEBUG
            LogInstance.Log($"State = {State}");
            LogInstance.Log($"token = {token}");
#endif

            switch (State)
            {
                case StateOfATNSlaveNAPNode.Init:
                    {
                        var partOfSpeech = token.PartOfSpeech;

                        switch (partOfSpeech)
                        {
                            case GrammaticalPartOfSpeech.Noun:
                            case GrammaticalPartOfSpeech.Pronoun:
                                {
                                    if(token.IsPossessive)
                                    {
                                        var possesiveNounPhrase = new NounPhrase_v2();
                                        mPossesiveNounPhrases.Add(possesiveNounPhrase);
                                        possesiveNounPhrase.Noun = token;
                                        State = StateOfATNSlaveNAPNode.GotDeterminerWithoutNoun;
                                        break;
                                    }
                                    var nounPhrase = new NounPhrase_v2();
                                    mNounPhrase = nounPhrase;
                                    Target.SetNode(nounPhrase, Context);
                                    nounPhrase.Noun = token;
                                    State = StateOfATNSlaveNAPNode.GotNoun;
                                }
                                break;

                            case GrammaticalPartOfSpeech.Article:
                                {
                                    mDeterminers.Add(token);
                                    State = StateOfATNSlaveNAPNode.GotDeterminerWithoutNoun;
                                }
                                break;

                            case GrammaticalPartOfSpeech.Number:
                                {
                                    mNumberValue = token.RepresentedNumber;
                                    State = StateOfATNSlaveNAPNode.GotDeterminerWithoutNoun;
                                }
                                break;

                            case GrammaticalPartOfSpeech.Adjective:
                                {
                                    var adjectivePhrase = new AdjectivePhrase_v2();
                                    mAdjectivePhrase = adjectivePhrase;
                                    Target.SetNode(adjectivePhrase, Context);
                                    adjectivePhrase.Adjective = token;
                                    State = StateOfATNSlaveNAPNode.GotAjectiveWithoutNoun;
                                }
                                break;

                            case GrammaticalPartOfSpeech.Adverb:
                                {
                                    mDeterminers.Add(token);
                                    State = StateOfATNSlaveNAPNode.GotDeterminerWithoutNoun;
                                }
                                break;

                            default:
                                throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
                        }
                    }
                    break;

                case StateOfATNSlaveNAPNode.GotDeterminerWithoutNoun:
                    {
                        var partOfSpeech = token.PartOfSpeech;

                        switch (partOfSpeech)
                        {
                            case GrammaticalPartOfSpeech.Noun:
                                {
                                    var nounPhrase = new NounPhrase_v2();
                                    mNounPhrase = nounPhrase;
                                    Target.SetNode(nounPhrase, Context);
                                    nounPhrase.Noun = token;
                                    State = StateOfATNSlaveNAPNode.GotNoun;

                                    if (!mDeterminers.IsEmpty())
                                    {
                                        nounPhrase.DeterminersList = mDeterminers.ToList();
                                        mDeterminers.Clear();
                                    }

                                    if (!mPossesiveNounPhrases.IsEmpty())
                                    {
                                        nounPhrase.PossesiveList = mPossesiveNounPhrases.ToList();
                                        mPossesiveNounPhrases.Clear();
                                    }

                                    if(mNumberValue.HasValue)
                                    {
                                        nounPhrase.NumberValue = mNumberValue;
                                    }

                                    if(mAdjectivePhrase != null)
                                    {
                                        mNounPhrase.AdjectivePhrasesList.Add(mAdjectivePhrase);
                                        mAdjectivePhrase = null;
                                    }                     
                                }
                                break;

                            case GrammaticalPartOfSpeech.Adverb:
                                mDeterminers.Add(token);
                                break;

                            case GrammaticalPartOfSpeech.Adjective:
                                {
#if DEBUG
                                    LogInstance.Log($"mDeterminers.Count = {mDeterminers.Count}");
#endif

                                    if (mDeterminers.Count > 0)
                                    {
#if DEBUG
                                        LogInstance.Log($"mDeterminers.Count > 0 (1) Context = {Context}");
#endif

                                        return false;
                                    }

                                    var oldAdjectivePhrase = mAdjectivePhrase;

#if DEBUG
                                    LogInstance.Log($"oldAdjectivePhrase = {oldAdjectivePhrase}");
#endif

                                    var adjectivePhrase = new AdjectivePhrase_v2();
                                    adjectivePhrase.Adjective = token;

                                    mAdjectivePhrase = adjectivePhrase;
                                    Target.ReplaceNode(adjectivePhrase, Context);
                                    
                                    if(oldAdjectivePhrase != null)
                                    {
                                        adjectivePhrase.AdjectivePhrasesList.Add(oldAdjectivePhrase);
                                    }
                                    
                                    State = StateOfATNSlaveNAPNode.GotAjectiveWithoutNoun;
                                }
                                break;

                            default:
                                throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
                        }
                    }
                    break;

                case StateOfATNSlaveNAPNode.GotNoun:
                    {
                        var partOfSpeech = token.PartOfSpeech;

                        switch (partOfSpeech)
                        {
                            case GrammaticalPartOfSpeech.Preposition:
                                {
                                    if(!token.IsOf)
                                    {
                                        throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
                                    }

                                    var target = new PossesiveTargetOfATNSlaveNAPNode(mNounPhrase);
                                    var nextState = new ATNSlaveNAPNounStateNode(Context, target, ContextOfState);
                                    ContextOfState.AddNode(nextState);
                                }
                                break;

                            default:
                                throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
                        }
                    }
                    break;

                case StateOfATNSlaveNAPNode.GotAjectiveWithoutNoun:
                    {
                        var partOfSpeech = token.PartOfSpeech;

                        switch (partOfSpeech)
                        {
                            case GrammaticalPartOfSpeech.Adjective:
                                {
#if DEBUG
                                    LogInstance.Log($"mDeterminers.Count = {mDeterminers.Count}");
#endif

                                    if(mDeterminers.Count > 0)
                                    {
#if DEBUG
                                        LogInstance.Log($"mDeterminers.Count > 0 (2) Context = {Context}");
#endif

                                        return false;
                                    }

                                    var oldAdjectivePhrase = mAdjectivePhrase;

#if DEBUG
                                    LogInstance.Log($"oldAdjectivePhrase = {oldAdjectivePhrase}");                               
#endif

                                    var adjectivePhrase = new AdjectivePhrase_v2();
                                    adjectivePhrase.Adjective = token;

                                    mAdjectivePhrase = adjectivePhrase;
                                    Target.ReplaceNode(adjectivePhrase, Context);
                                    
                                    if(oldAdjectivePhrase != null)
                                    {
                                        adjectivePhrase.AdjectivePhrasesList.Add(oldAdjectivePhrase);
                                    }
                                    
                                    State = StateOfATNSlaveNAPNode.GotAjectiveWithoutNoun;
                                }
                                break;

                            default:
                                throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
                        }
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(State), State, null);
            }

#if DEBUG
            LogInstance.Log($"mDeterminers.Count (end)= {mDeterminers.Count}");
#endif

            return true;
        }
    }
}
