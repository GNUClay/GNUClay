using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionModalVerbSubjVerbNoTransNodeAction(ATNConditionModalVerbSubjVerbNoTransNode_v2 item);

    public class ATNConditionModalVerbSubjVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionModalVerbSubjVerbNoTransNodeFactory_v2(ATNConditionModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionModalVerbSubjVerbNoTransNodeFactory_v2(ATNConditionModalVerbSubjVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionModalVerbSubjVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionModalVerbSubjVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionModalVerbSubjVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionModalVerbSubjVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionModalVerbSubjVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionModalVerbSubjVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_ModalVerb_Subj_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionModalVerbSubjVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionModalVerbSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionModalVerbSubjVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionModalVerbSubjVerbNoTransNode_v2 sameNode, InitATNConditionModalVerbSubjVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_ModalVerb_Subj_Verb_No_Trans;

        public ATNConditionModalVerbSubjVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionModalVerbSubjVerbNoTransNode_v2 mSameNode;
        private InitATNConditionModalVerbSubjVerbNoTransNodeAction mInitAction;

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

