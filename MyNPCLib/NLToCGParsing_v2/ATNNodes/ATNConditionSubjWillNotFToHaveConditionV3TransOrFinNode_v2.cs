using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillNotFToHaveConditionV3TransOrFinNodeAction(ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2 item);

    public class ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNodeFactory_v2(ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillNotFToHaveConditionV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillNotFToHaveConditionTransNode_v2 mParentNode;
        private ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillNotFToHaveConditionV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_Not_FToHave_Condition_V3_Obj_TransOrFin
    Condition_Subj_Will_Not_FToHave_Condition_V3_Condition_Fin
*/

    public class ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveConditionTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2 sameNode, InitATNConditionSubjWillNotFToHaveConditionV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_Not_FToHave_Condition_V3_TransOrFin;

        public ATNConditionSubjWillNotFToHaveConditionTransNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillNotFToHaveConditionV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionSubjWillNotFToHaveConditionV3TransOrFinNodeAction mInitAction;

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

