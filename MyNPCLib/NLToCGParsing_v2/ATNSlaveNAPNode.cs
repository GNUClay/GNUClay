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

            ContextOfState = new ContextOfATNSlaveNAPStateNode();
        }

        private ATNSlaveNAPNode(ContextOfATNParsing_v2 context)
        {
            mContext = context;
        }

        private ContextOfATNParsing_v2 mContext;
        public ITargetOfATNSlaveNAPNode Target;
        private ContextOfATNSlaveNAPStateNode ContextOfState;

        public ATNSlaveNAPNode Fork(ContextOfATNParsing_v2 context)
        {
            var result = new ATNSlaveNAPNode(context);
            result.Target = Target;
            result.ContextOfState = ContextOfState.Fork(context);
            return result;
        }

        public bool Run(ATNExtendedToken token)
        {
#if DEBUG
            //LogInstance.Log($"State = {State}");
            LogInstance.Log($"token = {token}");
#endif

            var currentNode = ContextOfState.CurrentNode;

            if(currentNode == null)
            {
                currentNode = CreateFirstNode(token);
                ContextOfState.AddNode(currentNode);
            }

            return currentNode.Run(token);
        }

        private ATNSlaveNAPBaseStateNode CreateFirstNode(ATNExtendedToken token)
        {
            var partOfSpeech = token.PartOfSpeech;

            switch (partOfSpeech)
            {
                case GrammaticalPartOfSpeech.Pronoun:
                case GrammaticalPartOfSpeech.Noun:
                case GrammaticalPartOfSpeech.Article:
                case GrammaticalPartOfSpeech.Adjective:
                case GrammaticalPartOfSpeech.Adverb:
                    return new ATNSlaveNAPNounStateNode(mContext, Target, ContextOfState);

                case GrammaticalPartOfSpeech.Preposition:
                    return new ATNSlaveNAPPrepositionalStateNode(mContext, Target, ContextOfState);

                default:
                    throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, null);
            }
        }

        public bool IsDirty
        {
            get
            {
                var currentNode = ContextOfState.CurrentNode;

                if(currentNode == null)
                {
                    return true;
                }

                return currentNode.IsDirty;
            }
        }
    }
}
