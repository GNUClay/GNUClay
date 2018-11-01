using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionSubjWillFToHaveBeenConditionV3NoTransNodeAction(ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2 item);

    public class ATNConditionSubjWillFToHaveBeenConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionV3NoTransNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionSubjWillFToHaveBeenConditionV3NoTransNodeFactory_v2(ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionSubjWillFToHaveBeenConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionSubjWillFToHaveBeenConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_Subj_Will_FToHave_Been_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2 sameNode, InitATNConditionSubjWillFToHaveBeenConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_Subj_Will_FToHave_Been_Condition_V3_No_Trans;

        public ATNConditionSubjWillFToHaveBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionSubjWillFToHaveBeenConditionV3NoTransNode_v2 mSameNode;
        private InitATNConditionSubjWillFToHaveBeenConditionV3NoTransNodeAction mInitAction;

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

