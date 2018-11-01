using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotBeConditionV3TransOrFinNodeAction(ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotBeConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotBeConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotBeConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotBeConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotBeConditionTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotBeConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_Be_Condition_V3_Obj_TransOrFin
    Condition_Subj_Will_Not_Be_Condition_V3_Condition_Fin
*/

    public class ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotBeConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_Be_Condition_V3_TransOrFin;

        public ATNConditionSubjWillNotBeConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotBeConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotBeConditionV3TransOrFinNodeAction mInitAction;

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

