using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillBeConditionV3TransOrFinNodeAction(ATNConditionSubjWillBeConditionV3TransOrFinNode_v2 item);

    public class ATNConditionSubjWillBeConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillBeConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjWillBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillBeConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjWillBeConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillBeConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillBeConditionTransNode_v2 mParentNode;
        private ATNConditionSubjWillBeConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillBeConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillBeConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillBeConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Be_Condition_V3_Obj_TransOrFin
    Condition_Subj_Will_Be_Condition_V3_No_Trans
    Condition_Subj_Will_Be_Condition_V3_Condition_Fin
*/

    public class ATNConditionSubjWillBeConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillBeConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillBeConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillBeConditionV3TransOrFinNode_v2 sameNode, InitATNConditionSubjWillBeConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Be_Condition_V3_TransOrFin;

        public ATNConditionSubjWillBeConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillBeConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillBeConditionV3TransOrFinNodeAction mInitAction;

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

