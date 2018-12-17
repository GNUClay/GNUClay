using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using MyNPCLib.SimpleWordsDict;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public enum KindOfATNSlaveNAPPrepositionalStateNode
    {
        Init,
        GotPreposition
    }

    public class ATNSlaveNAPPrepositionalStateNode: ATNSlaveNAPBaseStateNode
    {
        public ATNSlaveNAPPrepositionalStateNode(ContextOfATNParsing_v2 context, ITargetOfATNSlaveNAPNode target, ContextOfATNSlaveNAPStateNode contextOfState)
            : base(context, target, contextOfState)
        {
        }

        public ATNSlaveNAPPrepositionalStateNode(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
            : base(context, contextOfState)
        {
        }

        private KindOfATNSlaveNAPPrepositionalStateNode State = KindOfATNSlaveNAPPrepositionalStateNode.Init;
        private PrepositionalPhrase_v2 mPrepositionalPhrase;

        public override ATNSlaveNAPBaseStateNode Fork(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
        {
            var result = new ATNSlaveNAPPrepositionalStateNode(context, contextOfState);
            result.State = State;
            result.Target = Target;
            result.mPrepositionalPhrase = context.GetByRunTimeSessionKey<PrepositionalPhrase_v2>(mPrepositionalPhrase);

            return result;
        }

        public override bool Run(ATNExtendedToken token, CommaInstructionsOfATNSlaveNAPNode commaInstruction)
        {
#if DEBUG
            //LogInstance.Log($"State = {State}");
            //LogInstance.Log($"token = {token}");
#endif

            switch (State)
            {
                case KindOfATNSlaveNAPPrepositionalStateNode.Init:
                    {
                        var partOfSpeech = token.PartOfSpeech;

                        switch (partOfSpeech)
                        {
                            case GrammaticalPartOfSpeech.Preposition:
                                {
                                    var prepositionPhrase = new PrepositionalPhrase_v2();
                                    mPrepositionalPhrase = prepositionPhrase;
                                    Target.SetNode(prepositionPhrase, Context);
                                    prepositionPhrase.Preposition = token;
                                    State = KindOfATNSlaveNAPPrepositionalStateNode.GotPreposition;
                                }
                                break;

                            default:
                                throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
                        }
                    }
                    break;

                case KindOfATNSlaveNAPPrepositionalStateNode.GotPreposition:
                    {
                        var partOfSpeech = token.PartOfSpeech;

                        switch (partOfSpeech)
                        {
                            case GrammaticalPartOfSpeech.Pronoun:
                            case GrammaticalPartOfSpeech.Noun:
                            case GrammaticalPartOfSpeech.Article:
                            case GrammaticalPartOfSpeech.Number:
                            case GrammaticalPartOfSpeech.Adjective:
                                {
                                    var target = new PrepositionalTargetOfATNSlaveNAPNode(mPrepositionalPhrase);
                                    var nextState = new ATNSlaveNAPNounStateNode(Context, target, ContextOfState);
                                    ContextOfState.AddNode(nextState);
                                    nextState.Run(token, commaInstruction);
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

            return true;
        }

        public override bool IsDirty
        {
            get
            {
                if(mPrepositionalPhrase == null)
                {
                    return true;
                }

                return mPrepositionalPhrase.ChildrenNodesList.IsEmpty();
            }
        }
    }
}
