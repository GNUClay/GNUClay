using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNSubjWillFToHaveBeenConditionV3NoTransNodeAction(ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2 item);

    public class ATNSubjWillFToHaveBeenConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNSubjWillFToHaveBeenConditionV3NoTransNodeFactory_v2(ATNSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNSubjWillFToHaveBeenConditionV3NoTransNodeFactory_v2(ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNSubjWillFToHaveBeenConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNSubjWillFToHaveBeenConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Subj_Will_FToHave_Been_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2 sameNode, InitATNSubjWillFToHaveBeenConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Subj_Will_FToHave_Been_Condition_V3_No_Trans;

        public ATNSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNSubjWillFToHaveBeenConditionV3NoTransNode_v2 mSameNode;
        private InitATNSubjWillFToHaveBeenConditionV3NoTransNodeAction mInitAction;

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

