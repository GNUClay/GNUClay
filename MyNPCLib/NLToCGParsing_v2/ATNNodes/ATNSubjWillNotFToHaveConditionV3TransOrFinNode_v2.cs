using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillNotFToHaveConditionV3TransOrFinNodeAction(ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNSubjWillNotFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillNotFToHaveConditionV3TransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillNotFToHaveConditionV3TransOrFinNodeFactory_v2(ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillNotFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillNotFToHaveConditionTransNode_v2 mParentNode;
        private ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillNotFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_Not_FToHave_Condition_V3_Obj_TransOrFin
    Subj_Will_Not_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNSubjWillNotFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_Not_FToHave_Condition_V3_TransOrFin;

        public ATNSubjWillNotFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNSubjWillNotFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNSubjWillNotFToHaveConditionV3TransOrFinNodeAction mInitAction;

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

