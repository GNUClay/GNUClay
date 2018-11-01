using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeConditionTransNodeAction(ATNConditionSubjWillBeConditionTransNode_v2 item);

    public class ATNConditionSubjWillBeConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeConditionTransNodeFactory_v2(ATNConditionSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeConditionTransNodeFactory_v2(ATNConditionSubjWillBeConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeTransNode_v2 mParentNode;
        private ATNConditionSubjWillBeConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_Condition_Ving_TransOrFin
    Condition_Subj_Will_Be_Condition_V3_TransOrFin
*/

    public class ATNConditionSubjWillBeConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionTransNode_v2 sameNode, InitATNConditionSubjWillBeConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Condition_Trans;

        public ATNConditionSubjWillBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeConditionTransNode_v2 mSameNode;
        private InitATNConditionSubjWillBeConditionTransNodeAction mInitAction;

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

