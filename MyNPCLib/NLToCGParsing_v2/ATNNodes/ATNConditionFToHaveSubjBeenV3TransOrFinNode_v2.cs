using MyNPCLib.NLToCGParsing;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyNPCLib.NLToCGParsing_v2.ATNNodes
{
    public delegate void InitATNConditionFToHaveSubjBeenV3TransOrFinNodeAction(ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2 item);

    public class ATNConditionFToHaveSubjBeenV3TransOrFinNodeFactory_v2: BaseATNNodeFactory_v2
    {
        public ATNConditionFToHaveSubjBeenV3TransOrFinNodeFactory_v2(ATNConditionFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
        {
            mNumberOfConstructor = 1;
            mParentNode = parentNode;
            mToken = token;
        }

        public ATNConditionFToHaveSubjBeenV3TransOrFinNodeFactory_v2(ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2 sameNode, ATNExtendedToken token, InitATNConditionFToHaveSubjBeenV3TransOrFinNodeAction initAction)
        {
            mNumberOfConstructor = 2;
            mSameNode = sameNode;
            mToken = token;
            mInitAction = initAction;
        }

        private int mNumberOfConstructor;
        private ATNConditionFToHaveSubjBeenTransNode_v2 mParentNode;
        private ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2 mSameNode;
        private ATNExtendedToken mToken;
        private InitATNConditionFToHaveSubjBeenV3TransOrFinNodeAction mInitAction;

        public override BaseATNNode_v2 Create(ContextOfATNParsing_v2 context)
        {
            switch(mNumberOfConstructor)
            {
                case 1:
                    return new ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2(context, mParentNode, mToken);

                case 2:
                    return new ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2(context, mSameNode, mInitAction, mToken);

                default:
                    throw new ArgumentOutOfRangeException(nameof(mNumberOfConstructor), mNumberOfConstructor, null);
            }
        }
    }

/*Sub states:
    Condition_FToHave_Subj_Been_V3_Obj_TransOrFin
    Condition_FToHave_Subj_Been_V3_No_Trans
    Condition_FToHave_Subj_Been_V3_Condition_Fin
*/

    public class ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2: BaseATNNode_v2
    {
        public ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenTransNode_v2 parentNode, ATNExtendedToken token)
            : base(context, token)
        {
            ParentNode = parentNode;
        }

        public ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2(ContextOfATNParsing_v2 context, ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2 sameNode, InitATNConditionFToHaveSubjBeenV3TransOrFinNodeAction initAction, ATNExtendedToken token)
            : base(context, token)
        {
            mSameNode = sameNode;
            mInitAction = initAction;
            ParentNode = mSameNode.ParentNode;
            mInitAction?.Invoke(this);
        }

        public override StateOfATNParsing_v2 GlobalState => StateOfATNParsing_v2.Condition_FToHave_Subj_Been_V3_TransOrFin;

        public ATNConditionFToHaveSubjBeenTransNode_v2 ParentNode { get; private set; }
        private ATNConditionFToHaveSubjBeenV3TransOrFinNode_v2 mSameNode;
        private InitATNConditionFToHaveSubjBeenV3TransOrFinNodeAction mInitAction;

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

