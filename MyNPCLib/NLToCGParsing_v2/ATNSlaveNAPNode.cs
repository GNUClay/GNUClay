using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public class ATNSlaveNAPNode
    {
        public ATNSlaveNAPNode(ContextOfATNParsing_v2 context, ITargetOfATNSlaveNAPNode target)
        {
            mContext = context;

            Target = target;
        }

        public ATNSlaveNAPNode(ContextOfATNParsing_v2 context)
        {
            mContext = context;
        }

        private ContextOfATNParsing_v2 mContext;
        public ITargetOfATNSlaveNAPNode Target;
        public StateOfATNSlaveNAPNode State { get; set; } = StateOfATNSlaveNAPNode.Init;

        private NounPhrase_v2 mNounPhrase;
        private List<ATNExtendedToken> mDeterminers = new List<ATNExtendedToken>();

        public ATNSlaveNAPNode Fork(ContextOfATNParsing_v2 context)
        {
            var result = new ATNSlaveNAPNode(context);
            result.State = State;
            result.Target = Target;

            if(mNounPhrase == null)
            {
                result.mDeterminers = mDeterminers.ToList();
            }
            else
            {
                result.mNounPhrase = context.GetByRunTimeSessionKey<NounPhrase_v2>(mNounPhrase);
                foreach(var determiner in mDeterminers)
                {
                    result.mDeterminers.Add(context.GetByRunTimeSessionKey<ATNExtendedToken>(determiner));
                }
            }
            
            return result;
        }

        public void Run(ATNExtendedToken token)
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
                            case GrammaticalPartOfSpeech.Pronoun:
                                {
                                    var nounPhrase = new NounPhrase_v2();
                                    mNounPhrase = nounPhrase;
                                    Target.SetNode(nounPhrase, mContext);
                                    nounPhrase.Noun = token;
                                    State = StateOfATNSlaveNAPNode.GotNoun;
                                }
                                break;

                            case GrammaticalPartOfSpeech.Article:
                                {
                                    mDeterminers.Add(token);
                                    State = StateOfATNSlaveNAPNode.GotDeterminerWitoutNoun;
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
        }
    }
}
