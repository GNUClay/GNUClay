using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
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

            throw new NotImplementedException();
        }

        private ContextOfATNParsing_v2 mContext;
        public ITargetOfATNSlaveNAPNode Target;
        public StateOfATNSlaveNAPNode State { get; set; } = StateOfATNSlaveNAPNode.Init;

        public ATNSlaveNAPNode Fork(ContextOfATNParsing_v2 context)
        {
            var result = new ATNSlaveNAPNode(context);
            result.State = State;
            result.Target = Target;

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
                                    var nounPhrase = new NounPhrase();
                                    Target.SetNode(nounPhrase, mContext);
                                    nounPhrase.Noun = token;
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
