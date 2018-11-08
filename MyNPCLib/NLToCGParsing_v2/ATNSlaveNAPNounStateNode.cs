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

        public override ATNSlaveNAPBaseStateNode Fork(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
        {
            var result = new ATNSlaveNAPNounStateNode(context, contextOfState);
            result.State = State;
            result.Target = Target;

            if (mNounPhrase == null)
            {
                result.mDeterminers = mDeterminers.ToList();
            }
            else
            {
                result.mNounPhrase = context.GetByRunTimeSessionKey<NounPhrase_v2>(mNounPhrase);
                foreach (var determiner in mDeterminers)
                {
                    result.mDeterminers.Add(context.GetByRunTimeSessionKey<ATNExtendedToken>(determiner));
                }
            }

            result.mNumberValue = mNumberValue;

            return result;
        }

        public override void Run(ATNExtendedToken token)
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
                                        throw new NotImplementedException();
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
                                        nounPhrase.DeterminersList = mDeterminers;
                                    }

                                    if(mNumberValue.HasValue)
                                    {
                                        nounPhrase.NumberValue = mNumberValue;
                                    }
                                }
                                break;

                            case GrammaticalPartOfSpeech.Adverb:
                                mDeterminers.Add(token);
                                break;

                            default:
                                throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
                        }
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(State), State, null);
            }
        }
    }
}
