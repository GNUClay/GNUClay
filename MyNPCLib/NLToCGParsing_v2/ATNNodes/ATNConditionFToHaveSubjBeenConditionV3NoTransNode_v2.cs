using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenConditionV3NoTransNodeAction(ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2 item);

    public class ATNConditionFToHaveSubjBeenConditionV3NoTransNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenConditionV3NoTransNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenConditionV3NoTransNodeFactory_v2(ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenConditionV3NoTransNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenConditionV3TransOrFinNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenConditionV3NoTransNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_Been_Condition_V3_No_Obj_TransOrFin
*/

    public class ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionV3TransOrFinNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2 sameNode, InitATNConditionFToHaveSubjBeenConditionV3NoTransNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_Condition_V3_No_Trans;

        public ATNConditionFToHaveSubjBeenConditionV3TransOrFinNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenConditionV3NoTransNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenConditionV3NoTransNodeAction mInitAction;

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

