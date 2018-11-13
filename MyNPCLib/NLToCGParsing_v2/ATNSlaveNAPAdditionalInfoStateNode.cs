using MyNPCLib.NLToCGParsing;
using MyNPCLib.NLToCGParsing_v2.PhraseTree;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2
{
    public enum KindOfATNSlaveNAPAdditionalInfoStateNode
    {
        Init,
        GotPronoun
    }

    public class ATNSlaveNAPAdditionalInfoStateNode : ATNSlaveNAPBaseStateNode
    {
        public ATNSlaveNAPAdditionalInfoStateNode(ContextOfATNParsing_v2 context, ITargetOfATNSlaveNAPNode target, ContextOfATNSlaveNAPStateNode contextOfState)
            : base(context, target, contextOfState)
        {
        }

        public ATNSlaveNAPAdditionalInfoStateNode(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
            : base(context, contextOfState)
        {
        }

        private KindOfATNSlaveNAPAdditionalInfoStateNode State = KindOfATNSlaveNAPAdditionalInfoStateNode.Init;
        private ConjunctionalPhrase_v2 mConjunctionalPhrase;

        public override ATNSlaveNAPBaseStateNode Fork(ContextOfATNParsing_v2 context, ContextOfATNSlaveNAPStateNode contextOfState)
        {
            var result = new ATNSlaveNAPAdditionalInfoStateNode(context, contextOfState);
            result.State = State;
            result.Target = Target;
            result.mConjunctionalPhrase = context.GetByRunTimeSessionKey<ConjunctionalPhrase_v2>(mConjunctionalPhrase);

            return result;
        }

        public override bool Run(ATNExtendedToken token, CommaInstructionsOfATNSlaveNAPNode commaInstruction)
        {
#if DEBUG
            LogInstance.Log($"State = {State}");
            LogInstance.Log($"token = {token}");
#endif

            return true;
        }

        public override bool IsDirty
        {
            get
            {
                if (mConjunctionalPhrase == null)
                {
                    return true;
                }

                return mConjunctionalPhrase.ChildrenNodesList.IsEmpty();
            }
        }
    }
}
