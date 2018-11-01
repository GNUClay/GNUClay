using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillVerbNoTransNodeAction(ATNConditionSubjWillVerbNoTransNode_v2 item);

    public class ATNConditionSubjWillVerbNoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillVerbNoTransNodeFactory_v2(ATNConditionSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillVerbNoTransNodeFactory_v2(ATNConditionSubjWillVerbNoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillVerbNoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillVerbTransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillVerbNoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillVerbNoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillVerbNoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillVerbNoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Verb_No_Obj_TransOrFin
*/

    public class ATNConditionSubjWillVerbNoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbTransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillVerbNoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillVerbNoTransNode_v2 sameNode, InitATNConditionSubjWillVerbNoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Verb_No_Trans;

        public ATNConditionSubjWillVerbTransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillVerbNoTransNode_v2 mSameNode;
        private InitATNConditionSubjWillVerbNoTransNodeAction mInitAction;

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

