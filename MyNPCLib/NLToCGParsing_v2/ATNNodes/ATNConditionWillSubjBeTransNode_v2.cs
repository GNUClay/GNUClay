using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionWillSubjBeTransNodeAction(ATNConditionWillSubjBeTransNode_v2 item);

    public class ATNConditionWillSubjBeTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionWillSubjBeTransNodeFactory_v2(ATNConditionWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionWillSubjBeTransNodeFactory_v2(ATNConditionWillSubjBeTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionWillSubjBeTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionWillSubjTransNode_v2 mParentNode;
        private ATNConditionWillSubjBeTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionWillSubjBeTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionWillSubjBeTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionWillSubjBeTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Will_Subj_Be_Ving_TransOrFin
    Condition_Will_Subj_Be_V3_TransOrFin
    Condition_Will_Subj_Be_Condition_Trans
*/

    public class ATNConditionWillSubjBeTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionWillSubjBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionWillSubjBeTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionWillSubjBeTransNode_v2 sameNode, InitATNConditionWillSubjBeTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Will_Subj_Be_Trans;

        public ATNConditionWillSubjTransNode_v2 ParentNode { get; private set; }
        private ATNConditionWillSubjBeTransNode_v2 mSameNode;
        private InitATNConditionWillSubjBeTransNodeAction mInitAction;

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

