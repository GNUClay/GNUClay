using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveConditionTransNodeAction(ATNSubjWillFToHaveConditionTransNode_v2 item);

    public class ATNSubjWillFToHaveConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveConditionTransNodeFactory_v2(ATNSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveConditionTransNodeFactory_v2(ATNSubjWillFToHaveConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveTransNode_v2 mParentNode;
        private ATNSubjWillFToHaveConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Condition_V3_TransOrFin
*/

    public class ATNSubjWillFToHaveConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveConditionTransNode_v2 sameNode, InitATNSubjWillFToHaveConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Condition_Trans;

        public ATNSubjWillFToHaveTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveConditionTransNode_v2 mSameNode;
        private InitATNSubjWillFToHaveConditionTransNodeAction mInitAction;

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

