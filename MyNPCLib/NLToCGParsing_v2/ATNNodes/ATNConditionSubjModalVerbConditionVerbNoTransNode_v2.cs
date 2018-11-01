using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjModalVerbConditionVerbNoTransNodeAction(ATNConditionSubjModalVerbConditionVerbNoTransNode_v2 item);

    public class ATNConditionSubjModalVerbConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjModalVerbConditionVerbNoTransNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjModalVerbConditionVerbNoTransNodeFactory_v2(ATNConditionSubjModalVerbConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjModalVerbConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjModalVerbConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjModalVerbConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjModalVerbConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjModalVerbConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_ModalVerb_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionSubjModalVerbConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjModalVerbConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjModalVerbConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjModalVerbConditionVerbNoTransNode_v2 sameNode, InitATNConditionSubjModalVerbConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_ModalVerb_Condition_Verb_No_Trans;

        public ATNConditionSubjModalVerbConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjModalVerbConditionVerbNoTransNode_v2 mSameNode;
        private InitATNConditionSubjModalVerbConditionVerbNoTransNodeAction mInitAction;

        protected override void ImplementGoalToken()
        {
            throw new NotImplementedException();
        }

        protected override void ProcessNextToken()
        {
            throw new NotImplementedException();
        }
    }
}

