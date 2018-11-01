using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeConditionTransNodeAction(ATNConditionWillSubjBeConditionTransNode_v2 item);

    public class ATNConditionWillSubjBeConditionTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeConditionTransNodeFactory_v2(ATNConditionWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeConditionTransNodeFactory_v2(ATNConditionWillSubjBeConditionTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeConditionTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjBeTransNode_v2 mParentNode;
        private ATNConditionWillSubjBeConditionTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeConditionTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeConditionTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeConditionTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Be_Condition_Ving_TransOrFin
    Condition_Will_Subj_Be_Condition_V3_TransOrFin
*/

    public class ATNConditionWillSubjBeConditionTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeConditionTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeConditionTransNode_v2 sameNode, InitATNConditionWillSubjBeConditionTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Condition_Trans;

        public ATNConditionWillSubjBeTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeConditionTransNode_v2 mSameNode;
        private InitATNConditionWillSubjBeConditionTransNodeAction mInitAction;

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

