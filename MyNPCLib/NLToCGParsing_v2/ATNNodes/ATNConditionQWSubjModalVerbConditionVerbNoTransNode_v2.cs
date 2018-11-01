using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionQWSubjModalVerbConditionVerbNoTransNodeAction(ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2 item);

    public class ATNConditionQWSubjModalVerbConditionVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbNoTransNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionQWSubjModalVerbConditionVerbNoTransNodeFactory_v2(ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionQWSubjModalVerbConditionVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionQWSubjModalVerbConditionVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_QWSubj_ModalVerb_Condition_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2 sameNode, InitATNConditionQWSubjModalVerbConditionVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_QWSubj_ModalVerb_Condition_Verb_No_Trans;

        public ATNConditionQWSubjModalVerbConditionVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionQWSubjModalVerbConditionVerbNoTransNode_v2 mSameNode;
        private InitATNConditionQWSubjModalVerbConditionVerbNoTransNodeAction mInitAction;

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

